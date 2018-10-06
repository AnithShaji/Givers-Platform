using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.BLL.BusinessObjects.Common
{
    /// <summary>
    /// Common class
    /// </summary>
    public class CommonClass
    {
        /// <summary>
        /// Gets or sets request type
        /// </summary>
        public enum RequestType
        {
            /// <summary>
            /// prescription request
            /// </summary>
            Prescription,

            /// <summary>
            /// Create Referral
            /// </summary>
            Referral,
        }

        /// <summary>
        /// Gets or sets Result Status
        /// </summary>
        public enum ResultStatus
        {
            /// <summary>
            /// yet to complete pathway
            /// </summary>
            Ongoing = 1,

            /// <summary>
            /// completed pathway
            /// </summary>
            Completed
        }

        /// <summary>
        /// Gets or sets RefSession
        /// </summary>
        public enum RefSession
        {
            /// <summary>
            /// AM RefSession
            /// </summary>
            AM,

            /// <summary>
            /// PM RefSession
            /// </summary>
            PM,
        }

        /// <summary>
        /// Gets or sets Consider at master
        /// </summary>
        public enum ConsideratRiskMaster
        {
            /// <summary>
            /// yet to Consider at
            /// </summary>
            Yes = 1,

            /// <summary>
            /// no to Consider at
            /// </summary>
            No = 2
        }

        /// <summary>
        /// Gets or sets Months
        /// </summary>
        public enum Months
        {
            /// <summary>
            /// Month January 
            /// </summary>
            January = 1,

            /// <summary>
            /// Month February
            /// </summary>
            February = 2,

            /// <summary>
            /// Month March
            /// </summary>
            March = 3,

            /// <summary>
            /// Month April
            /// </summary>
            April = 4,

            /// <summary>
            /// Month May
            /// </summary>
            May = 5,

            /// <summary>
            /// Month June
            /// </summary>
            June = 6,

            /// <summary>
            /// Month july
            /// </summary>
            July = 7,

            /// <summary>
            /// Month August
            /// </summary>
            August = 8,

            /// <summary>
            /// Month September
            /// </summary>
            September = 9,

            /// <summary>
            /// Month October
            /// </summary>
            October = 10,

            /// <summary>
            /// Month November
            /// </summary>
            November = 11,

            /// <summary>
            /// Month December
            /// </summary>
            December = 12
        }

        /// <summary>
        /// Send Email Notification
        /// </summary>
        /// <param name="subject">the subject of the mail</param>
        /// <param name="bodyMessage">the message content of the mail</param>
        /// <param name="mailIds">the email id separate with comma</param>
        /// <returns>return true if mail send successfully</returns>
        public bool SendEmailNotification(string subject, string bodyMessage, string mailIds)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage mailMessage = new MailMessage();
            try
            {
                mailMessage.IsBodyHtml = true;
                if (mailIds != string.Empty)
                {
                    string[] tooMail = mailIds.Split(',');
                    if (tooMail != null && tooMail.Length > 0)
                    {
                        for (int i = 0; i < tooMail.Length; i++)
                        {
                            mailMessage.To.Add(new MailAddress(tooMail[i]));
                        }
                    }

                    mailMessage.Subject = subject;
                    mailMessage.Body = bodyMessage;
                    smtpClient.Send(mailMessage);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }
    }
}
