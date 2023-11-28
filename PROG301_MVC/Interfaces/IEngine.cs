using PROG301_MVC.Models;

namespace PROG301_MVC.Interfaces
{
    
    public interface IEngine : IAboutable
    {
        public string Name { get; protected set; }
        public bool IsStarted { get; protected set;}

        public void Start();
        public void Stop();
    }

}