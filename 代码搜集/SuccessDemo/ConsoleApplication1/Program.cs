using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //线程
            #region 不带参数无返回值
            Thread t1 = new Thread(Method1);
            t1.Start();
            Thread t2 = new Thread(Method2);
            t2.Start("param");

            //t1.Join();
            //t2.Join();
            #endregion

            Console.WriteLine("结束！");
            Console.ReadLine();
        }

        static void Method1()
        {
            Thread.Sleep(1000);
            Console.WriteLine("线程{0}：结束", Thread.CurrentThread.ManagedThreadId);
        }
        static void Method2(object obj)
        {
            Thread.Sleep(2000);
            Console.WriteLine(obj);
            Console.WriteLine("线程{0}：结束", Thread.CurrentThread.ManagedThreadId);
        }
        static string Method3(object obj)
        {
            Thread.Sleep(3000);
            Console.WriteLine(obj);
            Console.WriteLine("线程{0}：结束", Thread.CurrentThread.ManagedThreadId);
            return obj.ToString();
        }
    }
}
