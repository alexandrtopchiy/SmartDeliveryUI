﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace SmartDeliveryAPI.Models
{
    public class PackageDataModel
    {
        
        public int package_data_ID { get; set; }
        public DateTime send_date { get; set; }
        public DateTime arrival_date { get; set; }
        public DateTime receive_date { get; set; }
        public string package_status { get; set; }
        public string descript { get; set; }
        public int weights { get; set; }
        public int volume { get; set; }
    }
}