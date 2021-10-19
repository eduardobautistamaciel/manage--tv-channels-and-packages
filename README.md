# Projecto: Implementar una aplicación Web ASP.NET MVC con acceso al sistema mediante usuario y roles.

* Cada usuario tiene un nombre de usuario (único), contraseña y un determinado rol (un mismo usuario solo tiene un rol asignado en el sistema). Cuando el usuario ingresa al sistema, solo podrá visualizar determinadas opciones dependiendo del rol asignado. Se verifica que un usuario que no esté autenticado o no tenga permisos no pueda acceder a las funcionalidades que no le corresponden. No podrá visualizar las opciones de menú ni acceder a ellas si ingresa la URL correspondiente.

## Gestión de perfiles 
La aplicación cuenta con lo siguiente tipos de perfiles:
#### Usuario sin identificar:
- Ingreso al sitio.
Ingresará su usuario, su contraseña y en caso de que las credenciales sean válidas quedará autorizado a acceder a las funcionalidades correspondientes a su rol.
- Listado de paquetes disponibles incluyendo los canales que contiene.
- Registrarse como cliente.
Deberá ingresar su cédula, nombre y apellido y una contraseña.
La cédula será un numérico de entre 7 y 9 dígitos, su nombre y apellido tendrán un largo mínimo de 2 caracteres y la contraseña tendrá un largo mínimo de 6 caracteres y contendrá al menos una mayúscula, una minúscula y un dígito. Al quedar registrado se le asignará automáticamente un usuario del sistema que tendrá como nombre de usuario su cédula, la contraseña será la ingresada y su rol será “Cliente”.

#### Usuario Cliente:
- Visualización de todos los paquetes.
En este caso el cliente deberá tener alguna forma de poder comprar el paquete que seleccione.
- Compra de paquete.
Al seleccionar un paquete se muestran todos sus datos y se permite al usuario efectivizar la compra. La compra registra la fecha en que se realiza y establece una fecha de vencimiento a un año.
- Ver todas sus compras con los paquetes, canales.
- Cancelación de compra.
En cualquier momento el cliente puede cancelar la suscripción al paquete.

#### Usuario Operador:
- Los operadores deberán estar precargados y solamente tendrán nombre de usuario, contraseña y rol. Precargar al menos dos operadores.
- Visualizar todas las compras realizadas entre dos fechas y el costo total de ellas.
- Visualizar todos los clientes. Se mostrarán ordenados por apellido ascendentemente, y en caso de que haya más de un cliente con el mismo apellido se mostrarán ordenados por nombre ascendentemente.
- Estadísticas:
-- Dado el nombre de un canal obtener todos los paquetes que la incluyen.
-- Obtener lista de clientes que tengan compras cuyo vencimiento sea en los próximos 30 días o menos.
-- Obtener los paquetes de mayor valor. En caso de empate mostar todos los empatados.
