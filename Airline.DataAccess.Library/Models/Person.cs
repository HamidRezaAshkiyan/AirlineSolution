using System.ComponentModel.DataAnnotations;

namespace Airline.DataAccess.Library.Models;

public class Person
{
    [Key]                         public int      Id           { get; init; }
    [Required] [StringLength(25)] public string   FirstName    { get; set; }
    [Required] [StringLength(25)] public string   LastName     { get; set; }
    [Required]                    public int      Age          { get; set; }
    [Required] [StringLength(25)] public string   NationalCode { get; set; }
    public DateTime CreateDate   { get; set; }
}