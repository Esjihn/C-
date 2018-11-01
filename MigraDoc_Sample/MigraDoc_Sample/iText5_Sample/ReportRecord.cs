using System.Collections.Generic;
using CsvHelper.Configuration;

namespace iText5_Sample
{
    public class ReportRecord
    {
        public string ContestId { get; set; }
        public string Contest { get; set; }
        public string CandidateIssueId { get; set; }
        public string CandidateIssue { get; set; }
        public string Party { get; set; }
        public string PrecinctCode { get; set; }
        public string PrecinctName { get; set; }
        public string EarlyVotes { get; set; }
        public string MailVotes { get; set; }
        public string ElectionDayVotes { get; set; }
        public string ProvisionalVotes { get; set; }
        public string TotalVotes { get; set; }
        public string VotePercent { get; set; }
    }

    public sealed class ReportRecordMap : ClassMap<ReportRecord>
    {

        public readonly List<string> PropertyNames = new List<string>();
        public readonly List<string> Headers = new List<string>();
        
        public ReportRecordMap(bool combinesPrecincts, ElectionOptions options)
        {
            // TODO reinstate variables after tests. 
            //var precinct = Localization.Resources.Precinct;
            //var voteByMail = Localization.Resources.ReportsVBM;
            //var provisional = Localization.Resources.Provisional;
            var testString = "ok123";
            var precinct = testString;
            var voteByMail = testString;
            var provisional = testString;

            {
                var header = "Contest ID";
                Map(m =>
                    m.ContestId).Name(header);
                PropertyNames.Add(nameof(ReportRecord.ContestId));
                Headers.Add(header);
            }
            {
                var header = "Contest";
                Map(m =>
                    m.Contest).Name(header);
                PropertyNames.Add(nameof(ReportRecord.Contest));
                Headers.Add(header);
            }
            {
                var header = "Candidate Issue ID";
                Map(m =>
                    m.CandidateIssueId).Name(header);
                PropertyNames.Add(nameof(ReportRecord.CandidateIssueId));
                Headers.Add(header);
            }
            {
                var header = "Candidate Issue";
                Map(m =>
                    m.CandidateIssue).Name(header);
                PropertyNames.Add(nameof(ReportRecord.CandidateIssue));
                Headers.Add(header);
            }
            {
                var header = "Party";
                Map(m =>
                    m.Party).Name(header);
                PropertyNames.Add(nameof(ReportRecord.Party));
                Headers.Add(header);
            }
            if (!combinesPrecincts)
            {
                {
                    var header = $"{precinct} Code";
                    Map(m =>
                        m.PrecinctCode).Name(header);
                    PropertyNames.Add(nameof(ReportRecord.PrecinctCode));
                    Headers.Add(header);
                }
                {
                    var header = $"{precinct} Name";
                    Map(m =>
                        m.PrecinctName).Name(header);
                    PropertyNames.Add(nameof(ReportRecord.PrecinctName));
                    Headers.Add(header);
                }
            }

            if (options.DisplayDetailResults)
            {
                if (options.VoteTypesUsed.Contains(VoteType.Provisional))
                {
                    var header = $"{provisional} Votes";
                    Map(m =>
                        m.ProvisionalVotes).Name(header);
                    PropertyNames.Add(nameof(ReportRecord.ProvisionalVotes));
                    Headers.Add(header);
                }

                if (options.VoteTypesUsed.Contains(VoteType.Mail))
                {
                    var header = voteByMail;
                    Map(m =>
                        m.MailVotes).Name(header);
                    PropertyNames.Add(nameof(ReportRecord.MailVotes));
                    Headers.Add(header);
                }

                if (options.VoteTypesUsed.Contains(VoteType.Early))
                {
                    var header = "Early Votes";
                    Map(m =>
                        m.EarlyVotes).Name(header);
                    PropertyNames.Add(nameof(ReportRecord.EarlyVotes));
                    Headers.Add(header);
                }

                if (options.VoteTypesUsed.Contains(VoteType.PollingPlace))
                {
                    var header = "Election Day Votes";
                    Map(m =>
                        m.ElectionDayVotes).Name(header);
                    PropertyNames.Add(nameof(ReportRecord.ElectionDayVotes));
                    Headers.Add(header);
                }
            }

            {
                var header = "Total Votes";
                Map(m =>
                    m.TotalVotes).Name(header);
                PropertyNames.Add(nameof(ReportRecord.TotalVotes));
                Headers.Add(header);
            }
            {
                var header = "% of Total Votes";
                Map(m =>
                    m.VotePercent).Name(header);
                PropertyNames.Add(nameof(ReportRecord.VotePercent));
                Headers.Add(header);
            }
        }
    }
}
