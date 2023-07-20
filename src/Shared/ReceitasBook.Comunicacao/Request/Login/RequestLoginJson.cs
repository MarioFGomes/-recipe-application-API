using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Comunicacao.Request.Login;

public class RequestLoginJson
{
    public string Email { get; set; }
    public string Senha { get; set; }
}
