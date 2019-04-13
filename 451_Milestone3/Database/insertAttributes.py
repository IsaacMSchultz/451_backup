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
    #conn = psycopg2.connect("dbname='milestone3db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
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

    attr_sql = ""
    cat_sql = ""
    
    while line:
        data = json.loads(line)

        business_id = str(cleanStr4SQL(data['business_id']))         

        for k, v in data.items():            
            if k == "attributes" and (isinstance(v, dict) or (isinstance(v, str) and v != "")):
                attr_sql_temp = "INSERT INTO Attributes (business_id, attribute_name, attribute_value) VALUES "
                attrList = []
                recurseAttr(v, attrList, business_id)
                for attr in attrList:                    
                    attr_sql_temp += attr

                attr_sql_temp = attr_sql_temp[:-1] #Remove the last , from the end of the string.
                attr_sql_temp += ";" #add the semicolon to the end of the query

                if attr_sql_temp != "INSERT INTO Attributes (business_id, attribute_name, attribute_value) VALUES;":
                    attr_sql += attr_sql_temp                
                
            elif k == "categories" and (isinstance(v, list) or (isinstance(v, str) and v != "")):
                cat_sql += "INSERT INTO Category (business_id, category_name) VALUES "
                categories = v

                for item in categories:                    
                    cat_sql += "('" + business_id + "','" + cleanStr4SQL(item) + "'),"     
        
                cat_sql = cat_sql[:-1] #Remove the last , from the end of the string.
                cat_sql += ";" #add the semicolon to the end of the query
        
        if count_line % 100 == 99:            
            if attr_sql != "":                     
                try:
                    cur.execute(attr_sql)            
                except Exception as e:
                    print("Attribute insert failed! " + str(e) + "On line: " + str(count_line))
                attr_sql = ""
                conn.commit()
            if cat_sql != "":                       
                try:
                    cur.execute(cat_sql)            
                except Exception as e:
                    print("Category insert failed! " + str(e) + "On line: " + str(count_line)) 
                cat_sql = ""
                conn.commit()                        
        
        line = f.readline()
        count_line +=1

    if attr_sql != "":        
        try:
            cur.execute(attr_sql)            
        except Exception as e:
            print("Attribute insert failed! " + str(e) + "On line: " + str(count_line))
        conn.commit()
    if cat_sql != "":         
        try:
            cur.execute(cat_sql)            
        except Exception as e:
            print("Category insert failed! " + str(e) + "On line: " + str(count_line)) 
        conn.commit()  

print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")

f.close()
cur.close()
conn.close()