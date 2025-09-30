using System.ComponentModel.DataAnnotations;

namespace AutoOglasi.Models
{
    public enum Gorivo
    {
        [Display(Name = "Benzin")] Benzin,
        [Display(Name = "Dizel")] Dizel,
        [Display(Name = "TNG (plin)")] LPG,
        [Display(Name = "CNG")] CNG,
        [Display(Name = "Hibrid")] Hibrid,
        [Display(Name = "Električni")] Elektro
    }

    public enum Karoserija
    {
        [Display(Name = "Hečbek")] Hatchback,
        [Display(Name = "Sedan")] Sedan,
        [Display(Name = "Karavan")] Karavan,
        [Display(Name = "Kupe")] Kupe,
        [Display(Name = "Kabriolet")] Kabriolet,
        [Display(Name = "SUV")] SUV,
        [Display(Name = "MPV (monovolumen)")] MPV,
        [Display(Name = "Pickup")] Pickup
    }


    public class Automobil
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Marka { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Model { get; set; } = string.Empty;

        [Display(Name = "Godište")]
        [Range(1950, 2100, ErrorMessage = "Unesi realnu godinu (1950–2100).")]
        public int Godiste { get; set; }

        [Display(Name = "Zapremina motora (cm³)")]
        [Range(100, 10000, ErrorMessage = "Unesi zapreminu 100–10000 cm³.")]
        public int? ZapreminaMotora { get; set; }

        [Display(Name = "Snaga (KS)")]
        [Range(1, 2000)]
        public int? Snaga { get; set; }

        [Required]
        public Gorivo Gorivo { get; set; }

        [Required, Display(Name = "Karoserija")]
        public Karoserija Karoserija { get; set; }

        [Display(Name = "Opis")]
        [StringLength(2000)]
        public string? Opis { get; set; }

        [Required, DataType(DataType.Currency)]
        [Range(0, 100000000)]
        public decimal Cena { get; set; }

        [Required, Display(Name = "Kontakt")]
        [StringLength(100)]
        public string Kontakt { get; set; } = string.Empty;
    }
}
