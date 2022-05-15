using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    internal class Program
    {
        struct Train
        {
            public string Number;
            public string DepartureStation;
            public string ArrivalStation;
            public DateTime DepartureTime;
        }

        static Train[] GetEmptyTrainArray()
        {
            Train[] trains = new Train[0];
            return trains;
        }

        static Train[] AddNewTrainArray(Train train, Train[] trains)
        {
            Train[] newTrains = new Train[trains.Length + 1];

            for (int i = 0; i < trains.Length; i++)
            {
                newTrains[i] = trains[i];
            }
            newTrains[trains.Length - 1] = train;
            return newTrains;
        }

        static void ShowTableHead()
        {
            Console.WriteLine("{0,-15}{1,-22}{2,-19}{3,-20}", "Номер поезда", "Станция отправления", "Станция прибытия", "Время отправления"); 
        }

        static void ShowTrain(Train train)
        {
            Console.WriteLine("{0,-15}{1,-22}{2,-19}{3,-20}", train.Number, train.DepartureStation, train.ArrivalStation, train.DepartureTime);
        }

        static void ShowAlltrains(Train[] trains)
        {
            if (trains.Length == 0)
            {
                Console.WriteLine("поездов нету!");
            }
            else
            {
                for (int i = 0; i < trains.Length; i++)
                {
                    ShowTrain(trains[i]);
                }
            }
        }
        static void ShowDelimiter()
        {
            Console.WriteLine(new String('=', 10));
        }

        static void ShowMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить поезд в расписание");
            Console.WriteLine("0. Выход");
        }

        static int InputMenuPoint(int minPoint, int maxPoint)
        {
            bool inputResult;
            int number;

            do
            {
                Console.Write("Введите пункт меню:");
                inputResult = int.TryParse(Console.ReadLine(), out number);

                if (inputResult == false)
                {
                    Console.WriteLine("Введите корректное число!!!");
                }
                else
                {
                    if(number < minPoint || number > maxPoint)
                    {
                        Console.WriteLine("Число выходит за границы. Введите корректное число!");
                        inputResult = false;
                    }
                }
            }
            while (inputResult == false);  
            
            return number;
        }

        static void Main(string[] args)
        {
            Train[] trains = GetEmptyTrainArray();
            while (true)
            {
                ShowTableHead();
                ShowAlltrains(trains);
                ShowDelimiter();
                ShowMenu();
                int menuPoint = InputMenuPoint(0, 1);
                switch (menuPoint)
                {
                    case 1: break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
