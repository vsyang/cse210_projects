public class FinesCalculator
{
    //private decimal _finePerDay; // The fine amount per day for late returns.

    public FinesCalculator()
    {
        //_finePerDay = finePerDay;
    }

    // public decimal CalculateLateReturnFine(DateTime dueDate, DateTime actualReturnDate)
    // {
    //     if (dueDate >= actualReturnDate)
    //     {
    //         return 0; // No fine if returned on or before the due date.
    //     }

    //     // Calculate the number of days late.
    //     int daysLate = (int)(actualReturnDate - dueDate).TotalDays;

    //     // Calculate the total fine amount.
    //     decimal fine = _finePerDay * daysLate;
    //     return fine;
    // }

    public decimal CalculateLostBookFine(decimal bookPrice)
    {
        bookPrice = 13;
        return bookPrice;
    }
}
