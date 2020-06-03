using System.Threading.Tasks;

namespace TrainingCshar.Data_Process
{
    public interface IGestionApi
    {
        Task<string> GetHttpUrl(string url);
    }
}