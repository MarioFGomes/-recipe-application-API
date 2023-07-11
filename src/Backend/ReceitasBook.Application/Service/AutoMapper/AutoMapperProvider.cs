using AutoMapper;
using ReceitasBook.Comunicacao.Request;
using ReceitasBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Application.Service.AutoMapper;

public class AutoMapperProvider:Profile
{
    public AutoMapperProvider()
    {
        CreateMap<RequestRegistrarUsuario, Usuario>()
          .ForMember(destino => destino.Password, config => config.Ignore());

        CreateMap<Usuario, RequestRegistrarUsuario>();
    }
}
