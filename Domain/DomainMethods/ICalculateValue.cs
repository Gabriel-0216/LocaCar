using Domain.DomainMethods.Validator;
using Domain.Dto;

namespace Domain.DomainMethods;

public interface ICalculateValue
{
    decimal CalculateTotalValue(IList<VehicleCalculateDto> vehicles, DateTime startDate, DateTime finishDate);
}