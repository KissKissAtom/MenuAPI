namespace MenuAPI.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string TypeMenu { get; set; }
        public string NameMenu { get; set; }
        public string PhraseMenu { get; set; }
        public string Intensite { get; set; }
        public string NameEntree { get; set; }
        public string NamePlat { get; set; }
        public string NameDessert { get; set; }
        public string DescriptionEntree { get; set; }
        public string DescriptionPLat { get; set; }
        public string DescriptionDessert { get; set; }
        public string IngredientsMenu { get; set; }
        public string Image { get; set; }
        
    }
}
