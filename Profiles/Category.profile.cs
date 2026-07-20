using AutoMapper;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        // CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        CreateMap<ResCategoryDto, Category>().ReverseMap();
    }
}