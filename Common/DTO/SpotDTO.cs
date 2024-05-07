namespace Common.DTO;

public class SpotDTO
{
    public int Id { get; set; }

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