using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Linq;
using System.Collections.Generic;
using Avalonia.Media;
namespace PruebadeAvalanoia;
using System.Text.RegularExpressions;

public partial class MainWindow : Window
{
    bool mensaje=true;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void Presentarme(object sender, RoutedEventArgs e)
    {
        // 1. Obtenemos la lista de errores acumulados
        string errores = ObtenerErroresFormulario();

        // 2. Si hay errores, los mostramos en rojo y detenemos la ejecución
        if (!string.IsNullOrEmpty(errores))
        {
            TxtMensajeError.Foreground = Brushes.Red;
            TxtMensajeError.Text = "Por favor corrige lo siguiente:\n" + errores;
            return; 
        }

        // 3. Si pasa todas las validaciones, extraemos los datos de forma segura
        string nombre = nom1.Text?.Trim() ?? string.Empty;
        string apellido = nom3.Text?.Trim() ?? string.Empty;
        int.TryParse(edad.Text, out int edadNum);

        // 4. Mostramos el mensaje de éxito en verde (o el color que prefieras)
        TxtMensajeError.Foreground = Brushes.Green;
        if(mensaje==true)TxtMensajeError.Text = $"¡Hola! Mi nombre es {nombre} {apellido},\ntengo {edadNum} años y estoy aprendiendo a desarrollar interfaces gráficas con C#.";
        else TxtMensajeError.Text = $"¡Hola! Mi nombre es {nombre} {apellido},\ntengo {edadNum} años y actualmente estudio medicina mientras aprendo anatomía humana.";
    }
    private void Mensaje (object sender, RoutedEventArgs e)
    {
        if(mensaje==true) mensaje=false;
        else mensaje = true;
    }
    private void Limpiar(object sender, RoutedEventArgs e)
    {
        // Busca todos los elementos hijos del StackPanel que sean de tipo TextBox y limpia su texto
        foreach (var textBox in MiContenedor.Children.OfType<TextBox>())
        {
            textBox.Text = string.Empty;
        }
        nom1.Focus();
    }
    private string ObtenerErroresFormulario()
    {
        List<string> listaErrores = new List<string>();

        // Expresión regular para permitir solo letras (incluyendo tildes y la 'ñ') y espacios
        // ^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$
        string patronSoloLetras = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$";

        // Validación 1: Primer nombre obligatorio y solo letras
        if (nom1 == null || string.IsNullOrWhiteSpace(nom1.Text))
        {
            listaErrores.Add("- El campo 'Primer nombre' es obligatorio.");
        }
        else if (!Regex.IsMatch(nom1.Text.Trim(), patronSoloLetras))
        {
            listaErrores.Add("- El 'Primer nombre' solo debe contener letras (sin números ni símbolos).");
        }

        // Validación 2: Primer apellido obligatorio y solo letras
        if (nom3 == null || string.IsNullOrWhiteSpace(nom3.Text))
        {
            listaErrores.Add("- El campo 'Primer apellido' es obligatorio.");
        }
        else if (!Regex.IsMatch(nom3.Text.Trim(), patronSoloLetras))
        {
            listaErrores.Add("- El 'Primer apellido' solo debe contener letras (sin números ni símbolos).");
        }

        // Validación 3: Edad obligatoria y que sea un número válido
        if (edad == null || string.IsNullOrWhiteSpace(edad.Text))
        {
            listaErrores.Add("- El campo 'Edad' es obligatorio.");
        }
        else if (!int.TryParse(edad.Text.Trim(), out int valorEdad))
        {
            listaErrores.Add("- El campo 'Edad' debe ser un número entero válido.");
        }
        else if (valorEdad <= 0 || valorEdad > 120)
        {
            listaErrores.Add("- Por favor introduce una edad real (entre 1 y 120 años).");
        }

        // Devuelve todos los errores unidos por un salto de línea
        return string.Join("\n", listaErrores);
    }
}