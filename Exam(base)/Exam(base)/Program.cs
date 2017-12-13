//Методы:
//для пополнения и снятия денег

//События:
//- денег меньше определенного порога
//- попытка снять больше, чем есть остаток

//Обработчики событий:
//- отправка уведомления менеджменту
//- отправка уведомления в службу инкассации
//- отображение информации на дисплее(только в случае нехватки денег)

//Обработчики событий должны быть условными - только вывод на консоль соотв текста.
//Текст должен содержать номер и адрес банкомата, сумму денег на остатке - эти данные должны приходить как параметры событий


//Логгирование. 
//Реализовать класс Logger c методом WriteLine(string). Этот метод должен сохранять полученную строку в файл.
//Использовать Logger в классе Банкомат для логгирования любых операций со счетом.

//Переделать метод GetMoney банкомата на получение в качестве параметра, экземпляра класса Request.
//Класс Request может быть таким, например:
//public class Request
//{
//    public string ClientName;
//    public int Sum;
//}

//В этом случае, его сериализация в JSON будет такая: {"ClientName":"John Smith","Sum":850} . Для сериализации использовать NewtonSoft.Json

//Управление счетом будет осуществлятся посредством поступающих запросов в виде файлов.
//Применить FileWatcher для контроля над определенной папкой.При попадани в эту папку (Входящие) файла, являющегося сериализацией объекта Request,
//списывать деньги со счета.Успешно обработанные файлы перемещать в папку Обработанные.Файлы, не содержащие корректной сериализации Request,
//перемещать в папку Ошибки.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Exam_base_
{
    class Program
    {
        static void Main(string[] args)
        {
            Bancomat account = new Bancomat(456, "str.Lubarskogo, 65");
            Collector collect = new Collector(1, account);
            account.Put_money(1000);
            Console.WriteLine("=============================================================================\n\n");
            do
            {
                Console.WriteLine("Input you name: ");
                string Name = Console.ReadLine();

                Client client = new Client(Name, account);
                Management manag = new Management("Tom", account, client);

                Console.WriteLine("How much you want to withdraw?");
                int summ = Int32.Parse(Console.ReadLine());

                Request req = new Request();
                req.ClientName = client.Name;
                req.Sum = summ;
                //Newtonsoft.Json.Linq.JObject obj = Newtonsoft.Json.Linq.JObject.Parse(req.ClientName+req.Sum);
                string json = JsonConvert.SerializeObject(req, Formatting.Indented);
                account.Withdraw(summ);



            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
                
            
            
           
            //Console.WriteLine("==============================================================================\n\n");
            //account.Withdraw(200);
            //Console.WriteLine("===============================================================================\n\n");
            //account.Withdraw(300);
            //Console.WriteLine("===============================================================================\n\n");
            //account.Put_money(500);
            //Console.WriteLine("===============================================================================\n\n");
            //account.Withdraw(550);

            Console.ReadLine();
        }
    }
}
