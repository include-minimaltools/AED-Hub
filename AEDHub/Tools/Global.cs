using System;
using System.Collections.Generic;

namespace AEDHub.Tools
{
    static class Global
    {
        public static Queue<string> ServicesClients { get; set; } = new Queue<string>();
        public static Queue<string> CashClients { get; set; } = new Queue<string>();
        public static Stack<string> Path { get; set; } = new Stack<string>();
        public static List<Exception> Log { get; set; } = new List<Exception>();
    }
}
