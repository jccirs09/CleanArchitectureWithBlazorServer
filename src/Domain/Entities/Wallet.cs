using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class Wallet : AuditableEntity
{
    public int Id { get; set; }
    public decimal CurrentBalance { get; set; }

}
