/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r ../../_seedData/dbo/ContactTypes.sql
:r ../../_seedData/dbo/Positions.sql
:r ../../_seedData/dbo/JerseySizes.sql
:r ../../_seedData/dbo/EventTypes.sql

:r ../../_seedData/roster/Players.sql
:r ../../_seedData/js/Forms.sql
:r ../../_seedData/js/FormEntries.sql
--:r ../../_seedData/roster/Emails.sql
--:r ../../_seedData/roster/Phones.sql

--:r ../../_seedData/calendar/Events.sql
