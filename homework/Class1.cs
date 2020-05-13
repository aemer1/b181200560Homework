using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    public class Customer
    {

        int debt;
        string firstName, surName;
        long PersonalID;


        public void setDebt(int debt)
        {
            this.debt = debt;
        }
        public void setPersonalID(long PersonalID)
        {
            this.PersonalID = PersonalID;
        }

        public int getDebt() { return this.debt; }
        public long getPersonalID() { return PersonalID; }
        public Customer(int debt, string firstName, string surName, long PersonalID)
        {
            this.debt = debt;
            this.firstName = firstName;
            this.surName = surName;
            this.PersonalID = PersonalID;

        }
      
        public string list()
        {
            return (this.firstName + " "+ this.surName + " "+this.debt);

        }
        
       



    }
    }


