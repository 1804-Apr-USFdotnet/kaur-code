using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tapas.DataLayer.Models
{
    [Table("rest")]
    public class Restaurant : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Restaurant Name shoukd be within 25 characters")]
        public string Name { get; set; }
        [Column("s1")]
        public string Street1 { get; set; }
        [Column("s2")]
        public string Street2 { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        //[RegularExpression("[0-9]{5}")]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        //Related Models of Foreign Key Relationship
        public virtual ICollection<Review> Reviews { get; set; }

        [NotMapped]
        public int? AvgRating { get; set; }

        [NotMapped]
        public string Address
        {
            get
            {
                return Street1 + " ," + Street2 + " ," + City + " ," + State + " ," + Country + " ," + Zipcode;
            }

        }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
