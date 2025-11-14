namespace BeeBuzz.Data.Entities
{
    public class Beehive
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public bool Status { get; set; }

        public string ReasonForDeactivation { get; set; }
    }
}
