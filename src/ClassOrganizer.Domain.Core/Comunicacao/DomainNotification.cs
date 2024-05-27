using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizer.Domain.Core.Comunicacao
{
    public record DomainNotification : INotification
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
