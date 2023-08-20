using Neptunee.BaseCleanArchitecture.OResponse;
using Neptunee.BaseCleanArchitecture.Requests;

namespace StayHome.Application.Dashboard;

public class GetHomeQuery
{
    public class Request: IRequest<OperationResponse<Response>>
    {
        public int Year { get; set; }
    }
    public class Response 
    {
        public int EmployeesCount { get; set; }
        public int DriversCount { get; set; }
        public int CustomersCount { get; set; }
        public int ShopsCount { get; set; }
        public int OrdersCount { get; set; }
        public List<HomeInfoRes> BestShops { get; set; }
        public List<HomeInfoRes> BestDrivers { get; set; }
        public List<int> ShippingOrderCountMonthly { get; set; }
        public List<int> DeliveryOrderCountMonthly { get; set; }
        public List<int> PassengerOrderCountMonthly { get; set; }

        public class HomeInfoRes
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}