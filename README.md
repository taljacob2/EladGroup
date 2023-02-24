# EladGroup

## Initialize The Database

> **IMPORTANT:** Before proceeding, head to [`CreateDatabase.sql`](EladGroup/Sql/Init/CreateDatabase.sql)
> and modify the `FILENAME` paths of:
>
> - `N'I:\Tal\Microsoft SSMS\Installation\MSSQL15.SQLEXPRESS\MSSQL\DATA\EladGroup.mdf'`
> - `N'I:\Tal\Microsoft SSMS\Installation\MSSQL15.SQLEXPRESS\MSSQL\DATA\EladGroup_log.ldf'`
>
> to your own paths, where you want to save the database to.

You have 2 options to do so:

- **Via CLI (`sqlcmd`)**

  Make sure you have [sqlcmd](https://docs.microsoft.com/en-us/sql/tools/sqlcmd-utility?view=sql-server-ver15) installed, to allow queries to the database through the CLI.
    
  It may be already installed on your computer.
  You can check this by running:
  ```
  sqlcmd -?
  ```

  To initialize the database, on first run of the program, in [`Program.cs`](EladGroup/Program.cs) enable the line:
  
  ```csharp
  Startup.Instance.InitDatabase();
  ```  

  This will eventually execute the Sql script of [`CreateDatabase.sql`](EladGroup/Sql/Init/CreateDatabase.sql).  
  Afterwards, disable the line.

- **Via Import To SSMS**

  In SSMS, import the Sql script of [`CreateDatabase.sql`](EladGroup/Sql/Init/CreateDatabase.sql) to create the database.

## Documentation

See more docs [here](docs).
