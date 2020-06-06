using System.Threading.Tasks;

namespace CsharLibrary.Data_Process
{
    public interface IApiManagement
    {
        Task<string> GetHttpUrl(string url);

        string GetPattern();

    }
}