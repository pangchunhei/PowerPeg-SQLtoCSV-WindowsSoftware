USE [SYP_8F_AC_Plant_RM]

EXEC dbo.sp_Gateway_SearchTable @table = '10000STL1', @startDateTime = '2022-08-21', @endDateTime = '2022-08-23'