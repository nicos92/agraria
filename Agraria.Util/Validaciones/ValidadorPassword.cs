using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Agraria.Util.Validaciones
{
    [SupportedOSPlatform("windows")]
    public partial class ValidadorPassword : ValidadorTextBox
    {
        public ValidadorPassword(TextBox textBox, ErrorProvider errorProvider)
            : base(textBox, errorProvider)
        {
            MensajeError = "La contraseña debe tener al menos 8 caracteres,\n incluyendo mayúsculas, minúsculas,\n números y caracteres especiales @$!%_-*?&";
        }

        public override bool Validar()
        {
            return PasswordRegex().IsMatch(_textBox.Text);
        }

        protected override void ValidarKeyPress(object sender, KeyPressEventArgs e)
        {
            // No restringimos caracteres en la contraseña
            // Permitimos todos los caracteres necesarios para una contraseña segura
        }

        [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%_\-*?&])[A-Za-z\d@$!%_\-*?&]{8,}$", RegexOptions.Compiled)]
        private static partial Regex PasswordRegex();
    }
}