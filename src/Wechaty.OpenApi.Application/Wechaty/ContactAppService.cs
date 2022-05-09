using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Users;
using Wechaty.GrpcClient.Factory;
using Wechaty.Module.Filebox;
using Wechaty.Module.Puppet.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    public class ContactAppService : OpenApiAppService, IContactAppService
    {
        public ContactAppService(IGrpcClientFactory grpcClientFactory,ICurrentUser currentUser)
            :base(grpcClientFactory,currentUser)
        {
           
        }

        public Task<string> ContactAliasAsync(string contactId)
        {
            var response = _grpcClient.ContactAliasAsync(contactId);
            return response;
        }

        public async Task ContactAliasAsync(AliasInput input)
        {
            await _grpcClient.ContactAliasAsync(input.ContactId, input.Alias);
        }

        public async Task<FileBox> ContactAvatarAsync(string contactId)
        {
            var response = await _grpcClient.ContactAvatarAsync(contactId);
            return response;
        }

        public async Task ContactAvatarAsync(string contactId, FileBox file)
        {
            await _grpcClient.ContactAvatarAsync(contactId, file);
        }

        public async Task<List<string>> ContactListAsync()
        {
            var response = await _grpcClient.ContactListAsync();
            return response;
        }

        public async Task<ContactPayload> ContactPayloadAsync(string contactId)
        {
            var payload = await _grpcClient.ContactPayloadAsync(contactId);
            return payload;
        }

        public async Task ContactSelfNameAsync(string name)
        {
            await _grpcClient.ContactSelfNameAsync(name);
        }

        public async Task<string> ContactSelfQRCodeAsync()
        {
            var response = await _grpcClient.ContactSelfQRCodeAsync();
            return response;
        }

        public async Task ContactSelfSignatureAsync(string signature)
        {
            await _grpcClient.ContactSelfSignatureAsync(signature);
        }
    }
}
