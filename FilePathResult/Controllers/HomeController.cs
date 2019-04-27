using System;
using System.Collections.Generic;
using System.IO;  //sonradan eklendi
using System.Linq;
using System.Text;  //sonradan eklendi
using System.Web;
using System.Web.Mvc;

namespace FilePathResult.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homepage()
        {
            return View();
        }

        public FileStreamResult Download_File()
        {
            string data = "Bu bir deneme mesajidir."; //Bu veriyi Database den de çekmiş olabiliriz veya controller içinde gelen parametrelere göre üretmiş olabiliriz, biz kısa olsun diye direkt burada string bir değer verdik.
            MemoryStream memo = new MemoryStream();
            //Encoding.GetEncoding("ISO-8859-9").GetBytes(data);     //yada GetEncodings ilede kendi isteğiniz encoding i ekleyebilirsiz array halinde
            byte[] bytes=Encoding.UTF8.GetBytes(data); // MemoryStream 'e birşeyler yazmak için yazılacak olan ifadeyi byte'a çevirmemiz gerekiyor.
            memo.Write(bytes, 0, bytes.Length);
            memo.Position = 0; // çok önemli
            FileStreamResult result_stream = new FileStreamResult(memo, "text/plain");
            result_stream.FileDownloadName = "sample.txt"; //FileDownloadName kullanıcıya gidecek indirme adı siz Guid yapabilirsiniz yada kullanıcının adıyla indirtebilirsiniz.

            return result_stream;
        }

       
    }
}

/*
 FileStreamResult da kullanıcı bir işlem yapıyordur ve sizin kullanıcının yaptıgı işleme göre
 sizin o anda bir dosya üretmeniz gerekiyordur ve onun bunu indirebilmesini sağlayabiliriz.
 Orneğin kayıtların database den çekilip excel formatında kullanıcıya indirtilmesi.
     */
