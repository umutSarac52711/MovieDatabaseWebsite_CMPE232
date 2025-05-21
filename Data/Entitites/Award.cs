﻿namespace BlazorApp1.Data.Entitites;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Award
{
    [Key]
    public int Award_ID { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; } // e.g., "Oscar", "Golden Globe"

    [StringLength(255)]
    public string Category { get; set; } // e.g., "Best Picture", "Best Actor"

    public int Award_Year { get; set; }

    public int Awardable_ID { get; set; } // FK to Awardable.Awardable_ID

    // Navigation Property
    [ForeignKey("Awardable_ID")]
    public virtual Awardable Awardable { get; set; }
}