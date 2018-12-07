using System.ComponentModel.DataAnnotations;

namespace AppAssociados.Domain

{
    public class Usuario
    {
        public int id { get; set; }
        [Required(ErrorMessage="O nome do usuario é obrigatório",AllowEmptyStrings=false)]
        public string user { get; set; }
        [Required]
        [StringLength(10,MinimumLength=4,ErrorMessage="A senha deve conter no máximo 10 caracteres e no mínimo 4")]
        public string password { get; set; }
        [Required]
        public string nome { get; set; }
    }   
}