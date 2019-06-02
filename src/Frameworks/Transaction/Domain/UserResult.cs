namespace Transaction.Framework.Domain
{
    using System.Collections.Generic;
    using Transaction.Framework.Types;

    public class UserResult
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<FileResult> Files { get; set; }
    }
}
