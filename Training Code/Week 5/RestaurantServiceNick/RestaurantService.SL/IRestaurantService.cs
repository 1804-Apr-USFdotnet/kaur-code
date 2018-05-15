using System.Collections.Generic;
using System.ServiceModel;

namespace RestaurantService.SL
{
    [ServiceContract]
    public interface IRestaurantService
    {
        [OperationContract]
        IEnumerable<Restaurant> GetAll();

        [OperationContract]
        Restaurant Get(int id);
    }
}
