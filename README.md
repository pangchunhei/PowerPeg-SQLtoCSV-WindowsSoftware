
## Installation [![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://github.com/pangchunhei/PowerPeg-SQLtoCSV-WindowsSoftware/tree/integration-with-EMSD-db/release)

With a single click of the button below, a zip of this repository will start downloading.

[![Download zip](https://custom-icon-badges.herokuapp.com/badge/-Download-limegreen?style=for-the-badge&logo=download&logoColor=white "Download zip")](https://github.com/pangchunhei/PowerPeg-SQLtoCSV-WindowsSoftware/tree/integration-with-EMSD-db/release)

Step 1
- In local machine
```bash
  Download and copy the release folder to the local machine
  - Machine that can access the database is required
```

Step 2
- In local machine
```bash
  Update the the 'MappingTable.csv'
  - Only need to update if there is changes in the Mapping Table
```

Step 3
- For dev and release operator
```bash
  Update the config file 'App-UI.dll.config'
  - Coneection string
  - File default location
```

Step 4
- In Database Server (Access via SQL server management studio)
```bash
  Installation of the stored procedure and function
  - 'Prod - SQLQuerySearchSpecificCol.sql'
```

Step 5
- In local machine
```bash
  Create the App-UI.exe shortcut and place to 'C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup'
```

Step 6
```bash
  Restart the PC to run or press the shortcut to run
```    
