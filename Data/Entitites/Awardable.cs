namespace BlazorApp1.Data.Entitites;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Awardable
{
    [Key]
    public int Awardable_ID { get; set; }

    [Required]
    [StringLength(10)]
    public string Kind { get; set; } // e.g., "Movie", "Actor", "Director"

    // Navigation properties for the 1-to-1 relationships
    // Only one of these will be populated for a given Awardable_ID
    public virtual Movie Movie { get; set; }
    public virtual Actor Actor { get; set; }
    public virtual Director Director { get; set; }

    // An awardable entity can receive multiple awards
    public virtual ICollection<Award> Awards { get; set; } = new List<Award>();
}