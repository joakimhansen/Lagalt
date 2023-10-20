# Lagalt

## Setting Up and Running the Web API Locally
These instructions will guide you through the process of setting up and running the web API locally on your computer. The web API connects to a database, and in this guide, we assume you're using Visual Studio and Microsoft SQL Server Management Studio. To run the application locally, you'll need to set up your own database using provided SQL scripts.

### Prerequisites
Before you begin, ensure that you have the following prerequisites installed:

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)]([https://www.microsoft.com/en-us/sql-server/sql-server-downloads](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16#download-ssms)

### Installation Steps

1. **Clone the Web API Project from GitHub:**
   - Open your terminal or command prompt.
   - Navigate to the directory where you want to store the project.
   - Run the following command to clone the repository from GitHub:
     ```bash
     git clone github-url
     ```
   Replace `github-url` with the actual repository name.

2. **Initialize Your Database:**
   - In the project's root folder, you will find an `00_LagaltDB_init.sql` file. Use SQL Server Management Studio or any SQL client to execute this script in your local SQL Server to create the necessary database structure.

   - Additionally, you can insert test data into your database using the `01_InsertTestData.sql` script provided in the same folder.

3. **Set Up the Connection String:**
   - Open the `appsettings.json` file located in the project's root folder.
   - Locate the `"ConnectionStrings"` section, and replace the `DefaultConnection` connection string with your own connection string.

     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Your_Connection_String_Here"
     }
     ```

4. **Build and Run the Web API:**
   - Open the solution in Visual Studio.
   - Build the solution to ensure all dependencies are resolved.
   - Set the Web API project as the startup project.
   - Press `F5` or click "Start" to run the application. It should now be running locally on your computer.

5. **Access the Web API:**
   - You can access the web API at `http://localhost:port` (by default, the port is usually 7085)

### Frontend
The frontend of the application is hosted on Vercel:
[Lagalt-Frontend](https://lagalt-frontend-plum.vercel.app/)

### Backend
The swagger-documentation can be found here:
[Lagalt-Web-API](https://lagalt-docker.azurewebsites.net/swagger/index.html)

## Contributors
* [Magnus Uttisrud (@mUttisrud)](https://github.com/mUttisrud)
* [Joakim Hansen (@joakimhansen)](https://github.com/joakimhansen)
* [Silje Slettebakk (@Siljeesl)](https://github.com/Siljeesl)
* [Silje Denise Risnes (@silje-denise)](https://github.com/silje-denise)
