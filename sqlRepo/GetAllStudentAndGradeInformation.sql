--Author: ndeason
--Tags: 
--Description: Get all student and grade information

SELECT * FROM Students JOIN grades ON Students.[UID] = Grades.[UID]