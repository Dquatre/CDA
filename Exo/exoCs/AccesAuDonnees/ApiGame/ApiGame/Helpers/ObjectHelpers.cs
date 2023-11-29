using Newtonsoft.Json;
using System.Diagnostics;

namespace ApiGame.Helpers
{
    static class ObjectHelpers
    {
        public static void Dump(this object data)
        {
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            Trace.WriteLine("");
            Trace.WriteLine(json);
        }
    }
}
