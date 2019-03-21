using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public enum EventType { Golf, Bowling, Amusement_Park, Concert }

    public class Outing
    {
        public int Attendees { get; set; }
        public EventType EventType { get; set; }
        public decimal OutingsCost { get; set; }
        public decimal OutingsTypesCost { get; set; }
        public decimal PersonCost { get; set; }
        public decimal TotalCost { get; set; }
        //public DateTime OutingsDate { get; set; }
        public string OutingsDate { get; set; }


        public Outing(string outingsDate, int attendees, EventType eventType, decimal personCost)
        {
            Attendees = attendees;
            EventType = eventType;
            OutingsDate = outingsDate;
            PersonCost = personCost;
            //TotalCost = attendees * personCost;
        }

        public Outing()
        {

        }

    }
}
