-----------------------------------------------------------------------------------------------------------------------------------------------
-- Team 2
-- Milestone 2 Triggers
-- Isaac Schultz, Rebecca Rothschild
-----------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION defineCountReview() RETURNS trigger AS '
BEGIN
    UPDATE Business
    SET review_count = review_count + 1
    WHERE Business.business_id = NEW.business_id;
    RETURN NEW;
END
' LANGUAGE plpgsql;

CREATE TRIGGER countReview
AFTER INSERT ON Review
FOR EACH ROW
WHEN (NEW.review_id IS NOT NULL)
EXECUTE PROCEDURE defineCountReview();

-- test
INSERT INTO Review VALUES ('1111111111111111111111', '2eJEUJIP54tex7T9YOcLSw','1111111111111111111112', 5,'1996-10-07','it was bland',1,2,3);
SELECT * FROM Business WHERE business_id = '2eJEUJIP54tex7T9YOcLSw';

DROP TRIGGER countReview ON review;

--INSERT INTO yelp_user VALUES ('1111111111111111111112', 'bob', 0, 0, 0, 0, 0, 0, 1996-10-07, 1.1, 1.2);

-----------------------------------------------------------------------------------------------------------------------------------------------
-- Update on a checkin, handles counting the num_checkins for the business.
-----------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION defineCountCheckin() RETURNS trigger AS '
BEGIN
    UPDATE Business
    SET num_checkins = (SELECT COUNT(count) FROM checkins WHERE checkins.business_id = NEW.business_id GROUP BY count)
    WHERE Business.business_id = NEW.business_id;
    RETURN NEW;
END
' LANGUAGE plpgsql;

--test
SELECT COUNT(count) FROM checkins WHERE checkins.business_id = NEW.business_id GROUP BY count


CREATE TRIGGER countCheckin
AFTER UPDATE ON checkins
FOR EACH ROW
EXECUTE PROCEDURE defineCountReview();

-- test 
UPDATE checkins 
SET count = count + 1
WHERE business_id = '2eJEUJIP54tex7T9YOcLSw' AND hour = "1:00" AND day = "Monday";
SELECT * FROM Business WHERE business_id = '2eJEUJIP54tex7T9YOcLSw';

DROP TRIGGER countCheckin ON checkins;

---------------------------------------------------------------------------------------------------------------------------------------
-- Increment checkin count for proper hour and time
---------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION defineIncrementCountCheckin() RETURNS trigger AS '
BEGIN
    UPDATE CHECKINS
    SET count = count + 1
    WHERE checkins.business_id = NEW.business_id
    AND checkins.day = NEW.day
    AND checkins.time = NEW.time;
    RETURN NEW;
END
' LANGUAGE plpgsql;

CREATE TRIGGER countCheckinInsert
AFTER INSERT ON Checkins
FOR EACH ROW
EXECUTE PROCEDURE defineIncrementCountCheckin();

INSERT INTO Checkins VALUES ('2eJEUJIP54tex7T9YOcLSw','Friday', '20:00"');
SELECT * FROM Business WHERE business_id = '2eJEUJIP54tex7T9YOcLSw';

DROP TRIGGER countReview ON review;

INSERT INTO yelp_user VALUES ('1111111111111111111112', 'bob', 0, 0, 0, 0, 0, 0, 1996-10-07, 1.1, 1.2);



















-- Stuff that was in the postgres query when we were testing.
-- duHFBe87uNSXImQmvBhA7Q
/*
CREATE OR REPLACE FUNCTION defineCountReview() RETURNS trigger AS '
BEGIN
    UPDATE Business
    SET review_count= review_count + 1
    WHERE Business.business_id = NEW.business_id;
    RETURN NEW;
END
' LANGUAGE plpgsql;

CREATE TRIGGER countReview
AFTER INSERT ON Review
FOR EACH ROW
WHEN (NEW.review_id IS NOT NULL)
EXECUTE PROCEDURE defineCountReview();

DROP TRIGGER countReview ON review;

INSERT INTO Review VALUES ('1111111111111111111111', 'duHFBe87uNSXImQmvBhA7Q','1111111111111111111112', 5,'1996-10-07','it was bland',1,2,3);
SELECT *FROM Business WHERE business_id = 'duHFBe87uNSXImQmvBhA7Q';

INSERT INTO Review VALUES ('1111111111111111111115', '2eJEUJIP54tex7T9YOcLSw','1111111111111111111112', 5,'1996-10-07','it was bland',1,2,3);
SELECT * FROM Business WHERE business_id = '2eJEUJIP54tex7T9YOcLSw';

SELECT user_id FROM yelpUser;

SELECT * FROM Review;

INSERT INTO yelpuser VALUES ('1111111111111111111112', 'bob', 0, 0, 0, 0, 0, 0,'1996-10-07', 1.1, 1.2);
*/


-- duHFBe87uNSXImQmvBhA7Q    despacito arizona