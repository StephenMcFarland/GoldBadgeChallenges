using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class ProgramUI
    {
        private OutingRepository _outingRepo;
        private List<Outing> _outings;
        private bool running = true;


        public ProgramUI()
        {
            _outingRepo = new OutingRepository();
            _outings = _outingRepo.GetOutings();
        }


        public void Run()
        {
            while (running)
            {
                Console.WriteLine("Welcome to the outing app.\n" +
                "1. Show all outings\n" +
                "2. Add personal outing\n" +
                "3. Show outing cost by type\n" +
                "4. Show total outing cost\n" +
                "5. Exit");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ShowAllOutings();
                        break;
                    case 2:
                        AddPersonOutings();
                        break;
                    case 3:
                        ShowOutingCostByType();
                        break;
                    case 4:
                        TotalOutingCost();
                        break;
                    case 5:
                        running = false;
                        break;
                }
            }
        }

            
            private void AddPersonOutings()
            {
                Console.WriteLine("What is the event?\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n");

                int eventtype = int.Parse(Console.ReadLine());

                EventType type;
                switch (eventtype)
                {
                    default:
                    case 1:
                        type = EventType.Golf;
                        break;
                    case 2:
                        type = EventType.Bowling;
                        break;
                    case 3:
                        type = EventType.Amusement_Park;
                        break;
                    case 4:
                        type = EventType.Concert;
                        break;
                }
                Console.WriteLine("How many people attended the event?");
                int attendees = int.Parse(Console.ReadLine());

                Console.WriteLine("When did the event happen?");
                string date = Console.ReadLine();

                Console.WriteLine("What was the individual cost?");
                decimal personCost = decimal.Parse(Console.ReadLine());

                
                Outing outing = new Outing(date, attendees, type, personCost);

                _outingRepo.AddOutingToList(outing);
               
            }
            private void ShowOutingCostByType()
            {
            
            Console.WriteLine("What is the event?\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n");

            int eventtype = int.Parse(Console.ReadLine());

            EventType type;
            switch (eventtype)
            {
                default:
                case 1:
                    type = EventType.Golf;
                    break;
                case 2:
                    type = EventType.Bowling;
                    break;
                case 3:
                    type = EventType.Amusement_Park;
                    break;
                case 4:
                    type = EventType.Concert;
                    break;
            }
            decimal totalCost = 0;
                    totalCost = _outingRepo.CalcOutingCost(type, _outings);
            Console.WriteLine($"Total cost for {type} is: {totalCost}");
            }
            private void TotalOutingCost()
            {
            decimal totalCost = _outingRepo.CalcTotalOutingCost(_outings);
            Console.WriteLine($"Total cost for all events is: {totalCost}");
            }





            private void ShowAllOutings()
            { int count = _outings.Count;
            if (count == 0)
            {
                Console.WriteLine("There are no items in the list.");
            }
                foreach (Outing Outing in _outings)
                {
                    Console.WriteLine($"{Outing.OutingsDate} {Outing.EventType} {Outing.Attendees}");
                }
                Console.ReadKey();
            }
        }
    }

