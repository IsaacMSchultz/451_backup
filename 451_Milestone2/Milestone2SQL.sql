CREATE TABLE Business (
    business_id CHAR(22),
    name VARCHAR(200),
    city VARCHAR(20),
    state CHAR(2),
    zipcode CHAR(5),
    latitude FLOAT,
    longitude FLOAT,
    address VARCHAR(150),
    review_count INTEGER,
    num_checkins INTEGER,
    reviewRating FLOAT, -- I dont know exactly what this is??? but its in the schema so I'm keeping it
    is_open BOOLEAN,
    stars FLOAT,
    PRIMARY KEY (business_id)
);

CREATE TABLE User (
    user_id CHAR(22),
    average_stars FLOAT,
    cool INTEGER,
    funny INTEGER,
    useful INTEGER,
    name VARCHAR(100),
    fans INTEGER,
    review_count INTEGER,
    yelping_since DATE,
    user_latitiude FLOAT,
    user_longitude FLOAT,
    PRIMARY KEY (user_id)
);

--CREATE TABLE Friend (
    
--);

CREATE TABLE Review (
    review_id CHAR(22),
    review_stars INTEGER,
    date DATE,
    text VARCHAR(1000),
    useful_vote INTEGER,
    funny_vote INTEGER,
    cool_vote INTEGER,
    PRIMARY KEY (review_id)
);