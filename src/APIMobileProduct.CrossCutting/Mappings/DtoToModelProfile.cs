using APIMobileProduct.Domain.Models;
using APIMobileProduct.Domain.Dtos.Company;
using AutoMapper;
using APIMobileProduct.Domain.Dtos.Function;
using APIMobileProduct.Domain.Dtos.Profile;
using APIMobileProduct.Domain.Dtos.Permit;
using APIMobileProduct.Domain.Dtos.Group;
using APIMobileProduct.Domain.Dtos.User;
using APIMobileProduct.Domain.Dtos.Basemap;
using APIMobileProduct.Domain.Dtos.Offlinemap;
using APIMobileProduct.Domain.Dtos.Event;

namespace APIMobileProduct.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            //company
            CreateMap<CompanyModel, CompanyDto>()
            .ReverseMap();
            CreateMap<CompanyModel, CompanyDtoCreate>()
            .ReverseMap();
            CreateMap<CompanyModel, CompanyDtoUpdate>()
            .ReverseMap();

            //function
            CreateMap<FunctionModel, FunctionDto>()
            .ReverseMap();
            CreateMap<FunctionModel, FunctionDtoCreate>()
            .ReverseMap();
            CreateMap<FunctionModel, FunctionDtoUpdate>()
            .ReverseMap();

            //profile
            CreateMap<ProfileModel, ProfileDto>()
            .ReverseMap();
            CreateMap<ProfileModel, ProfileDtoCreate>()
            .ReverseMap();
            CreateMap<ProfileModel, ProfileDtoUpdate>()
            .ReverseMap();

            //permit            
            CreateMap<PermitModel, PermitDto>()
            .ReverseMap();
            CreateMap<PermitModel, PermitDtoCreate>()
            .ReverseMap();
            CreateMap<PermitModel, PermitDtoUpdate>()
            .ReverseMap();

            //group           
            CreateMap<GroupModel, GroupDto>()
            .ReverseMap();
            CreateMap<GroupModel, GroupDtoCreate>()
            .ReverseMap();
            CreateMap<GroupModel, GroupDtoUpdate>()
            .ReverseMap();
            CreateMap<GroupModel, GroupOfflinemapsDto>()
            .ReverseMap();

            //user           
            CreateMap<UserModel, UserDto>()
            .ReverseMap();
            CreateMap<UserModel, UserDtoCreate>()
            .ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>()
            .ReverseMap();

            //basemap           
            CreateMap<BasemapModel, BasemapDto>()
            .ReverseMap();
            CreateMap<BasemapModel, BasemapDtoCreate>()
            .ReverseMap();
            CreateMap<BasemapModel, BasemapDtoUpdate>()
            .ReverseMap();

            //offlinemap      
            CreateMap<OfflinemapModel, OfflinemapDto>()
            .ReverseMap();
            CreateMap<OfflinemapModel, OfflinemapDtoCreate>()
            .ReverseMap();
            CreateMap<OfflinemapModel, OfflinemapDtoUpdate>()
            .ReverseMap();
            CreateMap<OfflinemapModel, OfflinemapDtoUpdateCoords>()
            .ReverseMap();
            CreateMap<OfflinemapModel, OfflinemapDtoPendingResult>()
            .ReverseMap();

            //EventType      
            CreateMap<EventTypeModel, EventTypeDto>()
            .ReverseMap();
            CreateMap<EventTypeModel, EventTypeDtoCreate>()
            .ReverseMap();
            CreateMap<EventTypeModel, EventTypeDtoUpdate>()
            .ReverseMap();

            //EventAlias    
            CreateMap<EventAliasModel, EventAliasDto>()
            .ReverseMap();
            CreateMap<EventAliasModel, EventAliasDtoCreate>()
            .ReverseMap();
            CreateMap<EventAliasModel, EventAliasDtoUpdate>()
            .ReverseMap();
        }
    }
}
