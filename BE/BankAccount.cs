using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //struct to represent BankAccount
    public struct BankAccount
    {
        //properties in BankAaccount
        public int AccountNumber { get; set; }
        public int BankNumber { get; set; }
        public String BankName { get; set; }
        public int BankBranch { get; set; }
        public Address BankAdress { get; set; }
        public string CityOfBranch { get; set; }
        //ToString returns string with the info about the account
        public override string ToString()
        {
            string result = "Bank Account details:\n";
            result += "---------------------\n";
            result += string.Format("Bank Number:{0}\n", BankNumber);
            result += string.Format("Bank Branch:{0}\n", BankBranch);
            result += string.Format("City Of Branch:{0}\n", CityOfBranch);
            result += string.Format("Bank Adress:{0}\n", BankAdress.ToString());
            result += string.Format("Accout number: {0}\n", AccountNumber);
            return result;
        }
    }
}
