using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wechaty.Module.Filebox;
using Wechaty.Module.Puppet.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public interface IContactAppService: IApplicationService
    {
        Task<ContactPayload> ContactPayloadAsync(string contactId);
        Task<string> ContactAliasAsync(string contactId);
        Task ContactAliasAsync(string contactId, string? alias);
        Task<FileBox> ContactAvatarAsync(string contactId);
        Task ContactAvatarAsync(string contactId, FileBox file);
        Task<List<string>> ContactListAsync();
        Task ContactSelfNameAsync(string name);
        Task<string> ContactSelfQRCodeAsync();
        Task ContactSelfSignatureAsync(string signature);
    }
}
