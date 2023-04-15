using Newtonsoft.Json;

namespace SAKIB_PORTFOLIO.Helper
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson<T>(this ISession session, string key, object? value)
        {
            try
            {
                string JsonString = JsonConvert.SerializeObject(value, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                session.SetString(key, JsonString);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static List<T>? GetObjectFromJsonList<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(List<T>) : JsonConvert.DeserializeObject<List<T>>(value);
        }
    }
}
