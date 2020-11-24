using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Extensions
{
  public static class Extensions
  {
    #region ToUrlSlug
    /// <summary>
    /// String veriyi url formatında geçerli bir stringe dönüştürür
    /// </summary>
    /// <returns>Slug String'i Döndürür.</returns>
    public static string ToUrlSlug(this string text)
    {
      return Regex.Replace(Regex.Replace(Regex.Replace(text.Trim().ToLower().Replace(" ", "-").Replace("ö", "o").Replace(".", "").Replace("ç", "c").Replace("ş", "s").Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u"), @"\s+", " "), @"\s", ""), @"[^a-z0-9\s-]", "");
    }

    public static string SplitPhoneMask(this string text)
    {
      return text.Replace("(", "").Replace(")", "").Replace(" ", "");
    }

    public static string ToUniqueSlug(this string text)
    {
      var date = DateTime.Now;
      text = text + "-" + date.Year + date.Month + date.Day + date.Minute;
      text = text.ToUrlSlug();
      return text;
    }

    #endregion

    #region IsNumeric
    /// <summary>
    /// Bir değerin sayısal olup olmadığını kontrol eder.
    /// </summary>
    /// <returns>bool</returns>
    public static bool IsNumeric(this string theValue)
    {
      long retNum;
      return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
    }
    #endregion

    #region ToJson
    /// <summary>
    /// Nesneyi json stringe çevirir
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>Json String</returns>
    public static string ToJson(this object obj)
    {
      return JsonConvert.SerializeObject(obj);
    }
    #endregion

    #region FromJson
    /// <summary>
    /// Json string'i nesneye çevirir.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jsn"></param>
    /// <returns></returns>
    public static T FromJson<T>(this string jsn)
    {
      return JsonConvert.DeserializeObject<T>(jsn);
    }
    #endregion

    #region IsValidEmailAddress
    /// <summary>
    /// Bir string'in email adresi olup olmadığını kontrol eder.
    /// </summary>
    /// <param name="s"></param>
    /// <returns>bool</returns>
    public static bool IsValidEmailAddress(this string s)
    {
      try
      {
        var temp = new MailAddress(s);

        string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        var regex = new Regex(validEmailPattern, RegexOptions.IgnoreCase);

        if (!regex.IsMatch(s))
        {
          return false;
        }

      }
      catch
      {
        return false;
      }
      return true;
    }
    #endregion

    #region IsNullOrEmpty For Lists
    /// <summary>
    /// Bir listenin boş ve ya null olduğunu kontrol eder.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T>(this IList<T> items)
    {
      return items == null || !items.Any();
    }
    #endregion

    #region Parser
    /// <summary>
    /// String türünü bir değer türüne Parse yapmayı dener yapamzsa null değer döndürür.
    /// 'Nullable' değerler geçerlidir.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T Parse<T>(this string value)
    {
      T result = default(T);
      if (!string.IsNullOrEmpty(value))
      {
        TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
        result = (T)tc.ConvertFrom(value);
      }
      return result;
    }
    #endregion

    #region Age
    /// <summary>
    /// Doğum tarihinden yaşını hesaplar.
    /// </summary>
    /// <param name="dateOfBirth"></param>
    /// <returns></returns>
    static public int Age(this DateTime dateOfBirth)
    {
      if (DateTime.Today.Month < dateOfBirth.Month ||
      DateTime.Today.Month == dateOfBirth.Month &&
       DateTime.Today.Day < dateOfBirth.Day)
      {
        return DateTime.Today.Year - dateOfBirth.Year - 1;
      }
      else
        return DateTime.Today.Year - dateOfBirth.Year;
    }
    #endregion

    #region IsValidUrl
    /// <summary>
    /// String 'URL' formatında ise true değer döndürür
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsValidUrl(this string text)
    {
      if (!string.IsNullOrEmpty(text))
      {
        Regex rx = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        return rx.IsMatch(text);
      }
      else
      {
        return false;
      }
    }
    #endregion

    #region Elapsed
    /// <summary>
    /// Bugüne kadar geçen süreyi verir.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static TimeSpan Elapsed(this DateTime input)
    {
      return DateTime.Now.Subtract(input);
    }
    #endregion

    #region ToMD5
    /// <summary>
    /// String Veriyi MD5 Hash Değerini Üretir.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToMd5Hash(this string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        return value;
      }

      using (MD5 md5 = new MD5CryptoServiceProvider())
      {
        byte[] originalBytes = ASCIIEncoding.Default.GetBytes(value);
        byte[] encodedBytes = md5.ComputeHash(originalBytes);
        return BitConverter.ToString(encodedBytes).Replace("-", string.Empty);
      }
    }
    #endregion

    #region StripHTML
    public static string ToClearHtmlTags(this string text)
    {
      string textOnly = string.Empty;

      if (!string.IsNullOrEmpty(text))
      {
        Regex tagRemove = new Regex(@"<[^>]*(>|$)");
        Regex compressSpaces = new Regex(@"[\s\r\n]+");
        textOnly = tagRemove.Replace(text, string.Empty);
        textOnly = compressSpaces.Replace(textOnly, " ");
        textOnly = Regex.Replace(textOnly, @"<[^>]+>|&nbsp;", "").Trim();
      }

      return textOnly;
    }
    #endregion

    #region IEnumerable Extensions
    public static T PickRandom<T>(this IEnumerable<T> source)
    {
      return source.PickRandom(1).Single();
    }

    public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
    {
      return source.Shuffle().Take(count);
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
      return source.OrderBy(x => Guid.NewGuid());
    }
    #endregion

    public static string FirstCharToUpper(this string input)
    {
      switch (input)
      {
        case null: throw new ArgumentNullException(nameof(input));
        case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
        default: return input.First().ToString().ToUpper() + input.Substring(1);
      }
    }

  }
}
