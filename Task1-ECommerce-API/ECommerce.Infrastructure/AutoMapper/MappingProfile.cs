using AutoMapper;
using ECommerce.Application.DTOs.Customer;
using ECommerce.Application.DTOs.Product;
using ECommerce.Domain.Entities;
using System.Linq.Expressions;

namespace ECommerce.Infrastructure.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //product
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductUpdateDTO>();
            CreateMap<Product, ProductRemoveDTO>();

            //customer
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();



        }
    }
}
