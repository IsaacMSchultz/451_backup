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

CREATE TABLE Category (
    business_id CHAR(22),
    category_name VARCHAR(20),
    PRIMARY KEY (Business_id, category_name),
    FOREIGN KEY business_id REFERENCES Business(Business_id);
);

CREATE TABLE Attributes (
    business_id CHAR(22),
    attribute_name VARCHAR(20),
    attribute_value VARCHAR(30),
    PRIMARY KEY (Business_id, attribute_value),
    FOREIGN KEY business_id REFERENCES Business(Business_id);
);

CREATE TABLE Hours (
    business_id CHAR(22),
    day VARCHAR(20),
    open TIME,
    close TIME,
    PRIMARY KEY (Business_id, day),
    FOREIGN KEY business_id REFERENCES Business(Business_id);
);

CREATE TABLE Checkins (
    business_id CHAR(22),
    day VARCHAR(20),
    time TIME,
    count INTEGER,
    PRIMARY KEY (Business_id, day, time),
    FOREIGN KEY business_id REFERENCES Business(Business_id);
);