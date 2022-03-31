using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Blazor.Domain.Entities;
public class WalletTransaction : AuditableEntity
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public decimal Amount { get; set; }
    public decimal PreviousBalance { get; set; }
    public decimal NewBalance { get; set; }
    public string? Stat { get; set; }
    public string? Type { get; set; }
    public int? InvestmentId { get; set; }
    public int? PayoutId { get; set; }
}
