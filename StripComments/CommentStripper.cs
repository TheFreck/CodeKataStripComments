using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace StripComments
{
    public static class CommentStripper
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            var parsedText = text.Split("\n");
            var commentedText = String.Empty;
            foreach (var line in parsedText)
            {
                commentedText += RemoveComments(line, commentSymbols) + "\n";
            }
            return commentedText.TrimEnd();
        }

        public static string RemoveComments(string textInput, string[] commentFlags)
        {
            var flags = String.Empty;
            for (int i = 0; i < commentFlags.Length; i++)
            {
                flags += commentFlags[i];
            }
            return Regex.Replace(textInput, $"[{flags}].*", "").TrimEnd();
        }
    }
}