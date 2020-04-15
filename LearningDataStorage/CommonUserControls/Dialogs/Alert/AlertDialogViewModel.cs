namespace LearningDataStorage
{
    public class AlertDialogViewModel
    {
        public AlertDialogViewModel(string alertText)
        {
            AlertText = alertText;
        }

        public string AlertText { get; set; }
    }
}
