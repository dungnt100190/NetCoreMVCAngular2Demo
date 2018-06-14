namespace DataLibrary.DataModel
{
    using System.ComponentModel.DataAnnotations;

    public partial class Contact
    {
        public int ContactId { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }
    }
}
