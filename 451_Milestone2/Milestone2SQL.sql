CREATE TABLE Business (
    business_id CHAR(22),
    name VARCHAR(200) NOT NULL,
    city VARCHAR(20) NOT NULL,
    state CHAR(2) NOT NULL,
    zipcode CHAR(5) NOT NULL,
    latitude FLOAT NOT NULL,
    longitude FLOAT NOT NULL,
    address VARCHAR(150) NOT NULL,
    review_count INTEGER,
    num_checkins INTEGER,
    reviewRating FLOAT, -- I dont know exactly what this is??? but its in the schema so I'm keeping it
    is_open BOOLEAN NOT NULL,
    stars FLOAT,
    PRIMARY KEY (business_id)
);

CREATE TABLE YelpUser (
    user_id CHAR(22),
    name VARCHAR(100) NOT NULL,
    average_stars FLOAT,
    cool INTEGER,
    funny INTEGER,
    useful INTEGER,
    fans INTEGER,
    review_count INTEGER,
    yelping_since DATE NOT NULL,
    user_latitude FLOAT, -- Doesn't exist in the json files
    user_longitude FLOAT,
    PRIMARY KEY (user_id)
);

CREATE TABLE Review (
    review_id CHAR(22) UNIQUE,
    business_id CHAR(22),
    user_id CHAR(22),
    review_stars INTEGER NOT NULL,
    date DATE NOT NULL,
    text VARCHAR(1000),
    useful_vote INTEGER,
    funny_vote INTEGER,
    cool_vote INTEGER,
    PRIMARY KEY (review_id, business_id, user_id),
    FOREIGN KEY (business_id) REFERENCES Business(business_id),
    FOREIGN KEY (user_id) REFERENCES YelpUser(user_id)
);

CREATE TABLE Friend (
    user_id CHAR(22),
    friend_id CHAR(22) UNIQUE, -- CHECK that friend and user are not the same.
    PRIMARY KEY (user_id, friend_id),
    FOREIGN KEY (user_id) REFERENCES YelpUser(user_id)
);

CREATE TABLE Favorite (
    user_id CHAR(22),
    favorited_business CHAR(22),
    PRIMARY KEY (user_id, favorited_business),
    FOREIGN KEY (user_id) REFERENCES YelpUser(user_id),
    FOREIGN KEY (favorited_business) REFERENCES Business(business_id)
);

CREATE TABLE Category (
    business_id CHAR(22),
    category_name VARCHAR(20),
    PRIMARY KEY (Business_id, category_name),
    FOREIGN KEY (business_id) REFERENCES Business(Business_id)
);

CREATE TABLE Attributes (
    business_id CHAR(22),
    attribute_name VARCHAR(20),
    attribute_value VARCHAR(30),
    PRIMARY KEY (Business_id, attribute_value),
    FOREIGN KEY (business_id) REFERENCES Business(Business_id)
);

CREATE TABLE Hours (
    business_id CHAR(22),
    day VARCHAR(20),
    open TIME NOT NULL,
    close TIME NOT NULL,
    PRIMARY KEY (Business_id, day),
    FOREIGN KEY (business_id) REFERENCES Business(Business_id)
);

CREATE TABLE Checkins (
    business_id CHAR(22),
    day VARCHAR(20),
    time TIME,
    count INTEGER DEFAULT 1, -- changed not null to default 1
    PRIMARY KEY (Business_id, day, time),
    FOREIGN KEY (business_id) REFERENCES Business(Business_id)
);