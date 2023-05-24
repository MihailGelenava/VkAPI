namespace VkAPI.Utils
{
    public static class RandomGenerate
    {
        private static Random rd => new Random();

        private static readonly string englishCapitalAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string englishAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string russianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private static readonly string russianCapitalAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private static readonly string digits = "0123456789";

        public static string GetRandomString(int len)
        {
            string permissibleCharacters = $"{englishCapitalAlphabet}{englishAlphabet}{russianAlphabet}{russianCapitalAlphabet}{digits}";
            string result = "";
            for (int i = 0; i < len; i++)
            {
                result += permissibleCharacters[rd.Next(permissibleCharacters.Length)];
            }
            return result;
        }
    }
}
