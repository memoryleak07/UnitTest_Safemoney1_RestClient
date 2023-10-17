using System.Collections.Generic;

namespace SafemoneyRestClient.Helpers
{
    public static class ObjectExtended
    {
        public static List<string> GetItemValue(this object obj)
        {
            var properties = obj.GetType().GetProperties();
            List<string> values = new List<string>();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                if (value != null)
                {
                    values.Add(value.ToString());
                }
                else
                {
                    values.Add("");
                }
            }
            return values;
        }
    }
}
