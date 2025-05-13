using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{

    public class FlightController : Controller
    {
        IServiceFlight sf;
        IServicePlane sp;
        public FlightController(IServiceFlight sf, IServicePlane sp)
        {
            this.sf = sf;
            this.sp = sp;
        }

        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {

            if (dateDepart == null)
                return View(sf.GetMany());
            else
                return View(sf.GetMany(f => f.FlightDate.Equals(dateDepart)));
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View(sf.GetById(id));
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.planeFK = new SelectList(sp.GetMany(), "PlaneId", "Information");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection, IFormFile PilotImage)
        {
            try
            {

                if (PilotImage != null)
                {

                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot", "uploads", PilotImage.FileName);

                    Stream stream = new FileStream(path, FileMode.Create);
                    PilotImage.CopyTo(stream);

                    collection.Pilot = PilotImage.FileName;

                }

                sf.Add(collection);
                sf.Commit();

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }

        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            var flight = sf.GetById(id);
            ViewBag.planeFK = new SelectList(sp.GetMany(), "PlaneId", "Information");
            return View(flight);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection, IFormFile PilotImage)
        {

            try
            {
                if (PilotImage != null)
                {

                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot", "uploads", PilotImage.FileName);

                    Stream stream = new FileStream(path, FileMode.Create);
                    PilotImage.CopyTo(stream);

                    collection.Pilot = PilotImage.FileName;

                }
                sf.Update(collection);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sf.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Flight collection)
        {
            try
            {
                sf.Delete(sf.GetById(id));
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Sort()
        {
            return View("Index", sf.SortFlights());
        }

    }
}
