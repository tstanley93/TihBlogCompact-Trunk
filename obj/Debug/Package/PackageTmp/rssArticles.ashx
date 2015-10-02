<%@ WebHandler Language="C#" Class="rssArticles" %>

using System;
using System.Web;
using System.Collections.Generic;

public class rssArticles : ArticlesHttpHandlerBase
{
    protected override void PopulateChannel(string channelName, string userName)
    {
        ArticlesItem articleItem;
        Dictionary<string, string> articleNode;
        List<Dictionary<string, string>> articleNodes;
        
        try
        {
            Channel.Name = channelName;
            Channel.User = userName;

            if (!string.IsNullOrEmpty(channelName))
                Channel.Title += " '" + channelName + "'";

            if (!string.IsNullOrEmpty(userName))
                Channel.Title += " (generated for " + userName + ")";

            // get articles
            articleNodes = TihBlogCompact.Business.TBRssManager.GetArticlesForRss();

            // fill channel with all articles
            if (articleNodes != null && articleNodes.Count > 0)
            {
                for (int i = 0; i < articleNodes.Count; ++i)
                {
                    articleNode = articleNodes[i];

                    string id = "", title = "", content = "";
                    articleNode.TryGetValue("Title", out title);
                    articleNode.TryGetValue("Content", out content);
                    articleNode.TryGetValue("ID", out id);
                    
                    articleItem = new ArticlesItem(title, content, "~/Article.aspx?articleId=" + id);
                    Channel.Items.Add(articleItem);
                }
            }
        }
        catch (Exception)
        {
        }
    }
}
