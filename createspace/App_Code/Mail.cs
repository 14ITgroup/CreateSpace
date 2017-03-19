using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace langxun
{
    class Mail
    {
        ///<summary>
        /// 发送邮件
        ///</summary>
        ///<param name="sendEmailAddress">发件人邮箱</param>
        ///<param name="sendEmailPwd">发件人密码</param>
        ///<param name="msgToEmail">收件人邮箱地址</param>
        ///<param name="title">邮件标题</param>
        ///<param name="content">邮件内容</param>
        ///<returns>0：失败。1：成功！</returns>
        public static int SendEmail(string sendEmailAddress, string sendEmailPwd, string msgToEmail, string title, string content, string host)
        {
            //发件者邮箱地址
            string fjrtxt = sendEmailAddress;
            //发件者邮箱密码
            string mmtxt = sendEmailPwd;
            //主题
            string zttxt = title;
            //内容
            string nrtxt = content;
            //string[] fasong = fjrtxt.Split('@');
            //设置邮件协议
            SmtpClient client = new SmtpClient(host); //stmp的设置
            client.Port = 25;
            client.Timeout = 9999;
            client.UseDefaultCredentials = false;    //mail.stu.ouc.edu.cn
            //通过网络发送到Smtp服务器
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //通过用户名和密码 认证
            //client.Credentials = new NetworkCredential(fasong[0].ToString(), mmtxt);
            client.Credentials = new NetworkCredential(fjrtxt, mmtxt);
            //发件人和收件人的邮箱地址
            MailMessage mmsg = new MailMessage();
            mmsg.From = new MailAddress(fjrtxt);
                mmsg.To.Add(new MailAddress(msgToEmail));
            //邮件主题
            mmsg.Subject = zttxt;
            //主题编码
            mmsg.SubjectEncoding = Encoding.UTF8;
            //邮件正文
            mmsg.Body = nrtxt;
            //正文编码
            mmsg.BodyEncoding = Encoding.UTF8;
            //设置为HTML格式
            mmsg.IsBodyHtml = true;
            //优先级
            mmsg.Priority = MailPriority.High;
            try
            {
                client.Send(mmsg);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
