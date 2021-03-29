using System;
using AutoMapper;
using MyTodoApp_ISG.Model;
using MyTodoApp_ISG.ViewModel;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Todo, TodoAddViewModel>().ReverseMap();
        CreateMap<Todo, TodoUpdateViewModel>().ReverseMap();
    }
}
