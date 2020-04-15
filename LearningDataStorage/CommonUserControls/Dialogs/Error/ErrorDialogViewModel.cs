namespace LearningDataStorage
{
    public class ErrorDialogViewModel
    {
        public ErrorDialogViewModel(string errorText)
        {
            ErrorText = errorText;
        }

        public string ErrorText { get; set; }
    }
}
