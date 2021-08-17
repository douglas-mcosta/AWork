using System;
using AWork.Core.DomainObjects;
using AWork.Core.DomainObjects.Enums;

namespace AWork.Candidatos.Domain.Models
{
    //Idiomas do Candidato e seu nível
    public class LanguageCandidate : Entity
    {
        public LanguageCandidate(Guid id, Guid candidateId, Guid languageId, FluencyLevel fluencyLevel)
        {
            Id = id;
            CandidateId = candidateId;
            LanguageId = languageId;
            FluencyLevel = fluencyLevel;
        }

        public Guid CandidateId { get; private set; }
        public Guid LanguageId { get; private set; }
        public virtual FluencyLevel FluencyLevel { get; private set; }
        /* EF Relation */
        public Candidate Candidate { get; private set; }
        public Language Language { get; private set; }

        public void UpdateFluencyLevel(FluencyLevel fluencyLevel)
        {
            FluencyLevel = fluencyLevel;
        }
    }
}