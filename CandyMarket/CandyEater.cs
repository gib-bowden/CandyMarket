using System;
using System.Collections.Generic;
using System.Text;

namespace CandyMarket
{
    class CandyEater
    {
        readonly DatabaseContext _db; //can only be assigned in the consturction 

        public String Name { get; set; }

        public CandyEater(string name, DatabaseContext db)
        {
            Name = name;
            _db = db; 
        }

        public void AddCandy(CandyType typeOfCandy, int howMany)
        {
            _db.SaveNewCandy(typeOfCandy, howMany, Name);
        }

        public void RemoveCandy(CandyType typeOfCandy, int howMany)
        {
            _db.RemoveCandy(typeOfCandy, Name);
        }

        //public void GiveCandy(CandyType typeOfCandy, string receiver)
        //{
        //    _db.RemoveCandy(Name, typeOfCandy);
        //    _db.SaveNewCandy(typeOfCandy, 1, receiver);
        //}
    }
}
