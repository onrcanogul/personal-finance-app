using PF.Common.Models.Entities;
using PF.Domain.Entities.Identity;

namespace PF.Domain.Entities;

public class Expense : BaseEntity
{
    public string UserId { get; set; }
    public Guid ActivityId { get; set; }
    public decimal Price { get; set; }
    public bool IsPaid { get; set; }

    public Activity? Activity { get; set; }
    public User? User { get; set; }
}