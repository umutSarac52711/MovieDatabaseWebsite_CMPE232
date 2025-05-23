using System.ComponentModel.DataAnnotations;

namespace MovieDatabaseWebsite_CMPE232.Data.Entities;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductionCompany
{
    [Key]
    public int Company_ID { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [StringLength(100)]
    public string Country { get; set; }

    public int? Founded_Year { get; set; }

    // Navigation Properties
    public virtual ICollection<MovieCompany> MovieCompanies { get; set; } = new List<MovieCompany>();
}