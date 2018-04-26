exec msdb.dbo.rds_restore_database 
        @restore_db_name='adventureworks', 
        @s3_arn_to_restore_from='arn:aws:s3:::dotnickkaur-rds/AdventureWorks2017.bak';

exec msdb.dbo.rds_task_status;
