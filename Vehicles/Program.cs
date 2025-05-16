//ИП2-24 Редьков Михаил

using System;
using System.Security.Cryptography.X509Certificates;

namespace Vehicle
{
    public class Programm
    {
        static void Main()
        {
            bool IsOpen = true;

            Car car_1 = new Car("Chevrolet Impala", 0, 200, 4);
            Truck truck_1 = new Truck("DAF XF 105", 0, 130, 12);
            Bicycle bicycle_1 = new Bicycle("Mountai Bycicle", 0, 35);

            while(IsOpen)
            {      
                Console.Clear();

                car_1.Print();
                truck_1.Print();
                bicycle_1.Print();

                Console.WriteLine("_____________________");

                Console.WriteLine("1. Start\n2. Stop\n3.Load Cargo\n4. Exit");

                int input = GetUserInput("Select menu position: ");
                switch (input)
                {
                    case 1:
                        car_1.Start();
                        truck_1.Start();
                        bicycle_1.Start();
                        break;
                    case 2:
                        car_1.Stop();
                        truck_1.Stop();
                        bicycle_1.Stop();
                        break;
                    case 3:
                        truck_1.LoadCargo();
                        break;
                    case 4:
                        IsOpen = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            static int GetUserInput(string prompt)
            {
                int result;
                Console.Write(prompt);
                while (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Invalid input. Please, try again");
                    Console.Write(prompt);
                }
                return result;
            }
        }
    }

    public class Vehicle
    {

        public Vehicle(string model, int currentSpeed, int maxSpeed)
        {
            Model = model;
            CurrentSpeed = currentSpeed;
            MaxSpeed = maxSpeed;
        }

        protected string Model { get; set; }
        protected int CurrentSpeed { get; set; }
        protected int MaxSpeed { get; set; }

        public void Start()
        {
            System.Console.WriteLine($"Vehicle {Model} is starting...");

            while (CurrentSpeed < MaxSpeed)
            {
                CurrentSpeed += 10;
                if (CurrentSpeed > MaxSpeed) CurrentSpeed = MaxSpeed;
                Console.WriteLine($"Current Speed: {CurrentSpeed}");
                
                Thread.Sleep(150);
            }

            Console.WriteLine($"{Model} has reached its maximum speed of {MaxSpeed}.");
            Console.ReadKey();
        }

        public void Stop()
        {
            System.Console.WriteLine($"Vehicle {Model} stoped");
            CurrentSpeed = 0;
            Console.ReadKey();
        }

        public void Print()
        {
            Console.WriteLine($"Model: {Model}\nCurrent Speed: {CurrentSpeed}\nMax Speed: {MaxSpeed}\n");
        }
    }

    public class Car : Vehicle
    {
        public byte PassengerSeat { get; set; }
        public Car(string model, int currentSpeed, int maxSpeed, byte passengerSeat) : base(model, currentSpeed, maxSpeed)
        {
            PassengerSeat = passengerSeat;
        }
    }

    public class Truck : Vehicle
    {
        public int CargoCapacity { get; set; }
        public Truck(string model, int currentSpeed, int maxSpeed, int cargoCapacity) : base(model, currentSpeed, maxSpeed)
        {
            CargoCapacity = cargoCapacity;
        }

        public void LoadCargo()
        {
            Console.WriteLine("Loading cargo...");
            MaxSpeed -= CargoCapacity*3;
            CargoCapacity = 0;
        }
    }

    public class Bicycle : Vehicle
    {
        public Bicycle(string model, int currentSpeed, int maxSpeed) : base(model, currentSpeed, maxSpeed)
        {

        }

        void RingBell()
        {
            Console.WriteLine("*Bell is ringing*");
        }
    }
}
