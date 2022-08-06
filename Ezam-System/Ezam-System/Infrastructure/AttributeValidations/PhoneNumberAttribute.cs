using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Ezam_System.Infrastructure.AttributeValidations
{
    public class PhoneNumberAttribute : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            bool isValid = false;

            if (value is string phoneNumber)
            {
                string firstPattern = @"^(0|\+359)(88|89|87)[0-9]{7}$";
                string secondPattern = @"^02[0-9]{7}$";

                var firstPatternRegex = new Regex(firstPattern);
                var secondPatternRegex = new Regex(secondPattern);

                if (!firstPatternRegex.IsMatch(phoneNumber) && !secondPatternRegex.IsMatch(phoneNumber))
                {
                    return isValid;
                }
                isValid = true;

            }

            return isValid;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Номера не е правилен , трябва да започва с (02/+359/088/089/088), Пример: 0882232323 или +359885757575";
        }


    }
}
