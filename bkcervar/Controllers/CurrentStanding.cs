using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace bkcervar.Controllers
{
    public class CurrentStanding{
        public static String Parse(){
            HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;

            string urlToLoad = "http://www.bocanje-ibs.hr/?idclanka=0&idlige=127";
            HttpWebRequest request = HttpWebRequest.Create(urlToLoad) as HttpWebRequest;
            request.Method = "GET";

            /* Sart browser signature */
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=0.5");
            /* Sart browser signature */

            Console.WriteLine(request.RequestUri.AbsoluteUri);
            WebResponse response = request.GetResponse();

            var articleNodeString = "";

            htmlDoc.Load(response.GetResponseStream(), true);

            var findclasses = htmlDoc.DocumentNode
                    .Descendants("table")
                    .Where(d =>
                        d.Attributes.Contains("class")
                            &&
                        d.Attributes["class"].Value.Contains("tablica")
                    );

            var htmlString = "";
            foreach(var v in findclasses)
            {
                htmlString += v.InnerHtml;
            }

            return htmlString;
           /* if (htmlDoc.DocumentNode != null)
            {
                var articleNodes = htmlDoc.DocumentNode.SelectNodes("/table/");
                if (articleNodes != null && articleNodes.Any())
                {
                    foreach (var articleNode in articleNodes)
                    {
                        articleNodeString += WebUtility.HtmlDecode(articleNode.InnerText.Trim());
                    }
                }
            }
            return articleNodeString;*/
        }
    }
}
    