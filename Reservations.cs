using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AM7HackthoonaService.DataObjects
{
    public class Reservations : EntityData
    {
        public string Name { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string Stauts{ get; set; }
        public string UserId { get; set; }

    }
}