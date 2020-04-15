using System.Threading.Tasks;

namespace LearningDataStorage
{
    public interface IDialog
    {
        void Alert(string alertText);

        Task<bool> Answer(string answerText);

        void Error(string errorText);

        void Message(string messageText);
    }
}