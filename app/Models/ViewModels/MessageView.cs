namespace app.Models.ViewModels
{
    /// <summary>
    /// DTO модель сообщения 
    /// </summary>
    public class MessageView
    {        
        public string Text { get; set; }

        public string UserName { get; set; }

        public override string ToString() => $"{UserName}: {Text}";
    }
}
