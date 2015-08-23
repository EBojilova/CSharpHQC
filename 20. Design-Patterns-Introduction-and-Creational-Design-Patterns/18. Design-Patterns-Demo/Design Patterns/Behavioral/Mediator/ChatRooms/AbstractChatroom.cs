namespace Mediator.ChatRooms
{
    using Mediator.Participants;

    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>
    internal abstract class AbstractChatRoom
    {
        public abstract void Register(Participant participant);

        public abstract void Send(string from, string to, string message);
    }
}
