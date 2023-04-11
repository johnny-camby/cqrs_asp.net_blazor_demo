namespace DataLayer.CQRS.Customers.Commands
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string CustId { get; set; } = string.Empty;

    }
}
