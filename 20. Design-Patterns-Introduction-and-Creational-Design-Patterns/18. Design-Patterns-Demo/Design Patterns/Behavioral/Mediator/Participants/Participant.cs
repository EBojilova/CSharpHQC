namespace Mediator.Participants
{
    using System;

    using Mediator.ChatRooms;

    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    internal class Participant
    {
        private readonly string name;

        public Participant(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public AbstractChatRoom ChatRoom { get; set; }

        // Sending trough Chat Room
        public void Send(string to, string message)
        {
            this.ChatRoom.Send(this.name, to, message);
        }

        // Receiving from Chat Room Send method-see above
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, this.Name, message);
        }
    }
}
