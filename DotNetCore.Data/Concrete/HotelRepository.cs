using Dapper;
using DotNetCore.Data.Abstract;
using DotNetCore.Domain.Domain.Model;
using eService.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore.Data.Concrete
{
   public class HotelRepository : IHotelRepository
    {
        private bool disposedValue;

        //Listing will bring based on the search filter if any else based on the page size
        public async Task<HotelModel> SelectAllGetAllHotelList(SearchModel searchModel)
        {
            var hotelModel = new HotelModel();
            hotelModel.LstHotelModel = new List<HotelModel>();
            try
            {
                using(var connection= RepositoryFactory.getConnection())
                {
                    SqlMapper.GridReader xModel;
                    string spName = "usp_GetAllHotelList";

                    xModel = await connection.QueryMultipleAsync("", new
                    {
                        pageNumber=searchModel.PageNumber,
                        sortField = searchModel.SortField,
                        sortOrder = searchModel.SortOrder,
                        status = searchModel.Status,
                        searchKeyword = searchModel.SearchKeyword,
                        fromDate = searchModel.FromDate,
                        toDate = searchModel.ToDate,


                    }, commandType: CommandType.StoredProcedure);
                    hotelModel = xModel.Read<HotelModel>().First();
                    hotelModel.LstHotelModel = xModel.Read<HotelModel>().ToList();
                    hotelModel.LstAttachmentModel = xModel.Read<AttachmentModel>().ToList();
                    hotelModel.LstPricingModel = xModel.Read<PricingModel>().ToList();
                    hotelModel.LstFacilityModel = xModel.Read<FacilityModel>().ToList();
                    hotelModel.LstSearchModel = xModel.Read<SearchModel>().ToList();

                    return hotelModel;

                }
            }
            catch (Exception ex)
            {
                return hotelModel;
            }
        }

        //Getting hotel details by id
        public async Task<HotelModel> GetHotelDetailsById(long Id)
        {
            var hotelModel = new HotelModel();
            hotelModel.LstHotelModel = new List<HotelModel>();
            try
            {
                using (var connection = RepositoryFactory.getConnection())
                {
                    SqlMapper.GridReader xModel;
                    string spName = "usp_GetHotelDetailsById";

                    xModel = await connection.QueryMultipleAsync("", new
                    {
                        id = Id

                    }, commandType: CommandType.StoredProcedure);
                    hotelModel = xModel.Read<HotelModel>().First();
                    hotelModel.AttachmentModel = xModel.Read<AttachmentModel>().FirstOrDefault();
                    hotelModel.PricingModel = xModel.Read<PricingModel>().FirstOrDefault();
                    hotelModel.FacilityModel = xModel.Read<FacilityModel>().FirstOrDefault();
                    hotelModel.SearchModel = xModel.Read<SearchModel>().FirstOrDefault();
                    return hotelModel;

                }
            }
            catch (Exception ex)
            {
                return hotelModel;
            }
        }

        public async Task<HotelModel> SaveBooking(HotelModel model)
        {
            var hotelModel = new HotelModel();
            hotelModel.LstHotelModel = new List<HotelModel>();
            try
            {
                using (var connection = RepositoryFactory.getConnection())
                {
                    SqlMapper.GridReader xModel;
                    string spName = "usp_SaveBooking";

                    xModel = await connection.QueryMultipleAsync("", new
                    {
                        //ALL Input variable needs to pass to sp for saving the booking

                    }, commandType: CommandType.StoredProcedure);
                    hotelModel = xModel.Read<HotelModel>().First();
                    return hotelModel;

                }
            }
            catch (Exception ex)
            {
                return hotelModel;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~HotelRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
