using PROG301_MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROG301_MVC.Models
{
    public abstract class Engine : IEngine
    {
        public string Name { get; set; }
        public bool IsStarted { get; set; }

        public Engine()
        {
            Name = GetType().Name;
            IsStarted = false;
        }

        public virtual void Start()
        {
            IsStarted =  true;
        }

        public virtual void Stop()
        {
            IsStarted = false;
        }

        public string About()
        {
            string engineString = ToString() + " is not started.";
            if (IsStarted)
            {
                engineString = engineString.Replace("not ", "");
            }
            return engineString;
        }
    }
}
