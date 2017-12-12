using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_base_
{
    class Client
    {
        Bancomat _bank;
        public string Name { get; set; }
        public Client(string name, Bancomat b)
        {
            Name = name;
            _bank = b;

            _bank.Withdrawn += _bank_Withdrawn;

        }

        private void _bank_Withdrawn(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"\t---------------Client\"{Name}\"---- Withdrawn : {e.OperationSum}$------------ \n");

        }

        public void Message(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"\t--------------Client\"{Name}\"---- Withdrawn : {e.OperationSum}$--------------- \n");

        }

    }
}
