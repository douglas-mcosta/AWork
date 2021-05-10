using AWork.Core.Messages;
using System;

namespace AWork.Candidates.API.Application.Events
{
    public class UpdatedGoalCandidateEvent : Event
    {
        public Guid CandidateId { get; private set; }
        public string Goal { get; private set; }

        public UpdatedGoalCandidateEvent(Guid candidateId, string goal)
        {
            AggregateId = candidateId;
            CandidateId = candidateId;
            Goal = goal;
        }
    }
}
