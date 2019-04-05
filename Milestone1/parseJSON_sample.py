import json

def cleanStr4SQL(s): #use for entries that contain ' and \n
    return s.replace("'","`").replace("\n"," ")

def parseBusinessData():

    with open('yelp_business.json', 'r') as f:
        outfile = open('business.txt', 'w')
        line = f.readline() #grabs each business object
        count_line = 0
        input()
    
        while line:
            data = json.loads(line)
            outfile.write(cleanStr4SQL(data['business_id'])+'\t')
            outfile.write(cleanStr4SQL(data['full_address'])+'\t') #full_address
            outfile.write(cleanStr4SQL(data['name'])+'\t') #name
            outfile.write(cleanStr4SQL(data['state'])+'\t') #state
            outfile.write(cleanStr4SQL(data['city'])+'\t') #city
            #outfile.write(cleanStr4SQL(data['postal_code']) + '\t')  #zipcode- no zipcode data present
            outfile.write(str(data['latitude'])+'\t') #latitude
            outfile.write(str(data['longitude'])+'\t') #longitude
            outfile.write(str(data['stars'])+'\t') #stars
            outfile.write(str(data['review_count'])+'\t') #reviewcount
            outfile.write(str(data['open'])+'\t') 
            outfile.write(str([item for item in data['categories']])+'\t') #category list
            outfile.write(str([item for item in data['attributes']])+'\t') #want to get more data from attributes such as price and ambiance
            outfile.write(str([item for item in data['hours']])+'\t') #need more data from this- each day's hours of operation
            outfile.write('\n'); #all of the data for each business is on a single line

            line = f.readline()
            count_line +=1

    print(count_line)
    outfile.close()
    f.close()


def parseReviewData():
    with open('yelp_tip.json', 'r') as f:
        outfile = open('review.txt', 'w')
        line = f.readline() 
        
        while line:
            data = json.loads(line)
            outfile.write(cleanStr4SQL(data['user_id'])+'\t')
            outfile.write(cleanStr4SQL(data['text'])+'\t')
            outfile.write(cleanStr4SQL(data['business_id'])+'\t')
            outfile.write(str(data['likes'])+'\t') 
            outfile.write(str(data['date'])+'\t') 
            outfile.write(str(data['type'])+'\t') 

            outfile.write('\n');

            line = f.readline()

    outfile.close()
    f.close()


def parseCheckinData():
    with open('yelp_checkin.json', 'r') as f:
        outfile = open('checkins.txt', 'w')
        line = f.readline() 
         
        while line:
            data = json.loads(line)
            outfile.write(cleanStr4SQL(data['business_id'])+'\t')
            outfile.write(cleanStr4SQL(data['type'])+'\t')
            outfile.write(str(data['checkin_info'])+'\t')
            outfile.write('\n');

            line = f.readline()

    outfile.close()
    f.close()

def parseUserData(): #throws error
     with open('yelp_user.json', 'r') as f:
        outfile = open('users.txt', 'w')
        line = f.readline() 
        
        while line:
            data = json.loads(line)
            outfile.write(str(data['average_stars'])+'\t')
            outfile.write(str(data['compliments'])+'\t')
            outfile.write(str(data['elite'])+'\t')
            outfile.write(str(data['fans'])+'\t')
            outfile.write(str(data['friends'])+'\t')
            outfile.write(cleanStr4SQL(data['name'])+'\t')
            outfile.write(str(data['review_count'])+'\t')
            outfile.write(cleanStr4SQL(data['type'])+'\t')
            outfile.write(cleanStr4SQL(data['user_id'])+'\t')
            outfile.write(str(data['votes'])+'\t')
            outfile.write(cleanStr4SQL(data['yelping_since'])+'\t')
            outfile.write(str(data['average_stars'])+'\t')
            outfile.write(str(data['compliments'])+'\t')
            outfile.write(str(data['friends'])+'\t')

            outfile.write('\n')

            line = f.readline()
     outfile.close()
     f.close()


parseBusinessData()
#parseReviewData()
#parseCheckinData()
#parseUserData()
