using System.Globalization;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Agraria.Util.Validaciones
{
    [SupportedOSPlatform("windows")]
    public partial class ValidadorNumeroDecimal : ValidadorTextBox
    {
        // Argentina culture for decimal validation
        private static readonly CultureInfo ArgentinaCulture = new CultureInfo("es-AR");

        public ValidadorNumeroDecimal(TextBox textBox, ErrorProvider errorProvider)
            : base(textBox, errorProvider)
        {
            MensajeError = "Ingresa un número decimal válido con coma como separador decimal.";
        }

        public override bool Validar()
        {
            // Uses decimal.TryParse with Argentina culture for proper validation
            if (!decimal.TryParse(_textBox.Text, NumberStyles.Number, ArgentinaCulture, out _))
            {
                return false;
            }

            // Additional validation with regex to ensure proper format
            return DecimalRegex().IsMatch(_textBox.Text);
        }

        // Updated: Improved key press validation for Argentina decimal format
        protected override void ValidarKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Allow control characters (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Allow digits
            if (char.IsDigit(e.KeyChar))
            {
                // Check if we're after a comma and already have 2 decimal digits
                int commaIndex = textBox.Text.IndexOf(',');
                if (commaIndex != -1 && textBox.SelectionStart > commaIndex)
                {
                    // Count digits after comma
                    string decimalPart = textBox.Text.Substring(commaIndex + 1);
                    if (decimalPart.Length >= 2)
                    {
                        e.Handled = true; // Reject if already 2 decimal digits
                        return;
                    }
                }
                return;
            }

            // Allow comma as decimal separator (only one)
            if (e.KeyChar == ',' && !textBox.Text.Contains(','))
            {
                // Ensure comma is not the first character
                if (textBox.Text.Length == 0)
                {
                    e.Handled = true; // Don't allow comma at the beginning
                }
                return;
            }

            // Allow minus sign at the beginning for negative numbers
            if (e.KeyChar == '-' && textBox.SelectionStart == 0 && !textBox.Text.Contains('-'))
            {
                return;
            }

            // All other characters are rejected
            e.Handled = true;
        }

        [GeneratedRegex(@"^-?(\d{1,3}(\.\d{3})*|\d+)(,\d{1,2})?$", RegexOptions.Compiled)]
        private static partial Regex DecimalRegex();
    }
}