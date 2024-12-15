using PF.Common.Models.Entities;
using PF.Common.Models.Enums;

namespace PF.Domain.Entities;

public class Activity : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ActivityType Type { get; set; }
}