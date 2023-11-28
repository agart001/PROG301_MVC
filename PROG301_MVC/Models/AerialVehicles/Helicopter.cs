using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PROG301_MVC.Interfaces;
using PROG301_MVC.Models.Engines;


namespace PROG301_MVC.Models.AerialVehicles
{
    public class Helicopter : AerialVehicle
    {
        public Helicopter()
        {
            Engine = new ReciprocatingEngine();
            MaxAltitude = 8000;
        }

        public Helicopter(IEngine engine)
        {
            Engine = engine;
            MaxAltitude = 8000;
        }
    }
}
