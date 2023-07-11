using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Domain.Entity;

public class BaseModel
{
    public Guid Id { get; set; }
    public DateTime DataRegistro { get; set; }
    public int Status { get; set; }
    public BaseModel()
    {
        Id = Guid.NewGuid();
        DataRegistro = DateTime.UtcNow;
        Status = 1;
    }
}
