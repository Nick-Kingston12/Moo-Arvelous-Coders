using System;
using System.Collections.Generic;

namespace Moo_Arvelous_Coders.Models;

public partial class Farmer
{
    public string FarmerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Idnumber { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<CattleSaleRecord> CattleSaleRecords { get; set; } = new List<CattleSaleRecord>();

    public virtual ICollection<Cattle> Cattles { get; set; } = new List<Cattle>();

    public virtual ICollection<Farm> Farms { get; set; } = new List<Farm>();

    public virtual ICollection<HerdComment> HerdComments { get; set; } = new List<HerdComment>();

    public virtual ICollection<Herd> Herds { get; set; } = new List<Herd>();
}
