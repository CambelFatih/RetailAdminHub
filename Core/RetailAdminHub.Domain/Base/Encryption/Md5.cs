namespace RetailAdminHub.Domain.Base.Encryption;

public static class Md5
{
    public static string Create(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes).ToLower();

        }
    }

    public static bool IsHashed(string input)
    {
        // Check if the input is a valid MD5 hash (32 hexadecimal characters)
        if (input.Length != 32)
            return false;

        foreach (char c in input)
        {
            if (!Char.IsDigit(c) && (c < 'a' || c > 'f'))
                return false;
        }

        return true;
    }

    public static string Control(string input)
    {
        if (!IsHashed(input))
        {
            // Hash the input if it's not already hashed
            input = Create(input);
        }

        // Save the hashed password to the database
        // databaseSaveMethod(input);

        return input;
    }
}