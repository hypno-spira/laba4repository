using System;
using System.Linq;
namespace thefirst.Models
{
public class ModelData // Сериалыj
{

    public Guid Id { get; set; } = Guid.Empty;
    public int serial_id { get; set; }
    public string title { get; set; }
    public int year { get; set; }
    public string producer { get; set; }
    public string main_characters { get; set; }
    public BaseModelValidationResult Validate()
    {
        var validationResult = new BaseModelValidationResult();
        if (serial_id < 0) validationResult.Append($"Serial ID cannot be negative");
        if (string.IsNullOrWhiteSpace(title)) validationResult.Append($"Title cannot be empty");
        if (year < 1960 && year > 2020) validationResult.Append($"Year {year} is out of range");
        if (string.IsNullOrWhiteSpace(producer)) validationResult.Append($"Producer cannot be empty"); 
        if (!string.IsNullOrEmpty(producer) && ! char.IsUpper(producer.FirstOrDefault())) validationResult.Append($"Producer {producer} should start from capital letter");
        if (string.IsNullOrWhiteSpace(main_characters)) validationResult.Append($"Main_characters cannot be empty"); 

        return validationResult;
    }
    public override string ToString()

       {
           return $" Serial '{title}' with id {serial_id} was released in {year} by producer {producer}. The main characters are: {main_characters}.";
       }
}

}