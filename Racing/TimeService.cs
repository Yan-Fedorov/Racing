using Racing.Figure;
using System;
using System.Threading;

namespace Racing
{
    public class TimeService: IDisposable
    {
        //private readonly CarDecrease _carDecrease;
        //private readonly OopCar _car;
        public TimeService(/*CarDecrease carDecrease*//*, OopCar car*/)
        {
            //_carDecrease = carDecrease;
            //_car = car;
            ButtonFireTimer = new Timer(SwitchAllowFire, null, 0, 250);
        }

        static TimerCallback tmMove = new TimerCallback(SwitchAllowMovement);
        public Timer ButtonMovementTimer = new Timer(tmMove, null, 0, 500);
        public static bool AllowMovement = true;

        public static void SwitchAllowMovement(object obj)
        {
            if (AllowMovement == false)
                AllowMovement = true;
        }

        public Timer ButtonFireTimer;
        public static bool AllowFire = true;

        public void SwitchAllowFire(object obj)
        {
            if (AllowFire == false)
                AllowFire = true;
        }

        public static int I = 0;
        public static TimerCallback tmIncreaseSpeed = new TimerCallback(Increase);
        public Timer IncreaseSpeedTimer = new Timer(tmIncreaseSpeed, null, 0, 3000);

        public static void Increase(object obj)
        {
            if (I < 500)
                I += 100;
        }

        public void Dispose()
        {
            ButtonFireTimer.Dispose();
        }
    }
}
