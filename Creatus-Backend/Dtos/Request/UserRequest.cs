using System.ComponentModel.DataAnnotations;

namespace creatus_backend.Dtos.Request
{
    public class UserRequest
    {
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "O campo deve ter um endereço de e-mail válido.")]
        public string? Email { get; set; }

        public string? Password { get; set; }

        [Range(1, 5, ErrorMessage = "O nível deve estar entre 1 e 5.")]
        public int? Level { get; set; }
    }
}
