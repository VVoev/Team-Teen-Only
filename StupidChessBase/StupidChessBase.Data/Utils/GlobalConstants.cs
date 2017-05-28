namespace StupidChessBase.Utils
{
    public class GlobalConstants
    {
        public const string ErrorMessageForStringLength = "The {0} must be between {1} than {2} characters long";

        public const string NameValidationPattern = @"^[A-Z]+[a-zA-Z''-'\s]*$";

        public const string NameValidationError = "First name can contain only alphabetical characters and first letter should be uppercase";
    }
}