create database dbmvc


use dbmvc


create table Empleados (
EmpleadoId int primary key identity(1,1),
Nombre varchar(50),
Puesto varchar(50),
Oficina varchar(50),
Edad int,
Salario decimal
)

create proc spEmpleados
@Accion  int,
@Nombre  varchar(50) = NULL,
@Puesto varchar(50) = NULL,
@Oficina varchar(50) = NULL,
@Edad int = NULL,
@Salario decimal = NULL,
@EmpleadoId int = NULL
as
begin 


if @Accion = 1 begin

SELECT * FROM Empleados

end else if @Accion = 2 begin

INSERT INTO Empleados (Nombre, Puesto, Oficina, Edad, Salario)
VALUES (@Nombre ,@Puesto, @Oficina,@Edad,@Salario)

end ELSE IF @Accion = 3 BEGIN

DELETE FROM Empleados WHERE EmpleadoId =  @EmpleadoId

END ELSE IF @Accion = 4 BEGIN

UPDATE Empleados SET Nombre =@Nombre, Puesto = @Puesto, Oficina = @Oficina, Edad = @Edad, Salario =@Salario WHERE EmpleadoId =EmpleadoId 

END 

END


 