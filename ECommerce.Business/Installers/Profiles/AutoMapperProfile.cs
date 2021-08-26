using AutoMapper;
using ECommerce.Business.Model;
using eCommerce.DataAccess.Entities;

namespace ECommerce.Business.Installers.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Account, AccountsDto>()
                .ForMember(a => a.UserGroup, u => u.MapFrom(a => a.UserGroup.Description))
                .ForMember(a => a.Gender, g => g.MapFrom(a => a.Gender.Description))
                .ForMember(a => a.Role, r => r.MapFrom(a => a.Role.Description));
            
            CreateMap<AccountAddress, AccountAddressDto>().ReverseMap();
            CreateMap<AccountAddress, AccountAddressesDto>()
                .ForMember(a => a.Account, u => u.MapFrom(a => $"{a.Account.FirstName} {a.Account.LastName}"));
                
            
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, BrandsDto>();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoriesDto>()
                .ForMember(c => c.Parent, p => p.MapFrom(c => c.Parent.Name));
            
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CitiesDto>()
                .ForMember(c => c.Country, x => x.MapFrom(c => c.Country.Name));
            
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountriesDto>();
            
            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<Currency, CurrenciesDto>();
            
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<District, DistrictsDto>()
                .ForMember(d => d.City, c => c.MapFrom(d => d.City.Name));
             
            CreateMap<ExchangeRateHistory, ExchangeRateHistoryDto>().ReverseMap();
            CreateMap<ExchangeRateHistory, ExchangeRateHistoriesDto>()
                .ForMember(e => e.Currency, c => c.MapFrom(e => e.Currency.CurrencyCode));
            
            CreateMap<FavoriteProduct, FavoriteProductDto>().ReverseMap();
            CreateMap<FavoriteProduct, FavoriteProductsDto>()
                .ForMember(f => f.Account, a => a.MapFrom(f => $"{f.Account.FirstName} {f.Account.LastName}"))
                .ForMember(f => f.Product, p => p.MapFrom(f => f.Product.Description));
             
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Gender, GendersDto>();
            
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductsDto>()
                .ForMember(p => p.Currency, c => c.MapFrom(p => p.Currency.Symbol))
                .ForMember(p => p.Brand, b => b.MapFrom(p => p.Brand.Description))
                .ForMember(p => p.Category, c => c.MapFrom(p => p.Category.Name));
             
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupsDto>();
            
            CreateMap<ProductGroupLine, ProductGroupLineDto>().ReverseMap();
            CreateMap<ProductGroupLine, ProductGroupLinesDto>()
                .ForMember(l => l.Product, p => p.MapFrom(l => l.Product.Description))
                .ForMember(l => l.ProductGroup, g => g.MapFrom(l => l.ProductGroup.Description));
            
            CreateMap<RelatedProduct, RelatedProductDto>().ReverseMap();
            CreateMap<RelatedProduct, RelatedProductsDto>()
                .ForMember(r => r.Product, p => p.MapFrom(r => r.Product.Description))
                .ForMember(r => r.RelevantProduct, p => p.MapFrom(r => r.RelevantProduct.Description));
            
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, RolesDto>();
            
            CreateMap<Rule, RuleDto>().ReverseMap();
            CreateMap<Rule, RulesDto>()
                .ForMember(r => r.Role, x => x.MapFrom(r => r.Role.Description));
            
            CreateMap<Setting, SettingDto>().ReverseMap();
            CreateMap<Setting, SettingsDto>();
            
            CreateMap<UserGroup, UserGroupDto>().ReverseMap();
            CreateMap<UserGroup, UserGroupsDto>();

        }
    }
}