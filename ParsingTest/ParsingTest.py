import json

def cleanStr4SQL(s): #use for entries that contain ' and \n
    return s.replace("'","`").replace("\n"," ")

def parseCheckinData(): #DONE
    outfile = open('checkins.txt', 'w')

    def print_dict(dictionary, ident = '', braces=1):
        for key, value in dictionary.items():
            if isinstance(value, dict):
                outfile.write(ident + key + ' : ') # print (ident,braces*'[',key,braces*']') 
                print_dict(value, ident, braces+1) # print_dict(value, ident+'  ', braces+1)
            else:
                outfile.write(ident +'%s : %s' %(key, value) + '\t') #no need to clean this entry
                if str(key) == 'business_id': 
                        outfile.write('\n') #move to newline if at the end of entry

    with open('yelp_checkin.json', 'r') as f:
       line = f.readline() 
    
       while line:
          data = json.loads(line)
          print_dict(data)
          line = f.readline()

    print("Done parsing checkin data")
    outfile.close()
    f.close()

def parseBusinessData(): #DONE
     outfile = open('business.txt', 'w')

     def print_bussDict(dictionary, ident = '', braces=1):

        for key, value in dictionary.items():
            if isinstance(value, dict):
                outfile.write(ident) 
                print_bussDict(value, ident+'  ', braces+1)
            else:
                if 'business_id' in str(key): 
                   outfile.write('\n')
                if 'neighborhood' not in key:
                    outfile.write(cleanStr4SQL(ident+'%s : %s' %(key, value) + '\t'))

     with open('yelp_business.json', 'r') as f:
       line = f.readline() 
    
       while line:
         data = json.loads(line)
         print_bussDict(data)
         line = f.readline()

     print("Done parsing business data")
     outfile.close()
     f.close()

def parseUserData(): #DONE
     outfile = open('users.txt', 'w')

     def print_useDict(dictionary, ident = '', braces=1):

        for key, value in dictionary.items():
            if isinstance(value, dict):
                if 'compliment' not in ident:
                    outfile.write(ident + '\t') 
                print_useDict(value, ident+'\t', braces+1)
            else:
                if 'compliment' not in key and 'elite' not in key and 'cool' not in key:
                    outfile.write(cleanStr4SQL(ident+'%s : %s' %(key, value) + '\t'))
                if 'yelping_since' in str(key):
                   outfile.write('\n')

     with open('yelp_user.json', 'r') as f:
       line = f.readline() 
    
       while line:
         data = json.loads(line)
         print_useDict(data)
         line = f.readline()

     print("Done parsing user data")
     outfile.close()
     f.close()

def parseReviewData(): 
    with open('yelp_review.json', 'r') as f:
        outfile = open('review.txt', 'w')
        line = f.readline()
        input()
        while line:
            data = json.loads(line)
            outfile.write("review_id : " + cleanStr4SQL(data['review_id'])+'\t')
            outfile.write(cleanStr4SQL("user_id : " + data['user_id'])+'\t')
            outfile.write(cleanStr4SQL("business_id : " + data['business_id'])+'\t')
            outfile.write("stars : " + str(data['stars']) + '\t')
            outfile.write("date : " + str(data['date'])+'\t')
            outfile.write("text : " + cleanStr4SQL(data['text'])+'\t')
            outfile.write("useful : " + str(data['useful'])+'\t') 
            outfile.write("funny : " + str(data['funny'])+'\t') 
            outfile.write("cool : " + str(data['cool'])+'\t') 
            outfile.write('\n');

            line = f.readline()
            
    print("Done parsing review data")
    outfile.close()
    f.close()

#parseCheckinData()
#parseBusinessData()
parseUserData()
parseReviewData() #parses all data, but does not display finished message
