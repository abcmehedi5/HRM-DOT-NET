namespace REVISION_DOT_NET.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; } = 0;
    }
}
