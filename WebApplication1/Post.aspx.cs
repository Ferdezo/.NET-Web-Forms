using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ForumData4;
using System.Data;

namespace WebApplication1
{
    public partial class Post : System.Web.UI.Page
    {
        int topID;
        ForumDAO forumDAO = ForumDAO.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            String s = Request.QueryString["topID"];
            topID = int.Parse(s);

            postGrid.DataSource = GetData(topID);
            postGrid.DataBind();

            if (ApplicationState.logged)
            {
                btnAdd.Visible = true;
                tbAdd.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
                tbAdd.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string content = tbAdd.Text;
            if ("".Equals(content))
                return;
            tbAdd.Text = "";
            forumDAO.AddPost(content, topID, ApplicationState.currentUser);
            postGrid.DataSource = GetData(topID);
            postGrid.DataBind();
        }

        protected void postGrid_PageIndexChanged(object sender, EventArgs e)
        {
            GridViewPageEventArgs ev = e as GridViewPageEventArgs;
            postGrid.DataSource = GetData(topID);
            postGrid.PageIndex = ev.NewPageIndex;
            postGrid.DataBind();
        }

        protected DataTable GetData(int topID)
        {
            List<ForumData4.Post> posts = forumDAO.GetPosts(topID);
            DataTable dt = new DataTable();
            // define the table's schema
            dt.Columns.Add(new DataColumn("content", typeof(string)));
            dt.Columns.Add(new DataColumn("createdAt", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("author", typeof(string)));
            dt.Columns.Add(new DataColumn("avatar", typeof(string)));
            foreach (ForumData4.Post p in posts)
            {
                DataRow dr = dt.NewRow();
                dr["content"] = p.content;
                dr["createdAt"] = p.createdAt;
                dr["author"] = p.user.login;
                dr["avatar"] = @"~/Account/ImageServer.aspx";
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}