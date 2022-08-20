using DotNetCore.Domain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore.Data.Abstract
{
    public interface IHotelRepository : IDisposable
    {
       Task<HotelModel> SelectAllGetAllHotelList(SearchModel searchModel);

        Task<HotelModel> GetHotelDetailsById(long Id);

        Task<HotelModel> SaveBooking(HotelModel searchModel);

    }
}
