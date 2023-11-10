namespace Grouplab_Bank
{
    internal class Bank
    {
        public List<User> Users { get; set; }


        public Bank()
        {
            Users = new List<User>();

            var user = new User("admin", "123", true);
            Users.Add(user);

        }

        public void Run()
        {
            Console.WriteLine("Nu kör vi :) ");
        }

    }
}
