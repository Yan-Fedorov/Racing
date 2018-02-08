using Racing.Figure.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Figure.Car
{
    public class Shell : OopCar
    {
        private readonly OopCar _car;
        //private readonly Logic _logic;

        
        
        public Shell(OopCar car/*, Logic logic*/)
        {
            _car = car;

            
            Y = 14;
            figure = new char[,]
            {
                {'Ы'}
            };
        }

        public List<Shell> shells = new List<Shell>();

        public int Shells = 10;

        public void FlyUp()
        {


            //shells.Add(new Shell(_car, _logic));
            X = _car.X;
            Y--;
        }

     
    }
}
