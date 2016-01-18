using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ImageServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Request.QueryString["loc"];


            if (!File.Exists(Server.MapPath(@"~/App_Data/" + s +".png")))
                s = @"~/App_Data/avatar_default.png";
            else
                s = @"~/App_Data/" + s +".png";
            string loc = Server.MapPath(s);
            Response.WriteFile(loc);
            Response.ContentType = "image/png";
        }
    }
}