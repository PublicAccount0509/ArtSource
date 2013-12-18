namespace Ets.SingleApi.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Class:Help
    /// Namespace:Ets.SingleApi.Hosting
    /// Class Funtion:Represent the class to show help about service.
    /// </summary>
    /// Creator:zhouchao
    /// Creation Date:12/1/2011 1:41 PM
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    public partial class Help : Page
    {
        /// <summary>
        /// Initializes the <see cref="T:System.Web.UI.HtmlTextWriter"/> object and calls on the child controls of the <see cref="T:System.Web.UI.Page"/> to render.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> that receives the page content.</param>
        /// Creator:zhouchao
        /// Creation Date:12/1/2011 1:50 PM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        protected override void Render(HtmlTextWriter writer)
        {
            var root = HttpContext.Current.Request.ApplicationPath;
            var scheme = HttpContext.Current.Request.Url.Scheme;
            if (root == null)
            {
                return;
            }

            root = root.TrimEnd(new[] { '/', '\\' });

            if (string.IsNullOrEmpty(root) || string.IsNullOrWhiteSpace(root))
            {
                root = string.Format("{0}://{1}/Api", scheme, HttpContext.Current.Request.Url.Authority.TrimEnd(new[] { '/', '\\' }));
            }

            var list = new[]
                {
                    "Test",
                    "Authen", 
                    "BusinessArea",
                    "Coupon", 
                    "Cuisine", 
                    "Function", 
                    "Orders", 
                    "Payment", 
                    "ShoppingCart",
                    "HaiDiLaoShoppingCart", 
                    "Sms",
                    "User", 
                    "Supplier",
                    "HaiDiLaoSupplier",
                    "WapSupplier", 
                    "WeiXinWapHtjUser"
                };
            if (list.Length == 0)
            {
                return;
            }

            var tableItemList = new List<string>();
            foreach (var name in list)
            {
                var url = string.Format("{0}/{1}/help", root, name);
                var content = this.GetHtmlContent(url);
                content = Regex.Replace(content, @"\s+(?=<)|\s+$|(?<=>)\s+", string.Empty);
                int count;
                var tableItem = this.GetHtmlItem(content, @"(?i)[\<]tr.*?[\>].*?(</tr>)", out count);
                var tableHeader = this.GetHtmlItem(content, @"(?i)[\<]th.*?[\>].*?(</th>)");
                var tableBody = tableItem.Replace(tableHeader, string.Empty);
                tableBody = string.Format("<tr><td rowspan=\"{0}\" style=\"font-weight: bold; background-color: #cecf9c;text-align: center; vertical-align: middle;\">{1}</td>{2}", count, name, tableBody.Substring(4));
                tableItemList.Add(tableBody.Replace("href=\"help/operations/", string.Format("href=\"Api/{0}/help/operations/", name)));
            }

            var example = @"<br/><pre style='border: none;'>
            调用GET方法的示例：
            using (var client = new WebClient())
            {
            &#9;client.Headers['Content-type'] = 'application/json';
            &#9;client.Headers['AppKey'] = ConfigurationManager.AppSettings['AppKey'];
            &#9;client.Headers['AppPassword'] = ConfigurationManager.AppSettings['AppPassword'];
            &#9;client.Headers['Token'] = string.Empty;
            &#9;client.Encoding = Encoding.UTF8;

            &#9;var url = '<a href='" + root + @"/test/test'>" + root + @"/test/test</a>';
            &#9;var result = client.DownloadString(url);
            &#9;var jsonValue = JsonValue.Parse(result);
            &#9;if (jsonValue == null || jsonValue['Message'] == null || jsonValue['Result'] == null)
            &#9;{
            &#9;&#9;return string.Empty;
            &#9;}

            &#9;int statusCode = jsonValue['Message']['StatusCode'];
            &#9;if (statusCode == 200)
            &#9;{
            &#9;&#9;return string.Empty;
            &#9;}

            &#9;string result = jsonValue['Result'];
            &#9;return result;
            }


            调用POST方法的示例：
            using (var client = new WebClient())
            {
            &#9;client.Headers['Content-type'] = 'application/json';
            &#9;client.Headers['AppKey'] = ConfigurationManager.AppSettings['AppKey'];
            &#9;client.Headers['AppPassword'] = ConfigurationManager.AppSettings['AppPassword'];
            &#9;client.Headers['Token'] = string.Empty;
            &#9;client.Encoding = Encoding.UTF8;

            &#9;var url = '<a href='" + root + @"/test/test'>" + root + @"/test/test</a>';
            &#9;var data = string.Empty;
            &#9;var result = client.UploadString(url , data);
            &#9;var jsonValue = JsonValue.Parse(result);
            &#9;if (jsonValue == null || jsonValue['Message'] == null || jsonValue['Result'] == null)
            &#9;{
            &#9;&#9;return string.Empty;
            &#9;}

            &#9;int statusCode = jsonValue['Message']['StatusCode'];
            &#9;if (statusCode == 200)
            &#9;{
            &#9;&#9;return string.Empty;
            &#9;}

            &#9;string result = jsonValue['Result'];
            &#9;return result;
            }</pre>";

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var resut = string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build.ToString().PadLeft(4, '0'));
            var htmlContent = this.GetHtmlContent(string.Format("{0}/{1}/help", root, list.First()));
            var style = this.GetHtmlItem(htmlContent, @"(?i)[\<]style.*?[\>].*?(</style>)");
            // var title = string.Format("<p class=\"heading1\">{0}/</p><p>SinleApi接口文档.</p>", root);
            var title = string.Format("<p class=\"heading1\">{0}({1})</p>", "SingleApi接口说明", root);
            var head = string.Format("<head><title>{0}</title>{1}</head>", "SingleApi接口说明", style);
            var body = string.Format("<body><div id=\"content\">{0}<table style=\"width:100%;\"><tr style=\"height:25px;\"><th width=\"10%\"></th><th width=\"30%\">Uri</th><th width=\"10%\">Method</th><th>Description</th></tr>{1}<tr style=\"height:25px;\"><th colspan=\"4\">The system version is {3}</th></tr></table><br/><br/><table style=\"width:100%;\"><tr style=\"height:25px;\"><th>SingleApi调用示例</th></tr><tr><td>{2}</td></tr><tr style=\"height:25px;\"><th></th></tr></table><div></body>", title, string.Join(string.Empty, tableItemList), example.Replace("'", "\""), resut);
            var html = string.Format("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"[]><html xmlns=\"http://www.w3.org/1999/xhtml/\">{0}{1}</html>", head, body);

            var label = new Literal { Text = html };
            label.RenderControl(writer);
        }

        /// <summary>
        /// Gets the style.
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="regstr">The regstr</param>
        /// <returns>
        /// The result.
        /// </returns>
        /// Creator:zhouchao
        /// Creation Date:6/28/2012 3:26 PM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string GetHtmlItem(string content, string regstr)
        {
            int count;
            return this.GetHtmlItem(content, regstr, out count);
        }

        /// <summary>
        /// Gets the HTML item.
        /// </summary>
        /// <param name="content">The content</param>
        /// <param name="regstr">The regstr</param>
        /// <param name="count">The count</param>
        /// <returns>
        /// The result
        /// </returns>
        /// Creator:zhouchao
        /// Creation Date:6/28/2012 6:15 PM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string GetHtmlItem(string content, string regstr, out int count)
        {
            var regex = new Regex(regstr, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var matcheResult = regex.Matches(content);
            var result = (from Match match in matcheResult where match.Groups.Count != 0 select match.Groups[0].ToString()).ToList();
            count = result.Count;
            return string.Join(string.Empty, result);
        }

        /// <summary>
        /// Gets the content of the help.
        /// </summary>
        /// <param name="address">The address</param>
        /// <returns>
        /// The String
        /// </returns>
        /// Creator:zhouchao
        /// Creation Date:12/1/2011 2:33 PM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string GetHtmlContent(string address)
        {
            var request = (HttpWebRequest)WebRequest.Create(new Uri(address));
            request.Method = "Get";
            request.Timeout = 30000;

            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            if (responseStream == null)
            {
                return string.Empty;
            }

            using (var streamReader = new StreamReader(responseStream))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }
    }
}