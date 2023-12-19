
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace PruebaTecnica.net7.Data.Repositories;

[Table("users")]
public class User
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    public DateTime CreateAt { get; set; }
    public Boolean Active { get; set; }


}