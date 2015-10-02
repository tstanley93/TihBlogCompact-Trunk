using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Globalization;
using System.Web.Configuration;

namespace TihBlogCompact
{
    public class BasePage : System.Web.UI.Page
    {
        /// <SUMMARY>
        /// Overriding the InitializeCulture method to set the user selected
        /// option in the current thread. Note that this method is called much
        /// earlier in the Page lifecycle and we don't have access to any controls
        /// in this stage, so have to use Form collection.
        /// </SUMMARY>
        protected override void InitializeCulture()
        {
            GlobalizationSection globalizationSection;
            CultureInfo currentCulture;
            
            try
            {
                globalizationSection = WebConfigurationManager.GetSection("system.web/globalization") as GlobalizationSection;
                currentCulture = CultureInfo.CurrentCulture;

                // auto
                if (globalizationSection.Culture.Length == 0 || globalizationSection.Culture.ToLower().Equals("auto"))
                {
                    switch (currentCulture.TwoLetterISOLanguageName)
                    {
                        case "bg": SetCulture("bg-BG", "bg-BG");
                            break;
                        case "en": SetCulture("en-US", "en-US");
                            break;
                        case "de": SetCulture("de-DE", "de-DE");
                            break;
                        case "fr": SetCulture("fr-FR", "fr-FR");
                            break;
                        case "es": SetCulture("es-ES", "es-ES");
                            break;
                    }
                }
                else
                {
                    SetCulture(globalizationSection.Culture, globalizationSection.Culture);
                }

                base.InitializeCulture();
            }
            catch (Exception)
            { 
            }
        }


        /// <Summary>
        /// Sets the current UICulture and CurrentCulture based on
        /// the arguments
        /// </Summary>
        /// <PARAM name="name"></PARAM>
        /// <PARAM name="locale"></PARAM>
        protected void SetCulture(string name, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
        }
    }
}
