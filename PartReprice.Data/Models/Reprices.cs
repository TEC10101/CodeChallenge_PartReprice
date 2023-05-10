namespace PartReprice.Data.Models
{
    /// <summary>
    /// Data model for New Prices of parts.
    /// </summary>
    public class Reprices
    {
        /// <summary>
        /// The part Id.  Make into long if more than 65k parts.
        /// </summary>
        public int PartId { get; set; }

        /// <summary>
        /// The new price.
        /// </summary>
        public decimal Price { get; set; }
    }
}
