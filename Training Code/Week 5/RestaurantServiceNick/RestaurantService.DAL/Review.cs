namespace RestaurantService.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
