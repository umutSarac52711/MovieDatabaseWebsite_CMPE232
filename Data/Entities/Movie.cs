namespace MovieDatabaseWebsite_CMPE232.Data.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Movie
{
    [Key]
    [ForeignKey("Awardable")] // This is both PK for Movie and FK to Awardable
    public int Awardable_ID { get; set; }

    [Required]
    [StringLength(255)]
    public string Title { get; set; }

    public DateTime Release_Date { get; set; }

    [StringLength(100)]
    public string Language { get; set; }

    public int? Duration { get; set; } // In minutes

    [Column(TypeName = "decimal(15,2)")]
    public decimal? Budget { get; set; }

    [Column(TypeName = "decimal(15,2)")]
    public decimal? Revenue { get; set; }

    [Column(TypeName = "decimal(3,1)")]
    public decimal? Rating { get; set; } // e.g., 8.5

    // Navigation Properties
    public virtual Awardable Awardable { get; set; } // The "base" Awardable record

    public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    public virtual ICollection<MovieCompany> MovieCompanies { get; set; } = new List<MovieCompany>();
    public virtual ICollection<Features> Features { get; set; } = new List<Features>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    
    //unimplemented
    public string? PosterUrl { get; set; }
}