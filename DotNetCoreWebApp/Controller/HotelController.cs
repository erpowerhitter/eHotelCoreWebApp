using DotNetCore.Data.Abstract;
using DotNetCore.Domain.Domain.Model;
using eService.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp.Controller
{
    [Route("api/Hotel")]
    public class HotelController : BaseController
    {
        private readonly IHotelRepository _iHotelRepository;

        public HotelController(IHotelRepository iHotelRepository)
        {
            _iHotelRepository = iHotelRepository;
        }

        //For getting list of hotels with search criteria if any
        [HttpGet]       
        public IActionResult GetAllHotelList(SearchModel searchModel)
        {
           
            if (!User.Identity.IsAuthenticated)
            {
                //Application logic if any
                return null;
            }
               
            try
            {
                var response = _iHotelRepository.SelectAllGetAllHotelList(searchModel);
                return Ok(CommonResponse.CreateSuccessResponse("success", response));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //For Particular hotel detail
        [HttpGet]
        public IActionResult ViewHotelDetailsById(long hotelId)
        {

            if (!User.Identity.IsAuthenticated)
            {
                //Application logic if any
                return null;
            }
            try
            {
                var response = _iHotelRepository.GetHotelDetailsById(hotelId);
                return Ok(CommonResponse.CreateSuccessResponse("success", response));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult SaveBooking(HotelModel model)
        {

            if (!User.Identity.IsAuthenticated)
            {
                //Application logic if any
                return null;
            }
            try
            {
                var response = _iHotelRepository.SaveBooking(model);
                return Ok(CommonResponse.CreateSuccessResponse("success", response));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
