using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda1
{
    class Usuario
    {
        public string nombre;
        public string email;
        public string tel;

        public Usuario(string name = "", string mail = "", string phone = "")
        {
            nombre = name;
            email = mail;
            tel = phone;
        }
    }
}
