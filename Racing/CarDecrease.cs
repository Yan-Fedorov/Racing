using Racing.Figure;
namespace Racing
{
    public class CarDecrease
    {
        private readonly OopCar _car;       
        public CarDecrease(OopCar car)
        {
            _car = car;            
        }
        public int Dencrease = 0;
        public int PassNumber;
        public void ResizeCar()
        {
            if (Dencrease<=0)
            {
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
    }
}
