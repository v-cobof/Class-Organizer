using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Domain.Core.Services
{
    public interface IHashingService
    {
        public string CriarHash(string texto);
    }
}
