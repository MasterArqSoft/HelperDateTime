# 📜 Changelog

Todas las actualizaciones importantes de HelperDateTime se documentarán en este archivo.

Este proyecto sigue el formato de versionado semántico ([SemVer](https://semver.org/spec/v2.0.0.html)).

---

## [1.0.0] - 2025-04-17

### 🚀 Primera versión estable

- Librería inicial de utilidades avanzadas para manejo de fechas y horas en .NET 9.
- Implementación de las clases:
  - `DateQuery`
  - `DateTimeQuery`
  - `DateConversion`
  - `DateTimeConversions`
  - `DateComparison`
  - `DateTimeComparison`
  - `HelperValidateDate`
- Validaciones robustas:
  - Manejo seguro de nulos (`ArgumentNullException`)
  - Validación de enteros positivos (`ArgumentOutOfRangeException`)
  - Validación de cadenas no vacías.
- Operaciones de fecha:
  - Cálculo de diferencias de días.
  - Conteo de días específicos de la semana entre dos fechas.
  - Suma de intervalos: días, meses, años, horas, minutos y segundos.
- Conversión y formato:
  - Transformaciones entre `DateTime` y cadenas usando `CultureInfo.InvariantCulture`.
  - Formatos corto, medio, largo y completo de fechas.
  - Conversión segura entre zonas horarias (UTC ⇄ Local ⇄ TimeZone personalizada).
- Comparaciones de fechas:
  - Igualdad, anterioridad y posterioridad de fechas (`DateTime` y sólo fechas).
- Estándares de calidad:
  - Código limpio y modular aplicando principios SOLID.
  - Validaciones automáticas centralizadas (`HelperValidateDate`).
  - Documentación XML completa para soporte IntelliSense.
- Preparado para despliegue en NuGet en futuras versiones.

---

# 📅 Próximas versiones

- Publicar en NuGet.
- Agregar soporte extendido para culturas específicas.
- Aumentar cobertura de pruebas automáticas a >90%.
- Mejorar internacionalización (i18n) y localización (l10n).
