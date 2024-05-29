using System.ComponentModel.DataAnnotations;

namespace ClassOrganizer.Web.ViewModels
{
    public class AlunoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(255, ErrorMessage = "O Nome não pode ter mais de 255 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Usuário é obrigatório")]
        [StringLength(45, ErrorMessage = "O Usuário não pode ter mais de 45 caracteres")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A Senha deve ter pelo menos 6 caracteres")]
        public string Senha { get; set; }
    }

    public class AlunoComboBoxModel()
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
