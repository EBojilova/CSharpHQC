namespace Flyweight
{
    using System;

    internal class FlyweightMain
    {
        internal static void Main()
        {
            // Build a document with text
            const string Document = "AAZZBBZB";
            var chars = Document.ToCharArray();

            var factory = new CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                var character = factory.GetCharacter(c);
                character.Display(pointSize);
            }

            // Ste se otpechata 3, tai kato e lazy inicialization i samo 3 vida bukvi(A,B,Z) imame v celia string AAZZBBZB
            Console.WriteLine(factory.Counter);

            // Wait for user
            Console.ReadKey();
        }
    }
}
