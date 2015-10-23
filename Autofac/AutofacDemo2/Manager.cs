namespace AutofacDemo2
{
    public class Manager
    {
        private IPerson person;
        private ILog log;

        public Manager(IPerson person,ILog log)
        {
            this.person = person;
            this.log = log;
        }

        public void Say()
        {
            person.Say();
            log.Log();
        }
    }
}