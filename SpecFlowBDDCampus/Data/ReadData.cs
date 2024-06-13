using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDCampus.Data
{
    public class ReadData
    {
        public string file_name;
        public string jsonStr;
        public List<Client> clients;

        public List<Client> ReadDataFromJson()
        {
            file_name = @"C:\Users\PC\Desktop\SpecFlowBDDCampus (3)\SpecFlowBDDCampus\SpecFlowBDDCampus\Data\Data.json";

            using (StreamReader r = new StreamReader(file_name))
            {
                jsonStr = r.ReadToEnd();
                clients = JsonConvert.DeserializeObject<List<Client>>(jsonStr);
            }
            return clients;
        }
    }
}
