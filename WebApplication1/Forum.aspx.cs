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
    public partial class Forum : System.Web.UI.Page
    {
        ForumDAO forumDAO = ForumDAO.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            //forumGrid.DataSource = forumDAO.GetTopics();
            forumGrid.DataSource = GetData();
            forumGrid.DataBind();

            if(ApplicationState.logged)
            {
                btnAdd.Visible = true;
                tbAdd.Visible = true;
            } else
            {
                btnAdd.Visible = false;
                tbAdd.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String title = tbAdd.Text;
            if ("".Equals(title))
                return;
            tbAdd.Text = "";
            forumDAO.AddTopic(title, ApplicationState.currentUser);
            forumGrid.DataSource = GetData();
            forumGrid.DataBind();
        }

        protected DataTable GetData()
        {
            List<Topic> topics = forumDAO.GetTopics();
            DataTable dt = new DataTable();
            // define the table's schema
            dt.Columns.Add(new DataColumn("topID", typeof(int)));
            dt.Columns.Add(new DataColumn("title", typeof(string)));
            dt.Columns.Add(new DataColumn("createdAt", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("author", typeof(string)));
            dt.Columns.Add(new DataColumn("avatar", typeof(string)));
            foreach(Topic t in topics)
            {
                DataRow dr = dt.NewRow();
                dr["topID"] = t.topID;
                dr["title"] = t.title;
                dr["createdAt"] = t.createdAt;
                dr["author"] = t.author.login;
                dr["avatar"] = @"~/Account/ImageServer.aspx?loc=" + t.author.login;
                dt.Rows.Add(dr);
            }

            return dt;
        }

    }
}