using System.ComponentModel.DataAnnotations;


namespace DataAccess.Entities;

public class Spot
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public List<string> Properties { get; set; }

    public string Image { get; set; }

    public List<string> WindDirectionGood { get; set; }

    public List<string> WindDirectionOk { get; set; }

    public List<string> WindDirectionBad { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string Area { get; set; }

    public string County { get; set; }
}