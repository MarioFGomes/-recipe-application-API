using Microsoft.EntityFrameworkCore;
using ReceitasBook.Domain.Entity;
using ReceitasBook.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioWriteOnlyRepository, IUsuarioReadOnlyRepository
    {
        private readonly ReceitaBookContext _Context;
        public UsuarioRepository(ReceitaBookContext context)
        {

            _Context = context;

        }
        public async Task Adicionar(Usuario usuario)
        {
            await _Context.Usuario.AddAsync(usuario);
        }

        public async Task<bool> ExisteUsuarioComEmail(string email)
        {
            return await _Context.Usuario.AnyAsync(m =>m.Email.Equals(email));
        }
    }
}
