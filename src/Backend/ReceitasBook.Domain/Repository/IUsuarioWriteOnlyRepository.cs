using ReceitasBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Domain.Repository;

public interface IUsuarioWriteOnlyRepository
{
    Task Adicionar(Usuario usuario);
}
