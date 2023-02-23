# EladGroup

## Guides

[Configure DB And Tables From MSSQL](https://www.youtube.com/watch?v=JC98Me_BKsw)

[Setup Connection To The Database](https://www.youtube.com/watch?v=yBsl84hDtUg)

[Configure FK For Relationships](https://www.youtube.com/watch?v=-q4HT-od9ds)

---

## Create A Database And Scaffold With [Entity Framework 6](https://learn.microsoft.com/en-us/ef/ef6/get-started?source=recommendations)

### Install Entity Framework 6:

  In Visual Studio, open Package Manager Console, and run:
  ```
  Install-Package EntityFramework
  ```

### We will choose here the method to database first, and then genereate the models (i.e. scaffold) based on it.

- **Create the database:**

  - Open SSMS.

  - Connect to the server (with the connection string).

  - Right click on the "Databases" folder and create a new database.

  - Right click on the "Tables" folder and create a new table with fields of your choice.

- **Generate models base on the database:**

  - **Setup connection to the database in Visual Studio:**

    - Open Visual Studio

    - "View" -> "Server Explorer"

    - Right click on "Data Connections" -> "Add Connection…"

    - Select "Microsoft SQL Server" as the data source.

      ![](https://learn.microsoft.com/en-us/ef/ef6/media/selectdatasource.png)

    - Uncheck "Always use this selection".

    - Set the "Server name" as the connection string to the MSSQL server.

    - Set the "Select or enter a database name" as the name of the new database you have made.

      ![](https://learn.microsoft.com/en-us/ef/ef6/media/sqlexpressconnectiondf.png)    

  - **Generate models based on the database:**

    - In the current project, create a folder named "Models".

    - Right click it, and select "Add New Item…"

    - Select "Data" from the left menu and then "ADO.NET Entity Data Model". Click OK. This launches the "Entity Data Model Wizard".

    - Select "EF Designer from database".

      ![](https://learn.microsoft.com/en-us/ef/ef6/media/wizardstep1.png)

    - Click Next.

      ![](https://learn.microsoft.com/en-us/ef/ef6/media/wizardstep2.png)      

    - Click Next.

    - Select the "Tables" checkbox.
 
      ![](https://learn.microsoft.com/en-us/ef/ef6/media/wizardstep3.png)

    - Click Finish.

    - The models have been generated to the "Models" folder.

    