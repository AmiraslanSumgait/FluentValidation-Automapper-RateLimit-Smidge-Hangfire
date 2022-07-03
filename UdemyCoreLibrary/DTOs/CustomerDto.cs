namespace FluentValidationApp.Web.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string FullName { get; set; }
        public string Number { get; set; }
        public DateTime ValidDate { get; set; }
        //public string CreditCardNumber { get; set; } CreditCard class, Number property
        // public DateTime CreditCardValidDate { get; set; } CreditCard class,ValidDate property
    }
}
