using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace TihBlogCompact.Core
{
    /// <summary>
    ///  Compares only Dates of DateTime
    /// </summary>
    /// <example>
    /// '19-08-2008 05:00' and '19-08-2008 10:05' are equal
    ///</example>
    public class TbComparer : IComparer<DateTime>, IComparer<string>
    {
        public int Compare(DateTime aFirst, DateTime aSecond)
        {
            return aFirst.Date.CompareTo(aSecond.Date);
        }

        public int Compare(string x, string y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    Int64 xInt, yInt;

                    if (Int64.TryParse(x, out xInt) && Int64.TryParse(y, out yInt))
                    {
                        if (xInt > yInt)
                            return 1;
                        if (xInt < yInt)
                            return -1;
                        return 0;
                    }

                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Length.CompareTo(y.Length);

                    if (retval != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return retval;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        return x.CompareTo(y);
                    }
                }
            }
        }

    }
}
