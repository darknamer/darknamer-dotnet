using System.ComponentModel.DataAnnotations;

namespace Darknamer.Core.Models;

public class ModelStrBase : ModelBase
{
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();
}