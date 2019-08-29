using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using webMotors_backEnd.Models;

namespace webMotors_backEnd.Controllers
{
    public class AnuncioController : Controller
    {
        private contexto db = new contexto();

        // GET: anuncios
        public ActionResult Index()
        {
            return View(db.Anuncio.ToList());
        }

        // GET: anuncios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anuncio anuncio = db.Anuncio.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // GET: anuncios/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: anuncios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,marca,modelo,versao,ano,quilometragem,text")] anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Anuncio.Add(anuncio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anuncio);
        }

        // GET: anuncios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anuncio anuncio = db.Anuncio.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // POST: anuncios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,marca,modelo,versao,ano,quilometragem,text")] anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anuncio);
        }

        // GET: anuncios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            anuncio anuncio = db.Anuncio.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // POST: anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            anuncio anuncio = db.Anuncio.Find(id);
            db.Anuncio.Remove(anuncio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public string getMarca()
        {
            string ApiBaseUrl = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/"; // endereço da sua api
            string Method = "Make"; //caminho do método a ser chamado

            var model = new MarcasViewModel();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + Method);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Accept = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var retorno = JsonConvert.DeserializeObject(reader.ReadToEnd());
                    return JsonConvert.SerializeObject(retorno);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public string getModel(int markId)
        {
            string ApiBaseUrl = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/"; // endereço da sua api
            string Method = "Model"; //caminho do método a ser chamado
            string paramsData = "?MakeID=" + markId;

           

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + Method + paramsData);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Accept = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var retorno = JsonConvert.DeserializeObject(reader.ReadToEnd());
                    return JsonConvert.SerializeObject(retorno);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public string getVersion(int modelId)
        {
            string ApiBaseUrl = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/"; // endereço da sua api
            string Method = "Version"; //caminho do método a ser chamado
            string paramsData = "?ModelID=" + modelId;



            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + Method + paramsData);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Accept = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var retorno = JsonConvert.DeserializeObject(reader.ReadToEnd());
                    return JsonConvert.SerializeObject(retorno);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
