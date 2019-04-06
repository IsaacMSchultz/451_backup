import json
import psycopg2
import time

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

startingTime = time.process_time()
with open('./yelp_business.JSON','r') as f:    
    
    line = f.readline()
    count_line = 0

    while line:
        data = json.loads(line)
        
        sql_str = "INSERT INTO Business (business_id, name, city, state, zipcode, latitude, longitude, address, review_count, is_open, stars, num_checkins, reviewRating) " \
                    "VALUES ('" + cleanStr4SQL(data['business_id']) + "','" + cleanStr4SQL(data["name"]) + "','" + cleanStr4SQL(data["city"]) + "','" + \
                    cleanStr4SQL(data["state"]) + "','" + cleanStr4SQL(data["postal_code"]) + "','" + str(data["latitude"]) + "'," + str(data["longitude"]) + ",'" + \
                    cleanStr4SQL(data["address"]) + "'," + "0" + "," + int2BoolStr(data["is_open"]) + "," + str(data["stars"]) + "," + "0" + "," "0.0" + ");" 
        try:
            cur.execute(sql_str)
        except Exception as e:
            print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))
        
        conn.commit()
        line = f.readline()
        count_line +=1

print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")

f.close()
cur.close()
conn.close()