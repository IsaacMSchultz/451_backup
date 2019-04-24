UPDATE business SET REVIEW_COUNT=x.REVIEW_COUNT,
REVIEWRATING=x.REVIEWRATING FROM (
select business.business_id,COUNT(REVIEW.business_id) as REVIEW_COUNT, AVG(REVIEW.review_stars) as REVIEWRATING
FROM business inner join REVIEW on business.BUSINESS_ID = review.BUSINESS_ID
Group by business.BUSINESS_ID) as x WHERE business.business_id = x.business_id;

UPDATE business SET num_checkins = x.num_checkins FROM (
select business.business_id, SUM(checkins.count) as NUM_CHECKINS
FROM business inner join checkins on business.BUSINESS_ID = checkins.BUSINESS_ID
Group by business.BUSINESS_ID) as x WHERE business.business_id = x.business_id;