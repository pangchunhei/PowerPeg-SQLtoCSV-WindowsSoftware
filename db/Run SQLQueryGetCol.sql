USE [SYP_8F_AC_Plant_RM]
GO

EXEC DBO.sp_Gateway_SearchTable @table = '3000STL30', @startDateTime = '2022-08-06', @endDateTime = '2022-09-06'
GO