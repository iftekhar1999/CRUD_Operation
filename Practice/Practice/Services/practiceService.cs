using Practice.Model;

namespace Practice.Services
{
    public class practiceService : IPracticeService
    {
        private readonly List<practice> _practiceList;
        public practiceService()
        {
            _practiceList = new List<practice>()
            {
                new practice(){
                Id = 1,
                FirstName = "Test",
                LastName = "",
                isActive = true,
                }
            };
        }

        public List<practice> GetAllPrac(bool? isActive)
        {
            return isActive == null ? _practiceList : _practiceList.Where(prac => prac.isActive == isActive).ToList();
        }

        public practice? GetPractice(int id)
        {
            return _practiceList.FirstOrDefault(prac => prac.Id == id);
        }

        public practice AddPractice(update_practice obj)
        {
            var addprac = new practice()
            {
                Id = _practiceList.Max(prac => prac.Id) + 1,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                isActive = obj.isActive,
            };

            _practiceList.Add(addprac);

            return addprac;
        }

        public practice? UpdatePractice(int id, update_practice obj)
        {
            var practiceIndex = _practiceList.FindIndex(index => index.Id == id);
            if (practiceIndex > 0)
            {
                var prac = _practiceList[practiceIndex];

                prac.FirstName = obj.FirstName;
                prac.LastName = obj.LastName;
                prac.isActive = obj.isActive;

                _practiceList[practiceIndex] = prac;

                return prac;
            }
            else
            {
                return null;
            }
        }
        public bool DeletePractice(int id)
        {
            var practiceIndex = _practiceList.FindIndex(index => index.Id == id);
            if (practiceIndex >= 0)
            {
                _practiceList.RemoveAt(practiceIndex);
            }
            return practiceIndex >= 0;
        }
    }
}
