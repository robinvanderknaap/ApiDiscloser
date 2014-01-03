namespace ApiDiscloser.Example.Models
{
    /// <summary>
    /// Orderline
    /// </summary>
    public class OrderLine
    {
        /// <summary>
        /// Description of the product or service
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Amount of orderline
        /// </summary>
        public decimal Amount { get; set; }
    }
}