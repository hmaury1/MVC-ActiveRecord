using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using Castle.Components.Validator;
using System.Web.Script.Serialization;
using Castle.ActiveRecord.Queries;


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
            set { id = value; }
        }

        [Property]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        [Property]
        [ScriptIgnore]
        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        [Property, ValidateEmail]
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        [ValidateNonEmpty]
        public String MsgError
        {
            get { return msgError; }
            set { msgError = value; }
        }

        public User Authentication() {
            SimpleQuery<User> q = new SimpleQuery<User>(@" from User u where u.Name = :name And u.Password = :password");
            q.SetParameter("name", this.Name);
            q.SetParameter("password", this.Password);
            var list = q.Execute().ToList();
            if (list.Count() > 0) {
                return list[0];
            } else   {
                this.MsgError = "Usuario o contraseña incorrecto";
                return null;            
            }
        }

    }
}