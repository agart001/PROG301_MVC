namespace PROG301_MVC.Interfaces
{
    
    public interface IFlyable
    {
        public bool IsFlying { get; protected set;}

        public int CurrentAltitude { get; protected set;}
        public int MaxAltitude { get; protected set;}
        public int DefaultAltitudeChange { get; protected set;}

        public void FlyUp();
        public void FlyUp(int HowManyFeet);

        public void FlyDown();
        public void FlyDown(int HowManyFeet);

    }

}