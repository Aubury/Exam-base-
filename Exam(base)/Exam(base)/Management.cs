using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_base_
{
    class Management
    {
        Bancomat _bank;
        Client _client;
        public string Name { get; set; }
        public Management(string name, Bancomat b, Client c)
        {
            Name = name;
            _bank = b;
            _client = c;
            //_bank.Adding += _bank_Adding;
            //_bank.Balance_Zero += _bankomat_Balance_Zero;
            //_bank.Withdrawn += _client_Withdrawn;
            //_bank.Min_Balance += _bank_Min_Balance;
            _bank.Adding += _Operations_with_ATM;
            _bank.Balance_Zero += _Operations_with_ATM;
            _bank.Withdrawn += _Operations_with_ATM;
            _bank.Min_Balance += _Operations_with_ATM;
            _bank.Not_enough_money += _Operations_with_ATM;
        }
        private void _Operations_with_ATM(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"\t   ============= Management\"{Name}\" get massage ==============\n\n" + e.Message + "\n" + _bank.ToString());
        }
        //private void _bank_Min_Balance(object sender, AccountEventArgs e)
        //{
        //    Console.WriteLine($"\t   ============= Management\"{Name}\" get massage ==============\n\n" + e.Message + "\n" + _bank.ToString());
        //}

        //private void _bankomat_Balance_Zero(object sender, AccountEventArgs e)
        //{
        //    Console.WriteLine($"\t   ============= Management\"{Name}\" get massage ==============\n\n" + e.Message + "\n" + _bank.ToString());

        //}

        //private void _client_Withdrawn(object sender, AccountEventArgs e)
        //{
        //    Console.WriteLine($"\t  ============ Management\"{Name}\" get massage ==============\n\n" + e.Message + "\n" + _bank.ToString());

        //}

        //private void _bank_Adding(object sender, AccountEventArgs e)
        //{
        //    Console.WriteLine($"\t   ============ Management\"{Name}\" get massage ============= \n\n" + e.Message + "\n" + sender.ToString());

        //}
    }
}
