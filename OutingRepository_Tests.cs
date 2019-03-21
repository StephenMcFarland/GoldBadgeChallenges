using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03_Challenge;

namespace UnitTestProject1
{
    [TestClass]
    public class OutingRepository_Tests
    {

        [TestMethod]
        public void CalcOutingCost()
        {
            //Arrange
            OutingRepository _outingRepo = new OutingRepository();
            List<Outing> _outingsList = new List<Outing>();
            Outing _outing = new Outing();

            //Act
            _outing.PersonCost = 3;
            _outing.Attendees = 3;
            
            _outingsList.Add(_outing);
             
            EventType type = EventType.Golf;

            decimal actual = _outingRepo.CalcOutingCost(type, _outingsList);
            decimal expected = 9;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcTotalOutingCost()
        {
            //Arrange
            OutingRepository _outingRepo = new OutingRepository();
            List<Outing> _outingsList = new List<Outing>();
            Outing _outing = new Outing();

            //Act
            _outing.PersonCost = 3;
            _outing.Attendees = 3;

            _outingsList.Add(_outing);

            EventType type = EventType.Golf;

            decimal actual = _outingRepo.CalcOutingCost(type, _outingsList);
            decimal expected = 9;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
