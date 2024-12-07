namespace ToDo.Shared.Constants
{
    public static class Messages
    {
        public const string ERRO_SECRET_KEY_NOT_APPSETTINGS = "A chave secreta não está configurada no appsettings.json.";
        public const string ERRO_SECRET_KEY_SIZE = "A chave secreta para o algoritmo: 'HS256' não pode ter menos de: '128' bits.";

        public const string SUCCESS_NEW_USER = "Usuário registrado com sucesso.";
        public const string ERRO_USER_CONFLICT = "Usuário já existe.";

    }
}

