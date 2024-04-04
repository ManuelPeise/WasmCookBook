namespace Data.Models.Entities.Logging
{
    public class LogMessageEntity: AEntity
    {
        public int LogMessageId => Id;
        public string Message { get; set; } = string.Empty;
        public string ExceptionMessage { get; set; } = string.Empty;
        public string Stacktrace { get; set; } = string.Empty;
        public string Trigger { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
    }
}
