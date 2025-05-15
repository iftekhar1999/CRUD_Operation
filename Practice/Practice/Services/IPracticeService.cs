using Practice.Model;

namespace Practice.Services
{
    public interface IPracticeService
    {
        List<practice> GetAllPrac(bool? isActive);

        practice? GetPractice(int id);
        practice AddPractice(update_practice obj);
        practice? UpdatePractice(int id, update_practice obj);
        bool DeletePractice(int id);
    }
}
