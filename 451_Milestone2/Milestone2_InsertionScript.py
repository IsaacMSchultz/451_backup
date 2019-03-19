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

def insert2BusinessTable(): #Should have 11481
    #reading the JSON file
    startingTime = time.process_time()
    with open('./yelp_business.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('./yelp_business.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        #TODO: update the database name, username, and password
        try:
            conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='localhost' password='greatPassword'")
            #conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            # Generate the INSERT statement for the cussent business
            # TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statement based on your own table schema and
            # include values for all businessTable attributes                                                                    \/ num_checkins,
            sql_str = "INSERT INTO Business (business_id, name, city, state, zipcode, latitude, longitude, address, review_count, is_open, stars) " \
                      "VALUES ('" + cleanStr4SQL(data['business_id']) + "','" + cleanStr4SQL(data["name"]) + "','" + cleanStr4SQL(data["city"]) + "','" + \
                      cleanStr4SQL(data["state"]) + "','" + cleanStr4SQL(data["postal_code"]) + "','" + str(data["latitude"]) + "'," + str(data["longitude"]) + ",'" + \
                      cleanStr4SQL(data["address"]) + "'," + str(data["review_count"]) + "," + int2BoolStr(data["is_open"]) + "," + str(data["stars"]) + ");"     
            try:
                cur.execute(sql_str)
            except Exception as e:
                print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))
            conn.commit()
            # optionally you might write the INSERT statement to a file.
            # outfile.write(sql_str)

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()

def insert2UserTable(): #Should have 192999
    #reading the JSON file
    startingTime = time.process_time()
    with open('./yelp_user.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('./yelp_business.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        #TODO: update the database name, username, and password
        try:
            conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='localhost' password='greatPassword'")
            #conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            # Generate the INSERT statement for the cussent business
            # TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statement based on your own table schema and
            # include values for all businessTable attributes                                                                    \/ num_checkins,
            sql_str = "INSERT INTO Yelpuser (user_id, name, average_stars, cool, funny, useful, fans, review_count, yelping_since) " \
                      "VALUES ('" + cleanStr4SQL(data['user_id']) + "','" + cleanStr4SQL(data["name"]) + "','" + str(data["average_stars"]) + "','" + \
                      str(data["cool"]) + "','" + str(data["funny"]) + "','" + str(data["useful"]) + "'," + str(data["fans"]) + ",'" + \
                      str(data["review_count"]) + "','" + str(data["yelping_since"]) + "');"     
            try:
                cur.execute(sql_str)
                print("Insert success\n")
            except Exception as e:
                print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))
            conn.commit()
            # optionally you might write the INSERT statement to a file.
            # outfile.write(sql_str)

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()

def insert2ReviewTable(): #Should have 416479
    startingTime = time.process_time()
    with open('./yelp_review.JSON','r') as f:    #TODO: update path for the input file
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        try:
            conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='localhost' password='greatPassword'")
            #conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

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

        cur.close()
        conn.close()

    print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")
    f.close()

def insert2CheckinTable(): #Should have 416479
    #reading the JSON file
    startingTime = time.process_time()

    sql_str = "INSERT INTO Checkins (business_id, day, time) " \
                    "VALUES ("

    with open('./yelp_checkin.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('./yelp_business.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        #TODO: update the database name, username, and password
        try:
            conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='localhost' password='greatPassword'")
            #conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            
            """  sql_str = "INSERT INTO Checkins (business_id, day, time) " \
                    "VALUES ('" + cleanStr4SQL(data["business_id"]) + "','" + 'Monday' + "','" + (str([item for item in[item for item in data["time"]]])) + ");" """
                
            try:
                cur.execute(sql_str)
            except Exception as e:
                print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))
            conn.commit()
            # optionally you might write the INSERT statement to a file.
            # outfile.write(sql_str)

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()

def insert2FriendsTable(): #Should have 192999
    #reading the JSON file
    startingTime = time.process_time()
    with open('./yelp_user.JSON','r') as f: 
        #outfile =  open('./yelp_business.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        try:
            conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='localhost' password='greatPassword'")
            #conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)                                                           

            user_id = str(data['user_id'])

            sql_str = "INSERT INTO Friend (user_id, friend_id) " \
                "VALUES ('" + cleanStr4SQL(user_id) + "','"

            for k, v in data.items():
                if k == "friends":
                    # do something for each v in friends
                    temp_friends = v

                    for friend in temp_friends:
                        sql_str = sql_str + cleanStr4SQL(friend) + "');"
                        cur.execute(sql_str)
                        sql_str = "INSERT INTO Friend (user_id, friend_id) " \
                            "VALUES ('" + cleanStr4SQL(user_id) + "','"
                        # "INSERT INTO Friend (user_id, friend_id) VALUES ('nWDevhc2XTaAyRM29vZK6g','DheUtq-7vWqJtMH_WSgBGA');"

                        #"INSERT INTO Yelpuser (user_id, name, average_stars, cool, funny, useful, fans, review_count, yelping_since) VALUES ('om5ZiponkpRqUNa3pVPiRg','Andrea','3.94','40110','10882','83681',835,'2559','2006-01-18');"
                    #print("friends: " , k , " : " , v)

                   

            try:
                #cur.execute(sql_str)
                print("Insert success\n")
            except Exception as e:
                print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))
            conn.commit()
            # optionally you might write the INSERT statement to a file.
            # outfile.write(sql_str)

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()
    
#insert2BusinessTable()
#insert2UserTable()
#insert2ReviewTable()
#insert2CheckinTable()
#testCheckinInsert()
insert2FriendsTable()