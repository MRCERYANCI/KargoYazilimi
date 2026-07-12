using AutoMapper;
using KargoYazilimi.TransportMongoDb.Dtos.AboutDtos;
using KargoYazilimi.TransportMongoDb.Dtos.BranchDtos;
using KargoYazilimi.TransportMongoDb.Dtos.BrandDtos;
using KargoYazilimi.TransportMongoDb.Dtos.CareerApplicationDtos;
using KargoYazilimi.TransportMongoDb.Dtos.GetInTouchSectionDtos;
using KargoYazilimi.TransportMongoDb.Dtos.HowItWorkDtos;
using KargoYazilimi.TransportMongoDb.Dtos.OfferDtos;
using KargoYazilimi.TransportMongoDb.Dtos.ProjectSectionDtos;
using KargoYazilimi.TransportMongoDb.Dtos.QuestionDtos;
using KargoYazilimi.TransportMongoDb.Dtos.ShipmentDtos;
using KargoYazilimi.TransportMongoDb.Dtos.ShipmentMovementDtos;
using KargoYazilimi.TransportMongoDb.Dtos.SliderDtos;
using KargoYazilimi.TransportMongoDb.Dtos.TestimonialDtos;
using KargoYazilimi.TransportMongoDb.Entities;

namespace KargoYazilimi.TransportMongoDb.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            CreateMap<Slider, GetSldierByIdDto>().ReverseMap();


            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, GetBrandByIdDto>().ReverseMap();

            CreateMap<Offer, ResultOfferDto>().ReverseMap();
            CreateMap<Offer, CreateOfferDto>().ReverseMap();
            CreateMap<Offer, UpdateOfferDto>().ReverseMap();
            CreateMap<Offer, GetOfferByIdDto>().ReverseMap();


            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutByIdDto>().ReverseMap();

            CreateMap<GetInTouchSection, ResultGetInTouchSectionDto>().ReverseMap();
            CreateMap<GetInTouchSection, CreateGetInTouchSectionDto>().ReverseMap();
            CreateMap<GetInTouchSection, UpdateGetInTouchSectionDto>().ReverseMap();
            CreateMap<GetInTouchSection, GetGetInTouchSectionByIdDto>().ReverseMap();

            CreateMap<CareerApplication, ResultCareerApplicationDto>().ReverseMap();
            CreateMap<CareerApplication, CreateCareerApplicationDto>().ReverseMap();
            CreateMap<CareerApplication, UpdateCareerApplicationDto>().ReverseMap();
            CreateMap<CareerApplication, GetCareerApplicationByIdDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdDto>().ReverseMap();

            CreateMap<HowItWork, ResultHowItWorkDto>().ReverseMap();
            CreateMap<HowItWork, CreateHowItWorkDto>().ReverseMap();
            CreateMap<HowItWork, UpdateHowItWorkDto>().ReverseMap();
            CreateMap<HowItWork, GetHowItWorkByIdDto>().ReverseMap();

            CreateMap<Question, ResultQuestionDto>().ReverseMap();
            CreateMap<Question, CreateQuestionDto>().ReverseMap();
            CreateMap<Question, UpdateQuestionDto>().ReverseMap();
            CreateMap<Question, GetQuestionByIdDto>().ReverseMap();

            CreateMap<ProjectSection, ResultProjectSectionDto>().ReverseMap();
            CreateMap<ProjectSection, CreateProjectSectionDto>().ReverseMap();
            CreateMap<ProjectSection, UpdateProjectSectionDto>().ReverseMap();
            CreateMap<ProjectSection, GetProjectSectionByIdDto>().ReverseMap();
            CreateMap<ProjectSection, GetProjectSectionBySlugDto>().ReverseMap();

            CreateMap<Branch, ResultBranchDto>().ReverseMap();
            CreateMap<Branch, CreateBranchDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
            CreateMap<Branch, GetBranchByIdDto>().ReverseMap();

            CreateMap<Shipment, CreateShipmentDto>().ReverseMap();
            CreateMap<Shipment, ResultShipmentDto>().ReverseMap();
            CreateMap<Shipment, UpdateShipmentDto>().ReverseMap();
            CreateMap<Shipment, GetShipmentByIdDto>().ReverseMap();

            CreateMap<ShipmentMovement, CreateShipmentMovementDto>().ReverseMap();
            CreateMap<ShipmentMovement, ResultShipmentMovementDto>().ReverseMap();

            CreateMap<GetShipmentByIdDto, UpdateShipmentDto>().ReverseMap();
        }
    }
}
