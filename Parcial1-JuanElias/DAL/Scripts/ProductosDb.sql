Create database ProductosDb
go
use ProductosDb
go
create table Productos(
ProductoID int identity primary key,
Descripcion varchar(50),
Existencia int,
Costo int,
ValorInventario int
);