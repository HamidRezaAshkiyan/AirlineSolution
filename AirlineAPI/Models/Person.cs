using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirlineAPI.Models;

public class Person
{
    [Key]                         public int      Id           { get; set; }
    [Required] [StringLength(25)] public string   FirstName    { get; set; }
    [Required] [StringLength(25)] public string   LastName     { get; set; }
    [Required]                    public int      Age          { get; set; }
    [Required] [StringLength(25)] public string   NationalCode { get; set; }
    [DefaultValue("GetDate()")]   public DateTime CreateDate   { get; set; }
}