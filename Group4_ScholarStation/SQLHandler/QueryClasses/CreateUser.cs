using DataAccessControler;
using SQLHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.QueryClasses
{
    class CreateUser : ICreateUser
    {
        private IRead reader;
        private IUpdate update;

        public CreateUser()
        {
            this.reader = new ConnectionControler();
            this.update = new ConnectionControler();
        }

       public string Create_User(string firstName, string lastName, string email, string password)
        {
            string checkIfExist = "Select * from users Where user_email = '" + email + "'";
            if (reader.DataReader(checkIfExist).HasRows)
            {
                return "User account email already exist!";
            }
            else
            {
                string addUser = "INSERT INTO users  (user_email , user_password , user_type, user_fname, user_lname) " + 
                                 "VALUES('" + email + "','" + password + "','" + '1' + "','" + firstName + "','" + lastName + "')";
                update.ExecuteQueries(addUser);
                return addUser;
            }
        }
    }
}
