using System.ComponentModel.DataAnnotations.Schema;
using PF.Common.Models.Entities;
using PF.Common.Models.Enums;
using PF.Domain.Entities.Identity;

namespace PF.Domain.Entities;

public class Report : BaseEntity
{
    public string UserId { get; set; }
    public User? User { get; set; }
}