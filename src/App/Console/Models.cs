namespace SimpleBanking.ConsoleApp
{
    public static class Models
    {

        public class TransactionInput
        {
            public TransactionType  TransactionType { get; set; }
            public decimal Amount { get; set; }
        }

        public class TransactionResult
        {
            public int? AccountNumber { get; set; }
            public bool IsSuccessful { get; set; }
            public decimal? Balance { get; set; }
            public string Currency { get; set; }
            public string Message { get; set; }
        }

        public class SecurityToken
        {
            public string auth_token { get; set; }
        }

        public class Login
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        public class User
        {
            public int Id { get; set; }
            public string Fname { get; set; }
            public string Lname { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public enum TransactionType
        {
            Balance =0,
            Deposit = 1,
            Withdrawal = 2
        }
    }
}
