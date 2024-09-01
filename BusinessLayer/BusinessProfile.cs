using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;
using WebApi.Models;

namespace BusinessLayer
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<DataEntity, BaseInfo>();
            CreateMap<Company, CompanyInfo>();
            CreateMap<ArSubledger, ArSubledgerInfo>();
            CreateMap<Employee, EmployeeInfo>();
            CreateMap<Employee, EmployeeCreateInfo>();
        }
    }

}