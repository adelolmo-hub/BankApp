using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class ManageLogin
    {
        private static readonly List<string> types = new List<string>
        {
            "Admin",
            "Worker",
            "ITWorker",
        };
        private Worker _userLogin;
        public string Type {  get; private set; }

        public ManageLogin(Worker userLogin)
        {
            this._userLogin = userLogin;
            getTypeOfUser();
        }

        private void getTypeOfUser()
        {
            if (_userLogin.Id == 0)
            {
                Type = types[0];
            }
            else if (_userLogin is ITWorker)
            {
                Type = types[2];
            }
            else 
            {
                Type = types[1];
            }
        }
    }
}
