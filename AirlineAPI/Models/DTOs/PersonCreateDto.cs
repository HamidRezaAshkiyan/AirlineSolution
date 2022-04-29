using System.ComponentModel.DataAnnotations;

namespace AirlineAPI.Models.DTOs;

public class PersonCreateDto
{
    [Required] [StringLength(25)] public string FirstName    { get; set; }
    [Required] [StringLength(25)] public string LastName     { get; set; }
    [Required]                    public int    Age          { get; set; }
    [Required] [StringLength(25)] public string NationalCode { get; set; }
}