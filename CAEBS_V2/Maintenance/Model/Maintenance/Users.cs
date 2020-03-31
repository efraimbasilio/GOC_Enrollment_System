using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEBS_V2
{
    class Users
    {
        protected int id;
        protected int username;
        protected int password;
        protected int user_type;
        protected int fname;
        protected int lname;
        protected int mname;
        protected int emp_id;

        public int Id { get { return id; } set { id = value; } }
        public int Username { get { return username; } set { username = value; } }
        public int Password { get { return password; } set { password = value; } }
        public int User_type { get { return user_type; } set { user_type = value; } }
        public int Fname { get { return fname; } set { fname = value; } }
        public int Lname { get { return lname; } set { lname = value; } }
        public int Mname { get { return mname; } set { mname = value; } }
        public int Emp_id { get { return emp_id; } set { emp_id = value; } }



    }
}
