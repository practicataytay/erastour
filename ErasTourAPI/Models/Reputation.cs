using System.ComponentModel.DataAnnotations;
namespace ErasTourAPI.Models;

public class Reputation
{
    [Key]
    public int Id { get; set; }

    // año del álbum/era
    public int Year { get; set; }

    // color asociado
    public string Color { get; set; } = null!;

    // novio de la era
    public string Boyfriend { get; set; } = null!;

    // canción favorita
    public string FavoriteSong { get; set; } = null!;
}