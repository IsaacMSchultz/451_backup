psql -U postgres -d milestone2db < Milestone2SQL.sql
psql -U postgres -d milestone2db < Milestone2_TRIGGER.sql
python Milestone2_InsertionScript.py