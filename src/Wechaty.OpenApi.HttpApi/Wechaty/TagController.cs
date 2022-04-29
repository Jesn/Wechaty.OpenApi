using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Wechaty.OpenApi.Wechaty
{
    [Area(OpenApiRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = OpenApiRemoteServiceConsts.RemoteServiceName)]
    [Route("api/tag")]
    public class TagController : OpenApiController, ITagAppService
    {
        private readonly ITagAppService _tagAppService;
        public TagController(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        [HttpGet]
        [Route("list")]
        public Task<List<string>> TagContactListAsync()
        {
            return _tagAppService.TagContactListAsync();
        }


        [HttpDelete]
        [Route("delete")]
        public Task TagContactDeleteAsync(string tagId)
        {
            return _tagAppService.TagContactDeleteAsync(tagId);
        }

        [HttpGet]
        [Route("list/{contactId}")]
        public Task<List<string>> TagContactListAsync(string contactId)
        {
            return _tagAppService.TagContactListAsync(contactId);
        }

        [HttpPut]
        [Route("contactAddTag")]
        public Task TagContactAddAsync(string tagId, string contactId)
        {
            return _tagAppService.TagContactAddAsync(tagId, contactId);
        }

        [HttpPut]
        [Route("contactRemoveTag")]
        public Task TagContactRemoveAsync(string tagId, string contactId)
        {
            return _tagAppService.TagContactRemoveAsync(tagId, contactId);
        }
    }
}
