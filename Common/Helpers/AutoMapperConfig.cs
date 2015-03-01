using System;

namespace Common.Helpers
{
    using AutoMapper;
    using Common.DataModels;
    using Common.Models;

    public static class AutoMapperConfig
    {
        public static void Configurar()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.AddProfile(new BasicProfile());
                });
        }
    }

    public class BasicProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "Mapeos Básicos";
            }
        }

        protected override void Configure()
        {
            // Mapeos para los usuarios.
            Mapper.CreateMap<UsrDTO, Usr>().ReverseMap();

            // Mapeos para las relaciones.
            Mapper.CreateMap<RelationDTO, Relation>();
            Mapper.CreateMap<Relation, RelationDTO>()
                .ForMember(dst => dst.FirstUserId, src => src.MapFrom(opt => opt.FirstUserId))
                .ForMember(dst => dst.FirstUserName, src => src.MapFrom(opt => opt.Usr.UserName))
                .ForMember(dst => dst.RelationId, src => src.MapFrom(opt => opt.RelationId))
                .ForMember(dst => dst.SecondUserId, src => src.MapFrom(opt => opt.SecondUserId))
                .ForMember(dst => dst.SecondUserName, src => src.MapFrom(opt => opt.Usr1.UserName));

            // Mapeos para las solicitudes.
            Mapper.CreateMap<RequestDTO, Request>()
                .ForMember(dst => dst.Accepted, opt => opt.MapFrom(src => src.Accepted))
                .ForMember(dst => dst.Finished, opt => opt.MapFrom(src => src.Finished))
                .ForMember(dst => dst.LatFirstUser, opt => opt.MapFrom(src => src.LatFirstUser))
                .ForMember(dst => dst.LatSecondUser, opt => opt.MapFrom(src => src.LatSecondUser))
                .ForMember(dst => dst.LngFirstUser, opt => opt.MapFrom(src => src.LngFirstUser))
                .ForMember(dst => dst.LngSecondUser, opt => opt.MapFrom(src => src.LngSecondUser))
                .ForMember(dst => dst.RelationId, opt => opt.MapFrom(src => src.RelationId))
                .ForMember(dst => dst.RequestId, opt => opt.MapFrom(src => Guid.Parse(src.RequestId)));
            Mapper.CreateMap<Request, RequestDTO>()
                .ForMember(dst => dst.Accepted, opt => opt.MapFrom(src => src.Accepted))
                .ForMember(dst => dst.Finished, opt => opt.MapFrom(src => src.Finished))
                .ForMember(dst => dst.FirstUserName, opt => opt.MapFrom(src => src.Relation.Usr.UserName))
                .ForMember(dst => dst.LatFirstUser, opt => opt.MapFrom(src => src.LatFirstUser))
                .ForMember(dst => dst.LatSecondUser, opt => opt.MapFrom(src => src.LatSecondUser))
                .ForMember(dst => dst.LngFirstUser, opt => opt.MapFrom(src => src.LngFirstUser))
                .ForMember(dst => dst.LngSecondUser, opt => opt.MapFrom(src => src.LngSecondUser))
                .ForMember(dst => dst.RelationId, opt => opt.MapFrom(src => src.RelationId))
                .ForMember(dst => dst.RequestId, opt => opt.MapFrom(src => src.RequestId.ToString()))
                .ForMember(dst => dst.SecondUserName, opt => opt.MapFrom(src => src.Relation.Usr1.UserName));
        }
    }
}
