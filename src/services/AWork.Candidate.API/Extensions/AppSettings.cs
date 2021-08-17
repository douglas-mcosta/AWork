namespace AWork.Candidatos.API.Extensions
{
    public class AppSettings
    {
        public APIs APIs { get; set; }
        public AppConfig AppConfig { get; set; }
        public string MaximumNumberPhoneByCandidate { get; set; }

    }

    public class APIs
    {
        public string IdentityUrl { get; set; }
        public string CandidateUrl { get; set; }
    }
    public class AppConfig
    {
        public int MaximumNumberPhoneByCandidate { get; set; }
        public int MaximumNumberJobTitleInterestedByCandidate { get; set; }
    }
}
