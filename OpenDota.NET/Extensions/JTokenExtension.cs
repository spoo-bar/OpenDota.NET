using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Extensions
{
    public static class JTokenExtension
    {
        /// <summary>
		/// Gets the <see cref="T:Newtonsoft.Json.Linq.JToken" /> with the specified key converted to the specified type.
		/// </summary>
		/// <typeparam name="T">The type to convert the token to.</typeparam>
		/// <param name="key">The token key.</param>
		/// <returns>The converted token value.</returns>
		public static T Value<T>(this JToken json, string key, T defaultValue)
        {
            var valueObj = json[key];
            if (valueObj == null) return defaultValue;
            if (valueObj.Type == JTokenType.Null) return defaultValue;
            if (defaultValue.GetType().IsEnum) return GetEnumValue(valueObj, defaultValue);
            if (valueObj.Value<T>() == null) return defaultValue;

            return json.Value<T>(key);
        }

        private static T GetEnumValue<T>(JToken valueObj, T defaultValue)
        {
            if (valueObj.Value<int?>() == null) return defaultValue;
            var enumValue = valueObj.Value<int>();
            return (T)Enum.ToObject(defaultValue.GetType(), enumValue);
        }
    }
}
