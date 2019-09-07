# walletWebApi
*Este proyecto esta desarrollado en ASP.net MVC 5

*Para hacer correr esta aplicacion se requiere crear una base de datos en sqlserver:

--------------------------------------

use master
go
CREATE DATABASE Billetera
go
use Billetera
go
CREATE TABLE Billetera(
id int not null primary key identity,
operacion varchar(10) not null,
monto int not null
)

--------------------------------------

*La cadena de conexion de la base de datos se encuentra en: Datos --> App.Config --> 

--------------------------------------
<connectionStrings>
    <add name="BilleteraEntities" connectionString="metadata=res://*/BilleteraDatosModel.csdl|res://*/BilleteraDatosModel.ssdl|res://*/BilleteraDatosModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=HP;initial catalog=Billetera;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
--------------------------------------  

* Las pruebas se encuentran en: walletWebApi/WalletWebApi/WalletWebApi.Tests/Controllers/BilleteraTest.cs

*Levantar la aplicacion con IIS express.
  
