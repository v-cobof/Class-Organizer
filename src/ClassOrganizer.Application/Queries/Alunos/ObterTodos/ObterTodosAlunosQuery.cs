using ClassOrganizer.Application.DTO;
using ClassOrganizer.Domain.Core.Comunicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Application.Queries.Alunos.ObterTodos
{
    public record ObterTodosAlunosQuery : Query<IEnumerable<AlunoMinDTO>>
    {
    }
}
