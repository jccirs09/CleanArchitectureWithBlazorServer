using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class WalletPayout : AuditableEntity
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public decimal Amount { get; set; }    
    public string? FromUser { get; set; }
    public string? ToUser { get; set; }
    public string? Stat { get; set; }
}
