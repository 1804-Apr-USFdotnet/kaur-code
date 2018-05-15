using System.Runtime.Serialization;

namespace RestaurantService.SL
{
    [DataContract]
    public class Restaurant
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Phone { get; set; }
    }
}