namespace lunettes.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public int Quantite { get; set; }
        public int ProductsId { get; set; }
        public Products? Products { get; set; }
        public List<Products> ?products { get; set; }

    }
}
