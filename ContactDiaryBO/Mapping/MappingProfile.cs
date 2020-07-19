using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ContactDiaryDataAccess;

namespace ContactDiaryBO.Mapping
{
    public class MappingProfile
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.Contact, ContactDiaryDataAccess.Contact>();
                cfg.CreateMap<ContactDiaryDataAccess.Contact, Models.Contact>();

            });

            IMapper imapper = config.CreateMapper();
            return imapper;
        }
    }
}
