namespace SDRBL.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Address1 { get; set; }       
        public string Address2 { get; set; }            
        public string City { get; set; }
        public int StateId { get; set; }
        public string PostalCode { get; set; }
        public int PropertyId { get; set; }
        public StateDTO State { get; set; }
    }
}
