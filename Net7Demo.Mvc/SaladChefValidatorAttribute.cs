using System.ComponentModel.DataAnnotations;

namespace Net7Demo.Mvc;

public class SaladChefValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var saladChef = validationContext.GetRequiredService<SaladChef>();
        if (saladChef.ThingsYouCanPutInASalad.Contains(value.ToString()))
        {
            return ValidationResult.Success;
        }
        return new ValidationResult("You should not put that in a salad!");
    }
}

// Simple class configured as a service for dependency injection
public class SaladChef
{
    public string[] ThingsYouCanPutInASalad = { "Strawberries", "Pineapple", "Honeydew", "Watermelon", "Grapes" };
}
