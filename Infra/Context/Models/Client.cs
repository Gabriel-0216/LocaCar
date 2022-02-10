using Infra.Context.Models.ValueObjects;

namespace Infra.Context.Models;

public class Client : BaseEntity
{
    public Client(int id, DateTime birthDate, string firstName, string lastName,
        string phoneNumber, string email, string city, string street, string district, int number,
        string zipCode, string? country)
    {
        SetName(firstName, lastName);
        SetEmail(email);
        SetPhone(phoneNumber);
        SetAddress(city, street, district, number, zipCode, country);
        Id = id;
        BirthDate = birthDate;
    }

    public Client()
    {
        
    }
    
    
    public Name Name { get; set; }
    public DateTime BirthDate { get; set; }
    public Address Address { get; set; }
    public Phone PhoneNumber { get; set; }
    public Email EmailAddress { get; set; }

    private void SetName(string firstName, string lastName)
    {
        Name = new Name(firstName, lastName);
    }

    private void SetPhone(string phoneNumber)
    {
        PhoneNumber = new Phone(phoneNumber);
    }

    private void SetEmail(string email)
    {
        EmailAddress = new Email(email);
    }

    private void SetAddress(string city, string street, string district, int number,
        string zipCode, string? country)
    {
        Address = new Address(city, street, district, number, zipCode, country);
    }

    public IList<Rent> Rents { get; set; } = new List<Rent>();
    public IList<Payment> Payments { get; set; } = new List<Payment>();

}