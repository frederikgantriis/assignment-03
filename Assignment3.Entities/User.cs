using System.ComponentModel.DataAnnotations;

namespace Assignment3.Entities;

public class User {
    public int id { get; set; }

    [Required]
    public string name { get; set; }

    [Required]
    //TODO: Email should be unique
    public string email { get; set; }
    public List<Task> tasks { get; set; }
}
