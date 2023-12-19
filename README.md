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
