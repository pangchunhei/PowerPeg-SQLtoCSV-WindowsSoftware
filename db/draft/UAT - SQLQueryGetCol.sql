-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_Gateway_GetSelectedTable_ColumnName]
	@tableName nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT COLUMN_NAME, DATA_TYPE, ORDINAL_POSITION
	FROM [SYP_8F_AC_Plant_RM].[INFORMATION_SCHEMA].[COLUMNS]
	WHERE [TABLE_NAME] IN (SELECT Value FROM fn_SplitStr(@tableName, ','))
	ORDER BY ORDINAL_POSITION
END
GO
