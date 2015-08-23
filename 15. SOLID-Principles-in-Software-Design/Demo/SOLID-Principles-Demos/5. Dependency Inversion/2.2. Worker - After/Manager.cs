namespace DependencyInversionWorkerAfter
{
    using DependencyInversionWorkerAfter.Contracts;

    public class Manager
    {
        private IWorker worker;

        public Manager(IWorker worker)
        {
            this.worker = worker;
        }

        /// Moje i da niama field worker, a toi da se podava v metoda Manage, no po-sigurnia nachin e da se zadava prez konstruktora, a tozi variant e ako tova proparty se polzva samo za tozi metod
        public void Manage()
        {
            this.worker.Work();
        }
    }
}
