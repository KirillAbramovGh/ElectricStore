using AutoMapper;
using ElectricStore.Dtos;
using ElectricStore.Models;

namespace ElectricStore.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Company, CompanyDTO>();
        }
    }
}