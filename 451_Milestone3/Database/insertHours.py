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
    #conn = psycopg2.connect("dbname='milestone3db' user='postgres' host='localhost' password='greatPassword'")
    conn = psycopg2.connect("dbname='milestone3db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
except:
    print('Unable to connect to the database!')

cur = conn.cursor()

startingTime = time.process_time()
with open('./yelp_business.JSON','r') as f:
    line = f.readline()
    count_line = 0

    while line:
        data = json.loads(line)

        business_id = str(cleanStr4SQL(data['business_id'])) 

        sql_str = "INSERT INTO Hours (business_id, day, open, close) VALUES "

        for k, v in data.items():
            if k == "hours":
                hours = v

                for day, combinedTimes in hours.items():
                    times = combinedTimes.split('-')
                    sql_str += "('" + business_id + "','" + cleanStr4SQL(day) + "','" + cleanStr4SQL(times[0]) + "','" + cleanStr4SQL(times[1]) + "'),"

        sql_str = sql_str[:-1] #Remove the last , from the end of the string.
        sql_str += ";" #add the semicolon to the end of the query

        if sql_str != "INSERT INTO Hours (business_id, day, open, close) VALUES;":
            try:
                cur.execute(sql_str)
            except Exception as e:
                print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))
            conn.commit()

        conn.commit()
        line = f.readline()
        count_line +=1

print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")

f.close()
cur.close()
conn.close()