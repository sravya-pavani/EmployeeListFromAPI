using System;
using System.Web;
using System.Web.Configuration;

namespace EmployeeListFromAPI
{
    public static class SiteGlobal
    {
        /// <summary>
        /// Gets or sets the API URL.
        /// </summary>
        /// <value>The API URL.</value>
        static public string ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the default size of the page.
        /// </summary>
        /// <value>The default size of the page.</value>
        static public int DefaultPageSize { get; set; }

        /// <summary>
        /// Gets or sets the default index of the page.
        /// </summary>
        /// <value>The default index of the page.</value>
        static public int DefaultPageIndex { get; set; }

        /// <summary>
        /// Gets or sets the content type header.
        /// </summary>
        /// <value>The content type header.</value>
        static public string ContentTypeHeader { get; set; }

        /// <summary>
        /// Gets or sets the accept header.
        /// </summary>
        /// <value>The accept header.</value>
        static public string AcceptHeader { get; set; }

        /// <summary>
        /// Gets or sets the data json.
        /// </summary>
        /// <value>The data json.</value>
        static public string dataJson { get; set; }

        static SiteGlobal()
        {
            // Cache all these values in static properties.
            ApiUrl = WebConfigurationManager.AppSettings["APIUrl"];
            DefaultPageSize = Convert.ToInt32(WebConfigurationManager.AppSettings["DefaultPageSize"]);
            DefaultPageIndex = Convert.ToInt32(WebConfigurationManager.AppSettings["SiteHeader"]);
            ContentTypeHeader = WebConfigurationManager.AppSettings["ContentTypeHeader"];
            AcceptHeader = WebConfigurationManager.AppSettings["AcceptHeader"];
            dataJson = WebConfigurationManager.AppSettings["dataJson"];
        }
    }
}