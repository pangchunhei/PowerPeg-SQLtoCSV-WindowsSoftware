USE [SYP_8F_AC_Plant_RM]
GO
/****** Object:  StoredProcedure [dbo].[sp_Gateway_SearchTable]    Script Date: 8/29/2022 3:49:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** @startDateTime Inclusive, @endDateTime Exclusive ******/
ALTER PROC [dbo].[sp_Gateway_SearchTable] @table varchar(MAX), @startDateTime DATETIME, @endDateTime DATETIME
AS
BEGIN
	Declare @sql varchar(MAX)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 

	SET @sql = 'SELECT ''' + @table + ''' AS TableName, Site_Name AS SiteName, dbo.[''' + @table + '''].* FROM dbo.[' + @table + '], dbo.[MappingTable] WHERE Timestamp >= ''' + CONVERT(VARCHAR(10),@startDateTime, 101) + ''' AND Timestamp < ''' + CONVERT(VARCHAR(10),@endDateTime, 101) + ''' AND DBMSTable = ''' + @table + ''''

	Print @sql

	EXECUTE(@sql)
END

