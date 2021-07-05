using Newtonsoft.Json.Linq;

namespace AHpx.Extensions.StringExtensions
{
    public static class StringConverter
    {
        public static JObject ToJObject(this string s)
        {
            s = s.IsNotNullOrEmptyThrow("A null or empty string can't be convert to json!")
                .IsJsonStringOrThrow("Incoming string is not a valid json string!");
            
            return JObject.Parse(s);
        }
    }
}