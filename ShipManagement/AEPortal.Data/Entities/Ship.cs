using AEPortal.Common.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AEPortal.Data.Entities;

public class Ship : BaseEntity
{
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }
    [Column(TypeName = "Decimal(8,6)")]
    public decimal Latitude { get; set; }
    [Column(TypeName = "Decimal(9,6)")]
    public decimal Longitude { get; set; }
    public double Velocity { get; set; }
}