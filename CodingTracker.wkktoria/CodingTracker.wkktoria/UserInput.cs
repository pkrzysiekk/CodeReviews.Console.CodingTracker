using System.Globalization;

namespace CodingTracker.wkktoria;

public static class UserInput
{
    public static DateTime GetDateTimeInput(string forWhat)
    {
        string dateTimeInput;

        do
        {
            Console.Write($"Enter date for {forWhat} (format: dd-mm-yy hh:mm): ");

            dateTimeInput = Console.ReadLine();

            if (!Validation.ValidateDateTime(dateTimeInput)) Console.WriteLine("Invalid date format.");
        } while (!Validation.ValidateDateTime(dateTimeInput));

        return DateTime.ParseExact($"{dateTimeInput}:00", "dd-MM-yy HH:mm:ss", CultureInfo.InvariantCulture,
            DateTimeStyles.None);
    }

    public static int GetNumberInput(string forWhat)
    {
        string numberInput;

        do
        {
            Console.Write($"Enter number for {forWhat}: ");

            numberInput = Console.ReadLine();

            if (!int.TryParse(numberInput, out _) || int.Parse(numberInput) <= 0) Console.WriteLine("Invalid number.");
        } while (!int.TryParse(numberInput, out _) || int.Parse(numberInput) <= 0);

        return int.Parse(numberInput);
    }
}