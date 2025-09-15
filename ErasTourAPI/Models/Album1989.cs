using System.ComponentModel.DataAnnotations;

namespace ErasTourAPI.Models;

public class Album1989
{
    [Key]
    public int Id { get; set; }

    public int Year { get; set; }

    public string Color { get; set; } = null!;

    public string Boyfriend { get; set; } = null!;

    public string FavoriteSong { get; set; } = null!;
}