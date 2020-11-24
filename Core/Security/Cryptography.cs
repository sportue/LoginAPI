using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Core.Security
{
  public class Cryptography
  {
    private const string key = "06053501";
    public string EncryptString(string plainText)
    {
      byte[] pass = Encoding.Unicode.GetBytes(key);
      RijndaelManaged rijndaelCipher = new RijndaelManaged();
      MemoryStream memoryStream = new MemoryStream();
      ICryptoTransform rijndaelEncryptor = rijndaelCipher.CreateEncryptor(pass, pass);
      CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelEncryptor, CryptoStreamMode.Write);
      byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);
      cryptoStream.Write(plainBytes, 0, plainBytes.Length);
      cryptoStream.FlushFinalBlock();
      byte[] cipherBytes = memoryStream.ToArray();
      memoryStream.Close();
      cryptoStream.Close();
      string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);
      return cipherText;
    }
    public string DecryptString(string cipherText)
    {
      byte[] pass = Encoding.Unicode.GetBytes(key);
      RijndaelManaged rijndaelCipher = new RijndaelManaged();
      MemoryStream memoryStream = new MemoryStream();
      ICryptoTransform rijndaelDecryptor = rijndaelCipher.CreateDecryptor(pass, pass);
      CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelDecryptor, CryptoStreamMode.Write);
      string plainText = String.Empty;
      try
      {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
        cryptoStream.FlushFinalBlock();
        byte[] plainBytes = memoryStream.ToArray();
        plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
      }
      finally
      {
        memoryStream.Close();
        cryptoStream.Close();
      }
      return plainText;
    }
    public static string StringToBase64(string Text)
    {
      if (Text.Length > 0)
      {
        var temp = Encoding.UTF8.GetBytes(Text);
        Text = Convert.ToBase64String(temp);
      }
      return Text;
    }
    public static string Base64ToString(string Text)
    {
      if (Text.Length > 0)
      {
        var temp = Convert.FromBase64String(Text);
        Text = Encoding.UTF8.GetString(temp);
      }
      return Text;
    }

    public static string GenerateKey(int passwordLength)
    {
      var chars = "ABCDEFGHIJKLMNOPRSTUVYZ0123456789";
      var random = new Random();
      var generatedPassword = new string(
          Enumerable.Repeat(chars, passwordLength)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());

      return generatedPassword;
    }
  }
}
