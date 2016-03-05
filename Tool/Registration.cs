using System;

namespace Tool {

    public class Registration {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int? BibNumber { get; set; }
        public int RaceDayAge { get; set; }
        public string Gender { get; set; }
        public string EventName { get; set; }
        public string RaceName { get; set; }
        public string DivisionName { get; set; }
        public decimal TotalFee { get; set; }
        public DateTime RegistrationDate { get; set; }


    }
}
