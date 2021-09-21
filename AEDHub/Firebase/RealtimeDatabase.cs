using AEDHub.Models;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEDHub.Firebase
{
    public static class RealtimeDatabase
    {
        private static IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "Sxi9dABdSVpOIxLT2DYrkbpwWLOj06jU039LTqy0",
            BasePath = "https://aedhub-default-rtdb.firebaseio.com/"
        };

        private static FirebaseClient Database = new FirebaseClient(fcon);

        public static Queue<string> CashClients
        {
            get => Database.Get("clients/cash").ResultAs<Queue<string>>() ?? new Queue<string>();
            set => new FirebaseClient(fcon).Set("clients/cash", value);
        }

        public static Queue<string> ServicesClients
        {
            get => Database.Get("clients/services").ResultAs<Queue<string>>() ?? new Queue<string>();
            set => Database.Set("clients/services", value);
        }

        public static ASSISTED_CLIENTS AssistedClients
        {
            get => Database.Get("clients/assisted").ResultAs<ASSISTED_CLIENTS>() ?? new ASSISTED_CLIENTS();
            set => Database.Set("clients/assisted", value);
        }
    }
}
