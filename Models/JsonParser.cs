using Newtonsoft.Json;

namespace API2.Models
{
    public static class JsonParser
    {
        public static List<DataObject> Parse(string jsonData)
        {
            List<DataObject> dataList = JsonConvert.DeserializeObject<List<DataObject>>(jsonData);
            return dataList;
        }
    }
}
