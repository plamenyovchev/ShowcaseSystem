﻿namespace Showcase.Server.DataTransferModels.Project
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using MissingFeatures;

    using Newtonsoft.Json;

    using Showcase.Data.Models;
    using Showcase.Server.Common;
    using Showcase.Server.Common.Mapping;

    public class ProjectResponseModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public const int ShortDescriptionLength = 200;

        public int Id { get; set; }

        public string Name { get; set; }

        public string MainImageUrl { get; set; }

        public string Content { get; set; }

        public string RepositoryUrl { get; set; }

        public string LiveDemoUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Likes { get; set; }

        public int Visits { get; set; }

        public int Comments { get; set; }

        public IEnumerable<string> Collaborators { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }

        public IEnumerable<TagResponseModel> Tags { get; set; }

        public bool IsLiked { get; set; }

        public string TitleUrl
        {
            get
            {
                return this.Name.ToUrl();
            }
        }

        public string ShortDate
        {
            get
            {
                return this.CreatedOn.ToString(Constants.ShortDateFormat);
            }
        }

        public string ShortDescription 
        {
            get
            {
                if (this.Content.Length <= ProjectResponseModel.ShortDescriptionLength)
                {
                    return this.Content;
                }
                else
                {
                    return this.Content.Substring(0, ProjectResponseModel.ShortDescriptionLength) + "...";
                }
            }
        }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectResponseModel>()
                .ForMember(pr => pr.Name, opt => opt.MapFrom(pr => pr.Title))
                .ForMember(pr => pr.Likes, opt => opt.MapFrom(pr => pr.Likes.Count))
                .ForMember(pr => pr.Visits, opt => opt.MapFrom(pr => pr.Visits.Count))
                .ForMember(pr => pr.Comments, opt => opt.MapFrom(pr => pr.Comments.Count))
                .ForMember(pr => pr.MainImageUrl, opt => opt.MapFrom(pr => pr.MainImage.Url + "." + pr.MainImage.FileExtension))
                .ForMember(pr => pr.ImageUrls, opt => opt.MapFrom(pr => pr.Images.Select(i => i.Url + "." + i.FileExtension)))
                .ForMember(pr => pr.Collaborators, opt => opt.MapFrom(pr => pr.Collaborators.Select(c => c.Username).OrderBy(c => c)));
        }
    }
}