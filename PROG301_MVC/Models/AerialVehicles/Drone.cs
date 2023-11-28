using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PROG301_MVC.Interfaces;
using PROG301_MVC.Models.Engines;


namespace PROG301_MVC.Models.AerialVehicles
{
    public class Drone : AerialVehicle
    {
        public Drone()
        {
            Engine = new UAVEngine();
            MaxAltitude = 500;
        }

        public Drone(IEngine engine)
        {
            Engine = engine;
            MaxAltitude = 500;
        }
    }
}
