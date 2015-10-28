using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPattern.Singleton
{
    /// <summary>
    /// Sealed LoadBalancer class to ensure it is not overridden
    /// </summary>
    public sealed class LoadBalancer
    {
        #region Singleton variables

        private static LoadBalancer instance;
        private static object syncLock = new object();

        #endregion
        
        #region Private variables

        private List<string> servers;
        private Random random = new Random();        

        #endregion

        //Make default constructor private so that no one can initialize it from outside
        private LoadBalancer()
        {
            //Perform initialization operations
            servers = new List<string>();
            for(int i = 0; i < 3; i++)
            {
                servers.Add(string.Format(CultureInfo.InvariantCulture, "Server_{0}", i));
            }
        }

        //Design a static method or property to return the single class instance.
        public static LoadBalancer Instance
        {
            get
            {
                if(instance == null)
                {
                    lock(syncLock)
                    {
                        if (instance == null)
                            instance = new LoadBalancer();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Business logic implementation
        /// </summary>
        public string Server
        {
            get
            {
                //Here random.next(maxcount) takes into consideration that iterations start from 0.
                int index = random.Next(servers.Count);
                return servers[index];
            }
        }
    }
}
