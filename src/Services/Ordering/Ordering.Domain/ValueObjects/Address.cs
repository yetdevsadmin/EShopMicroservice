
namespace Ordering.Domain.ValueObjects; 

public record Address
{
    public string FixtureName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? EmailAddress { get; set; } = default!;
    public string AddressLine { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string State { get; set; } = default!;
    public string ZipCode { get; set; } = default!;

    protected Address() 
    { 
    }

    private Address(string fixtureName, string lastName, string? emailAddress, string addressLine, string country, string state, string zipCode)
    {
        FixtureName = fixtureName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public static Address of(string fixtureName, string lastName, string? emailAddress, string addressLine, string country, string state, string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);
      
        return new Address(fixtureName, lastName, emailAddress, addressLine, country, state, zipCode);
    }
}
