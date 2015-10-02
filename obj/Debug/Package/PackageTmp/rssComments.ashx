<%@ WebHandler Language="C#" Class="rssComments" %>

using System;
using System.Web;
using System.Collections.Generic;

public class rssComments : CommentsHttpHandlerBase
{
    protected override void PopulateChannel(string channelName, string userName)
    {
        CommentsItem commentItem;
        Dictionary<string, string> commentNode;
        List<Dictionary<string, string>> commentNodes;
        DateTime dateTime;
        string articleId = "0", title;
        
        try
        {
            // channel name should contains id of article
            if (string.IsNullOrEmpty(channelName))
                throw new Exception("channelName is null");

            if (!string.IsNullOrEmpty(channelName))
                articleId = channelName.Replace("comments for article #", "");

            Channel.Title = "Comments for " + TihBlogCompact.Business.Articles.GetArticleTitle(articleId);
            Channel.User = userName;

            // get comments
            commentNodes = TihBlogCompact.Business.TBRssManager.GetCommentsForRss(articleId);      

            // fill channel with all comments
            if (commentNodes != null && commentNodes.Count > 0)
            {
                for (int i = 0; i < commentNodes.Count; ++i)
                {
                    commentNode = commentNodes[i];

                    string names = "", published = "", comment = "";
                    commentNode.TryGetValue("names", out names);
                    commentNode.TryGetValue("published", out published);
                    commentNode.TryGetValue("Comment", out comment);

                    if (DateTime.TryParse(published, out dateTime))
                        title = "Posted By " + names + " on " + dateTime.ToString("dd MMMM yyyy HH:mm");
                    else
                        title = "Posted By " + names;

                    commentItem = new CommentsItem(title, comment, "~/Article.aspx?articleId=" + channelName + "&comments=true");
                    Channel.Items.Add(commentItem);
                }
            }
        }
        catch (Exception)
        {
        }
    }
}
