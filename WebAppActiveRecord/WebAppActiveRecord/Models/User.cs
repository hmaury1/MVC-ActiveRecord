using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using Castle.Components.Validator;
using System.Web.Script.Serialization;


namespace WebAppActiveRecord.Models
{
    [ActiveRecord(Table = "user", Schema = "test")]
    public class User : ActiveRecordValidationBase<User>
    {
        private int id;
        private string name;
        private string password;
        private string email;
        private string msgError;


        [PrimaryKey(PrimaryKeyType.Native)]
        public int Id
        {
            get { return id; }
            set {
                id = value; 
            }
        }

        [Property]
        public String Name
        {
            get { return name; }
            set {
                if (value != null)
                name = value; 
            }
        }

        [Property]
        [ScriptIgnore]
        public String Password
        {
            get { return password; }
            set {
                if (value != null)
                password = value; 
            }
        }

        [Property, ValidateEmail]
        public String Email
        {
            get { return email; }
            set {
                if (value != null)
                email = value; 
            }
        }

        public String MsgError
        {
            get { return msgError; }
            set { msgError = value; }
        }

        internal void setProperties(User UserInstance)
        {
            this.Name = UserInstance.Name;
            this.Password = UserInstance.Password;
            this.Email = UserInstance.Email;
        }
    }
}