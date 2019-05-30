Create database RegistroProductos
go
use RegistroProductos
go
create table Productos(
ProductoID int primary key,
Descripcion varchar(50),
Existencia int,
Costo int,
ValorInventario int
);