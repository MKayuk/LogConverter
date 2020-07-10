using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.MatheusBauabBressan.Models
{
    public class AgoraLog
    {
        public string provider { get; set; }
        public string httpmethod { get; set; }
        public string statuscode { get; set; }
        public string uripath { get; set; }
        public string timetaken { get; set; }
        public string responsesize { get; set; }
        public string cachestatus { get; set; }
    }
}
