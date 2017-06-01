using System;
using System.Net;

namespace SRT_editor
{
    class Translate
    {
        private const String apikey = "trnsl.1.1.20170523T163434Z.71957655b8b0b6d3.4009c85236d8ec35e0d3f43e79476125c966e394";
        private Language startlanguage;
        private Language translatelanguage;
        public Translate(Language lngfrom, Language lngto)
        {
            startlanguage = lngfrom;
            translatelanguage = lngto;
        }

        public String getResult(String texttotranslate)
        {
            String site = "https://translate.yandex.net/api/v1.5/tr.json/translate?lang="+ startlanguage +"-"+ translatelanguage +"&text="+ texttotranslate +"&key=" + apikey;
            WebClient webclient = new WebClient();
            String result = webclient.DownloadString(site);
            // "{\"code\":200,\"lang\":\"nl-en\",\"text\":[\"Earlier in Bates Motel.\"]}"
            int startingpoint = result.IndexOf(":[\"") + 3;
            int endpoint = result.IndexOf("\"]}");
            int length = endpoint - startingpoint;
            result = GetTextBetween(result, startingpoint, length);
            return result;
        }

        private String GetTextBetween(String source, int start, int length)
        {
            return source.Substring(start,length);
        }
    }
}
