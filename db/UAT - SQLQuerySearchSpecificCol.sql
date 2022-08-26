USE [SYP_8F_AC_Plant_RM]
GO
/****** Object:  StoredProcedure [dbo].[sp_Gateway_SearchTable]    Script Date: 8/16/2022 11:55:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** @startDateTime Inclusive, @endDateTime Exclusive ******/
ALTER PROC [dbo].[sp_Gateway_SearchTable] @selectColumn varchar(MAX), @table varchar(MAX), @startDateTime DATETIME, @endDateTime DATETIME
AS
BEGIN
	Declare @sql varchar(MAX)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @sql = 'SELECT ' + @selectColumn + ' FROM dbo.[' + @table + '] WHERE Timestamp >= ''' + CONVERT(VARCHAR(10),@startDateTime, 23) + ''' AND Timestamp < ''' + CONVERT(VARCHAR(10),@endDateTime, 23) + ''''

	Print @sql

	EXECUTE(@sql)
END

