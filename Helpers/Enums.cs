namespace Helpers
{
    public class Enumerators
    {
        public enum ProfileType
        {
            Admin = 1,
            User = 2
        }

        public enum UserFields
        {
            Name = 1,
            Email = 2,
            Password = 3
        }

        public enum SessionFields
        {
            Token = 1,
            CreatedDate = 2,
            ExpirationDate = 3
        }

        public enum RandomKeys
        {
            Galaxy = 1,
            Surreptitious = 2,
            Whimsical = 3,
            Pulchritudinous = 4,
            Ubiquitous = 5
        }
    }
}