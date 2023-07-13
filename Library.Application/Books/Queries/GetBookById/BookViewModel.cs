//using AutoMapper;
//using Library.Application.Common.Mapping;
//using Library.Domain;
//using MediatR;

//namespace Library.Application.Books.Queries.GetBookById;

//public class BookViewModel : IMapWith<Book>
//{
//    public Guid Id { get; set; }
//    public string ISBN { get; set; } = null!;
//    public string Name { get; set; } = null!;
//    public string Genre { get; set; } = null!;
//    public string Description { get; set; } = null!;
//    public string Author { get; set; } = null!;
//    public DateTime RentStart { get; set; }
//    public DateTime RentEnd { get; set; }

//    public void Mapping(Profile profile)
//    {
//        profile.CreateMap<Book, BookViewModel>()
//            .ForMember(bookVm => bookVm.ISBN,
//            vm => vm.MapFrom(book => book.ISBN))
//            .ForMember(bookVm => bookVm.Name,
//            vm => vm.MapFrom(book => book.Name))
//            .ForMember(bookVm => bookVm.Genre,
//            vm => vm.MapFrom(book => book.Genre))
//            .ForMember(bookVm => bookVm.Description,
//            vm => vm.MapFrom(book => book.Description))
//            .ForMember(bookVm => bookVm.Author,
//            vm => vm.MapFrom(book => book.Author))
//            .ForMember(bookVm => bookVm.RentStart,
//            vm => vm.MapFrom(book => book.RentStart))
//            .ForMember(bookVm => bookVm.RentEnd,
//            vm => vm.MapFrom(book => book.RentEnd));
//    }
//}
