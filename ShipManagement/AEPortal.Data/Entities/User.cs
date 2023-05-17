using AEPortal.Common.BaseEntities;
using AEPortal.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AEPortal.Data.Entities;

public class Ship : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    [Column(TypeName = "varchar(6)")]
    public DeleteFlag DeleteFlag { get; set; }
}