namespace LearningDataStorage
{
    public class MessageDialogViewModel
    {
        public MessageDialogViewModel(string messageText)
        {
            MessageText = messageText;
        }

        public string MessageText { get; set; }
    }
}
