namespace AdvFullstack_Labb1.Services.Shared
{
    public static class BookingHelper
    {
        public static DateTime RoundStartTime(DateTime startTime)
        {
            var roundedStartTime = new DateTime(
                startTime.Year,
                startTime.Month,
                startTime.Day,
                startTime.Hour,
                0,
                0,
                startTime.Kind);

            return roundedStartTime;
        }
    }
}
