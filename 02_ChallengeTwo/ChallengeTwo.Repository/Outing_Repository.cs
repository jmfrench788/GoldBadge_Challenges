using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

   public class Outing_Repository
    {
        private readonly List<Outing> _outingsInDB = new List<Outing>();

        public List<Outing> GetOuting()
        {
            return _outingsInDB;
        }

        public bool AddOutingToDB(Outing outing)
        {
            if (outing !=null)
            {
                _outingsInDB.Add(outing);
                return true;
            }
            else
            {
                return false;
            }
        }

     
    }
