using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GestaoJogos.Domain.Commons
{
    public static class Extensions
    {
        public static string ToText(this object value)
        {
            return value != null ? value.ToString() : string.Empty;
        }

        public static int ToInt(this object value)
        {
            return string.IsNullOrEmpty(value.ToText()) ? 0 : int.Parse(value.ToText());
        }

        public static decimal ToDecimal(this object value)
        {
            return value != null && value.ToText() != "" ? decimal.Parse(value.ToText()) : 0M;
        }

        public static bool ToBool(this object value)
        {
            return value != null && bool.TryParse(value.ToText(), out var valueBool) ? valueBool : value.ToInt() == 1;
        }

        public static string OnlyNumbers(this string text)
        {
            var regex = new Regex(@"\d+");
            return regex.Matches(text).Aggregate("", (current, m) => current + m.Value);
        }

        public static List<string> StringToList(this string text)
        {
            return new List<string> {text};
        }
    }
}