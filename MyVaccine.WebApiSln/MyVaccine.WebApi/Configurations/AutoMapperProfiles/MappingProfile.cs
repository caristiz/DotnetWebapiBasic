﻿using AutoMapper;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Dtos.Vaccine;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dependent, DependentRequestDto>().ReverseMap();
            CreateMap<Dependent, DependentResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DependentId)).ReverseMap();

            CreateMap<Allergy, AllergyRequestDto>().ReverseMap();
            CreateMap<Allergy, AllergyResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AllergyId)).ReverseMap();

            CreateMap<FamilyGroup, FamilyGroupRequestDto>().ReverseMap();
            CreateMap<FamilyGroup, FamilyGroupResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FamilyGroupId)).ReverseMap();

            CreateMap<Vaccine, VaccineRequestDto>().ReverseMap();
            CreateMap < Vaccine,VaccineResponseDto > ()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VaccineId)).ReverseMap();

        }


    }
}
