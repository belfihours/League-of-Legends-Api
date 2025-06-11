using System.ComponentModel.DataAnnotations;

namespace League.Common.Configuration;

public class ApiConfiguration
{
    public static string Section { get; } = "ApiConfigurations";

    [Required]
    public ChampionsConfiguration Champions { get; set; } = new ();
}
