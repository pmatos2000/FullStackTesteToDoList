namespace Todo.Tests.Mocks
{
    public static class MockConstants
    {
        public const long USER_ID_ONE = 101;
        public const string PASSWORD = "Senha123.";
        public const string HASH_PASSWORD_SUCESS = "$2a$12$OObrKd/R6sFC9VTzfoJckOtXWf9XynPFPuL6r4xobdrg1QGV9L.Ym";

        public const long CATEGORY_ID_ONE = 201;
        public const string CATEGORY_NAME_ONE = "CATEGORY_NAME_UM";
        public const long CATEGORY_ID_TWO = 202;
        public const string CATEGORY_NAME_TWO = "CATEGORY_NAME_TWO";

        public const long TASK_ID_ONE = 301;
        public const string TASK_TITLE_ONE = "TASK_TITLE_ONE";
        public const string TASK_DESCRIPTION_ONE = "TASK_DESCRIPTION_ONE";
        public const bool TASK_IS_COMPLETED_ONE = true;

        public const long TASK_ID_TWO = 302;
        public const long TASK_ID_THREE = 303;

        public static DateTime DATE_CREATED_AT_ONE = DateTime.Now.AddHours(-1);
        public static DateTime DATE_UPDATED_AT_ONE = DateTime.Now;

    }
}
