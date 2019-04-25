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
    #conn = psycopg2.connect("dbname='test1' user='postgres' host='localhost' password='greatPassword'")
    conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
except:
    print('Unable to connect to the database!')

cur = conn.cursor()

def myprint(d):
    for k, v in d.items():
        if isinstance(v, dict):
            myprint(v)
        else:
            #print "{0} : {1}".format(k, v)
            try:
                cur.execute("INSERT INTO Attributes (business_id, attribute_name, attribute_value) VALUES ('" + business_id + "','" + k + "','" + str(v) + "');")
            except Exception as e:
                print("Insert failed! " + str(e) + "On line: " + str(count_line))

startingTime = time.process_time()
print (os.getcwd())
with open('./yelp_business.JSON','r') as f:
    line = f.readline()
    count_line = 0
    
    while line:
        data = json.loads(line)

        business_id = str(cleanStr4SQL(data['business_id'])) 

        for k, v in data.items():
            if k == "attributes":
                myprint(v)
                
            elif k == "categories":
                categories = v

                for item in categories:
                    try:
                        cur.execute("INSERT INTO Category (business_id, category_name) VALUES ('" + business_id + "','" + cleanStr4SQL(item) + "');")
                    except Exception as e:
                        print("Insert failed! " + str(e) + "On line: " + str(count_line))
                    
                    
        conn.commit()

        line = f.readline()
        count_line +=1

print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")

f.close()
cur.close()
conn.close()