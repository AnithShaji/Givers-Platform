using e_Welfare.Web.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_Welfare.Controllers
{
    public class FileUplaodController : Controller
    {

        /// <summary>
        /// Render File Upload Partial View
        /// </summary>
        /// <returns>File Upload Partial View</returns>
        [ValidateInput(false)]
        public ActionResult FileUploadPartialView()
        {
            //var applicantList = this._manageClient.ApplicantDashboardList(tabName);

            return this.PartialView("FileUploadPV");
        }

        /// <summary>
        /// Upload File
        /// </summary>
        /// <returns>view or edit page of uploaded file</returns>
        [HttpPost]
        public ActionResult UploadFile()
        {
            HttpPostedFileBase myFile = Request.Files["FileUploaded"];
            bool isUploaded = false;
            string filePath = string.Empty;
            if (myFile != null)
            {
                string fName = Path.GetFileNameWithoutExtension(myFile.FileName) + "-" + DateTime.Now.ToString("yyMMddHHmmss") + Path.GetExtension(myFile.FileName);
                string tempFolderName = ConfigurationManager.AppSettings["Image.TempFolderName"];

                if (myFile != null && myFile.ContentLength != 0)
                {
                    string tempFolderPath = Server.MapPath("~/" + tempFolderName);

                    if (FileHelper.CreateFolderIfNeeded(tempFolderPath))
                    {
                        try
                        {
                            myFile.SaveAs(Path.Combine(tempFolderPath, fName));
                            isUploaded = true;
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                }

                filePath = string.Concat("/", tempFolderName, "/", fName);
            }

            return this.Json(new { isUploaded, filePath }, "text/html");
        }
    }
}