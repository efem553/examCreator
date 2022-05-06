using examCreator.Models;
using HtmlAgilityPack;
using System.Net;

namespace examCreator.Utility
{
    public class NewsFetcher
    {

        public List<NewsContent> GetLastFive()
        {
            HtmlWeb wired = new HtmlWeb();
            HtmlDocument page = new HtmlDocument();
            page =wired.Load("https://www.wired.com/");
            List<NewsContent> newsList = new List<NewsContent>();
            IEnumerable<HtmlNode> newsDiv = page.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "") == "summary-list__items").Last().Descendants("div").Where(node => node.GetAttributeValue("data-section-title", "").StartsWith("hero collage/right rail "));
            IEnumerable<HtmlNode> newsContent;
            IEnumerable<HtmlNode> newsHeader;
            List<string> NewsUrls = new List<string>();
            foreach(HtmlNode item in newsDiv)
                {
                
                NewsUrls.Add(item.ChildNodes[1].ChildNodes[0].Attributes[3].Value);

            }
            var i = 0;
            foreach (string item in NewsUrls)
            {
                page = wired.Load("https://www.wired.com"+item);
                var head = page.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("data-testid", "") == "ContentHeaderTitleBlockWrapper").First().ChildNodes[1].InnerText;
                var text = page.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "") == "body__inner-container").First().ChildNodes[0].InnerText;
                var url = item.Split("/").Last();
                newsList.Add(new NewsContent
                {
                    Header = head,
                    Content = text,
                    NewsUrl = url
                });
                i++;
                if (i==5)
                {
                    break;
                }
            }

            return newsList;
        }
    }
    
}
