using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Web.Mvc;
using LinqLearn.DataBase;

namespace LinqLearn.Controllers
{
    public class HomeController : Controller
    {
        MyDataContext ctx = new MyDataContext();

        public ActionResult Index()
        {
            ViewData["TableTest"] =Select();
            Insert();
            Update();
            Delete();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Select()
        {
            string str_a = "";
            var query1 = from p in ctx.UserLoginLogs
                             //  where q.UserName == "789" //条件查询
                                where p.UserName.Contains("78")    //模糊查询
                                where p.TimeStamp.Contains("98") && p.IP == "11.11.11.11"    //多条件查询 
                         select p;
            foreach (var _user in query1)
            {
                str_a += _user.ID.ToString();
            }
            return str_a;
        }
        private void Insert() {
            //插入数据
            UserLoginLog ull = new UserLoginLog {
                User_ID = "a100",
                UserName = "Kim",
                IP = "20190312",
                TimeStamp =Guid.NewGuid().ToString("N").Substring(0,12)
            };
            ctx.UserLoginLogs.InsertOnSubmit(ull);
            ctx.SubmitChanges();
        }

        private void Update() {
            //更新数据
            var query1 = (from q in ctx.UserLoginLogs
                          where q.UserName == "789"
                          select q).SingleOrDefault();
            //判断query1是否为空，若不为空，则修改IP。
            if (query1 != null)
            {
                query1.IP = "123.124.125.254";
                ctx.SubmitChanges();
            }
        }
        private void Delete() {
            //删除数据
            var userloginlog = from u in ctx.UserLoginLogs where u.ID == 89 select u;
            ctx.UserLoginLogs.DeleteAllOnSubmit(userloginlog);
            ctx.SubmitChanges();
        }
    }
}