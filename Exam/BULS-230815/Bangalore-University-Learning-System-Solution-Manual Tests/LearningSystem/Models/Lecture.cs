namespace LearningSystem.Models
{
    using LearningSystem.Utilities;

    public class Lecture
    {
        private const int MinNameLength = 3;

        private string name;

        public Lecture(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validations.ValidateArgumentLenght(value, "lecture name", MinNameLength);

                this.name = value;
            }
        }
    }
}