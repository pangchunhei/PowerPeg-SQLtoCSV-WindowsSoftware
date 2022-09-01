-- Select the database --
USE [SYP_8F_AC_Plant_RM]
GO

/****** Object:  StoredProcedure [dbo].[sp_Gateway_SearchTable]    Script Date: 9/1/2022 11:16:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** @startDateTime Inclusive, @endDateTime Exclusive ******/
CREATE PROC [dbo].[sp_Gateway_SearchTable] @table varchar(MAX), @startDateTime DATETIME, @endDateTime DATETIME
AS
BEGIN
	Declare @sql varchar(MAX)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @sql = 'SELECT dbo.[' + @table + '].* FROM dbo.[' + @table + '] WHERE Timestamp >= ''' + CONVERT(VARCHAR(10),@startDateTime, 101) + ''' AND Timestamp < ''' + CONVERT(VARCHAR(10),@endDateTime, 101) + ''''

	Print @sql

	EXECUTE(@sql)
END