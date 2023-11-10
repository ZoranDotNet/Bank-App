namespace Grouplab_Bank
{
    internal class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool Admin { get; set; } = false;
        public int FailedLogin { get; set; } = 0;
        public bool IsLocked { get; set; } = false;
        public List<BankAccount>? BankAccounts { get; set; }


        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            BankAccounts = new List<BankAccount>();
        }

        public User(string username, string password, bool admin)
        {
            Username = username;
            Password = password;
            Admin = admin;
            BankAccounts = new List<BankAccount>();
        }

    }
}
