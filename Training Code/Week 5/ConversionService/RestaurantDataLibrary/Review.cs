namespace RestaurantDataLibrary
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

        [StringLength(200)]
        public string Comment { get; set; }

        public int? Restaurant_Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public virtual rest rest { get; set; }
    }
}
