﻿namespace Showcase.Server.DataTransferModels.Project
{
    using AutoMapper;
    using MissingFeatures;

    using Showcase.Data.Models;
    using Showcase.Server.Common.Mapping;

    public class PostProjectResponseModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string TitleUrl { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, PostProjectResponseModel>()
                .ForMember(p => p.TitleUrl, opt => opt.MapFrom(p => p.Title.ToUrl()));
        }
    }
}