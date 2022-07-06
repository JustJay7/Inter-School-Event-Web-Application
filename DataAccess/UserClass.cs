using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserClass
    {
        protected string _UserEmail;
        protected string _UserPassword;
        protected string _CurrentPassword;
        protected string _NewPassword;

        public string UserEmail
        {
            get
            {
                return _UserEmail;
            }
            set
            {
                _UserEmail = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return _UserPassword;
            }
            set
            {
                _UserPassword = value;
            }
        }

        public string CurrentPassword
        {
            get
            {
                return _CurrentPassword;
            }
            set
            {
                _CurrentPassword = value;
            }
        }
        public string NewPassword
        {
            get
            {
                return _NewPassword;
            }
            set
            {
                _NewPassword = value;
            }
        }
        public virtual int LoginCheck()
        {
            return 0;
        }
        public virtual int ChangePassword()
        {
            return 0;
        }

        public virtual bool CheckEmail()
        {
            return false;
        }
    }
}
