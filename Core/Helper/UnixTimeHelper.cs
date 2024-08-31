namespace uygulama_havuzu_server.Core.Helper {
    public static class UnixTimeHelper {
        public static string ConvertUnixTimeToDateTimeString(long unixTime) {
            var dateTime = DateTimeOffset.FromUnixTimeSeconds((long)unixTime).DateTime;
            return dateTime.ToString("H:mm:ss");
        }
    }
}
