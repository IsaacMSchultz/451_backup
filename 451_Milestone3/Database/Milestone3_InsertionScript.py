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

def insert2BusinessTable(conn, cur): #Should have 11481
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

def insert2HoursTable(conn, cur): #Has 55502
    startingTime = time.process_time()
    with open('./yelp_business.JSON','r') as f:
        line = f.readline()
        count_line = 0

        while line:
            data = json.loads(line)

            business_id = str(cleanStr4SQL(data['business_id'])) 

            for k, v in data.items():
                if k == "hours":
                    hours = v

                    for day, combinedTimes in hours.items():
                        times = combinedTimes.split('-')
                        cur.execute("INSERT INTO Hours (business_id, day, open, close) VALUES ('" + business_id + "','" + cleanStr4SQL(day) + "','" + cleanStr4SQL(times[0]) + "','" + cleanStr4SQL(times[1]) + "');")
                       
            conn.commit()

            line = f.readline()
            count_line +=1

    print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")
    f.close()

def insert2AttributesTable(conn, cur): #Has 97117

    def myprint(d):
        for k, v in d.items():
            if isinstance(v, dict):
                myprint(v)
            else:
                #print "{0} : {1}".format(k, v)
                cur.execute("INSERT INTO Attributes (business_id, attribute_name, attribute_value) VALUES ('" + business_id + "','" + k + "','" + str(v) + "');")

    startingTime = time.process_time()
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

def insert2UserTable(conn, cur): #Should have 192999
    startingTime = time.process_time()
    with open('./yelp_user.JSON','r') as f:
        line = f.readline()
        count_line = 0

        while line:
            data = json.loads(line)
            sql_str = "INSERT INTO Yelpuser (user_id, name, average_stars, cool, funny, useful, fans, review_count, yelping_since) " \
                      "VALUES ('" + cleanStr4SQL(data['user_id']) + "','" + cleanStr4SQL(data["name"]) + "','" + str(data["average_stars"]) + "','" + \
                      str(data["cool"]) + "','" + str(data["funny"]) + "','" + str(data["useful"]) + "'," + str(data["fans"]) + ",'" + \
                      str(data["review_count"]) + "','" + str(data["yelping_since"]) + "');"     
            try:
                cur.execute(sql_str)
            except Exception as e:
                print("Insert failed! " + str(e) + "\nOn line: " + str(count_line))
            
            conn.commit()
            line = f.readline()
            count_line +=1

    print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")
    f.close()

def insert2FriendsTable(conn, cur): #Has 1052706
    #reading the JSON file
    startingTime = time.process_time()
    with open('./yelp_user.JSON','r') as f: 
        #outfile =  open('./yelp_business.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

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

            conn.commit()

            line = f.readline()
            count_line +=1

    print("Processed " + str(count_line) + " Entries in " + str(time.process_time() - startingTime) + " seconds")
    f.close()

def insert2CheckinTable(conn, cur): #Has 481360
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

def insert2ReviewTable(conn, cur): #Should have 416479
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

try:
    #conn = psycopg2.connect("dbname='test1' user='postgres' host='localhost' password='greatPassword'")
    conn = psycopg2.connect("dbname='milestone2db' user='postgres' host='35.230.13.126' password='oiAv4Kmdup8Pd4vd'")
except:
    print('Unable to connect to the database!')

cur = conn.cursor()
    
#insert2BusinessTable(conn, cur)
#insert2UserTable(conn, cur)
#insert2ReviewTable(conn, cur)
#insert2CheckinTable(conn, cur)
insert2FriendsTable(conn, cur)
######insert2CategoriesTable(conn, cur) #done inside the attributes function
#insert2AttributesTable(conn, cur)
#insert2HoursTable(conn, cur)

cur.close()
conn.close()
