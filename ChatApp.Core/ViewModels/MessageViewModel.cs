namespace ChatApp.Core.ViewModels
{
    public class MessageViewModel
    {
        public string Content { get; set; }
        public string Timestamp { get; set; }
        public string From { get; set; }
        public string FromEmail { get; set; }
        public string To { get; set; }
        public string Avatar { get; set; }
    }
}
