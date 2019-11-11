namespace DevIct.PublicMeetings.Back.Data.Models
{
    /// <summary>
    /// Represents a physical address.
    /// </summary>
    public struct Address
    {
        /// <summary>
        /// The street portion of the address.
        /// </summary>
        public string? AddressOne { get; set; }

        /// <summary>
        /// The second line of the address.
        /// </summary>
        public string? AddressTwo { get; set; }

        /// <summary>
        /// The name of the city the address is in.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// The name of the state the address is in.
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// The zip code containing the address.
        /// </summary>
        public string? Zip { get; set; }
    }
}
