using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EShop.Core.Helpers
{
    public static class RandomHelper
    {
        public static string Numeric(int charSize)
        {
            var number = new byte[255];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            var chars = Convert.ToBase64String(number);
            var source = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            var builder = new StringBuilder();
            foreach (var ch in chars.Where(x => source.Contains(x)))
            {
                builder.Append(ch);
                if (charSize <= builder.Length)
                    break;
            }

            return builder.ToString();
        }
        
        public static string Character(int charSize)
        {
            var number = new byte[255];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            var chars = Convert.ToBase64String(number);
            var source = new[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'Y', 'Z', 'W', 'X',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'u', 'v', 'y', 'z', 'w', 'x'
            };
            var builder = new StringBuilder();
            foreach (var ch in chars.Where(x => source.Contains(x)))
            {
                builder.Append(ch);
                if (charSize <= builder.Length)
                    break;
            }

            return builder.ToString();
        }
        
        public static string Mixed(int charSize)
        {
            var number = new byte[255];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            var chars = Convert.ToBase64String(number);
            var source = new[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'Y', 'Z', 'W', 'X',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'u', 'v', 'y', 'z', 'w', 'x',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
            var builder = new StringBuilder();
            foreach (var ch in chars.Where(x => source.Contains(x)))
            {
                builder.Append(ch);
                if (charSize <= builder.Length)
                    break;
            }

            return builder.ToString();
        }
    }
}