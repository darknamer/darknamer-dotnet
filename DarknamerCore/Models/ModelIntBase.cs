using System.ComponentModel.DataAnnotations;

namespace Darknamer.Core.Models;

public class ModelIntBase : ModelBase
{
    [Key] public int Id { get; set; }
}