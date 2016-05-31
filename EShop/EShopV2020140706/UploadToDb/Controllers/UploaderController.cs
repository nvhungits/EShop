using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadToDb.Controllers
{
    public class UploaderController : Controller
    {
        UploadToDbEntities db = new UploadToDbEntities();

        //
        // GET: /Uploader/
        public ActionResult Index()
        {
            return View(db.Documents);
        }

        public void Download(int id)
        {
            var f = db.Documents.Find(id);
            Response.ContentType = f.Mime;
            Response.OutputStream.Write(f.Data, 0, f.Data.Length);
        }

        public ActionResult Upload()
        {
            var f = Request.Files["document"];
            if (f != null && f.ContentLength > 0)
            {
                byte[] data = new byte[f.ContentLength];
                f.InputStream.Read(data, 0, data.Length);


                var fi = new Document()
                {
                    Data = data,
                    Mime=f.ContentType
                };

                db.Documents.Add(fi);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
	}
}