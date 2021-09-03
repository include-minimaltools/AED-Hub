using System;

namespace AEDHub.Models
{
    class PROJECT : STUDENT
    {
        public string ProjectName { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime DateLimit { get; set; }
        public int Score { get; set; }
        public bool isSentLate { get; set; }
    }
}
