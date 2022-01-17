namespace Darknamer.Core.Models;

public class ModelBase
{
    public bool IsActive { get; set; } = true;
    public bool IsDelete { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = "";
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public string UpdatedBy { get; set; } = "";
}