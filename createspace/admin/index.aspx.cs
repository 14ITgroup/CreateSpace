using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AdminIndex : System.Web.UI.Page
{
    protected int perPage = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int se = GetSe();
            AllPageBind(se);
            DdlCon.SelectedValue = se.ToString();
        }

    }

    protected void DdlCon_SelectedIndexChanged(object sender, EventArgs e)
    {
        int seNum = -1;
        try
        {
            seNum = Convert.ToInt32(DdlCon.SelectedValue);
        }
        catch
        {
            return;
        }
        if (seNum == 0)
        {
            Response.Redirect("Index.aspx");
        }
        else
        {
            Response.Redirect("Index.aspx?seNum=" + seNum.ToString());
        }
        Session["nowPage"] = "0";
    }

    protected void RptCon_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void AllPageBind(int se)
    {
        int nowpage = GetNowPage();
        using (var db = new Entities())
        {
            List<applications> seaData = new List<applications>();
            switch (se)
            {
                case 0: //
                    seaData = (from it in db.applications
                               orderby it.dealtime descending
                               select it).Skip(nowpage*perPage).Take(perPage).ToList();break;
                case 1:
                    seaData = (from it in db.applications
                               where it.deal != 0
                               orderby it.dealtime descending
                               select it).Skip(nowpage * perPage).Take(perPage).ToList(); break;
                case 2:
                    seaData = (from it in db.applications
                               where it.deal == 0
                               orderby it.dealtime descending
                               select it).Skip(nowpage * perPage).Take(perPage).ToList();break;
                case 3:
                    seaData = (from it in db.applications
                               where it.deal == 1
                               orderby it.dealtime descending
                               select it).Skip(nowpage * perPage).Take(perPage).ToList(); break;
                case 4:
                    seaData = (from it in db.applications
                               where it.deal == 2
                               orderby it.dealtime descending
                               select it).Skip(nowpage * perPage).Take(perPage).ToList();break;
                default: break;
            }
            List<Applist> fianData = Trans(seaData);
            PageBind(fianData);
            LblAllPage.Text = GetAllPage(se).ToString();
            LblNowPage.Text = (nowpage + 1).ToString();
        }
    }

    protected int GetAllPage(int se)
    {
        int allPage = 1;
        using (var db = new Entities())
        {
            List<applications> seaData = new List<applications>();
            switch (se)
            {
                case 0: //
                    seaData = (from it in db.applications
                               orderby it.dealtime descending
                               select it).ToList();
                    allPage = seaData.Count / perPage;
                    if (seaData.Count % perPage > 0) allPage++; break;
                case 1:
                    seaData = (from it in db.applications
                               where it.deal != 0
                               orderby it.dealtime descending
                               select it).ToList();
                    allPage = seaData.Count / perPage;
                    if (seaData.Count % perPage > 0) allPage++; break;
                case 2:
                    seaData = (from it in db.applications
                               where it.deal == 0
                               orderby it.dealtime descending
                               select it).ToList();
                    allPage = seaData.Count / perPage;
                    if (seaData.Count % perPage > 0) allPage++; break;
                case 3:
                    seaData = (from it in db.applications
                               where it.deal == 1
                               orderby it.dealtime descending
                               select it).ToList();
                    allPage = seaData.Count / perPage;
                    if (seaData.Count % perPage > 0) allPage++; break;
                case 4:
                    seaData = (from it in db.applications
                               where it.deal == 2
                               orderby it.dealtime descending
                               select it).ToList();
                    allPage = seaData.Count / perPage;
                    if (seaData.Count % perPage > 0) allPage++; break;
                default: break;
            }
        }
        if (allPage == 0) allPage++;
        return allPage;

    }

    protected void PageBind(List<Applist> a)
    {
        RptCon.DataSource = a;
        RptCon.DataBind();
    }

    protected List<Applist> Trans(List<applications> oriData)
    {
        List<Applist> transResult = new List<Applist>();
        if (oriData.Count != 0)
        {
            for (int i = 0; i < oriData.Count; i++)
            {
                Applist temp = new Applist();
                temp.id = oriData[i].id;
                temp.tim = oriData[i].state;
                temp.AppName = oriData[i].stuname;
                temp.dealstate = oriData[i].deal;
                temp.AppTitle = oriData[i].title;
                temp.AppTime=TimeTrans.UnixTimestampToDateTime(temp.AppTime, oriData[i].apptime);
                transResult.Add(temp);
            }
        }
        return transResult;
    }

    protected int GetNowPage()
    {
        int nowPage = 0;
        try
        {
            nowPage = Convert.ToInt32(Session["nowPage"]);
        }
        catch
        {
            Session["nowPage"] = "0";
        }
        return nowPage;
    }

    protected int GetSe()
    {
        int se = 0;
        try { se = Convert.ToInt32(Request.QueryString["seNum"]); } catch { }
        if (se > 4) se = 0;
        return se;
    }

    protected void BtnFirst_Click(object sender, EventArgs e)
    {
        int nowPage = GetNowPage();
        if (nowPage == 0) { return; }
        else Session["nowPage"] = "0";
    }

    protected void BtnLast_Click(object sender, EventArgs e)
    {
        int nowPage = GetNowPage();
        if (nowPage == 0) { return; }
        else Session["nowPage"] = (nowPage-1).ToString();
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        int nowPage = GetNowPage();
        int allPage = GetAllPage(GetSe());
        if ((nowPage + 1) == allPage) { return; }
        else Session["nowPage"] = (nowPage + 1).ToString();
    }

    protected void BtnFinal_Click(object sender, EventArgs e)
    { 
        int nowPage = GetNowPage();
        int allPage = GetAllPage(GetSe());
        if ((nowPage + 1) == allPage) { return; }
        else Session["nowPage"] = (allPage - 1).ToString();
    }

    protected void BtnGo_Click(object sender, EventArgs e)
    {
        int nowPage = GetNowPage();
        int allPage = GetAllPage(GetSe());
        int goPage = -1;
        try
        {
            goPage = Convert.ToInt32(TxtPage.Text);
        }
        catch { return; }
        if (goPage < 1 || goPage > allPage || goPage==nowPage+1) { return; }
        else { Session["nowPage"] = (goPage - 1).ToString(); }
    }
}

public partial class Applist
{
    public int id { get; set; }
    public string AppTitle { get; set; }
    public string AppName { get; set; }
    public DateTime AppTime { get; set; }
    public int tim { get; set; }
    public int dealstate { get; set; }
}