

## 接口测试

### Contact
- [x] [GET] `/api/Contact/alias` 目前Padlocal协议返回的数据是空，不知道其协议是否能返回数据
- [x] [PUT] `/api/Contact/alias`
- [x] [GET] `/api/Contact/avatar`
- [ ] [PUT] `/api/Contact/avatar`
- [x] [GET] `/api/Contact/list`
- [x] [PUT] `/api/Contact/selfName`
- [x] [GET] `/api/Contact/selfQRCode`
- [x] [PUT] `/api/Contact/selfSignature` 
- [x] [PUT] `/api/Contact/payload`


### FriendShip
- [ ] [PUT] `/api/FriendShip/accept`
- [ ] [PUT] `/api/FriendShip/addFriend`
- [ ] [GET] `/api/FriendShip/payload`
- [ ] [GET] `/api/FriendShip/searchByPhone`
- [ ] [GET] `/api/FriendShip/searchByWeiXin`

### Message
- [ ] [GET] `​/api​/Message​/messageContact` --> *` ERR PuppetServiceImpl grpcError() messageContact() rejection: not implement`*
- [ ] [GET] `/api/Message/messageFile` *rpc.Core.RpcException: Status(StatusCode="Internal", Detail="[tid:85a66eef] [353ms] download file failed，需要特殊处理下*
- [ ] [GET] `/api/Message/messageImage`
- [x] [GET] `/api/Message/messageImageStream`
- [x] [GET] `/api/Message/messageMiniProgram`
- [ ] [put] `/api/Message/recall`  
    *__异常：`request has been cancelled for reason: SERVER_ERROR: 2 UNKNOWN: [tid:70f1ff83] wechat bad request error`<strong>__*
- [x] [PUT] `/api/Message/sendContact`
- [ ] [PUT] `/api/Message/sendFile`
- [x] [PUT] `/api/Message/sendMiniProgram`
- [x] [PUT] `/api/Message/sendText`
- [x] [PUT] `/api/Message/SendUrl`
- [x] [PUT] `/api/Message/messageUrl`
- [ ] [PUT]`/api/Message/payload`

### Room
- [x] [PUT] `/api/Room/payload`
- [x] [PUT] `/api/Room/Add`
- [x] [GET] `/api/Room/announce`
- [x] [PUT] `/api/Room/announce` 如果当前账号不是群主或者群管理员的话，修改公告会报错`request has been cancelled for reason: SERVER_ERROR: 2`
- [x] [GET] `/api/Room/avatar`
- [ ] [POST] `/api/Room/create` --> *`ERR PuppetServiceImpl grpcError() roomCreate() rejection: roomId is required`*
- [x] [DELETE] `/api/Room/delete` 当前用户作为管理员，不能移除其他管理员，只能移除普通成员
- [ ] [PUT] `/api/Room/accept`
- [x] [GET] `/api/Room/list`
- [x] [GET] `/api/Room/members`
- [ ] [GET] `/api/Room/memberPayload`
- [ ] [GET] `/api/Room/qrcode` --> `ERR PuppetServiceImpl grpcError() roomQRCode() rejection: bufferToQrcode(buf) fail!`
- [x] [PUT] `/api/Room/quit`
- [ ] [GET] `/api/Room/topic` 这个其实也是更新操作，暂时先停用该接口
- [x] [PUT] `/api/Room/topic`

### Tag
- [x] [POST] `/api/Tag/contactAddTag`
- [x] [DELETE] `/api/Tag/delete`
- [x] [GET] `/api/Tag/list/{contactId}`
- [x] [GET] `/api/Tag/list`
- [x] [PUT] `/api/Tag/contactRemoveTag`