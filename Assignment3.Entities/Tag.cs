using System.ComponentModel.DataAnnotations;

namespace Assignment3.Entities;

public class Tag
{
    public int id { get; set; }

    [Required]
    [StringLength(50)]
    public string name { get; set; }
    public List<Task> tasks { get; set; }
}
