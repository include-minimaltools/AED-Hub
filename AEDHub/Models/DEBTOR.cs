
namespace AEDHub.Models
{
    class DEBTOR : PERSON
    {
        public int Id { get; set; }
        public double Debt { get; set; }
        public bool isPay { get; set; }
    }
}
