--Author: mJameson
--Tags: 
--Description: Get all student and grade information for one student's UID
DECLARE @studentUID varchar(256)

SELECT * FROM Students JOIN grades ON Students.[UID] = Grades.[UID]
WHERE Students.[UID] = @studentUID