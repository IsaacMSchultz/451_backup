psql -U postgres -d milestone2db < Milestone2SQL.sql
python insertBusiness.py
start insertAttributes.bat
start insertCheckin.bat
start insertHours.bat
start insertUser.bat