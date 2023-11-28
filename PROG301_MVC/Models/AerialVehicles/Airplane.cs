using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PROG301_MVC.Interfaces;
using PROG301_MVC.Models.Engines;


namespace PROG301_MVC.Models.AerialVehicles
{
    public class Airplane : AerialVehicle
    {
        public Airplane()
        {
            Engine = new JetEngine();
            MaxAltitude = 41000;
        }

        public Airplane(IEngine engine)
        {
            Engine = engine;
            MaxAltitude = 41000;
        }
    }
}
