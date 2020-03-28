using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public static class StringExtensions
{
    // намира MD5 сумата на низа
    public static string ToMd5Hash(this string input)
    {
        // намиране на самата MD5 сума
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // преобразуваме я към текст
        var builder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }


    // връща дали низа съдържа една от стойностите за "вярно"
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" }; // стойности за "вярно"
        return stringTrueValues.Contains(input.ToLower());
    }

    // преобразува низа в число тип short
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    // преобразува низа в число тип integer
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    // преобразува низа в число тип long
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    // преобразува низа в DateTime
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    // прави първата буква на низа главна
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return 
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + 
            input.Substring(1, input.Length - 1);
    }

    // взима текста между низовете startString и endString, започвайки от позиция startFrom
    public static string GetStringBetween(
        this string input, string startString, string endString, int startFrom = 0)
    {
        // ако не съдържа startString и endString, връща празен низ
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        // намира позицията на startString 
        var startPosition = 
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        // намира позицията на endString 
        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        // отрязва и връща текста между двете
        return input.Substring(startPosition, endPosition - startPosition);
    }

    // преобразува низа от кирилица в шльокавица
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
        var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            // заменя всички малки букви
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            // заменя всички главни букви
            input = input.Replace(bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    // преобразува от латински букви в кирилица
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            // заменя всички малки букви
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            // заменя всички главни букви
            input = input.Replace(latinLetters[i].ToUpper(),
                bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    // преобразува низа във валидно потребителско име (съдържащо само a-z A-Z 0-9 _ .)
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters(); // първо на латиница!
        return Regex.Replace(input, @"[^a-zA-Z0-9_\.]+", string.Empty);
    }

    // преобразува низа във валидно потребителско име (съдържащо само a-z A-Z 0-9 _ . -)
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters(); // първо на латиница!
        return Regex.Replace(input, @"[^a-zA-Z0-9_\.\-]+", string.Empty);
    }

    // връща първите charsCount симовли от низа
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    // връща файловото разширение
    public static string GetFileExtension(this string fileName)
    {
        // ако е празен низ, връща празен
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        // особени случаи на разширение
        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        if (fileParts.Count() == 1 ||                  // ако няма точка
            string.IsNullOrEmpty(fileParts.Last()))    // след точката няма нищо
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    // връща типа на даден файл
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };
        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        // резултат ако не е никое от горните
        return "application/octet-stream";
    }

    // връща низа като масив от байтове
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}
