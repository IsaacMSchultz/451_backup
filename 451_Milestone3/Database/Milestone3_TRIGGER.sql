-----------------------------------------------------------------------------------------------------------------------------------------------
-- Team 2
-- Milestone 2 Triggers
-- Isaac Schultz, Rebecca Rothschild
-----------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION defineCountReview() RETURNS trigger AS '
BEGIN
    UPDATE Business
    SET review_count = review_count + 1.0
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
-- INSERT INTO Review VALUES ('1111111111111111111111', '2eJEUJIP54tex7T9YOcLSw','1111111111111111111112', 5,'1996-10-07','it was bland',1,2,3);
-- SELECT * FROM Business WHERE business_id = '2eJEUJIP54tex7T9YOcLSw';

-- DROP TRIGGER countReview ON review;

--INSERT INTO yelp_user VALUES ('1111111111111111111112', 'bob', 0, 0, 0, 0, 0, 0, 1996-10-07, 1.1, 1.2);

----------------------------------------------------------------------------------------------------------------------------------------------
-- Insertion on Review recalculates the reviewRating of a Business
----------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION defineCalcReviewRating() RETURNS trigger AS $calcReview$
BEGIN
    UPDATE Business
    SET reviewRating = (SELECT SUM(review.review_stars) FROM Review WHERE review.business_id = NEW.business_id)/review_count
    WHERE Business.business_id = NEW.business_id;
    RETURN NEW;
END
$calcReview$ LANGUAGE plpgsql;

CREATE TRIGGER CalcReviewRating --triggers are executed in alphabetical order
AFTER INSERT ON Review
FOR EACH ROW
WHEN (NEW.review_id IS NOT NULL)
EXECUTE PROCEDURE defineCalcReviewRating();


-- -- test
-- INSERT INTO Business Values ('0000000000000000000001', 'Wendys', 'Alpaca', 'WA', '98296', 0, 0, 'Robinson Road', 0, 0, 0, True);
-- INSERT INTO yelpuser VALUES ('1111111111111111111112', 'bob', 0, 0, 0, 0, 0, 0, '1996-10-07', 1.1, 1.2);
-- INSERT INTO Review VALUES ('1111111111111111115555', '0000000000000000000001','1111111111111111111112', 2,'1996-10-07','it was bland',1,2,3);
-- INSERT INTO Review VALUES ('1111111111111111115556', '0000000000000000000001','1111111111111111111112', 1,'1996-10-07','ew',1,2,3);
-- INSERT INTO Review VALUES ('1111111111111111115557', '0000000000000000000001','1111111111111111111112', 5,'1996-10-07','Nice 4 for 4 deal!',1,2,3);
-- SELECT * FROM Business WHERE business_id = '0000000000000000000001'; --reviewrating should be 2.7

-- DROP TRIGGER zCalcReviewRating ON review;
-----------------------------------------------------------------------------------------------------------------------------------------------
-- Update on a checkin, handles counting the num_checkins for the business.
-----------------------------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION defineCountCheckin() RETURNS trigger AS $countCheckin$
BEGIN
    UPDATE Business
    SET num_checkins = (SELECT SUM(count) FROM checkins WHERE checkins.business_id = NEW.business_id GROUP BY business_id)
    WHERE Business.business_id = NEW.business_id;
	RAISE NOTICE 'OLD.business_id %', (SELECT SUM(count) FROM checkins WHERE checkins.business_id = NEW.business_id GROUP BY business_id);
    RETURN NEW;
END
$countCheckin$ LANGUAGE plpgsql;

CREATE TRIGGER countCheckin
AFTER UPDATE ON checkins
FOR EACH ROW
EXECUTE PROCEDURE defineCountCheckin();

-- test 
--INSERT INTO checkins VALUES ('QpRfQtlbwlmqUsq4DKjqqw', 'Monday', '01:00:00',  1);
--INSERT INTO checkins VALUES ('QpRfQtlbwlmqUsq4DKjqqw', 'Monday', '04:00:00',  6);

-- UPDATE checkins 
-- SET count = count + 1
-- WHERE business_id = 'QpRfQtlbwlmqUsq4DKjqqw' AND time = '01:00:00' AND day = 'Monday';
-- SELECT * FROM Business WHERE business_id = 'QpRfQtlbwlmqUsq4DKjqqw';

-- DROP TRIGGER countCheckin ON checkins;

CREATE OR REPLACE FUNCTION defineInsertCheckin() RETURNS trigger AS $insertCheckin$
BEGIN    
    IF EXISTS (SELECT * FROM Checkins WHERE business_id = NEW.business_id AND checkins.day = NEW.day AND checkins.time = NEW.time) THEN	
    	UPDATE Checkins SET count = count + NEW.count WHERE business_id = NEW.business_id AND checkins.day = NEW.day AND checkins.time = NEW.time;
		RETURN NULL;
    ELSE
    	--INSERT INTO Checkins VALUES (NEW.business_id, NEW.day, NEW.time, NEW.count);
		RETURN NEW;
    END IF;	
END
$insertCheckin$ LANGUAGE plpgsql;

CREATE TRIGGER insertCheckin
BEFORE INSERT ON checkins
FOR EACH ROW
WHEN (pg_trigger_depth() < 1)
EXECUTE PROCEDURE defineInsertCheckin();

--DROP TRIGGER insertCheckin ON checkins;

---------------------------------------------------------------------------------------------------------------------------------------
-- Increment checkin count for proper hour and time
---------------------------------------------------------------------------------------------------------------------------------------

-- CREATE OR REPLACE FUNCTION defineIncrementCountCheckin() RETURNS trigger AS '
-- BEGIN
--     UPDATE CHECKINS
--     SET count = count + 1
--     WHERE checkins.business_id = NEW.business_id
--     AND checkins.day = NEW.day
--     AND checkins.time = NEW.time;
--     RETURN NEW;
-- END
-- ' LANGUAGE plpgsql;

-- CREATE TRIGGER countCheckinInsert
-- AFTER INSERT ON Checkins
-- FOR EACH ROW
-- EXECUTE PROCEDURE defineIncrementCountCheckin();

-- INSERT INTO Checkins VALUES ('2eJEUJIP54tex7T9YOcLSw','Friday', '20:00"');
-- SELECT * FROM Business WHERE business_id = '2eJEUJIP54tex7T9YOcLSw';

-- DROP TRIGGER countReview ON review;

--INSERT INTO yelp_user VALUES ('1111111111111111111112', 'bob', 0, 0, 0, 0, 0, 0, 1996-10-07, 1.1, 1.2);

