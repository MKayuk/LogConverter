using CandidateTesting.MatheusBauabBressan.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.MatheusBauabBressan.Adapters
{
    public class CastToAgora
    {
        public string MinhaCDNToAgora(string log)
        {
            List<AgoraLog> loglist = new List<AgoraLog>();

            using (var reader = new StringReader(log))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    // pattern from minhaCDN 312|200|HIT|"GET /robots.txt HTTP/1.1"|100.2
                    var splitted = line.Split('|');

                    var obj = new AgoraLog()
                    {
                        provider = "MINHA CDN",
                        responsesize = splitted[0],
                        statuscode = splitted[1],
                        cachestatus = splitted[2],
                        timetaken = splitted[4]
                    };

                    int indexSep = splitted[3].IndexOf('/');

                    obj.httpmethod = splitted[3].Substring(1, indexSep - 1);
                    obj.uripath = splitted[3].Substring(indexSep, splitted[3].IndexOf("HTTP") - indexSep);

                    loglist.Add(obj);
                }
            }

            string returnText = $@"#Version: 1.0
#Date: {DateTime.Now:dd/MM/yyyy hh:mm:ss}
#Fields: provider http-method status-code uri-path time-taken
response-size cache-status
";

            //pattern for Agora "MINHA CDN" GET 200 /robots.txt 100 312 HIT
            foreach (var log1 in loglist)
            {
                returnText += $"\"{log1.provider}\" {log1.httpmethod} {log1.statuscode} {log1.uripath} {log1.timetaken} {log1.responsesize} {log1.cachestatus} \n";
            }

            return returnText;
        }
    }
}
