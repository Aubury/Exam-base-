using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_base_
{
    class Client
    {
        Logger log = new Logger();
        Bancomat _bank;
        public string Name { get; set; }
        public Client(string name, Bancomat b)
        {
            Name = name;
            _bank = b;

            _bank.Withdrawn += _bank_Withdrawn;
            _bank.Not_enough_money += _try_Withdrawn;
        }

        private void _bank_Withdrawn(object sender, AccountEventArgs e)
        {
            log.WriteLine($"\t---------------Client\"{Name}\"---- Withdrawn : {e.OperationSum}$------------ \n");

        }
        private void _try_Withdrawn(object sender, AccountEventArgs e)
        {
            log.WriteLine($"\t---------------Client\"{Name}\"---- tries to withdraw money : {e.OperationSum}$------------ \n");

        }

    }
}
