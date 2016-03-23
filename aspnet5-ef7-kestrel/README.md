# SQL Server "Todo list" sample app - CSharp

## What's here? ##

A "Todo list" sample app for [SQL Server](https://www.microsoft.com/en-us/server-cloud/products/sql-server-2016/) and [Azure SQL Database](https://azure.microsoft.com/en-us/documentation/services/sql-database/) written in [C#](https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx) that uses [AngularJS]() as the front-end, [ASP.NET 5](http://docs.asp.net/en/latest/conceptual-overview/aspnet.html) with [EF7](https://docs.efproject.net/en/latest/) as the ORM and is hosted in [Kestrel](https://github.com/aspnet/KestrelHttpServer) in [.NET Core](http://docs.asp.net/en/latest/conceptual-overview/dotnetcore.html) which can run on Linux, Mac OS X and Windows.

##Setup your environment##
* Install ASP.NET 5 and coreclr for your environment: [Linux](https://docs.asp.net/en/latest/getting-started/installing-on-linux.html) | [Mac OS X](https://docs.asp.net/en/latest/getting-started/installing-on-mac.html) | [Windows](https://docs.asp.net/en/latest/getting-started/installing-on-windows.html)
* Type: `dnvm list` in a terminal window to check if `coreclr` was installed correctly
* Download and install VS Code for your environment: [Installing VS Code](https://code.visualstudio.com/Docs/editor/setup)
* Download and install Git for your platform: [Download Git](https://git-scm.com/download)
* Clone Git repo: `git clone https://github.com/sanagama/sql-todo-sample`
* Change directory to: `sql-todo-sample\aspnet5-ef7-kestrel`

##Run the sample in VS Code##
* Start VS Code by typing: `code .`
* Click `OK` to install the `C# extension` if VS Code prompts you.
* Restore project dependencies:
    - Press `Ctrl+Shift+P` and type `dnx`
    - Click `dnx: Restore Packages` then click `dnu: restore - (aspnet5-ef7-kestrel)`
* Run the app:
    - Press `Ctrl+Shift+P` and type `dnx`
    - Click `'dnx: Run Command` then click `dnx: web - (aspnet5-ef7-kestrel)`
    - At this point, the Kestrel web server should be running in a new terminal window.  
* Use the REST APIs from your browser:
    - Browse to: <http://localhost:5000/api/Persons>
    - Browse to: <http://localhost:5000/api/Persons/1>
    - Browse to: <http://localhost:5000/api/Tasks>
    - Browse to: <http://localhost:5000/api/Tasks/3>
