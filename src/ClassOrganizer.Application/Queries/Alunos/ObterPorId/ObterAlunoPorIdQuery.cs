using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;
using ClassOrganizer.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Queries.Alunos.ObterPorId
{
    public record ObterAlunoPorIdQuery : Query<AlunoDTO>
    {
        public int Id { get; set; }
    }
}
