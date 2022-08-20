using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Domain.Domain.Model
{
    public class SearchModel
    {
        public int PageNumber { get; set; }
        public string SortField { get; set; }
        public string SortOrder { get; set; }
        public string Status { get; set; }
        public string SearchKeyword { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
}
