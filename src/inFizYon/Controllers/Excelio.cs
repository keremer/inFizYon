using System.IO;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using inFizYon;
using inFizYon.Ontology;

namespace inFizYon.Data
{
    public class ExcelController : Controller
    {

        //// private inFizYonDbContext db = new inFizYonDbContext(serviceProvider.GetRequiredService<DbContextOptions<inFizYonDbContext>>());

        //// POST: /phrase/UploadFiles/1

        //public ActionResult Index()
        //{
        //    ViewBag.Message = "Welcome to ASP.NET MVC!";

        //    return View();
        //}

        //public ActionResult About()
        //{
        //    return View();
        //}

        //// Alternative 2 for file upload: based on dropzone.js

        //private const string TempPath = @"~/Uploads";
        ////@"C:\Projects\inFizYon\Upload"; modified by Kerem Ercoskun 201409191400

        //private void ExcelDocViewer(string fileName)
        //{
        //    try
        //    {
        //        System.Diagnostics.Process.Start(fileName);
        //    }
        //    catch { }
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        /// <summary>
        /// to Save DropzoneJs Uploaded Files
        /// </summary>
        // public ActionResult DropzoneUpload(inFizYonDbContext context)

        // {
        // bool isSavedSuccessfully = false;

        //foreach (string fileName in Request.Files)
        //{
        //    HttpPostedFileBase file = Request.Files[fileName];

        //    //You can Save the file content here

        //    string targetFolder = HttpContext.Server.MapPath(TempPath);
        //    string targetPath = Path.Combine(targetFolder, file.FileName);
        //    file.SaveAs(targetPath);

        //    //List<inMF> sectionList = new List<inMF>();
        //    var excelData = new ExcelData(targetPath);
        //    //Code to record section txt (Phase I)
        //    var sectiontxt = excelData.getData("1");

        //    if (ModelState.IsValid)
        //    {
        //        foreach (var row in sectiontxt)
        //        {

        //            var sText = row["Title"].ToString();
        //            var secNo = row["Section"].ToString();
        //            {
        //                var newPhrase = new Phrase { phrsENtxt = sText, phrsTRtxt = "", phrsComp = 50, phrsReliance = 100 };
        //                context.PhraseSet.Add(newPhrase);
        //                context.SaveChanges();
        //                var newSection = new inMF { SecNr = secNo, SectionID = newPhrase.phrsID };
        //                context.MFSectionSet.Add(newSection);
        //                context.SaveChanges();
        //            }
        //        };
        //        // isSavedSuccessfully = true;
        //    }
        //    {
        //        //Log the error (uncomment dex variable name and add a line here to write a log.
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //    }
        //}

        //return Json(new { Message = string.Empty });
        // }
        //}
    } }
