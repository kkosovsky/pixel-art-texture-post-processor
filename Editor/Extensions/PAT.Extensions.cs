namespace PAT
{
    static class PAT_Extensions
    {
        internal static bool ContainsAnySubstring(this string self, string[] substrings)
        {
            if (substrings == null || substrings.Length == 0)
            {
                return false;
            }

            foreach (string substring in substrings)
            {
                if (!string.IsNullOrEmpty(substring) && self.Contains(substring))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
