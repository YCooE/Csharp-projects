using System;

namespace Car
{

    class Car
    {
        public string Name { get; private set; }

        public int Speed {
            get;
            private set;
        }

        public void Accelerate()
        {
            if (Speed > 100)
            {
                return;
            }
            Speed += 5;
        }

        public void Deaccelerate()
        {
            if (Speed < 5)
            {
                Speed = 0;
                return;
            }
            Speed -= 5;
        }



        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }
    }

    class MainClass
    {
        public static void Main (string[] args)
        {
            Car car1 = new Car("Seje bil", 50);
            Console.WriteLine (car1.Name + "drives" + car1.Speed + "km/h");
        }
    }
}
