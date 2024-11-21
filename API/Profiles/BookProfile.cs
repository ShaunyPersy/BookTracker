using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles {
    class BookProfile : Profile{
        public BookProfile(){
            CreateMap<Book, BookReadDto>();
            CreateMap<Book, BookWriteDto>();
            CreateMap<Book, BookUpdateDto>();
        }
    }
}