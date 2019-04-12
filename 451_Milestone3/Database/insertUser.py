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
    #conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
except:
    print('Unable to connect to the database!')

cur = conn.cursor()

startingTime = time.process_time()
with open('./yelp_user.JSON','r') as f:
    line = f.readline()
    count_line = 0

    sql_str = "INSERT INTO Yelpuser (user_id, name, average_stars, cool, funny, useful, fans, review_count, yelping_since) VALUES "

    while line:
        data = json.loads(line)        
        sql_str += "('" + cleanStr4SQL(data['user_id']) + "','" + cleanStr4SQL(data["name"]) + "','" + str(data["average_stars"]) + "','" + \
                    str(data["cool"]) + "','" + str(data["funny"]) + "','" + str(data["useful"]) + "'," + str(data["fans"]) + ",'" + \
                    str(data["review_count"]) + "','" + str(data["yelping_since"]) + "'),"

        if count_line % 100 == 99:
            sql_str = sql_str[:-1] #Remove the last , from the end of the string.
            sql_str += ";" #add the semicolon to the end of the query

            try:
                cur.execute(sql_str)
            except Exception as e:
                print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))
            sql_str = "INSERT INTO Yelpuser (user_id, name, average_stars, cool, funny, useful, fans, review_count, yelping_since) VALUES "
            conn.commit()

        line = f.readline()
        count_line +=1

    if sql_str != "INSERT INTO Yelpuser (user_id, name, average_stars, cool, funny, useful, fans, review_count, yelping_since) VALUES ":
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