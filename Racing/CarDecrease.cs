using Racing.Additions;
using Racing.Figure;
using System;
using System.Linq;

namespace Racing
{
    public class CarDecrease: IInterfaceItem, IAddition
    {
        private readonly OopCar _car;
        private readonly Fall_Drow _figures;
        public CarDecrease(OopCar car, Fall_Drow figures)
        {
            _car = car;
            _figures = figures;
        }
        public int Dencrease = 0;
        public int PassNumber;
        public void ResizeCar()
        {
            if (Dencrease<=0)
            {
                if(_car.X > 9)
                {
                    _car.X = 9;
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
                _car.figure = new[,]
            {
                {'^'},                               
            };
                Dencrease--;
            }
        }

        public int GetUi(int offset)
        {
            Console.SetCursorPosition(30, offset + 6);
            Console.Write($"Оставшееся время длительности уменьшения - {PassNumber}");
            return 4;
        }

        public bool TryApply(Collision collision)
        {
            if (collision.Symbol != 'D')
                return false;

            Dencrease++;
           ResizeCar();
          PassNumber = 30;
            _figures.figuresList.Remove(_figures.figuresList.FirstOrDefault(x => x.figure[0, 0] == 'D'));
            return true;
        }
    }
}
