namespace uygulama_havuzu_server.Core.Helper {
    public static class UnixTimeHelper {
        public static string UnixTimeToDateTime(long unixTime) {
            var dateTime = DateTimeOffset.FromUnixTimeSeconds((long)unixTime).DateTime;
            return dateTime.ToString("H:mm:ss");
        }
    }
}
