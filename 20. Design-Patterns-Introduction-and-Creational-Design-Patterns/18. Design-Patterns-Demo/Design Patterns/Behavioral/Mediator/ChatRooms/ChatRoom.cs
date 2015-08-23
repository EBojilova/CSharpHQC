namespace Mediator.ChatRooms
{
    using System.Collections.Generic;

    using Mediator.Participants;

    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
    internal class ChatRoom : AbstractChatRoom
    {
        private readonly Dictionary<string, Participant> participants = new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!this.participants.ContainsValue(participant))
            {
                this.participants[participant.Name] = participant;
            }

            participant.ChatRoom = this;
        }

        public override void Send(string from, string to, string message)
        {
            if (!this.participants.ContainsKey(to))
            {
                return;
            }

            var participant = this.participants[to];
            participant.Receive(from, message);
        }
    }
}