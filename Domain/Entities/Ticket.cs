using System.ComponentModel.DataAnnotations;
using BiletUygulamasi.Domain.ValueObjects;


namespace BiletUygulamasi.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Ad")]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; } = string.Empty;

        [Required, Display(Name = "TC Kimlik No")]
        [TcKimlik]
        public string TcKimlik { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [Display(Name = "Kalkış Yeri")]
        public string Origin { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [Display(Name = "Varış Yeri")]
        public string Destination { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Tarih")]
        public DateTime TravelDate { get; set; }

        // --- Fatura ile ilgili alanlar ---
        public bool IsInvoiced { get; set; } = false;
        public DateTime? InvoicedAt { get; set; }
        public string? InvoiceNumber { get; set; }
    }
}
