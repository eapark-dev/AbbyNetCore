using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Model;
public class Category
{
    [Key] //primary key 지정
    public int id { get; set; }
    [Required]
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
}

