using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wechaty.Module.Filebox;
using Wechaty.Module.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public interface IContactAppService: IApplicationService
    {
        Task<ContactPayload> ContactPayloadAsync(string contactId);
        Task<string> ContactAliasAsync(string contactId);
        Task ContactAliasAsync(AliasInput input);
        Task<FileBox> ContactAvatarAsync(string contactId);
        Task ContactAvatarAsync(string contactId, FileBox file);
        Task<List<string>> ContactListAsync();
        Task ContactSelfNameAsync(string name);
        Task<string> ContactSelfQRCodeAsync();
        Task ContactSelfSignatureAsync(string signature);
    }
}
