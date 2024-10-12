##Proyecto API REST de Gestión Médica
Este proyecto es una API REST desarrollada en .NET para la gestión de información médica, incluyendo médicos, pacientes y citas médicas.
Requisitos Previos
Asegúrate de tener instalado lo siguiente en tu sistema:

.NET SDK (versión 6.0 o superior)
Git
Un IDE como Visual Studio o Visual Studio Code

##Pasos para Clonar y Ejecutar el Proyecto

Clonar el Repositorio
Abre una terminal y ejecuta el siguiente comando:
Copygit clone https://github.com/tu-usuario/nombre-del-repositorio.git

Navegar al Directorio del Proyecto
Copycd nombre-del-repositorio

Restaurar las Dependencias
Copydotnet restore

Configurar la Base de Datos

Abre el archivo appsettings.json y asegúrate de que la cadena de conexión a la base de datos sea correcta.
Ejecuta las migraciones para crear la base de datos:
Copydotnet ef database update



Compilar el Proyecto
Copydotnet build


Uso de la API
Puedes probar los endpoints de la API utilizando herramientas como Postman o curl. Aquí hay algunos ejemplos de endpoints:

GET /api/Medico: Obtiene todos los médicos
POST /api/Medico: Crea un nuevo médico
GET /api/Medico/{id}: Obtiene un médico específico
PUT /api/Medico/{id}: Actualiza un médico existente
DELETE /api/Medico/{id}: Elimina un médico
