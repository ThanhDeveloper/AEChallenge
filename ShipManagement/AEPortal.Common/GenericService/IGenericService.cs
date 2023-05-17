using AEPortal.Common.Models;

namespace AEPortal.Common.GenericService
{
    public interface IGenericService<ViewModel, SearchModel, ReponseModel> where ViewModel : class where SearchModel : BaseSearchViewModel where ReponseModel : class
    {
        Task<ReponseModel> GetByIdAsync(int id);
        Task<PageList<ReponseModel>> Search(SearchModel searchModel);

        Task<int> AddAsync(ViewModel model);
        Task<int> UpdateAsync(int id, ViewModel model);

        Task RemoveAsync(int id);
        Task RemoveRangeAsync(IEnumerable<int> id);
    }
}
