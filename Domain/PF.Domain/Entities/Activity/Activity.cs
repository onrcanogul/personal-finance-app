using PF.Common.Models.Entities;

namespace PF.Domain.Entities;

public class Activity : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}