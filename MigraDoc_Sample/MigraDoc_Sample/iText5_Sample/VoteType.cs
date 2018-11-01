namespace iText5_Sample
{
    class VoteType
    {
        public static string Provisional = "Provisional";
        public static string Mail = "Mail";
        public static string Early = "Early";
        public static string PollingPlace = "Polling Place";

        
        public VoteType(string provisional, string mail, string early, string pollingplace)
        {
            Provisional = provisional;
            Mail = mail;
            Early = early;
            PollingPlace = pollingplace;
        }
    }
}
