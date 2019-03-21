using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class OutingRepository
    {
        List<Outing> _outingsList = new List<Outing>();
        Outing _outing = new Outing();

        public void AddOutingToList(Outing outing)
        {
            _outingsList.Add(outing);
        }

        public List<Outing> GetOutings()
        {
            return _outingsList;
        }

       
        public decimal CalcOutingCost(EventType type, List<Outing> outingsList)
        {
            decimal totalType = 0;
            foreach (Outing outing in outingsList)
            {
                if (outing.EventType == type)
                {
                    totalType += outing.PersonCost * outing.Attendees;
                }
            }
            return totalType;
        }
        public decimal CalcTotalOutingCost(List<Outing> outingsList)
        {
            decimal total = 0;
            foreach (Outing outing in _outingsList)
            {
                total += outing.PersonCost * outing.Attendees;

            }
            return total;

        }
    }
}
