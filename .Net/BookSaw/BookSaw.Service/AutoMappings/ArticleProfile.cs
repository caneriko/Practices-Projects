using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSaw.Core.ViewModels.Article;
using BookSaw.Core.Entities;

namespace ArticleSaw.Service.AutoMappings
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleAddViewModel>().ReverseMap();
            CreateMap<Article, ArticleViewModel>().ReverseMap();
            CreateMap<Article, ArticleUpdateViewModel>().ReverseMap();
            CreateMap<Article, ArticleListViewModel>().ReverseMap();
        }
    }
}
