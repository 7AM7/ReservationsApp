using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AM7HackkthonAppService.DataObjects
{
    public class Reservations : EntityData
    {
        public string Name { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string Status { get; set; }
        public bool Done { get; set; }
    }
}