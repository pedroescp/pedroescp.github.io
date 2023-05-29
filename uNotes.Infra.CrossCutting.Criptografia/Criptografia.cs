using Microsoft.Extensions.Configuration;
using uNotes.Infra.CrossCutting.Enums;
using System.Security.Cryptography;
using System.Text;

namespace uNotes.Infra.CrossCutting.Criptografia;

public static class Criptografia
{
    private static string PasswordHash = string.Empty;
    private static string SaltKey = string.Empty;
    private static string VIKey = string.Empty;
    public static string Encrypt(string plainText, TipoCriptografia tipoCriptografia)
    {
        ObterChavesCriptografia(tipoCriptografia);

        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
        var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

        byte[] cipherTextBytes;

        using (var memoryStream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                cipherTextBytes = memoryStream.ToArray();
                cryptoStream.Close();
            }
            memoryStream.Close();
        }
        return Convert.ToBase64String(cipherTextBytes);
    }

    public static string Decrypt(string encryptedText, TipoCriptografia tipoCriptografia)
    {
        ObterChavesCriptografia(tipoCriptografia);

        byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
        byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

        var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
        var memoryStream = new MemoryStream(cipherTextBytes);
        var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        byte[] plainTextBytes = new byte[cipherTextBytes.Length];

        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
    }

    private static void ObterChavesCriptografia(TipoCriptografia tipoCriptografia)
    {
        var config = Configuracoes.Configuracoes.Conf;
        var key = tipoCriptografia.ToString();
        PasswordHash = config.GetSection("Criptografia").GetSection(key).GetValue<string>("PasswordHash");
        SaltKey = config.GetSection("Criptografia").GetSection(key).GetValue<string>("SaltKey");
        VIKey = config.GetSection("Criptografia").GetSection(key).GetValue<string>("VIKey");
    }
}
