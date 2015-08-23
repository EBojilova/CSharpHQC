namespace Flyweight
{
    using System.Collections.Generic;

    using Flyweight.Characters;

    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    internal class CharacterFactory
    {
        private readonly Dictionary<char, Character> characters = new Dictionary<char, Character>();

        public int Counter { get; set; }

        public Character GetCharacter(char key)
        {
            // Uses "lazy initialization"
            Character character = null;
            if (this.characters.ContainsKey(key))
            {
                character = this.characters[key];
            }
            else
            {
                this.Counter++;
                switch (key)
                {
                    case 'A':
                        character = new CharacterA();
                        break;
                    case 'B':
                        character = new CharacterB();
                        break;

                    // TODO: Add all letters from A to Z
                    case 'Z':
                        character = new CharacterZ();
                        break;
                }

                this.characters.Add(key, character);
            }

            return character;
        }
    }
}