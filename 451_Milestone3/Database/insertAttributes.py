import json
import psycopg2
import time
import os

def cleanStr4SQL(s):
    return s.replace("'","`").replace("\n"," ")

def int2BoolStr (value):
    if value == 0:
        return 'False'
    else:
        return 'True'

try:
    conn = psycopg2.connect("dbname='milestone3db' user='postgres' host='localhost' password='greatPassword'")
    #conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
except:
    print('Unable to connect to the database!')

cur = conn.cursor()

def recurseAttr(d, attrList, business_id):    
    for k, v in d.items():
        if isinstance(v, dict):
            recurseAttr(v, attrList, business_id)
        else:            
            attrList.append("('" + business_id + "','" + k + "','" + str(v) + "'),")    

startingTime = time.process_time()
print (os.getcwd())
with open('./yelp_business.JSON','r') as f:
    line = f.readline()
    count_line = 0
    
    while line:
        data = json.loads(line)

        business_id = str(cleanStr4SQL(data['business_id'])) 

        attr_sql = "INSERT INTO Attributes (business_id, attribute_name, attribute_value) VALUES "
        cat_sql = "INSERT INTO Category (business_id, category_name) VALUES "

        for k, v in data.items():
            if k == "attributes":
                attrList = []
                recurseAttr(v, attrList, business_id)
                for attr in attrList:                    
                    attr_sql += attr
                
            elif k == "categories":
                categories = v

                for item in categories:                    
                    cat_sql += "('" + business_id + "','" + cleanStr4SQL(item) + "'),"                    
        
        attr_sql = attr_sql[:-1] #Remove the last , from the end of the string.
        attr_sql += ";" #add the semicolon to the end of the query
        cat_sql = cat_sql[:-1] #Remove the last , from the end of the string.
        cat_sql += ";" #add the semicolon to the end of the query

        if attr_sql != "INSERT INTO Attributes (business_id, attribute_name, attribute_value) VALUES;":
            try:
                cur.execute(attr_sql)            
            except Exception as e:
                print("Attribute insert failed! " + str(e) + "On line: " + str(count_line))
            conn.commit()
        if cat_sql != "INSERT INTO Category (business_id, category_name) VALUES;":         
            try:
                cur.execute(cat_sql)            
            except Exception as e:
                print("Category insert failed! " + str(e) + "On line: " + str(count_line)) 
            conn.commit()                        

        line = f.readline()
        count_line +=1

print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")

f.close()
cur.close()
conn.close()