using CandidateTesting.MatheusBauabBressan.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CandidateTesting.MatheusBauabBressan
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                    throw new ArgumentException("Invalid Arguments. Ex: converter.exe [minhaCDN log URL] [file output path]");
                else
                    new Converter().Convert(args[0], args[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: { ex.Message }");
            }
        }
    }
}
