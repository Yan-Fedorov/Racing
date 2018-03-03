using Racing.Additions;
using Racing.Figure;
using System;
using System.Linq;

namespace Racing
{
    public class CarDecrease: ConsoleMethods, IInterfaceItem, IAddition
    {
        private readonly OopCar _car;
        private readonly Fall_Drow _figures;
        public CarDecrease(OopCar car, Fall_Drow figures)
        {
            _car = car;
            _figures = figures;
            //Dencrease = 0;
            //PassNumber = 0;
            //refresh = true;
        }
        public int Dencrease = 0;
        public int PassNumber;
        public void ResizeCar()
        {
            var x = _car.X;
            if (Dencrease<=0)
            {
                if(_car.X > 9)
                {
                    _car.X = 9;
                }
                if (_car.figure.GetLength(0) == 1)
                {
                    _car.X = x - 1;
                }
                _car.figure = new[,]
            {               
                {' ','^'},
                {'^','^'},
                {' ','^'},                
            };
                
            }
            else if(Dencrease > 0)
            {
                if(_car.figure.GetLength(0)> 1)
                {
                    _car.X = x + 1;
                }
                _car.figure = new[,]
            {
                {'^'},                               
            };
                
                
                Dencrease--;
            }
        }
        private bool refresh = true;
        public int GetUi(int offset)
        {
            
            if (PassNumber == 0 && refresh)
            {
                ClearConData(offset);
                refresh = false;
                return 2;
            }
            else if (PassNumber > 0)
            {
                Console.SetCursorPosition(30, offset);
                Console.Write($"Оставшееся время длительности уменьшения - {PassNumber}");
                refresh = true;
            }
            return 2;
        }

        public bool TryApply(Collision collision)
        {
            if (collision.Symbol != 'D')
                return false;

            Dencrease++;
           ResizeCar();
          PassNumber = 30;
            _figures.RemoveBy(collision);
            return true;
        }
    }
}
