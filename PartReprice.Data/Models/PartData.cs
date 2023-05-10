namespace PartReprice.Data.Models
{
    /// <summary>
    /// Data model for the Part record.
    /// </summary>
    public class PartData
    {
        /// <summary>
        /// The Part Id unique identifier.  Make into long if more that 65k parts in the system.
        /// </summary>
        public int PartId { get; set; }

        /// <summary>
        /// Short description of the part.
        /// </summary>
        public string PartDesc { get; set; }

        /// <summary>
        /// The price of the part.
        /// </summary>
        public decimal Price { get; set; }
    }
}
