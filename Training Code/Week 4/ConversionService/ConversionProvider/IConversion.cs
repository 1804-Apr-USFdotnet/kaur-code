using System.Runtime.Serialization;
using System.ServiceModel;
using RestaurantDataLibrary;
using System.Collections.Generic;
using System;

namespace ConversionProvider
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IConversion
    {
        /* [OperationContract]
         string GetData(int value);

         [OperationContract]
         CompositeType GetDataUsingDataContract(CompositeType composite);
         */
        // TODO: Add your service operations here
        [OperationContract]
        decimal ConvertUSDToINR(int units, decimal currentRate);
        [OperationContract]
        decimal ConvertINRToUSD(int units, decimal currentRate);
        [OperationContract]
        decimal ConvertCelciusToFahrenheit(decimal celcius);
        [OperationContract]
        IEnumerable<Restaurant> GetRestaurants();
        [OperationContract]
        rest GetRestaurantById(int id);
    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
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
        public string Phone { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
