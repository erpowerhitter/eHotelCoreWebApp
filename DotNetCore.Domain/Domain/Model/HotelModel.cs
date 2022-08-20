using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Domain.Domain.Model
{
   public class HotelModel
    {
        //Different properties like
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Desc { get; set; }
        public string Location { get; set; }

        public AttachmentModel AttachmentModel { get; set; }
        public PricingModel PricingModel { get; set; }
        public FacilityModel FacilityModel { get; set; }
        public SearchModel SearchModel { get; set; }

        public List<HotelModel> LstHotelModel { get; set; }

        public List<AttachmentModel> LstAttachmentModel { get; set; }
        public List<PricingModel> LstPricingModel { get; set; }
        public List<FacilityModel> LstFacilityModel { get; set; }
        public List<SearchModel> LstSearchModel { get; set; }
    }
}
