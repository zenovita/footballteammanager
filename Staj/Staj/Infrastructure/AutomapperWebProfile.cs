using Staj.Domain;
using Staj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.Infrastructure
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {


            CreateMap<TeamDomainModel, TeamViewModel>();
            CreateMap<TeamViewModel, TeamDomainModel>();

        }

        public static void Run()
        {


            AutoMapper.Mapper.Initialize(a => { a.AddProfile<AutomapperWebProfile>(); });
        }



    }
}