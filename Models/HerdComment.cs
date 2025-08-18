using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moo_Arvelous_Coders.Models;

public partial class HerdComment
{

    [Key]
    public string CommentId { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);

    [Required(ErrorMessage = "Comment is required.")]
    public string CommentDescription { get; set; }

    [Required(ErrorMessage = "Please select a herd.")]
    public string? HerdId { get; set; }

    public string? FarmerId { get; set; }

    public virtual Farmer? Farmer { get; set; }

    public virtual Herd? Herd { get; set; }

}
