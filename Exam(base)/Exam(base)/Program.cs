using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_base_
{
    class Program
    {
        static void Main(string[] args)
        {
            Bancomat account = new Bancomat(456, "str.Lubarskogo, 65");
            Client client = new Client("Bob", account);
            Management manag = new Management("Tom", account, client);
            Collector collect = new Collector(1, account, manag, client);

            account.Put_money(1000);
            Console.WriteLine("=============================================================================\n\n");
            account.Withdraw(500);
            Console.WriteLine("==============================================================================\n\n");
            account.Withdraw(200);
            Console.WriteLine("===============================================================================\n\n");
            account.Withdraw(300);
            Console.WriteLine("===============================================================================\n\n");
            account.Put_money(500);
            Console.WriteLine("===============================================================================\n\n");
            account.Withdraw(550);

            Console.ReadLine();
        }
    }
}
