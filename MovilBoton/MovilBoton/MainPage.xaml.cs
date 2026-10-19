namespace MovilBoton
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalcularClicked(object? sender, EventArgs e)
        {
            // Obtener los valores de los campos
            string nombre = EntryNombre.Text?.Trim() ?? string.Empty;
            string apellido = EntryApellido.Text?.Trim() ?? string.Empty;
            string edadTexto = EntryEdad.Text?.Trim() ?? string.Empty;
            string salarioTexto = EntrySalario.Text?.Trim() ?? string.Empty;

            // Validación: todos los campos deben estar completos
            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(edadTexto) ||
                string.IsNullOrEmpty(salarioTexto))
            {
                await DisplayAlertAsync("Error", "Todos los campos deben estar completos.", "OK");
                return;
            }

            // Validación: edad debe ser un número entero válido
            if (!int.TryParse(edadTexto, out int edad) || edad <= 0)
            {
                await DisplayAlertAsync("Error", "La edad debe ser un número entero válido mayor a 0.", "OK");
                return;
            }

            // Validación: salario debe ser un número válido
            if (!double.TryParse(salarioTexto, out double salario) || salario <= 0)
            {
                await DisplayAlertAsync("Error", "El salario debe ser un número válido mayor a 0.", "OK");
                return;
            }

            // Cálculo del aporte al IESS (9.45% del salario)
            double aporte = salario * 0.0945;

            // Mostrar alerta con el resultado
            string mensaje = $"Bienvenido \"{nombre} {apellido}\"\n" +
                             $"Tienes \"{edad}\" años\n" +
                             $"Tu aporte mensual es \"{aporte:F2}\"";

            await DisplayAlertAsync("Resultado", mensaje, "OK");
        }
    }
}
