SELECT '10000STL1' AS TableName, Site_Name AS SiteName, dbo.[10000STL1].* 
FROM dbo.[10000STL1], dbo.[MappingTable]
WHERE Timestamp >= '08/21/2022' AND Timestamp < '08/23/2022' AND DBMSTable = '3000STL10' 