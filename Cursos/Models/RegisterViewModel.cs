using System.ComponentModel.DataAnnotations;

namespace Cursos.Models
{

    public class RegisterViewModel
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o seu nome.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o seu email.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Por favor, informe uma senha com pelo menos 1 letra maiúscula, 1 letra minúscula, 1 número, 1 símbolo ecom no mínimo 8 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a sua senha.")]
        public string? Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem, por favor verifique.")]
        [Required(ErrorMessage = "Por favor, confirme a sua senha.")]
        public string? SenhaConfirmacao { get; set; }

    }

}