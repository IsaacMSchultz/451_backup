psql -h 35.230.13.126 -U postgres -d milestone3db < Milestone3SQL.sql
python insertBusiness.py
start insertAttributes.bat
start insertCheckin.bat
start insertHours.bat
start insertUser.bat