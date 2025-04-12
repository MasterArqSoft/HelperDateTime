# 🕓 HelperDateTime

**HelperDateTime** es una solución desarrollada en **.NET 9** que proporciona utilidades avanzadas para trabajar con fechas y horas en aplicaciones .NET. Está diseñada para ser **modular, extensible, testeable y fácil de integrar** en otros proyectos.

---

## 📁 Estructura del Proyecto

La solución está compuesta por tres proyectos:

- `HelperDateTime`: Biblioteca principal con métodos utilitarios para manipulación de fechas y horas.
  - `DateTimeQuery.cs`: Métodos para conversiones de zonas horarias, intervalos y partes de fecha/hora.
  - `DateQuery.cs`: Operaciones sobre fechas como años bisiestos, diferencias, etc.
  - `HelperValidateDate.cs`: Métodos de validación de fechas y cadenas relacionadas.
- `HelperDateTime.Console`: Proyecto de consola con ejemplos y pruebas manuales.
- `HelperDateTime.Tests`: Proyecto de pruebas unitarias con `xUnit`.

---

## ⚙️ Requisitos del Sistema

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Visual Studio 2022 o superior / VS Code
- Opcional: Docker (para pruebas de portabilidad)

---

## 🚀 Instalación y Ejecución

### Clonar el repositorio

```bash
git clone https://github.com/usuario/HelperDateTime.git
cd HelperDateTime
```

### Restaurar dependencias y compilar

```bash
dotnet restore
dotnet build --configuration Release
```

### Ejecutar proyecto de consola

```bash
dotnet run --project HelperDateTime.Console
```

> Este comando ejecuta la aplicación de consola que ejemplifica el uso de la biblioteca principal.

---

## 🧪 Pruebas Unitarias

La solución cuenta con pruebas automatizadas utilizando `xUnit`.

Ejecuta las pruebas con el siguiente comando:

```bash
dotnet test
```

> Las pruebas validan conversiones de fechas, intervalos, zonas horarias y validaciones de entradas.

---

## 🧱 Diseño y Arquitectura

La solución sigue principios de diseño limpio y modular:

- ✅ **Separación de responsabilidades**: cada clase tiene una función clara.
- 🧩 **Extensibilidad**: se puede ampliar sin romper funcionalidades existentes.
- 📄 **Documentación XML**: para integración con IntelliSense.
- 🧼 **Sin dependencias externas**: fácil de incluir como librería utilitaria en otros proyectos.

---

### Construir y ejecutar

```bash
docker build -t helperdatetime .
docker run helperdatetime
```

---

## 🔐 Seguridad

Este proyecto **no implementa mecanismos de autenticación ni autorización**, ya que se enfoca exclusivamente en utilidades para la gestión de fechas y horas.

> 🔒 No se manejan datos sensibles ni conexiones externas.

---

## 🧭 Roadmap

- [ ] Publicar la librería en NuGet.
- [ ] Soporte para más zonas horarias.
- [ ] Agregar formatos culturales y localización.
- [ ] Aumentar cobertura de pruebas >90%.
- [ ] Incluir ejemplos en notebooks interactivos (`dotnet interactive`).

---

## 🤝 Cómo Contribuir

¡Gracias por tu interés en contribuir!

1. Haz un fork del repositorio.
2. Crea una nueva rama para tu funcionalidad:
   ```bash
   git checkout -b feature/nueva-funcionalidad
   ```
3. Realiza tus cambios y añade pruebas unitarias.
4. Asegúrate de que todo compila y pasa:
   ```bash
   dotnet test
   ```
5. Abre un Pull Request describiendo claramente tus aportes.

> ✍️ Buenas prácticas: código documentado, pruebas cubiertas y mensajes de commit claros.

---

## 🐞 Reporte de Errores

Si detectas un bug o deseas proponer una mejora:

1. Abre un Issue describiendo el problema.
2. Incluye pasos para reproducir, resultados esperados y actuales.
3. Adjunta ejemplos o logs si es posible.

---

## 📄 Licencia

Este proyecto está bajo licencia [MIT](LICENSE).  
Eres libre de usar, modificar y distribuir esta solución con atribución al autor original.

---

## 📚 Recursos Adicionales

- [Documentación oficial de .NET](https://learn.microsoft.com/dotnet/)
- [System.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)
- [System.TimeZoneInfo](https://learn.microsoft.com/en-us/dotnet/api/system.timezoneinfo)
- [xUnit Test Framework](https://xunit.net/)
- [Crear bibliotecas reutilizables en .NET](https://learn.microsoft.com/en-us/dotnet/standard/class-library-overview)
