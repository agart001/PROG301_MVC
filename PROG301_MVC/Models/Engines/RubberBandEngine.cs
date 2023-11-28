using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG301_MVC.Models.Engines
{
    public class RubberBandEngine : Engine
    {
        public int NumWinds { get; set; }
        public int NumWindsFullyWound { get; set; }

        public bool IsFullyWound { 
            get { return NumWinds >= NumWindsFullyWound; } 
        }

        public RubberBandEngine() : base()
        {
            NumWindsFullyWound = 20;
        }

        public void Wind()
        {
            NumWinds++;

            if(NumWinds >= NumWindsFullyWound) NumWinds = NumWindsFullyWound;
        }

        public void UnWind()
        {
            NumWinds--;

            if(NumWinds <= 0) NumWinds = 0;
        }
    }
}
