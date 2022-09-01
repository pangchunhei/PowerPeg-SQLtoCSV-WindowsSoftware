
# PowerPeg Custom Software
This Software is design to query the DataBase data with multiple tables and put into a single CSV file.




## Features

- Update the DataBase server connection settings
- Instant generation of the CSV file
- Schedule generation of the CSV file




## Installation

Step 1
- In local machine
```bash
  Copy the release folder to the local machine
  - Machine that can access the daatbase is required
```

Step 2
- In local machine
```bash
  Update the the MappingTable.csv
  - Only need to update if there is changes in the Mapping Table
```

Step 3
- In Database Server (Access via SQL server management studio)
```bash
  Installation of the stored procedure and function
  - Prod - SplitForIN.sql
  - Prod - SQLQuerySearchSpecificCol.sql
```

Step 4
- In local machine
```bash
  Create the App-UI.exe shortcut and place to 'C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Startup'
```

Step 5
```bash
  Restart the PC to run or press the shortcut to run
```    
