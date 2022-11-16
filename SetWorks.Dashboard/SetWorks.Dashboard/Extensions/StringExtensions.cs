namespace SetWorks.Dashboard.Extensions
{

    //This could also be called a DateTimeExtension.  I'm sure some folks have a definite answer!
    public static class StringExtensions
    {
        public static DateTime FromYYYYMMDD(this string yyyyMMdd)
        {
            //Should this be a const?  (probably)
            string[] format = { "yyyyMMdd" };
            DateTime date;

            if (DateTime.TryParseExact(yyyyMMdd,
                                       format,
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.None,
                                       out date))
            {
                return date;
            }
            else
            {
                throw new ArgumentException("Invalid datetime format, must be yyyyMMdd");
            }
        }
    }
}
