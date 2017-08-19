using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace WebApiSandbox.Repository
{
    public class SessionFactoryProvider
    {
        private static readonly object LockObject = new object();
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if(_sessionFactory == null)
                {
                    lock (LockObject)
                    {
                        if (_sessionFactory == null)
                            _sessionFactory = Build();
                    }
                }
                return _sessionFactory;
            }
        }

        private static string CurrentSessionContextClass
        {
            get
            {
                return
                    !string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["CurrentSessionContextClass"])
                    ? System.Configuration.ConfigurationManager.AppSettings["CurrentSessionContextClass"]
                    : "web";
            }
        }

        /// <summary>
        /// Creates the SessionFactory with all required configurations specific to database
        /// </summary>
        /// <returns>
        /// The SessionFactory object.
        /// </returns>
        public static ISessionFactory Build()
        {
            //Create New Configuration
            var configuration = new Configuration();
            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionString = ConnectionString.Get();
                db.Driver<MySqlDataDriver>();
                db.Dialect<MySQLDialect>();
                db.LogSqlInConsole = true; //Shows SQL query when running unit tests
                db.LogFormattedSql = true; //Formats SQL query for readablity
            })
            .SessionFactory();

            //Configure the Current Session Context
            configuration.SetProperty("current_session_context_class", CurrentSessionContextClass);

            //Add Model Mappings
            //configuration.AddMapping()

            return configuration.BuildSessionFactory();
        }

        /// <summary>
        /// Gets the current session
        /// </summary>
        /// <returns>
        /// The current session
        /// </returns>
        public static ISession GetCurrentSession()
        {
            try
            {
                //If there is no session bound to the currend session context, bind it!!
                if (!CurrentSessionContext.HasBind(SessionFactory))
                    CurrentSessionContext.Bind(SessionFactory.OpenSession());

                return SessionFactory.GetCurrentSession();
            }
            catch
            {
                //If error is thrown, unbind the old session and bind a new one!!
                CurrentSessionContext.Unbind(SessionFactory);
                CurrentSessionContext.Bind(SessionFactory.OpenSession());

                return SessionFactory.GetCurrentSession();
            }
        }

        /// <summary>
        /// Begins a database transaction
        /// </summary>
        /// <remarks>
        /// You will need to implement Action Filter to begin and use one transaction per action.
        /// ActionFilterAttribute - OnActionExecuting is and ideal place to call this method.
        /// </remarks>
        public static void BeginTransaction()
        {
            GetCurrentSession().BeginTransaction();
        }

        /// <summary>
        /// Commits a database transaction
        /// </summary>
        /// <remarks>
        /// You will need to implement Action Filter to begin and use one transaction per action.
        /// ActionFilterAttribute - OnActionExecuting is and ideal place to call this method.
        /// </remarks>
        public static void CommitTransaction()
        {
            using(var session = CurrentSessionContext.Unbind(SessionFactory))
            {
                if (session == null) return;
                if (session.Transaction == null) return;
                if (!session.Transaction.IsActive) return;
                session.Transaction.Commit();
            }
        }

        /// <summary>
        /// Force the database transaction to rollback
        /// </summary>
        /// <remarks>
        /// You will need to implement Action Filter to begin and use one transaction per action.
        /// ActionFilterAttribute - OnActionExecuting is and ideal place to call this method.
        /// </remarks>
        public static void RollbackTransaction()
        {
            using(var session = CurrentSessionContext.Unbind(SessionFactory))
            {
                if (session == null) return;
                if (session.Transaction == null) return;
                if (!session.Transaction.IsActive) return;
                session.Transaction.Rollback();
            }
        }
    }
}
