using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Entities;
using Victory.Core.ViewModels.Article;

namespace Victory.Service.Mapping
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleListViewModel>().ReverseMap();
            CreateMap<Article, ArticleBlogViewModel>().ReverseMap();
            CreateMap<Article, UpdateArticleViewModel>().ReverseMap();
            CreateMap<Article, AddArticleViewModel>().ReverseMap();
        }
    }
}
