namespace Transaction.Framework.Domain
{
    using Transaction.Framework.Types;

    public class FileResult
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string UserId { get; set; }
        public UserResult User { get; set; }
    }
}
