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

INSERT INTO Review VALUES ('1111111111111111111111', '2eJEUJIP54tex7T9YOcLSw','1111111111111111111112', 5,'1996-10-07','it was bland',1,2,3);
SELECT * FROM Business WHERE business_id = '2eJEUJIP54tex7T9YOcLSw';

DROP TRIGGER countReview ON review;

INSERT INTO yelp_user VALUES ('1111111111111111111112', 'bob', 0, 0, 0, 0, 0, 0, 1996-10-07, 1.1, 1.2);

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