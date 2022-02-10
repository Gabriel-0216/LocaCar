using Domain.DomainMethods.Validator;
using Domain.Dto;

namespace Domain.DomainMethods;

public class CalculateValue : ICalculateValue
{
    public CalculateValueResponse CalculateRentValue(decimal dailyValue, int days)
    {
        decimal value = 0;
        if (days < 0) throw new Exception("Can't calculate a rent for zero days");

        if (dailyValue < 0) throw new Exception("The daily value is less than zero");

        value = dailyValue * days;
        var response = new CalculateValueResponse(value, days);
        return response;
    }

    public decimal CalculateTotalValue(IList<VehicleCalculateDto> vehicles, DateTime startDate, DateTime finishDate)
    {
        decimal value = 0;
        var days = (finishDate - startDate).TotalDays;
        foreach (var item in vehicles)
        {
            var calculateRent = CalculateRentValue(item.DailyValue, Convert.ToInt32(days));
            value += calculateRent.Value;
        }

        return value;
    }
}