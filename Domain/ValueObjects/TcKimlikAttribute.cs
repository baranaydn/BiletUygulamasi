using System.ComponentModel.DataAnnotations;

namespace BiletUygulamasi.Domain.ValueObjects
{
    public sealed class TcKimlikAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var s = value?.ToString()?.Trim();
            if (string.IsNullOrEmpty(s) || s.Length != 11)
                return new ValidationResult("TC Kimlik No 11 haneli olmalıdır.");
            if (!ulong.TryParse(s, out _))
                return new ValidationResult("TC Kimlik No sadece rakamlardan oluşmalıdır.");
            if (s[0] == '0')
                return new ValidationResult("TC Kimlik No 0 ile başlayamaz.");

            int[] d = s.Select(c => c - '0').ToArray();
            int d10 = (((d[0] + d[2] + d[4] + d[6] + d[8]) * 7) - (d[1] + d[3] + d[5] + d[7])) % 10;
            if (d10 < 0) d10 += 10;
            int d11 = (d.Take(10).Sum()) % 10;

            if (d[9] != d10 || d[10] != d11)
                return new ValidationResult("Geçersiz TC Kimlik No.");

            return ValidationResult.Success!;
        }
    }
}
