Create database DbProductos
go
use DbProductos
go
create table Productos(
ProductoID int identity primary key,
Descripcion varchar(50),
Existencia int,
Costo float,
ValorInventario float
);