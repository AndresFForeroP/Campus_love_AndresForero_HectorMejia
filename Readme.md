# ❤️ Campus Love

**Campus Love** es una aplicación de consola desarrollada en **C# (.NET 9.0)** que simula un sistema de emparejamiento universitario.  
El sistema permite a los usuarios registrarse, iniciar sesión, interactuar con otros perfiles mediante **Likes/Dislikes**, ver coincidencias (matches) y gestionar su cuenta.  

El proyecto sigue principios de **Arquitectura Hexagonal**, **SOLID** y **Clean Code**, garantizando una separación clara entre la lógica de negocio, la infraestructura y la interfaz de usuario.  

---

## 🚀 Características principales

- **Gestión de usuarios**  
  - Registro de nuevos usuarios.  
  - Inicio de sesión.  
  - Modificación de datos personales.  
  - Eliminación de cuentas.  

- **Interacciones**  
  - Ver perfiles disponibles uno por uno.  
  - Dar **Like** o **Dislike**.  
  - Matches automáticos cuando dos usuarios se dan Like.  
  - Estadísticas globales (usuarios con más likes, más matches, etc.).  

- **Créditos diarios de interacción**  
  - Cada usuario tiene un límite de Likes por día.    

- **Persistencia de datos**  
  - Uso de **MySQL** mediante **Entity Framework Core** y **Pomelo.EntityFrameworkCore.MySql**.  

- **Interfaz de consola**  
  - Implementada con **Spectre.Console** y **Spectre.Console.Cli**.  
  - Menú interactivo y amigable.  

---

## 🛠️ Tecnologías y Frameworks

El proyecto utiliza los siguientes paquetes NuGet:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.8" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.8" />
<PackageReference Include="Microsoft.Extensions.Configuration" Version="9.0.8" />
<PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="9.0.8" />
<PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="9.0.8" />
<PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="9.0.0-rc.1.efcore.9.0.0" />
<PackageReference Include="Spectre.Console" Version="0.50.0" />
<PackageReference Include="Spectre.Console.Cli" Version="0.50.0" />
```

---

## 🏗️ Arquitectura

El proyecto está diseñado bajo **Arquitectura Hexagonal**, garantizando flexibilidad, escalabilidad y mantenibilidad.  

### Capas principales:

- **Domain** → Entidades del negocio (`Usuario`, `Interaccion`, `Match`) y reglas de negocio puras.  
- **Application** → Casos de uso (`UserService`, `MatchService`, `EstadisticasService`).  
- **Infrastructure** → Persistencia con **EF Core + MySQL**, repositorios y configuración.  
- **UI** → Consola interactiva con **Spectre.Console**.  

---

## ⚙️ Requisitos

- **.NET SDK 9.0+**  
- **MySQL 8.0+**  
- **Visual Studio 2022 / VS Code**  

---

## ▶️ Ejecución

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/AndresFForeroP/Campus_love_AndresForero_HectorMejia.git
   ```

2. Configurar la cadena de conexión en `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "MysqlConnection": "server=localhost;database=CampusLove;user=root;password=tu_password;"
     }
   }
   ```
3. Ejecutar el programa:
   ```bash
   dotnet run
   ```

---

## 📖 Menú de la aplicación

```
1. Iniciar Sesión
   - Encontrar el Amor
   - Matches
   - Cambiar mis datos
   - Eliminar Cuenta

2. Crear Nuevo Usuario
3. Salir
```

---

## 📜 Licencia

Este proyecto está bajo la licencia [MIT](LICENSE).  
Puedes usarlo, modificarlo y distribuirlo libremente siempre que se mantenga la atribución original.  

---

## ✨ Notas

- El sistema simula un **modo multicliente ficticio** en la consola.  
- La información ya **no se guarda en listas en memoria**, sino en **MySQL**.  
- Cumple con los principios de **SOLID** y **Arquitectura Hexagonal**.  
- Diseñado para ser fácilmente escalable a entornos web o móviles en el futuro.  

---

## 👥 Autores

- **Andrés Felipe Forero Perez**
- **Hector Andres Mejia Samoret**

    Campuslands bucaramanga 2025

    Curso: C#