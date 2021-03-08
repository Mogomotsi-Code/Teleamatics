using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using SighthingData.Models;

namespace SightingData.Api.Controllers
{
    [ApiController]
    [EnableCors( origins: "*", headers: "*", methods: "*")]
    [Route("[controller]")]
    public class DeviceStatsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Device> Get()
        {
            var deviceData = ReadCsvFile();
            return deviceData;
        }


        #region Private Methods
        private  List<Device> ReadCsvFile()
        {
            try
            {

                var deviceData = new List<Device>();
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DataFiles\*.csv");
                var files = Directory.GetFiles(@"DataFiles");
                foreach (var file in files)
                {
                    using (var csvParser = new TextFieldParser(file))
                    {
                        csvParser.SetDelimiters(new string[] { "," });
                        csvParser.HasFieldsEnclosedInQuotes = false;

                        // Skip the row with the column names
                        csvParser.ReadLine();

                        while (!csvParser.EndOfData)
                        {
                            // Read current line fields, pointer moves to the next line.
                            string[] fields = csvParser.ReadFields();
                            string Name = fields[0];
                            string Address = fields[1];
                            var device = new Device()
                            {
                                Servertime = DateTime.Parse(fields[0]),
                                PhoneTime = DateTime.Parse(fields[1]),
                                DeviceId = fields[2],
                                Lat = fields[3],
                                Lon = fields[4],
                                Acc = fields[5],
                                Speed = fields[6],
                                Ts = fields[7]
                            };
                            deviceData.Add(device);
                        }
                    }
                }

                return deviceData;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
    }
}
