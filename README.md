# Saludo-Avalonia
📋 Descripción de la Aplicación
Esta aplicación gráfica de escritorio ha sido desarrollada utilizando Avalonia UI y C# (.NET). Su propósito principal es capturar información personal básica del usuario (primer nombre, primer apellido y edad), aplicar un sistema robusto de validación de datos en tiempo real y presentar un mensaje formateado en pantalla si todas las reglas se cumplen de manera correcta.

---

🛠️ Explicación de los Controles Utilizados
La interfaz gráfica está diseñada dentro de un contenedor principal (StackPanel) y hace uso de los siguientes controles de Avalonia:

TextBox: Utilizados para la entrada de datos por parte del usuario.

nom1: Campo designado para el Primer nombre.

nom3: Campo designado para el Primer apellido.

edad: Campo numérico designado para la Edad.

Propiedad clave utilizada: .Text para extraer el contenido y .Focus() para reposicionar el cursor de forma automática en caso de error.

TextBlock:

Títulos y etiquetas informativas estáticas.

TxtMensajeError: Un control dinámico que cambia su contenido y color de texto (Foreground) para mostrar la lista de errores en rojo o el mensaje de éxito en verde.

Button:

Botón "Presentarme": Ejecuta la lógica central de validación y extracción de datos.

Botón "Limpiar": Restablece todos los campos de texto a su estado vacío y limpia el panel de mensajes.

Botón "Mensaje": Cambia una variable tipo bool dependiendio si es true o false muestra un mensaje diferente

---

⚙️ Funcionamiento de los Eventos
La interacción del usuario está controlada mediante eventos enlazados directamente desde el código XAML hacia el archivo MainWindow.axaml.cs:

Evento Click del Botón Presentarme (Presentarme):

Invoca al método centralizado ObtenerErroresFormulario().

Si la validación devuelve errores, estos se imprimen en color rojo, se devuelve el foco al primer campo afectado y se detiene la ejecución.

Si la validación es exitosa (string.IsNullOrEmpty), limpia los errores, extrae la información con seguridad utilizando operadores de nulos (??) y muestra la tarjeta de presentación en color verde (indicando que estudia medicina y aprende anatomía humana).

Evento Click del Botón Limpiar (Limpiar):

Recorre dinámicamente los controles hijos del contenedor principal utilizando LINQ (MiContenedor.Children.OfType<TextBox>()) para vaciar sus propiedades .Text de forma masiva.

Restablece el TextBlock de notificaciones dejándolo en blanco.

Devuelve automáticamente el cursor al primer campo de texto (nom1.Focus()), dejando la interfaz lista para una nueva captura de datos.

Evento Click del boton MEnsaje:

Cambia el estado de la varible mensaje para que cuando el evento click presentarme muestre un mensaje diferente dependiendo si es true o false en la presentacion

---

<img width="1366" height="729" alt="image" src="https://github.com/user-attachments/assets/57cdb33b-0cf9-4660-9e36-2aa05c77a86a" />
<img width="1366" height="723" alt="image" src="https://github.com/user-attachments/assets/40f185aa-311d-4fb2-b08b-745388ca656b" />
<img width="1366" height="694" alt="image" src="https://github.com/user-attachments/assets/a0db1fd2-2da1-42d3-9eaf-d8b41cdb176b" />
<img width="1366" height="740" alt="image" src="https://github.com/user-attachments/assets/b927723b-816e-4a8a-a8b3-6f2d2aa07e22" />

---

🚀 Instrucciones para Ejecutar el Programa
Sigue estos pasos para compilar y ejecutar la aplicación en tu entorno local:

Requisitos previos:

Tener instalado .NET SDK (versión compatible con Avalonia UI, preferiblemente .NET 8.0 o superior).

Un entorno de desarrollo como Visual Studio, Visual Studio Code o JetBrains Rider con las extensiones de Avalonia instaladas.

Abrir el proyecto:

Abre tu terminal o IDE preferido y navega hasta la carpeta raíz del proyecto donde se encuentra el archivo .sln o el archivo .csproj. (Nota: El repositorio clonado no incluye las carpetas bin ni obj, ya que se generan de manera automática al compilar la primera vez).

Ejecutar la aplicación:

Ejecuta el siguiente comando en la terminal:

Bash
dotnet run
La aplicación se compilará automáticamente (restaurando e infiriendo los archivos temporales necesarios en bin/obj) y se abrirá la ventana gráfica de escritorio lista para interactuar.

---

# ¿Cuál es la función de MainWindow.axaml y MainWindow.axaml.cs, y cómo se relacionan mediante x:Name y los eventos Click para permitir que el usuario interactúe con la aplicación?

El axaml es el encargado visual de que se muestren textos, cajas de textos, botones y mas. El .cs es el encargado de que cuando un evento le dan click llena una celda ejecute una accion una serie de pasos dependiendo de lo que se quiera lograr. El x:Name es el encargado de identificador de texto o boton u otro entre mas de ellos y sirve para que se realize una accion sobre el por ejemplo el proyecto limpiar. Y los eventos Click son los encargados de llamar a la accion cuando le da click.
En resumen axaml es lo que se muestra en pantalla y .cs lo que ocurre detras de pantalla.
