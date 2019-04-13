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
    conn = psycopg2.connect("dbname='milestone3db' user='postgres' host='localhost' password='greatPassword'")
    #conn = psycopg2.connect("dbname='milestone3db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
except:
    print('Unable to connect to the database!')

cur = conn.cursor()

startingTime = time.process_time()
with open('./yelp_checkin.JSON','r') as f:
    line = f.readline()
    count_line = 0

    sql_str = "INSERT INTO Checkins (business_id, day, time, count) VALUES "

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
                            sql_str += "('" + business_id + "','" + name + "','" + innerName + "','" + str(innerValue) + "'),"

        if count_line % 1000 == 999:
            sql_str = sql_str[:-1] #Remove the last , from the end of the string.
            sql_str += ";" #add the semicolon to the end of the query

            try:
                cur.execute(sql_str)
            except Exception as e:
                print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))
            sql_str = "INSERT INTO Checkins (business_id, day, time, count) VALUES "
            conn.commit()

        line = f.readline()
        count_line +=1

    if sql_str != "INSERT INTO Checkins (business_id, day, time, count) VALUES;":
        sql_str = sql_str[:-1] #Remove the last , from the end of the string.
        sql_str += ";" #add the semicolon to the end of the query

        try:
            cur.execute(sql_str)
        except Exception as e:
            print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))            
        conn.commit()

print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")

f.close()
cur.close()
conn.close()