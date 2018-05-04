using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tapas.DataLayer.Models
{
    public class Review:BaseEntity
    {
        [Column("Id")]
        [ScaffoldColumn(false)]
        public int ReviewId { get; set; }
        [Required]
        [Range(1,10, ErrorMessage ="Rating should be between 1 and 10")]
        public int Rating { get; set; }
        [StringLength(200,ErrorMessage ="Comment should not be exceeed mored than 200 characters")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public DateTime Created { get ; set; }
        public DateTime? Modified { get ; set ; }
    }
}