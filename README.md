# ContactRegister
## Technology Used:
* Asp.net MVC Core with Entity Framework
* Sql server 2008 R2
* Advanced Javascript  and Jquery
* css, with boostrap
## Packages
* microsoft.aspnetcore.mvc.razor.runtimecompilation\5.0.13\
* microsoft.entityframeworkcore.sqlserver\5.0.3\
* microsoft.entityframeworkcore.tools\5.0.3\
* microsoft.jquery.unobtrusive.ajax\3.2.6\
* microsoft.visualstudio.web.codegeneration.design\5.0.2\
## For Creating DataBase:
* Open The Packet Management Consol
* PM> *add-migration "create-Db"*   //create Database
* PM> *update-database*
* Once Build succeed,Go and varify into your sql server. ( see the database and tables)
* Add connectionString into your Project (*appsettings.js*)
## Database Details
* Database Name : *DB_ContactRegister*
* Table : *Companies*, *People*
* Companies : {CompanyID(PK), CompanyName, CompanyAddress}
* People : {PID ,CID(FK), Name,Address,PhoneNUmber} 
## extra css and js file
* ~\wwwroot\js\site.js
* ~\WebContactRegister\wwwroot\css\site.css [line num 73-96]
# Project Working Flow
* clone this project on your system
* open the project , buld and run
* **CREATE** : Clck the *createNew* Button for create company and registering the contact person(**Condition**: Must have registered at least one contact person at a company)
* **ADD MULTIPLE CONTACTS SAME TIME** If you want to add multiple people at a same time, click *Add* button and enter the details and save (**Phone Number:Validation** , **Name Required feild**)
* Back to list : Click *Back* button
* **VIEW** :If you want to see the details of each company Click *Detail* button curresponded by the company(**Just View**)
* **DELETE** :If you want to Delete : click *Delete* Button(**Deleted Company and Curesponded details**)
* **EDIT**: If you want to edit company and details: Click *Edit* Button, (You can change company name, Add more contacts, delete contacts)
* **SerchBar** : search Only Company Name ( Not added more)
👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍👍
