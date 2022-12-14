USE [mainDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_gateway_search_table_1]    Script Date: 8/16/2022 11:55:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[sp_gateway_search_table_1] @selectCol varchar(MAX)
AS
BEGIN
	Declare @sql varchar(MAX)

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @sql = 'SELECT ' + @selectCol + ' FROM dbo.Table_1'

	EXECUTE(@sql)
END

