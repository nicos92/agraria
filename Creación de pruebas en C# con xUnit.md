# **Manual de documentación: Creación de pruebas en C\# con xUnit**

Este manual describe el proceso para crear y ejecutar pruebas unitarias en C\# utilizando el framework **xUnit**, junto con herramientas para medir la cobertura de código y generar reportes. Se basa en los comandos utilizados en un curso de Udemy y está orientado a desarrolladores que deseen replicar este flujo de trabajo.

---

## **1\. Introducción**

Las pruebas unitarias son fundamentales para garantizar la calidad y el correcto funcionamiento del código. **xUnit** es uno de los frameworks de prueba más populares en el ecosistema .NET, y se integra perfectamente con la CLI de .NET.

Este manual cubre:

- Creación de proyectos de prueba y bibliotecas de clases.  
- Instalación de paquetes necesarios (xUnit, Moq, coverlet).  
- Ejecución de pruebas con y sin cobertura.  
- Generación de reportes de cobertura en formato HTML.

Todos los comandos están pensados para ser ejecutados en la **terminal** (PowerShell, bash, cmd) desde la raíz de la solución o del proyecto correspondiente.

---

## **2\. Flujo de trabajo general**

El proceso típico consta de los siguientes pasos:

1. **Crear la estructura de proyectos**

   - Un proyecto de biblioteca de clases (classlib) que contiene el código a probar.  
   - Un proyecto de pruebas (console) o (xunit) que contendrá los tests.

2. **Agregar los paquetes NuGet necesarios**

   - Paquetes de xUnit, el runner de Visual Studio, y el SDK de pruebas de Microsoft.

3. **Escribir las pruebas**

   - Crear clases y métodos de prueba usando atributos `[Fact]` o `[Theory]`.

4. **Ejecutar las pruebas**

   - Usar `dotnet test` para correr los tests.

5. **Medir la cobertura de código**

   - Instalar coverlet y ejecutar `dotnet test` con parámetros de cobertura.

6. **Generar reportes de cobertura**

   - Instalar ReportGenerator y convertir los archivos de cobertura en un reporte HTML.

---

## **3\. Comandos explicados en detalle**

### **3.1. Creación de proyectos**

dotnet new console

- **Propósito:** Crea un nuevo proyecto de aplicación de consola.  
- **Uso en el flujo:** Se utiliza para generar el proyecto que contendrá las pruebas (aunque también se puede usar `dotnet new xunit`). En el curso se empleó `console` para luego agregar manualmente los paquetes de prueba.

dotnet new classlib

- **Propósito:** Crea un proyecto de biblioteca de clases (DLL).  
- **Uso en el flujo:** Es el proyecto que contiene el código fuente que se desea probar (el sistema bajo prueba).

**Nota:** Una alternativa más directa para crear un proyecto de pruebas es `dotnet new xunit`, que ya incluye las referencias necesarias. Sin embargo, el enfoque mostrado permite entender qué paquetes se agregan explícitamente.

### **3.2. Instalación de paquetes NuGet**

Los siguientes comandos se ejecutan dentro de la carpeta del **proyecto de pruebas** (el que contiene los tests).

dotnet add package Microsoft.NET.Test.Sdk \--version 18.3.0

- **Propósito:** Agrega el SDK de pruebas de Microsoft. Es necesario para que `dotnet test` reconozca el proyecto como un proyecto de pruebas.  
- **Versión:** 18.3.0 (estable en el momento del curso).

dotnet add package xunit \--version 2.9.2

- **Propósito:** Instala el framework xUnit, que proporciona los atributos (`[Fact]`, `[Theory]`) y las aserciones (`Assert`).  
- **Versión:** 2.9.2.

dotnet add package xunit.runner.visualstudio \--version 3.1.5

- **Propósito:** Permite ejecutar las pruebas desde Visual Studio, Visual Studio Code o mediante `dotnet test`.  
- **Versión:** 3.1.5.

dotnet add package Moq \--version 4.20.72

- **Propósito:** Agrega **Moq**, una biblioteca de mocking que facilita la creación de objetos simulados (fakes) para aislar las pruebas de dependencias externas.  
- **Versión:** 4.20.72.

dotnet add package coverlet.msbuild \--version 8.0.1

- **Propósito:** Permite medir la cobertura de código utilizando coverlet integrado con MSBuild. Se usa junto con parámetros de `dotnet test`.

dotnet add package coverlet.collector \--version 8.0.1

- **Propósito:** Recolecta los datos de cobertura cuando se ejecutan las pruebas. Es el paquete recomendado para usar con el parámetro `CollectCoverage`.

### **3.3. Ejecución de pruebas**

dotnet test

- **Propósito:** Compila los proyectos y ejecuta todas las pruebas encontradas en la solución o proyecto actual. Muestra un resumen de pruebas pasadas, fallidas o omitidas.

dotnet test \--no-build /p:CollectCoverage=true

- **Propósito:** Ejecuta las pruebas sin recompilar (`--no-build`) y habilita la recolección de cobertura de código mediante el parámetro MSBuild `/p:CollectCoverage=true`. Este comando requiere que el paquete `coverlet.collector` esté instalado.

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura

- **Propósito:** Similar al anterior, pero además especifica el formato de salida del archivo de cobertura. Aquí se usa **cobertura**, un formato XML ampliamente utilizado por herramientas de análisis. El archivo generado suele llamarse `coverage.cobertura.xml`.

### **3.4. Instalación y uso de ReportGenerator**

dotnet tool install \--global dotnet-reportgenerator-globaltool

- **Propósito:** Instala de forma global la herramienta **ReportGenerator**, que permite convertir archivos de cobertura (como el XML de cobertura) en reportes visuales (HTML, JSON, etc.).

reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:coveragereport" \-reporttypes:Html

- **Propósito:** Genera un reporte HTML a partir del archivo `coverage.cobertura.xml`.  
  - `-reports`: especifica el archivo de entrada.  
  - `-targetdir`: carpeta de salida (se creará `coveragereport`).  
  - `-reporttypes`: define el formato del reporte (Html es el más común para visualizar en navegador).

---

## **4\. Información adicional (aportes del autor)**

En esta sección se incluyen recomendaciones y aclaraciones que complementan el flujo original.

### **4.1. Uso de `dotnet new xunit`**

En lugar de crear un proyecto `console` y agregar manualmente los paquetes, se puede crear directamente un proyecto de pruebas con:

dotnet new xunit \-n NombreProyectoPruebas

Esto ya incluye las referencias a `Microsoft.NET.Test.Sdk`, `xunit`, `xunit.runner.visualstudio` y `coverlet.collector`. Luego solo sería necesario agregar `Moq` y `coverlet.msbuild` si se desea.

### **4.2. Organización de la solución**

Una práctica común es mantener una estructura donde la solución contiene:

- Carpeta `src/` con los proyectos de código fuente (classlib).  
- Carpeta `tests/` con los proyectos de pruebas.

Ejemplo:

MiSolucion.sln

├── src/

│   └── MiBiblioteca/

│       ├── MiBiblioteca.csproj

│       └── ...

└── tests/

    └── MiBiblioteca.Tests/

        ├── MiBiblioteca.Tests.csproj

        └── ...

Para crear la solución y los proyectos:

dotnet new sln \-n MiSolucion

dotnet new classlib \-n MiBiblioteca \-o src/MiBiblioteca

dotnet new xunit \-n MiBiblioteca.Tests \-o tests/MiBiblioteca.Tests

dotnet sln add src/MiBiblioteca/MiBiblioteca.csproj

dotnet sln add tests/MiBiblioteca.Tests/MiBiblioteca.Tests.csproj

### **4.3. Ejecución de cobertura en todos los proyectos**

Si se tiene más de un proyecto de pruebas, se puede ejecutar `dotnet test` desde la raíz de la solución con el parámetro de cobertura, y coverlet recolectará los datos de todos ellos.

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./coverage/

El parámetro `CoverletOutput` permite definir una carpeta de salida para los archivos de cobertura.

### **4.4. Configuración de filtros de cobertura**

Es posible excluir ciertos archivos o tipos del análisis de cobertura mediante un archivo `coverlet.settings` o mediante parámetros MSBuild. Por ejemplo, para excluir el código de pruebas de la cobertura:

dotnet test /p:CollectCoverage=true /p:Exclude="\[xunit.\*\]\*%2c\[\*.Tests\]\*"

### **4.5. Versiones de paquetes**

Las versiones utilizadas en el curso son específicas. Antes de instalar, se recomienda verificar las versiones más recientes estables en [NuGet.org](https://www.nuget.org/) o usar `dotnet add package <nombre> --version` sin especificar versión para obtener la última.

### **4.6. Alternativa para ReportGenerator sin instalación global**

Si no se desea instalar una herramienta global, se puede usar ReportGenerator como una herramienta local mediante un archivo de manifiesto:

dotnet new tool-manifest

dotnet tool install dotnet-reportgenerator-globaltool

dotnet reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:coveragereport" \-reporttypes:Html

Esto mantiene las herramientas a nivel de proyecto.

### **4.7. Integración continua**

Los comandos mostrados son fácilmente integrables en pipelines de CI/CD (GitHub Actions, Azure DevOps, etc.). Por ejemplo, se pueden usar en un flujo de trabajo para ejecutar pruebas y generar reportes de cobertura como artefactos.

---

## **5\. Conclusión**

Los comandos y pasos descritos proporcionan una base sólida para implementar pruebas unitarias con xUnit en .NET. A partir de esta estructura, el desarrollador puede escribir pruebas, simular dependencias con Moq, medir la cobertura de código con coverlet y visualizar los resultados con ReportGenerator.

Dominar este flujo permite asegurar la calidad del software y facilita la detección temprana de errores, contribuyendo a un desarrollo más robusto y mantenible.

