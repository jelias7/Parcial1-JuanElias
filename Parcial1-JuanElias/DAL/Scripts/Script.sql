Create table Productos(
ProductoID int identity primary key,
Descripcion varchar(50),
Existencia int,
Costo float,
ValorInventario float
);

Create table Inventarios(
id int,
total float
);