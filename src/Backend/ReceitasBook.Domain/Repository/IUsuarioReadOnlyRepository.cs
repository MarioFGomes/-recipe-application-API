using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Domain.Repository;

public interface IUsuarioReadOnlyRepository
{
    Task<bool> ExisteUsuarioComEmail(string email);
}
