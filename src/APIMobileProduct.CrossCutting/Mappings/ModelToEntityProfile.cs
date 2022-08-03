using APIMobileProduct.Domain.Entities;
using APIMobileProduct.Domain.Models;
using AutoMapper;

namespace APIMobileProduct.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<CompanyEntity, CompanyModel>().ReverseMap();
            CreateMap<FunctionEntity, FunctionModel>().ReverseMap();
            CreateMap<ProfileEntity, ProfileModel>().ReverseMap();
            CreateMap<PermitEntity, PermitModel>().ReverseMap();
            CreateMap<GroupEntity, GroupModel>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<BasemapEntity, BasemapModel>().ReverseMap();
            CreateMap<OfflinemapEntity, OfflinemapModel>().ReverseMap();
            CreateMap<EventTypeEntity, EventTypeModel>().ReverseMap();
            CreateMap<EventAliasEntity, EventAliasModel>().ReverseMap();

        }
    }
}
