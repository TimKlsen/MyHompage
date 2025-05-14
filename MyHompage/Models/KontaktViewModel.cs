using System.ComponentModel.DataAnnotations;

public class KontaktViewModel
{
    [Required]
    public string Name
    {
        get; set;
    }

    [Required]
    [EmailAddress]
    public string Email
    {
        get; set;
    }

    [Required]
    public string Nachricht
    {
        get; set;
    }
}
