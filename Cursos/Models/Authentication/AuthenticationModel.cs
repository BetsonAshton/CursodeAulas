namespace Cursos.Models.Authentication
{
    /// <summary>
    /// Modelo de dados para as informações que serão
    /// gravadas no Cookie de autenticação
    /// </summary>
    public class AuthenticationModel
    {
        public Guid? IdAdm { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataHoraAcesso { get; set; }
        

    }
}
