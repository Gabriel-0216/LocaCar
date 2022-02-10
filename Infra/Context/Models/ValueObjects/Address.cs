using Flunt.Notifications;

namespace Infra.Context.Models.ValueObjects;

public class Address : Notifiable<Notification>
{
    public Address()
    {
        
    }

    public Address(string city, string street, string district, int number, string zipCode, string? country)
    {
        if(string.IsNullOrWhiteSpace(city)) AddNotification(city, "City empty");
        if(string.IsNullOrWhiteSpace(street)) AddNotification(street, "Street empty");
        if(string.IsNullOrWhiteSpace(district)) AddNotification(district, "district empty");
        if(string.IsNullOrWhiteSpace(zipCode)) AddNotification(zipCode, "ZipCode empty");
        
        if(city.Length > 50) AddNotification(city, "Length greater than 50 characters");
        if(district.Length > 50) AddNotification(district, "Length greater than 50 characters");
        if(zipCode.Length > 50) AddNotification(zipCode, "Length greater than 50 characters");
        if(country is not null && country.Length > 50) AddNotification(country, "Length greater than 50 characters");


        City = city;
        Street = street;
        District = district;
        Number = number;
        ZipCode = zipCode;
        Country = country;
    }

    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public int Number { get; set; }
    public string ZipCode { get; set; } = string.Empty;
    public string? Country { get; set; }
    
}