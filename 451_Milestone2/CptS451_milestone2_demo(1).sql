--glossary
Business
YelpUser
Review
Friend
Checkins
Category
Attributes
Hours
zipcode
business_id
city  (business city)
name   (business name)
user_id
friend_id
review_id
review_count
text
review_stars
date (review)
reviewrating (Business)
num_checkins
day  (checkin)
time (checkin)
count (checkin)


--1.
SELECT COUNT(*) 
FROM  Business;
SELECT COUNT(*) 
FROM  YelpUser;
SELECT COUNT(*) 
FROM  Review;
SELECT COUNT(*) 
FROM  Friend;
SELECT COUNT(*) 
FROM  Checkins;
SELECT COUNT(*) 
FROM  Category;
SELECT COUNT(*) 
FROM  Attributes;
SELECT COUNT(*) 
FROM  Hours;



--2. Run the following queries on your business table, checkin table and review table. Make sure to change the attribute names based on your schema. 

SELECT zipcode, count(business_id) 
FROM Business
GROUP BY zipcode
HAVING count(business_id)>400
ORDER BY zipcode

SELECT zipcode, COUNT(distinct C.category)
FROM Business as B, Category as C
WHERE B.business_id = C.business_id
GROUP BY zipcode
HAVING count(distinct C.category)>75
ORDER BY zipcode

SELECT zipcode, COUNT(distinct A.attribute)
FROM Business as B, Attributes as A
WHERE B.business_id = A.business_id
GROUP BY zipcode
HAVING count(distinct A.attribute)>80


--3. Run the following queries on your business table, checkin table and tips table. Make sure to change the attribute names based on your schema. 

SELECT YelpUser.user_id, count(friend_id)
FROM YelpUser, Friend
WHERE YelpUser.user_id = Friend.user_id AND 
      YelpUser.user_id = 'zvbewosyFz94fSlmoxTdPQ'
GROUP BY YelpUser.user_id

SELECT business_id, name, city, review_count, num_checkins, reviewrating 
FROM Business 
WHERE business_id ='6lovZEiwWcRYRhyKd94DRg' ;

-----------

SELECT SUM(count) 
FROM Checkins 
WHERE business_id ='6lovZEiwWcRYRhyKd94DRg';

SELECT count(*), avg(review_stars)
FROM Review
WHERE  business_id = '6lovZEiwWcRYRhyKd94DRg';


--4. 
--Type the following statements. Make sure to change the attribute names based on your schema.  Don’t run the update statement before you show the results for steps 1 and 2 to the TA.

UPDATE Checkins 
SET count = count + 1 
WHERE business_id ='6lovZEiwWcRYRhyKd94DRg'  AND day ='Friday' AND time = '15:00';

INSERT INTO Checkins (business_id, day,time,count)
VALUES ('h_vsOvGHQtEpUroh-5lcHA','Friday','15:00',1);

------------


SELECT business_id,name, city, num_checkins 
FROM Business 
WHERE business_id ='h_vsOvGHQtEpUroh-5lcHA';



--5.
--Type the following statements. Make sure to change the attribute names based on your schema.  Don’t run the insert statement before you show the results for the first query to the TA.

INSERT INTO Review (review_id, user_id, business_id,text,review_stars,date,funny,useful,cool)  
VALUES ('ZuRjoWuinqWhecT-PRZ-qw','zvbewosyFz94fSlmoxTdPQ', '6lovZEiwWcRYRhyKd94DRg', 'Great!',5,'2019-03-22',0,0,0);



