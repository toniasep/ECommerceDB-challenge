using AutoMapper;
using ECommerceDB.Controllers.Responses;
using ECommerceDB.Models.Entities;
using ECommerceDB.Models.Paginations;

namespace ECommerceDB.Models.Factories;

public static class ProductFactory
{
    public static PagingOutput<ProductListResponse> MakeWithPaginate(
        PagedList<ProductEntity> model,
        PagingConfig paging
        )
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ProductEntity, ProductListResponse>()
                .ForMember(
                    dest => dest.Categories,
                    opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.Category.Name).ToList())
                );
        });
        var mapper = config.CreateMapper();

        return new PagingOutput<ProductListResponse>
        {
            Paging = paging.Paging,
            Items = mapper.Map<List<ProductListResponse>>(model.Items)
        };
    }


}