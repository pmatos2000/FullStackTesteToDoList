namespace ToDo.Shared.Constants
{
    public static class Messages
    {
        public const string ERRO_SECRET_KEY_NOT_APPSETTINGS = "A chave secreta não está configurada no appsettings.json.";
        public const string ERRO_SECRET_KEY_SIZE = "A chave secreta para o algoritmo: 'HS256' não pode ter menos de: '128' bits.";

        public const string SUCCESS_NEW_USER = "Usuário registrado com sucesso.";
        public const string ERRO_USER_CONFLICT = "Usuário já existe.";

        public const string ERRO_PASSWORD_REQUERED = "A senha é obrigatória.";
        public const string ERRO_PASSWORD_SIZE_MIN = "A senha deve ter pelo menos {0} caracteres.";
        public const string ERRO_PASSWORD_SIZE_MAX = "A senha deve ter no máximo {0} caracteres.";
        public const string ERRO_PASSWORD_CHAR_LOWER = "A senha deve conter pelo menos uma letra minúscula.";
        public const string ERRO_PASSWORD_CHAR_UPPER = "A senha deve conter pelo menos uma letra maiúscula.";
        public const string ERRO_PASSWORD_NUMBER = "A senha deve conter pelo menos um número.";
        public const string ERRO_PASSWORD_CHAR_SPECIAL = "A senha deve conter pelo menos um caractere especial.";

        public const string ERRO_USER_NOT_EXIT = "Usuário não encontrado.";
        public const string ERRO_PASSWORD_INVALID = "Senha inválida.";

        public const string ERRO_INVALID_CREDENTIALS = "Credenciais inválidas.";

        public const string SUCESS_NEW_CATEGORY = "Categoria criada";
        public const string ERRO_CATEGORY_CONFLICT = "Categoria já existente";

        public const string ERRO_OPTIONAL_ID = "O valor deve ser null ou maior que zero.";
    }
}

