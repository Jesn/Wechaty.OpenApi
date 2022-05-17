using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Wechaty.Module.Filebox;
using Wechaty.Module.Schemas;

namespace Wechaty.OpenApi.Wechaty
{
    [Area(OpenApiRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = OpenApiRemoteServiceConsts.RemoteServiceName)]
    [Route("api/contact")]
    public class ContactController : OpenApiController, IContactAppService
    {

        private IContactAppService _contactAppService;
        public ContactController(IContactAppService contactAppService)
        {
            _contactAppService = contactAppService;
        }

        [HttpGet]
        [Route("alias")]
        public Task<string> ContactAliasAsync(string contactId)
        {
            return _contactAppService.ContactAliasAsync(contactId);
        }

        [HttpPut]
        [Route("alias")]
        public Task ContactAliasAsync(AliasInput input)
        {
            return _contactAppService.ContactAliasAsync(input);
        }

        [HttpGet]
        [Route("avatar")]
        public Task<FileBox> ContactAvatarAsync(string contactId)
        {
            return _contactAppService.ContactAvatarAsync(contactId);
        }

        [HttpPut]
        [Route("avatar")]
        public Task ContactAvatarAsync(string contactId, FileBox file)
        {
            return _contactAppService.ContactAvatarAsync(contactId, file);
        }

        [HttpGet]
        [Route("list")]
        public Task<List<string>> ContactListAsync()
        {
            return _contactAppService.ContactListAsync();
        }

        [HttpPut]
        [Route("payload")]
        public Task<ContactPayload> ContactPayloadAsync(string contactId)
        {
            return _contactAppService.ContactPayloadAsync(contactId);
        }

        [HttpPut]
        [Route("selfName")]
        public Task ContactSelfNameAsync(string name)
        {
            return _contactAppService.ContactSelfNameAsync(name);
        }

        [HttpGet]
        [Route("selfQRCode")]
        public Task<string> ContactSelfQRCodeAsync()
        {
            return _contactAppService.ContactSelfQRCodeAsync();
        }

        [HttpPut]
        [Route("selfSignature")]
        public Task ContactSelfSignatureAsync(string signature)
        {
            return _contactAppService.ContactSelfSignatureAsync(signature);
        }
    }
}
