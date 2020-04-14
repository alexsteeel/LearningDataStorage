using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;

namespace LearningDataStorage
{
    public class Dialog
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
    }
}
