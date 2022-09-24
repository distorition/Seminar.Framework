using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar
{
    public class ConnectionString
    {
        public string Host { get; set; }
        public string DataBaseName { get; set; }
        public string UserName { get; set; }    
        public string Password { get; set; }

        public override string ToString()//делаем это чтобы можео было вывести потом эти данные в консоль
        {
            return $"Host:{Host},DataBaseName:{DataBaseName},UserName:{UserName},Password:{Password}";
        }
    }
}
