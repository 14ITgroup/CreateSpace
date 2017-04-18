using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using langxun;

/// <summary>
/// MyMail 的摘要说明
/// </summary>
public class MyMail
{
    public MyMail()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    protected static string myEmail = "itstudio@stu.ouc.edu.cn";

    protected static string myPassword = "Itdn2016";

    protected static string myHost = "mail.stu.ouc.edu.cn";

    public static int adminMail()
    {
        int result = 0;
        string emailTitle = "一条新的众创空间申请等待处理";
        using (var db = new Entities())
        {
            var adminList = (from it in db.usercontact where it.usclass == 1 select it).ToList();
            if (adminList.Count == 0) return 0;
            for (int i = 0; i < adminList.Count; i++)
            {
                usercontact my = adminList[i];
                string emailContent = "尊敬的" + my.usname + ",有一条新的众创空间申请等待处理，请您点击以下页面进入<a href =\"#\">点我</a>";
                Mail.SendEmail(myEmail, myPassword, my.usemail, emailTitle, emailContent, myHost);
                result++;
            }
        }
        return result;
    }

    public static int teacherMail(applications things)
    {
        int result = 0;
        string emailTitle = "一条新的众创空间申请已经被同意";
        DateTime dt = new DateTime();
        TimeTrans.UnixTimestampToDateTime(dt, things.apptime);
        string appDate = dt.ToString("yyyy年MM月dd日");
        string DateState = "";
        switch (things.state)
        {
            case 0: DateState = "上午"; break;
            case 1: DateState = "下午"; break;
            case 2: DateState = "晚上"; break;
        }
        using (var db = new Entities())
        {
            var teacherList = (from it in db.usercontact
                               where it.usclass == 0
                               select it).ToList();
            if (teacherList.Count == 0) return 0;
            for (int i = 0; i < teacherList.Count; i++)
            {
                usercontact my = teacherList[i];
                string emailContent = "尊敬的" + my.usname + ",由申请人:" + things.stuname + ",提出的于" + appDate + " " + DateState + "的申请已被同意。申请理由为:" + things.body + "\n如有安排请通知爱特工作室";
                Mail.SendEmail(myEmail, myPassword, my.usemail, emailTitle, emailContent, myHost);
                result++;
            }
        }
        return result;
    }

    public static int appMail(applications things)
    {
        int result = 0;
        string emailTitle = "您的众创空间使用申请已成功发出";
        DateTime dt = new DateTime();
        TimeTrans.UnixTimestampToDateTime(dt, things.apptime);
        string appDate = dt.ToString("yyyy年MM月dd日");
        string DateState = "";
        switch (things.state)
        {
            case 0: DateState = "上午"; break;
            case 1: DateState = "下午"; break;
            case 2: DateState = "晚上"; break;
        }
        string emailContent = things.stuname + "您好,您提出的于" + appDate + " " + DateState + "的申请已发出并且等待管理员审核。申请理由为:" + things.body + "\n如有特殊情况请联系爱特工作室";
        result = Mail.SendEmail(myEmail, myPassword, things.email, emailTitle, emailContent, myHost);
        return result;
    }

    public static int appReMail(applications things)
    {
        int result = 0;
        string emailTitle = "";
        string finalState = "";
        string nextText = "";
        if (things.deal == 1) { emailTitle = "您的众创空间使用申请已被同意"; finalState = "同意"; nextText = "。请使用器械时小心拿放，以免损坏。谢谢合作！"; }
        else { emailTitle = "您的众创空间使用申请已被拒绝"; finalState = "拒绝"; nextText = "。请更换申请时间。谢谢合作！"; }
        DateTime dt = new DateTime();
        TimeTrans.UnixTimestampToDateTime(dt, things.apptime);
        string appDate = dt.ToString("yyyy年MM月dd日");
        string DateState = "";
        switch (things.state)
        {
            case 0: DateState = "上午"; break;
            case 1: DateState = "下午"; break;
            case 2: DateState = "晚上"; break;
        }
        string emailContent = things.stuname + "您好,您提出的于" + appDate + " " + DateState + "的申请已被"+finalState+nextText;
        result = Mail.SendEmail(myEmail, myPassword, things.email, emailTitle, emailContent, myHost);
        return result;
    }

    public static int CancelMail(applications things)
    {
        int result = 0;
        string emailTitle = "您的众创空间使用申请已取消";
        DateTime dt = new DateTime();
        TimeTrans.UnixTimestampToDateTime(dt, things.apptime);
        string appDate = dt.ToString("yyyy年MM月dd日");
        string DateState = "";
        switch (things.state)
        {
            case 0: DateState = "上午"; break;
            case 1: DateState = "下午"; break;
            case 2: DateState = "晚上"; break;
        }
        string emailContent = things.stuname + "您好,您提出的于" + appDate + " " + DateState + "的申请已被取消，如果这不是您的意愿，请联系爱特工作室";
        result = Mail.SendEmail(myEmail, myPassword, things.email, emailTitle, emailContent, myHost);
        return result;
    }

}