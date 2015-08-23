namespace Mediator
{
    using System;

    using Mediator.ChatRooms;
    using Mediator.Participants;

    internal class MediatorMain
    {
        internal static void Main()
        {
            var chatRoom = new ChatRoom();

            // There are lots of Users, Which do not know for each other. The connection between them is through Chat Room
            Participant george = new Beetle("George");
            Participant paul = new Beetle("Paul");
            Participant ringo = new Beetle("Ringo");
            Participant john = new Beetle("John");
            Participant yoko = new NonBeetle("Yoko");

            chatRoom.Register(george);
            chatRoom.Register(paul);
            chatRoom.Register(ringo);
            chatRoom.Register(john);
            chatRoom.Register(yoko);

            yoko.Send(john.Name, "Hi John!");
            paul.Send(ringo.Name, "All you need is love");
            ringo.Send(george.Name, "My sweet Lord");
            paul.Send(john.Name, "Can't buy me love");
            john.Send(yoko.Name, "My sweet love");
        }
    }
}
