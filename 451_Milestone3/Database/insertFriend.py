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
with open('./yelp_user.JSON','r') as f: 
    #outfile =  open('./yelp_business.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
    line = f.readline()
    count_line = 0    

    sql_str = "INSERT INTO Friend (user_id, friend_id) VALUES "

    while line:
        data = json.loads(line)                                                           

        user_id = str(data['user_id'])

        for k, v in data.items():
            if k == "friends":
                # do something for each v in friends
                temp_friends = v

                for friend in temp_friends:
                    sql_str += "('" + cleanStr4SQL(user_id) + "','" + cleanStr4SQL(friend) + "'),"

        if count_line % 10000 == 9999:
            sql_str = sql_str[:-1] #Remove the last , from the end of the string.
            sql_str += ";" #add the semicolon to the end of the query

            if sql_str != "INSERT INTO Friend (user_id, friend_id) VALUES;":
                try:
                    cur.execute(sql_str)
                except Exception as e:
                    print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))
                sql_str = "INSERT INTO Friend (user_id, friend_id) VALUES "
                conn.commit()
            
        line = f.readline()
        count_line +=1

    if sql_str != "INSERT INTO Friend (user_id, friend_id) VALUES;":
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