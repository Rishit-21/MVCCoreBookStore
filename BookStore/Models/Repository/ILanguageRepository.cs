using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Models.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}