using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PROG301_MVC.Interfaces;
using PROG301_MVC.Models.Engines;

namespace PROG301_MVC.Models.AerialVehicles
{
    public class ToyPlane : AerialVehicle
    {
        bool isWoundUP
        {
            get;
        }

        public ToyPlane()
        {
            Engine = new RubberBandEngine();

            MaxAltitude = 50;
            DefaultAltitudeChange = 5;
        }

        public ToyPlane(IEngine engine)
        {
            Engine = engine;

            MaxAltitude = 50;
            DefaultAltitudeChange = 5;
        }

        public override void StartEngine()
        {
            if (Engine == null) { throw new ArgumentNullException(nameof(Engine)); }
            if (((RubberBandEngine)Engine).IsFullyWound) Engine.Start();
        }

        public override string TakeOff()
        {
            if (Engine == null) { throw new ArgumentNullException(nameof(Engine)); }
            if (Engine.IsStarted)
            {
                IsFlying = true ;
                return $"{this} is flying.";
            }
            return $"{this} can't fly it's engine is not wound.";
        }

        public void WindUp()
        {
            if (Engine == null) { throw new ArgumentNullException(nameof(Engine)); }
            while (((RubberBandEngine)Engine).IsFullyWound == false)
            {
                Wind();
            }
        }

        public void Wind()
        {
            if (Engine == null) { throw new ArgumentNullException(nameof(Engine)); }
            ((RubberBandEngine)Engine).Wind();
        }

        public void UnWind()
        {
            if (Engine == null) { throw new ArgumentNullException(nameof(Engine)); }
            ((RubberBandEngine)Engine).UnWind();
        }

        public void UnWindCompletely()
        {
            if (Engine == null) { throw new ArgumentNullException(nameof(Engine)); }
            while (((RubberBandEngine)Engine).NumWinds > 0)
            {
                ((RubberBandEngine)Engine).UnWind();
            }
        }

        protected string getWindUpString()
        {
            string woundUp = "It's not wound up.";
            if(isWoundUP) woundUp = woundUp.Replace("not ", "");
            return woundUp;
        }

        public new string About()
        {
            return base.About() + "\n" + this.getWindUpString();
        }
    }
}
