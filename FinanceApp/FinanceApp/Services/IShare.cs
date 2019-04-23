using System.Threading.Tasks;

namespace FinanceApp.Services
{
    public interface IShare
    {
        Task Show(string title, string url);
    }
}
