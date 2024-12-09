namespace ToDo.Shared.Util
{
    public static class Password
    {
        private const int WORK_FACTORY = 12;

        public static string PasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, WORK_FACTORY);
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
