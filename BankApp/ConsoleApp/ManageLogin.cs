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
            "Manager",
            "ITWorker",
        };
        public Worker _userLogin { get; private set; }
        public string Type { get; private set; } = null;

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
            if (_userLogin is ITWorker itWorker)
            {
                if (itWorker.manager) {
                    Type = types[1];
                }
                else
                {
                    Type = types[2];
                }
            }
        }
    }
}
