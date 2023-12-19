# PruebaTecnicaBE
### 1) Clonar el proyecto del repositorio


### 2) Crear base de datos en mysql con el nombre que desee(ej. bdusers)

### 3) En el archivo de configuracion(appsetting.json) en el proyecto AppUsers.webApi agregar la siguiente configuración de base de datos.
```json
"ConnectionStrings": {
    "default": "server=localhost; database=bdusers;user id=root; password=tu-password"
  },
```
### 4) Crear migraciones y actualizar BD

Para crear y actualizar las migraciones usaremos las herramientas de Rider.
#### Creacion de Migracion: seleccionamos la solucion =>Entity Framework Core=>Add
Migration
#### Creacion de Migracion: seleccionamos la solucion =>Entity Framework Core=>Update Database

## Con esta configuracion estamos listo para probar las apis

### 5) Envio de Correo
#### Para el envio de correo he dejado la configuracion en el archivo setting, y el metodo comentado en el servicio de creacion de usuario, de manera que el correo se envie cuando se cree un nuevo usuario y con los datos proporcionados en el request del api serviran de insumo para el envio de correo 
