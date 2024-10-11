namespace AdventureF24;
using System.Text.RegularExpressions;

public static class SemanticTools
{
    public static string CreateArticle(string word)
    {
        string article = "a";
        bool startsWithVowel = Regex.IsMatch(word, @"^[aeiouAEIOU]");
        if (startsWithVowel)
            article = "an";
        return article;
    }
}