using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marija_Bozic_Dan_60.Service
{
    public static class ReadTxtFile
    {
        public static List<string> ReadLocationFromFile()
        {
            List<string> allLocations = new List<string>();
            string fileName = @"..\..\TXTFiles\Lokacije.txt";
            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader reader = File.OpenText(fileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] lineData = line.Split(',');
                            string locationName = lineData[0];
                            allLocations.Add(locationName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
            return allLocations;
        }
    }
}
