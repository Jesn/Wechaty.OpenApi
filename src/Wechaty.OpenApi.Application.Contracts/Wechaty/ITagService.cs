using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Wechaty.OpenApi.Wechaty
{
    public interface ITagService: IApplicationService
    {
        Task TagContactAddAsync(string tagId, string contactId);
        Task TagContactDeleteAsync(string tagId);
        Task<List<string>> TagContactListAsync(string contactId);
        Task<List<string>> TagContactListAsync();
        Task TagContactRemoveAsync(string tagId, string contactId);
    }
}
