using System.Collections.Generic;
using System.Text;

namespace ScheduleBukepAPI.helpers
{
    /// <summary>
    /// ������ Url ������ ��� Api.
    /// </summary>
    public static class CreatorUrl
    {
        private const string UrlApi = "https://my.bukep.ru:447/api/Schedule";

        /// <summary>
        /// ������� Url ��� Api � �����������.
        /// </summary>
        /// <param name="nameMethod">��� ������ ��� Api</param>
        /// <param name="parameter">���������</param>
        /// <returns></returns>
        public static string CreateUrl(string nameMethod, IDictionary<string, string> parameter)
        {
            var urlParameter = CreateUrlParameter(parameter);
            var url = $"{UrlApi}/{nameMethod}?{urlParameter}";
            return url;
        }

        private static string CreateUrlParameter(IDictionary<string, string> parameters)
        {
            var urlParameter = new StringBuilder();
            foreach (var name in parameters.Keys)
            {
                var value = parameters[name];
                urlParameter.AppendFormat("{0}={1}&", name, value);
            }
            return urlParameter.ToString();
        }
    }
}