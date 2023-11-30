﻿using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Articles.Queries.GetArticlesWithPagination;

public class ArticleDto
{
    public int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Article, ArticleDto>();
        }
    }
}
