<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-purple?style=for-the-badge&logo=dotnet" alt=".NET 9 Badge"/>
  <img src="https://img.shields.io/badge/Build-Passing-brightgreen?style=for-the-badge" alt="Build Status Badge"/>
  <img src="https://img.shields.io/badge/Tests-Passing-brightgreen?style=for-the-badge" alt="Tests Passing Badge"/>
  <img src="https://img.shields.io/badge/Changelog-Maintained-brightgreen?style=for-the-badge" alt="Changelog Maintained"/>
  <img src="https://img.shields.io/badge/License-MIT-blue?style=for-the-badge" alt="License MIT Badge"/>

  <!-- Futuro: cuando publiques en NuGet
  <img src="https://img.shields.io/nuget/v/HelperDateTime?style=for-the-badge&color=blueviolet" alt="NuGet Version Badge"/>
  -->
  <!-- Futuro: cuando agregues cobertura
  <img src="https://img.shields.io/badge/Coverage-90%25-brightgreen?style=for-the-badge" alt="Coverage Badge"/>
  -->
</p>

# 🕓 HelperDateTime

🚀 Utilidades avanzadas para fechas y horas en aplicaciones .NET

---

# 📑 Tabla de Contenido

- [🕓 HelperDateTime](#-helperdatetime)
- [📑 Tabla de Contenido](#-tabla-de-contenido)
- [🧩 Descripción](#-descripción)
- [🏗️ Estructura del Proyecto](#️-estructura-del-proyecto)
- [⚙️ Requisitos del Sistema](#️-requisitos-del-sistema)
- [🚀 Instalación y Ejecución](#-instalación-y-ejecución)
  - [Clonar el Repositorio](#clonar-el-repositorio)
  - [Restaurar dependencias y compilar](#restaurar-dependencias-y-compilar)
  - [Ejecutar el Proyecto de Consola](#ejecutar-el-proyecto-de-consola)
- [🧪 Pruebas Unitarias](#-pruebas-unitarias)
- [🧱 Diseño y Arquitectura](#-diseño-y-arquitectura)
- [🔐 Seguridad](#-seguridad)
- [📌 Estado del Proyecto](#-estado-del-proyecto)
- [🎯 Roadmap](#-roadmap)
- [🤝 Cómo Contribuir](#-cómo-contribuir)
- [🐞 Reporte de Bugs](#-reporte-de-bugs)
- [📢 Participa](#-participa)
- [📄 Licencia](#-licencia)
- [📚 Recursos Adicionales](#-recursos-adicionales)

---

# 🧩 Descripción

**HelperDateTime** es una solución en **.NET 9** que proporciona herramientas avanzadas para manipular fechas, horas, intervalos, formatos y zonas horarias.
Está diseñada para ser **modular**, **extensible**, **testeable** y fácilmente integrable en proyectos .NET.

---

# 🏗️ Estructura del Proyecto

| Proyecto                   | Descripción                                                       |
| :------------------------- | :---------------------------------------------------------------- |
| **HelperDateTime**         | Librería principal con operaciones de fecha, hora y validaciones. |
| **HelperDateTime.Console** | Proyecto de consola interactivo con menú de pruebas manuales.     |
| **HelperDateTime.Tests**   | Proyecto de pruebas unitarias utilizando xUnit.                   |

---

# ⚙️ Requisitos del Sistema

- .NET 9 SDK
- Visual Studio 2022 o superior / Visual Studio Code

---

# 🚀 Instalación y Ejecución

### Clonar el Repositorio

```bash
git clone https://github.com/usuario/HelperDateTime.git
cd HelperDateTime
```

### Restaurar dependencias y compilar

```bash
dotnet restore
dotnet build --configuration Release
```

### Ejecutar el Proyecto de Consola

```bash
dotnet run --project HelperDateTime.Console
```

# 🧪 Pruebas Unitarias

```bash
dotnet test
```

---

# 🧱 Diseño y Arquitectura

| Componente                               | Responsabilidad                         |
| :--------------------------------------- | :-------------------------------------- |
| **DateQuery**                            | Operaciones básicas sobre fechas        |
| **DateTimeQuery**                        | Manipulación avanzada de fechas y horas |
| **DateComparison / DateTimeComparison**  | Comparaciones                           |
| **DateConversion / DateTimeConversions** | Conversión y formateo                   |
| **HelperValidateDate**                   | Validaciones robustas de parámetros     |

---

# 🔐 Seguridad

- No se almacenan ni procesan datos sensibles.
- No se implementan mecanismos de autenticación.

---

# 📌 Estado del Proyecto

✅ En Desarrollo Activo  
🚀 Próximo objetivo: Publicar en NuGet y alcanzar cobertura de pruebas superior al 90%.

---

# 🎯 Roadmap

- [ ] Publicar en NuGet
- [ ] Soporte extendido para zonas horarias regionales
- [ ] Aumentar cobertura de pruebas >90%
- [ ] Localización multilingüe
- [ ] Integración con notebooks interactivos (.NET Interactive)

---

# 🤝 Cómo Contribuir

1. Realiza un fork del repositorio
2. Crea una nueva rama:

```bash
git checkout -b feature/nueva-funcionalidad
```

3. Realiza tus cambios y añade pruebas unitarias
4. Asegúrate de que todo pase:

```bash
dotnet test
```

5. Envía un Pull Request

---

# 🐞 Reporte de Bugs

Por favor abre un [Issue](https://github.com/usuario/HelperDateTime/issues) incluyendo:

- Descripción del problema
- Pasos para reproducirlo
- Comportamiento esperado
- Capturas de pantalla o logs (si aplica)

---

# 📢 Participa

- [Reportar un Bug](https://github.com/usuario/HelperDateTime/issues)
- [Solicitar Funcionalidad](https://github.com/usuario/HelperDateTime/issues)
- [Ver Pull Requests](https://github.com/usuario/HelperDateTime/pulls)

---

# 📄 Licencia

Este proyecto está licenciado bajo la **MIT License**.

---

# 📚 Recursos Adicionales

- [Documentación oficial de .NET](https://learn.microsoft.com/dotnet/)
- [System.DateTime](https://learn.microsoft.com/dotnet/api/system.datetime)
- [System.TimeZoneInfo](https://learn.microsoft.com/dotnet/api/system.timezoneinfo)
- [xUnit Test Framework](https://xunit.net/)
- [Guía de bibliotecas reutilizables en .NET](https://learn.microsoft.com/dotnet/standard/library-guidance)

---
