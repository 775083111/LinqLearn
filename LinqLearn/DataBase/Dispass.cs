using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqLearn.DataBase
{
    public class Dispass
    {
        //保护区不允许保留提交了
        public static int addtion(int x, int y)
        {
            return x + y;
        }
        public void substraction(double x, double y)
        {
            Console.WriteLine("Action不带返回参数委托做减法结果为:{0}", x - y);
        }

    }
}