using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;

namespace LearningDataStorage
{
    public class Dialog : IDialog
    {
        public async Task<bool> Answer(string answerText)
        {
            var view = new AnswerDialog
            {
                DataContext = new AnswerDialogViewModel(answerText)
            };

            var result = await DialogHost.Show(view, "RootDialog");

            return (bool)result;
        }

        public async void Message(string messageText)
        {
            var view = new MessageDialog
            {
                DataContext = new MessageDialogViewModel(messageText)
            };

            await DialogHost.Show(view, "RootDialog");
        }

        public async void Alert(string alertText)
        {
            var view = new AlertDialog
            {
                DataContext = new AlertDialogViewModel(alertText)
            };

            await DialogHost.Show(view, "RootDialog");
        }

        public async void Error(string errorText)
        {
            var view = new ErrorDialog
            {
                DataContext = new ErrorDialogViewModel(errorText)
            };

            await DialogHost.Show(view, "RootDialog");
        }
    }
}
