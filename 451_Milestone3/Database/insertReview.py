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
with open('./yelp_review.JSON','r') as f:    #TODO: update path for the input file
    line = f.readline()
    count_line = 0

    while line:
        data = json.loads(line)
        sql_str = "INSERT INTO Review (review_id, business_id, user_id, review_stars, date, text, useful_vote, funny_vote, cool_vote) " \
                "VALUES ('" + cleanStr4SQL(data["review_id"]) + "','" + cleanStr4SQL(data["business_id"]) + "','" + cleanStr4SQL(data["user_id"]) + "','" + \
                str(data["stars"]) + "','" + str(data["date"]) + "','" + cleanStr4SQL(data["text"]) + "','" + str(data["useful"]) + "'," + str(data["funny"]) + ",'" + \
                str(data["cool"]) + "');"
        
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