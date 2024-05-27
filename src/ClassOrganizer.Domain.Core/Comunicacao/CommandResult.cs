using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Domain.Core.Comunicacao
{
    public record CommandResult
    {
        public bool EhSucesso { get; private set; }

        public CommandResult(bool success)
        {
            EhSucesso = success;
        }

        public static CommandResult Sucesso()
        {
            return new CommandResult(true);
        }

        public static CommandResult Falha()
        {
            return new CommandResult(false);
        }

        public static implicit operator CommandResult(bool success) => new(success);
    }
}
