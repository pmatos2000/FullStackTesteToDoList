namespace ToDo.Shared.Constants
{
    public static class ErrorMessage
    {
        public const string SECRET_KEY_NOT_APPSETTINGS = "A chave secreta não está configurada no appsettings.json.";
        public const string SECRET_KEY_SIZE = "A chave secreta para o algoritmo: 'HS256' não pode ter menos de: '128' bits.";
    }
}
