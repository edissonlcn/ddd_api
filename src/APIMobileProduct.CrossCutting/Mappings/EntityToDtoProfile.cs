using APIMobileProduct.Domain.Entities;
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
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            //company
            CreateMap<CompanyDto, CompanyEntity>().ReverseMap();
            CreateMap<CompanyDtoCreateResult, CompanyEntity>().ReverseMap();
            CreateMap<CompanyDtoUpdateResult, CompanyEntity>().ReverseMap();

            //function
            CreateMap<FunctionDto, FunctionEntity>().ReverseMap();
            CreateMap<FunctionDtoCreateResult, FunctionEntity>().ReverseMap();
            CreateMap<FunctionDtoUpdateResult, FunctionEntity>().ReverseMap();

            //profile
            CreateMap<ProfileDto, ProfileEntity>().ReverseMap();
            CreateMap<ProfileGroupCreateDto, ProfileEntity>().ReverseMap();
            CreateMap<ProfileDtoCreateResult, ProfileEntity>().ReverseMap();
            CreateMap<ProfileDtoUpdateResult, ProfileEntity>().ReverseMap();

            //permit
            CreateMap<PermitDto, PermitEntity>().ReverseMap();
            CreateMap<PermitDtoCreateResult, PermitEntity>().ReverseMap();
            CreateMap<PermitDtoUpdateResult, PermitEntity>().ReverseMap();

            //group
            CreateMap<GroupDto, GroupEntity>().ReverseMap();
            CreateMap<GroupDtoCreate, GroupEntity>().ReverseMap();
            CreateMap<GroupDtoCreateResult, GroupEntity>().ReverseMap();
            CreateMap<GroupDtoUpdateResult, GroupEntity>().ReverseMap();
            CreateMap<GroupOfflinemapsDto, GroupEntity>().ReverseMap();

            //user
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();

            //basemap
            CreateMap<BasemapDto, BasemapEntity>().ReverseMap();
            CreateMap<BasemapDtoCreateResult, BasemapEntity>().ReverseMap();
            CreateMap<BasemapDtoUpdateResult, BasemapEntity>().ReverseMap();

            //offline
            CreateMap<OfflinemapDto, OfflinemapEntity>().ReverseMap();
            CreateMap<OfflinemapDtoCreateResult, OfflinemapEntity>().ReverseMap();
            CreateMap<OfflinemapDtoUpdateResult, OfflinemapEntity>().ReverseMap();
            CreateMap<OfflinemapDtoPendingResult, OfflinemapEntity>().ReverseMap();

            //EventType
            CreateMap<EventTypeDto, EventTypeEntity>().ReverseMap();
            CreateMap<EventTypeDtoCreateResult, EventTypeEntity>().ReverseMap();
            CreateMap<EventTypeDtoUpdateResult, EventTypeEntity>().ReverseMap();

            //EventAlias
            CreateMap<EventAliasDto, EventAliasEntity>().ReverseMap();
            CreateMap<EventAliasDtoCreateResult, EventAliasEntity>().ReverseMap();
            CreateMap<EventAliasDtoUpdateResult, EventAliasEntity>().ReverseMap();

        }
    }
}
