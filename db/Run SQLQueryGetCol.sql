USE [SYP_8F_AC_Plant_RM]
GO

EXEC DBO.sp_Gateway_SearchTable @table = '3000STL22', @startDateTime = '2022-08-21', @endDateTime = '2022-08-22'
GO