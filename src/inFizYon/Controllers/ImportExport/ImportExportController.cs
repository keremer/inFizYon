using Excel;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using inFizYon.Data;
using inFizYon.Ontology;

// Controller with required classes to import/export cobie, excel, word and ifc files
// Class: ImportExportController => class for controller actions
// Class: ReadExcel => Read/Import data from excel file
// Class: ReadWord => Read/Import data from excel file
// Class: ReadIFC => Read/Import data from IFC file
// Class: WriteCobie => Write/Export data to a cobie excel file
// Class: Pack => Convert phrases to documents or vice versa

namespace inFizYon.Controllers
{
    public class ImportExportController : Controller
    {
        IHostingEnvironment _env;
        inFizYonDbContext context;

        public ImportExportController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to inFizYon Platform!";

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ///// <summary>
        ///// to Save DropzoneJs Uploaded Files
        ///// </summary>
        //public IActionResult SectionUpload(inFizYonDbContext context)
        //{
        //    return Json(new { Message = string.Empty });
        //}

        [HttpPost("ImportExport")]
        [ValidateAntiForgeryToken]
 
            public async Task<IActionResult> Post(List<IFormFile> files)
            {
            //Alternate: Based on IHostingEnvironment
            //Debug: Check the string values
            //string webRootPath = _env.WebRootPath;
            //string contentRootPath = _env.ContentRootPath;
            //return Content(webRootPath + "\n" + contentRootPath);

            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //using (var stream = new FileStream(filePath, FileMode.Create))
                        var fileName = ContentDispositionHeaderValue
                        .Parse(file.ContentDisposition)
                        .FileName
                        .Trim('"');// FileName returns "fileName.ext"(with double quotes) in beta 3

                        if (fileName.EndsWith(".txt"))// Important for security if saving in webroot
                        {
                            filePath = _env.ContentRootPath + "\\Uploads\\" + fileName;
                            using (var targetStream = System.IO.File.Create(filePath))
                            {
                                await file.CopyToAsync(targetStream);
                            }
                        }
                        else if (fileName.EndsWith(".csv"))// Comma Seperated Values
                        {
                            filePath = _env.ContentRootPath + "\\Uploads\\" + fileName;
                            using (var targetStream = System.IO.File.Create(filePath))
                            {
                                await file.CopyToAsync(targetStream);
                            }
                        }
                        else if (fileName.EndsWith(".xls"))// Excel 2003 file
                        {
                            filePath = _env.ContentRootPath + "\\Uploads\\" + fileName;
                            using (var targetStream = System.IO.File.Create(filePath))
                            {
                                await file.CopyToAsync(targetStream);
                            }
                            
                            
                            //List<inMF> sectionList = new List<inMF>();
                            var excelData = new ReadExcel(fileName);
                            //Code to record section txt (Phase I)
                            var sectiontxt = excelData.getData("Sheet1");

                            //Initialize method variables
                            int recordNr = 0;
                            int Depth = 0;
                            //int cntChild = 1;
                            int[] captureParent = new int[15];
                            int[,] valParent = new int[10, captureParent.Max()];
                            valParent[1, 0] = 1;
                            valParent[1, 1] = 1;

                            Pack Spec = new Pack();

                            if (ModelState.IsValid)
                            {
                                foreach (var row in sectiontxt)
                                {
                                    recordNr = recordNr + 1;
                                    var sText = row["phrsTRtxt"].ToString();
                                    int plvl = int.Parse(row["parLevel"].ToString());

                                    if (plvl == Depth) // That means we advance on same list
                                        Spec.AddNLine(recordNr, plvl, captureParent[plvl - 1], sText);

                                    if (plvl < Depth) // That means we moved to a higher level on nested list
                                        for (int i = Depth; i > plvl; i--) //Flush medieval values to 0
                                        {
                                            captureParent[i] = 0;
                                        }

                                    Depth = Depth - (Depth - plvl); //Find the level on nested list
                                    Spec.AddNLine(recordNr, plvl, captureParent[Depth - 1], sText); //Writeline the ID of previous parent

                                    if (plvl > Depth) // That means we moved to a lower level on nested list
                                        captureParent[plvl] = recordNr; // Capture ID of new parent -in case a new nested list exists
                                    Spec.AddNLine(recordNr, plvl, captureParent[Depth], sText); //Writeline the ID of new parent
                                    Depth = Depth + (plvl - Depth); //Determine new depth

                                    {
                                        sText = row["Title"].ToString();
                                        var secNo = row["Section"].ToString();
                                        var newPhrase = new Phrase { phrsENtxt = sText, phrsTRtxt = "", phrsComp = 50, phrsReliance = 100 };
                                        context.phraseSet.Add(newPhrase);
                                        context.SaveChanges();
                                        var newSection = new InMF { secNr = secNo, sectionID = newPhrase.phrsID };
                                        context.inMFSet.Add(newSection);
                                        context.SaveChanges();
                                    }
                                };
                                //isSavedSuccessfully = true;
                            }

                            {
                                //Log the error (uncomment dex variable name and add a line here to write a log.
                                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                            }
                    }

                        else if (fileName.EndsWith(".xlsx"))// Excel 2010 file
                        {
                            filePath = _env.ContentRootPath + "\\Uploads\\" + fileName;
                            using (var targetStream = System.IO.File.Create(filePath))
                            {
                                await file.CopyToAsync(targetStream);
                            }
                        }
                        else if (fileName.EndsWith(".doc"))// Word 2003 file
                        {
                            filePath = _env.ContentRootPath + "\\Uploads\\" + fileName;
                            using (var targetStream = System.IO.File.Create(filePath))
                            {
                                await file.CopyToAsync(targetStream);
                            }
                        }
                        else if (fileName.EndsWith(".docx"))// Word 2010 file
                        {
                            filePath = _env.ContentRootPath + "\\Uploads\\" + fileName;
                            using (var targetStream = System.IO.File.Create(filePath))
                            {
                                await file.CopyToAsync(targetStream);
                            }
                        }
                    }
                }
                return Ok(new { count = files.Count, size, filePath });
            }
        }
    }
                    

        // POST: /phrase/UploadFiles/1
        //private const string TempPath = @"~/Uploads";
        ////@"C:\Projects\inFizYon\Upload"; modified by Kerem Ercoskun 201409191400
        //private string myfile = "";
        //private string location = "";

        // Alternative 2 for file upload: based on dropzone.js

        //private void ExcelDocViewer(string fileName)
        //{
        //    try
        //    {
        //        System.Diagnostics.Process.Start(fileName);
        //    }
        //    catch { }
        //}

    //READ: WORD
    // Word Document Reader, import word data to inFizYon
    //________________________________________________________

    // Here the do it all method, call it after the constructor
    // it will try to find and parse document.xml from the zipped file
    // and return the docx's text in a string
    public class ReadWord
    {

        // lets open the zip file and look up for the
        // document.xml file
        // and save its zip location into the location variable
        private string getDocumentXmlFile_FromZipFile()
        {
        // ICsharpCode helps here to open the zipped file
        var myfile = "";
            ZipFile zip = new ZipFile(myfile);

            // lets take a look to the file entries inside the zip file
            // up to we get
            foreach (ZipEntry entry in zip)
            {

                if (string.Compare(entry.Name, "[Content_Types].xml", true) == 0)
                {
                    Stream contentTypes = zip.GetInputStream(entry);

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.PreserveWhitespace = true;
                    xmlDoc.Load(contentTypes);

                    contentTypes.Close();

                    // we need a XmlNamespaceManager for resolving namespaces
                    XmlNamespaceManager xnm = new XmlNamespaceManager(xmlDoc.NameTable);
                    xnm.AddNamespace("t", @"http://schemas.openxmlformats.org/package/2006/content-types");

                    // lets find the location of document.xml
                    XmlNode node = xmlDoc.DocumentElement.SelectSingleNode("/t:Types/t:Override[@ContentType=\"application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml\"]", xnm);

                    if (node != null)
                    {
                        string location = ((XmlElement)node).GetAttribute("PartName");
                        return location.TrimStart(new char[] { '/' });
                    }
                    break;
                }
                // close the zip
                zip.Close();
            }
            //check - correct this line
            return null;
        }
    }

    //READ: EXCEL
    // Excel Spreadsheet Reader, import excel data to inFizYon
    //________________________________________________________

    public class ReadExcel
    {
        string _path;

        public ReadExcel(string path)
        {
            _path = path;
        }

        public IExcelDataReader getExcelReader()
        {
            // ExcelDataReader works with the binary Excel file, so it needs a FileStream
            // to get started. This is how we avoid dependencies on ACE or Interop:
            FileStream stream = File.Open(_path, FileMode.Open, FileAccess.Read);

            // We return the interface, so that 
            IExcelDataReader reader = null;
            try
            {
                if (_path.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                if (_path.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                return reader;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<string> getWorksheetNames()
        {
            var reader = this.getExcelReader();
            var workbook = reader.AsDataSet();
            var sheets = from DataTable sheet in workbook.Tables select sheet.TableName;
            return sheets;
        }

        public IEnumerable<DataRow> getData(string sheet, bool firstRowIsColumnNames = true)
        {
            var reader = this.getExcelReader();
            reader.IsFirstRowAsColumnNames = firstRowIsColumnNames;
            var workSheet = reader.AsDataSet().Tables[sheet];
            var rows = from DataRow a in workSheet.Rows select a;
            return rows;
        }
    }

    //PACK:
    //Class to process important data as a document and inject to the database.
    //_________________________________________________________________________

    public class Pack
    {
        private List<NLine> specLines = new List<NLine>();

        public void AddNLine(int node, int lvl, int parent, string content)
        {
            NLine line = new NLine();
            line.LineID = node;
            line.ParentID = parent;
            line.Lvl = lvl;
            line.Content = content;
            specLines.Add(line);
        }

        //public double OrderTotal()
        //{
        //    double total = 0;
        //    foreach (NLine line in _orderLines)
        //    {
        //        total += line.OrderLineTotal();
        //    }
        //    return total;
        //}

        // Nested class
        private class NLine
        {
            public int LineID { get; set; }
            public int ParentID { get; set; }
            public int Lvl { get; set; }
            public string Content { get; set; }

            //public double OrderLineTotal()
            //{
            //    return Child * Lvl;
            //}
        }
    }

            



 
