﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_base_
{
    class Bancomat
    {
        public event EventHandler<AccountEventArgs> Adding;
        public event EventHandler<AccountEventArgs> Withdrawn;
        public event EventHandler<AccountEventArgs> Balance_Zero;
        public event EventHandler<AccountEventArgs> Min_Balance;
        public event EventHandler<AccountEventArgs> Not_enough_money;


        Logger log = new Logger();
        public int ID { get; set; }
        public string Address { get; set; }
        public decimal Current_amount { get; set; }
        public decimal balance { get; set; } = 100;
        public override string ToString()
        {
            return $"\t Bancomat ID \"{ID}\"\n\t Address :\\{Address}\\\n\t At the cash machine = {Current_amount}$ \n";
        }

        public Bancomat(int id, string address)
        {
            ID = id;
            Address = address;
            Current_amount = 0;
        }
        public Bancomat(int sum)
        {
            Current_amount = sum;
        }
        public void Put_money(int sum)
        {
            Current_amount += sum;
           if (Adding != null) { Adding(this, new AccountEventArgs($"\t  ****************  Replenishment of ATM at {sum}$  ****************\n ", sum, Current_amount)); }
        }
        public void Withdraw(Request req)
        {

            if (Current_amount - req.Sum < 0)
            {
                if (Not_enough_money != null) { Not_enough_money(this, new AccountEventArgs($"\t  ************* Not enough money in the ATM ****************\n\n" + ToString(), Current_amount, req.Sum)); }
            }

            if (Current_amount - req.Sum == 0)
            {
                Current_amount -= req.Sum;
                if (Balance_Zero != null) { Balance_Zero(this, new AccountEventArgs($"\t  -------------  Withdraw {req.Sum}$ -------------\n\n**************** Bancomat is empty ***************\n\n" + ToString(), Current_amount, req.Sum)); }
            }
            if (Current_amount - req.Sum < balance && Current_amount - req.Sum > 0) 
            {
                Current_amount -= req.Sum;
                if (Min_Balance != null) { Min_Balance(this, new AccountEventArgs($"\t  -------------  Withdraw {req.Sum}$ -------------\n\n**************** Balance is less than the minimum ***************\n\n" + ToString(), Current_amount, req.Sum)); }
            }
            if (Current_amount - req.Sum > 0)
            {
                if (Withdrawn != null)
                {
                    Current_amount -= req.Sum;
                    Withdrawn(this, new AccountEventArgs($"\t -------------  Withdraw {req.Sum}$ -------------\n", Current_amount, req.Sum));

                }

            }
        }
    }
}
