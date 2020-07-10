using CandidateTesting.MatheusBauabBressan.Adapters;
using CandidateTesting.MatheusBauabBressan.AppCode;
using CandidateTesting.MatheusBauabBressan.Models;
using System;
using System.IO;
using System.Text;

namespace CandidateTesting.MatheusBauabBressan.AppCode
{
    public class Converter
    {
        private string MinhaCdnLog { get; set; }
        private string AgoraLog { get; set; }
        private CastToAgora Caster { get; set; } = new CastToAgora();

        public void Convert(string url, string outputPath)
        {
            //get MinhaCDN log
            MinhaCdnLog = new MinhaCDN().GetLog(url).GetAwaiter().GetResult();

            if (!string.IsNullOrEmpty(MinhaCdnLog))
            {
                //cast to Agora format log
                AgoraLog = Caster.MinhaCDNToAgora(MinhaCdnLog);
            }
            //Write into file .txt
            File.WriteAllText(outputPath, AgoraLog);
        }
    }
}
