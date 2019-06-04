Create table Productos(
ProductoID int identity primary key,
Descripcion varchar(50),
Existencia int,
Costo float,
ValorInventario float
);

Create table Inventarios(
InventarioId int,
total float
);

Create Table Ubicaciones(
UbicacionId int,
Descripcion varchar(30)
);