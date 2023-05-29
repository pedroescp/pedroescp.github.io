using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface IAutenticacaoService
    {
        string GerarTokenClaims(string email);
    }
}
