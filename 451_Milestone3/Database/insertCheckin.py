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
with open('./yelp_checkin.JSON','r') as f:
    line = f.readline()
    count_line = 0

    while line:
        data = json.loads(line)

        business_id = str(cleanStr4SQL(data['business_id'])) 

        for k, v in data.items():
            if k == "time":
                week = v

                for name, value in week.items():
                    if isinstance(value, dict): 
                        # parse through list
                        inner = value
                        for innerName, innerValue in inner.items():
                            try:
                                cur.execute("INSERT INTO Checkins (business_id, day, time, count) VALUES ('" + business_id + "','" + name + "','" + innerName + "','" + str(innerValue) + "');")
                            except Exception as e:
                                print("Error inserting on line " +str(count_line) + ": " + str(e))

        conn.commit()

        line = f.readline()
        count_line +=1

print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")

f.close()
cur.close()
conn.close()