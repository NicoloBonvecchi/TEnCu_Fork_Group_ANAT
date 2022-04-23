using System.IO;
using UnityEngine.Events;

namespace Startup.Local
{
    public class TextManager
    {
        public static string LoadLocalTextFromFile(string path, UnityAction onFileNotPresent = null)
        {
            if (File.Exists(path))
                return File.ReadAllText(path);
            onFileNotPresent?.Invoke();
            return "";
        }
        public static void SaveTextToFile(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
}