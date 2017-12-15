using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_base_
{
    class Collector
    {
        Logger log = new Logger();
        Bancomat _bank;
        public int ID_Collector { get; set; }
        public Collector(int id, Bancomat b)
        {
            ID_Collector = id;
            _bank = b;

            _bank.Balance_Zero += _The_ATM_needs_attention;
            _bank.Min_Balance += _The_ATM_needs_attention;
            _bank.Not_enough_money += _The_ATM_needs_attention;
        }
        private void _The_ATM_needs_attention(object sender, AccountEventArgs e)
        {
           log.WriteLine($"\t  ================  Collector \"{ID_Collector}\" get massege!==============\n\n" + e.Message + "\n" + _bank.ToString());
        }
      
    }
}
