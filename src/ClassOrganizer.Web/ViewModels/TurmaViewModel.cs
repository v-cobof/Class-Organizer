using System.ComponentModel.DataAnnotations;

namespace ClassOrganizer.Web.ViewModels
{
    public class TurmaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Curso é obrigatório")]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "Nome da turma é obrigatório")]
        [StringLength(45, ErrorMessage = "O Nome da turma não pode ter mais de 45 caracteres")]
        public string NomeTurma { get; set; }

        [Required(ErrorMessage = "Ano é obrigatório")]
        public int Ano { get; set; }
    }

    public class TurmaComboBoxModel()
    {
        public int Id { get; set; }
        public string NomeTurma { get; set; }
    }
}
