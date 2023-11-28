using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROG301_MVC.Models;
using PROG301_MVC.Models.AerialVehicles;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using Newtonsoft.Json;

namespace PROG301_MVC.Controllers
{
    public class AerialVehicleController : Controller
    {

        Dictionary<string, Type> AVTypes = new Dictionary<string, Type>();

        private List<string> AVNames() => new List<string>(AVTypes.Keys);

        static private List<AerialVehicle> Vehicles = new List<AerialVehicle>()
        {
            new Airplane(),
            new Helicopter(),
            new Drone(),
            new ToyPlane()
        };

        public AerialVehicleController() 
        {
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(t => t.IsSubclassOf(typeof(AerialVehicle))).ToArray();

            foreach(Type t in types)
            {
                AVTypes.Add(t.Name, t);
            }
        }

        // GET: AerialVehicleController
        public ActionResult Index()
        {
            return View(Vehicles);
        }

        // GET: AerialVehicleController/Details/5
        public ActionResult Details(int id)
        {
            var selected = Vehicles[id];
            return View(selected);
        }

        // GET: AerialVehicleController/Create
        public ActionResult Create()
        {
            ViewData["AVNames"] = AVNames();
            return View();
        }

        // POST: AerialVehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                AerialVehicle av;

                string name = collection["Name"];

                if (AVTypes[name] != null)
                {
                    av = (AerialVehicle)Activator.CreateInstance(AVTypes[name]);
                    if (av == null) throw new NullReferenceException(nameof(AVTypes));
                }
                else { throw new NullReferenceException(nameof(AVTypes)); }

                av.MaxAltitude = int.Parse(collection["MaxAltitude"]);
                av.DefaultAltitudeChange = int.Parse(collection["DefaultAltitudeChange"]);
                av.CurrentAltitude = int.Parse(collection["CurrentAltitude"]);

                if(av.CurrentAltitude > 0) { av.IsFlying = true; }

                Vehicles.Add(av);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AerialVehicleController/Edit/5
        public ActionResult Edit(int id)
        {    
            var selected = Vehicles[id];
            return View(selected);
        }

        // POST: AerialVehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                AerialVehicle selected = Vehicles[id];

                int[] originvals = new int[] 
                {
                    selected.MaxAltitude, 
                    selected.DefaultAltitudeChange, 
                    selected.CurrentAltitude
                };
                int[] newvals = new int[]
                {
                    int.Parse(collection["MaxAltitude"]), 
                    int.Parse(collection["DefaultAltitudeChange"]), 
                    int.Parse(collection["CurrentAltitude"])
                };

                if(originvals.Equals(newvals) == false)
                {
                    selected.MaxAltitude = newvals[0];
                    selected.DefaultAltitudeChange = newvals[1];
                    selected.CurrentAltitude = newvals[2];
                }

                if(selected.CurrentAltitude > 0) { selected.IsFlying = true; }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AerialVehicleController/Delete/5
        public ActionResult Delete(int id)
        {
            var selected = Vehicles[id];
            return View(selected);
        }

        // POST: AerialVehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                AerialVehicle selected = Vehicles[id];
                Vehicles.Remove(selected);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
