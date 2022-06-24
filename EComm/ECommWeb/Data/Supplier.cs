using System.ComponentModel.DataAnnotations;

namespace ECommWeb.Data;

public class Supplier
{
    public int Id { get; set; }

    [Required]
    public string CompanyName { get; set; } = string.Empty;
}
