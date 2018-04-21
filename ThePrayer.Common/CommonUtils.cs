using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ThePrayer.Common
{

    public static class CommonUtils
    {

        public static T DeserializeJsonFile<T>(string filePath)
        {
            var content = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static void DeserializeJsonFile(string filePath, object populatingObject)
        {
            var content = File.ReadAllText(filePath);
            JsonConvert.PopulateObject(content, populatingObject);
        }

    }

}
