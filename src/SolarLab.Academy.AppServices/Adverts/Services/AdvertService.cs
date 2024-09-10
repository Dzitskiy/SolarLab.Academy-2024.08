using SolarLab.Academy.AppServices.Adverts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.AppServices.Adverts.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;

        public AdvertService(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }
    }
}
