using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MvcProjectWmp101.Library
{
    public static class MyExtensions
    {
        //static olmak zorundadır. her yerden çağırabilmemiz için yazmazsak new keywordü kullanılır.
        //static sınıfların static methodları olmalıdır.

        public static MvcHtmlString Button(this HtmlHelper helper, string id = "", string typ = "", string text = "")
        {
            string html = string.Format("<button id='{0}' name='{0}' type='{1}'>{2}</button>",id,typ,text);

            return MvcHtmlString.Create(html);
            //< button id = "" name = "" type = "" class="">Text</button>

        }

        public static MvcHtmlString Button(this HtmlHelper helper, string id = "", string typ = "", string cssClass = "", string text = "")
        {
            string html = string.Format($"<button id='{id}' name='{id}' type='{typ}' class='{cssClass}'>{text}</button>");

            return MvcHtmlString.Create(html);
            //< button id = "" name = "" type = "" class="">Text</button>
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string id = "", ButtonType typ = ButtonType.button, string cssClass = "", string text = "")
        {
            string html = string.Format($"<button id='{id}' name='{id}' type='{typ}' class='{cssClass}'>{text}</button>");

            return MvcHtmlString.Create(html);
            //< button id = "" name = "" type = "" class="">Text</button>
        }
         public static MvcHtmlString Button(this HtmlHelper helper, string id = "", ButtonType typ = ButtonType.button,
             string cssClass = "",string style = "", string text = "")
        {
            TagBuilder tag = new TagBuilder("button");
            tag.AddCssClass(cssClass);
            tag.GenerateId(id);
            tag.Attributes.Add(new KeyValuePair<string,string>("type",typ.ToString()));
            tag.Attributes.Add(new KeyValuePair<string, string>("name", id));
            tag.Attributes.Add(new KeyValuePair<string, string>("style", style));
            tag.SetInnerText(text);
            return MvcHtmlString.Create(tag.ToString());
        }


        public static MvcHtmlString Paragraph(this HtmlHelper helper,string id="",int borderSize=1,string borderStyle="solid",string text = "")
        {
            string html = string.Format($"<p id='{id}' name='{id}' style='border:{borderSize}px {borderStyle}'>{text}</p>");

            return MvcHtmlString.Create(html);

                //< p id="" style="border:1px solid">asdsa</p>
        }

        public static MvcHtmlString Paragraph(this HtmlHelper helper,string id="",int borderSize=1,string borderStyle="solid",Func<object,HelperResult>template=null)
        {
            string html = string.Format($"<p id='{id}' name='{id}' style='border:{borderSize}px {borderStyle}>{template.Invoke(null)}</p>");

            return MvcHtmlString.Create(html);

                //< p id="" style="border:1px solid">asdsa</p>
        }





        public enum ButtonType
        {
            button = 0,
            submit = 1,
            reset = 2
        }

    }
}