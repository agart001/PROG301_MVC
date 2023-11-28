using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PROG301_MVC.Interfaces;

namespace PROG301_MVC.Models
{
    public abstract class AerialVehicle : IFlyable, IAboutable
    {
        public IEngine? Engine { get; set; }
        public bool IsFlying { get; set; }
        public int MaxAltitude { get; set; }
        public int CurrentAltitude { get; set; }
        public int DefaultAltitudeChange { get; set;}

        public Guid ID { get; protected set; }
        public string Name { get; protected set; }

        public AerialVehicle()
        {
            Name = GetType().Name;
            ID = Guid.NewGuid();
            DefaultAltitudeChange = 1000;
        }

        public AerialVehicle(IEngine engine)
        {
            Name = GetType().Name;
            DefaultAltitudeChange = 1000;
            Engine = engine;
        }

        public virtual void StartEngine()
        {
            if (Engine == null) { throw new ArgumentNullException(nameof(Engine)); }
            Engine.Start();
        }

        public virtual void StopEngine()
        {
            if (Engine == null) { throw new ArgumentNullException(nameof(Engine)); }
            Engine.Stop();
        }

        public void FlyUp()
        {
            CurrentAltitude += DefaultAltitudeChange;

            if(CurrentAltitude >= MaxAltitude) CurrentAltitude = MaxAltitude;
        }

        public void FlyUp(int HowManyFeet)
        {
            //If HowMany feet is nagtive trow invaid operation exception
            if (HowManyFeet < 0) throw new InvalidOperationException("Can't FlyUp a negative amount");
            
            CurrentAltitude += HowManyFeet;

            if(CurrentAltitude >= MaxAltitude) CurrentAltitude = MaxAltitude;
        }

        public void FlyDown()
        {
            CurrentAltitude -= DefaultAltitudeChange;

            if(CurrentAltitude <= 0) 
            {
                CurrentAltitude = 0;
                IsFlying = false;
            }
        }

        public void FlyDown(int HowManyFeet)
        {
            if (HowManyFeet < 0) throw new InvalidOperationException("Can't FlyDown a negative amount");
            
            CurrentAltitude -= HowManyFeet;

            if(CurrentAltitude <= 0) 
            {
                CurrentAltitude = 0;
                IsFlying = false;
            }
        }
        public virtual string TakeOff()
        {
            if (Engine == null) { throw new ArgumentNullException(nameof(Engine)); }
            if (Engine.IsStarted)
            {
                IsFlying = true ;
                return $"{this} is flying";
            }
            return $"{this} can't fly it's engine is not started.";
        }

        /// <summary>
        /// Returns a string that describes if an engine is started
        /// </summary>
        /// <returns></returns>
        public string getEngineStartedString()
        {
            if (Engine == null) { throw new ArgumentNullException(nameof(Engine)); }
            return Engine.About();
        }

        public string About()
        {
            string about = string.Format("This {0} has a max altitude of {1} ft. \nIt's current altitude is {2} ft. \n{3}", 
                this.ToString(), this.MaxAltitude.ToString(), this.CurrentAltitude, this.getEngineStartedString());
            return about;
        }
    }
}
