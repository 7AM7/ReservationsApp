using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3.Models
{
    public class Reservations
    {
        bool a = true;
        public int Id { get; set; }
        public string Name { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public string Status { get; set; }
        public bool Done { get { return a; } set { a=value; } }


        //string _id;
        //string _name;
        //string _timefrom;
        //string _timeto;
        //bool _done;

        //[JsonProperty(PropertyName = "id")]
        //public string ID
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}

        //[JsonProperty(PropertyName = "Name")]
        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}

        //[JsonProperty(PropertyName = "TimeFrom")]
        //public string TimeFrom
        //{
        //    get { return _timefrom; }
        //    set { _timefrom = value; }
        //}

        //[JsonProperty(PropertyName = "TimeTo")]
        //public string TimeTo
        //{
        //    get { return _timeto; }
        //    set { _timeto = value; }
        //}
        //[JsonProperty(PropertyName = "done")]
        //public bool Done
        //{
        //    get { return _done; }
        //    set { _done = value; }
        //}
    }
}
