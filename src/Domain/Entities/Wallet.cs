namespace CleanArchitecture.Blazor.Domain.Entities;
public class Wallet : AuditableEntity
{
    public int Id { get; set; }
    public decimal CurrentBalance { get; set; }

}
