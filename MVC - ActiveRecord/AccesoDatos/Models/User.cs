using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using Castle.Components.Validator;
using Iesi.Collections;
using NHibernate;
using Castle.ActiveRecord.Queries;
using NHibernate.Transform;
using Omu.ValueInjecter;

namespace Models
{
    [ActiveRecord(Table = "user", Schema = "test")]
    public class User : ActiveRecordValidationBase<User>
    {
        private int id;
        private string name;
        private string password;
        private string email;
        
        #region Propiedades 
            private  static ISession Session =     Castle.ActiveRecord.ActiveRecordMediator.GetSessionFactoryHolder().CreateSession(typeof(Castle.ActiveRecord.ActiveRecordBase));

            [PrimaryKey(PrimaryKeyType.Native)]
            public int Id
            {
                get { return id; }
                set
                {
                    id = value;
                }
            }

            [Property]
            public String Name
            {
                get { return name; }
                set
                {
                    if (value != null)
                        name = value;
                }
            }

            [Property]
            public String Password
            {
                get { return password; }
                set
                {
                    if (value != null)
                        password = value;
                }
            }

            [Property, ValidateEmail]
            public String Email
            {
                get { return email; }
                set
                {
                    if (value != null)
                        email = value;
                }
            }
            
        #endregion

        #region crud

            public static Entidades.User Get(int id)
            {
                return ActiveRecordBase<User>.Find(id);
            }

            public static Entidades.User[] Lista()
            {

                return (from record in ActiveRecordBase<User>.FindAll() select (Entidades.User)record).ToArray();
            }

            public static Entidades.User Guardar(Entidades.User UserInstance)
            {
                var instance = (UserInstance.Id == 0 ? (Models.User)UserInstance : (Models.User) ActiveRecordBase<User>.Find(UserInstance.Id).InjectFrom(UserInstance));
                instance.Save();
                return instance;
            }

            public static bool Eliminar(int id)
            {
                ActiveRecordBase<User>.Find(id).Delete();
                return true;
            }

       #endregion
            
        #region Metodos
            public static Entidades.User Authentication(Entidades.User UserInstance)
            {
                var list = new SimpleQuery<User>(@" from User u where u.Name = ? And u.Password = ?", UserInstance.Name, UserInstance.Password).Execute();
                return list.Count() > 0 ? (Entidades.User) list[0] : UserInstance;
            }
        #endregion 

        #region implicit
            public static implicit operator Entidades.User(Models.User UserDal)
            {
                return (Entidades.User)new Entidades.User().InjectFrom(UserDal);
            }

            public static implicit operator User(Entidades.User UserDTO)
            {
                return (Models.User) new Models.User().InjectFrom(UserDTO);
            }
        #endregion
    }
}