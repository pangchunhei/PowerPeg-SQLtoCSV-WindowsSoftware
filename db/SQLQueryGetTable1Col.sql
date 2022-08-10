USE [mainDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_Gateway_get_Table_1_Col]    Script Date: 8/10/2022 3:47:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_Gateway_get_Table_1_Col]
	-- Add the parameters for the stored procedure here
	@tableName nvarchar(128)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT d.COLUMN_NAME, d.ORDINAL_POSITION, d.DATA_TYPE
	FROM INFORMATION_SCHEMA.COLUMNS d
	WHERE d.TABLE_NAME = @tableName;
END
