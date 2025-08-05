namespace ResturantSystem.Modules
{
    public static class FileManager
    {
        public static void SaveToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        public static string LoadFromFile(string filePath)
        {
            return File.Exists(filePath) ? File.ReadAllText(filePath) : string.Empty;
        }
    }
}

