using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeChatAPI.Entity;
using WeChatAPI.MpEntity;

namespace WeChatAPI
{
    /// <summary>
    /// 微信企业API操作类
    /// </summary>
    public class QyApiHandler
    {
        private static QyApiHandler qyApiHandler;

        public static QyApiHandler Instance
        {
            get { return qyApiHandler; }
        }

        public static void Init(string CorpID, string Secret, string AgentId)
        {
            qyApiHandler = new QyApiHandler(CorpID, Secret, AgentId);
        }

        public static Dictionary<string, string> TokenPool = new Dictionary<string, string>();

        public QyApiHandler(string CorpID, string Secret, string AgentId)
        {
            this.CorpID = CorpID;
            this.Secret = Secret;
            this.AgentId = AgentId;
        }

        public string CorpID = string.Empty;
        public string Secret = string.Empty;
        public string AgentId = string.Empty;
        public string access_token = string.Empty;

        #region 判断access_token是否过期
        /// <summary>
        /// 判断access_token是否过期
        /// </summary>
        /// <param name="res"></param>
        /// <param name="needRefresh"></param>
        /// <returns></returns>
        public bool IsAccessTokenError(BaseRes res, bool needRefresh = true)
        {
            var rel = res.errcode == "42001" || res.errcode == "41001" || res.errcode == "40002" || res.errcode == "40014";
            if (rel && needRefresh)
            {
                if (needRefresh)
                {
                    // 超时并且需要刷新
                    RefreshToken();
                }
                else
                {
                    throw new BusinessBaseException(ExceptionCode.WechatCannotDelete);
                }
            }
            return rel;
        }
        #endregion

        #region 刷新access_token
        /// <summary>
        /// 刷新access_token
        /// </summary>
        /// <returns></returns>
        public void RefreshToken()
        {
            var rel = QyAPI.GetToken(CorpID, Secret);
            if (!string.IsNullOrEmpty(rel.access_token))
            {
                if (TokenPool.ContainsKey(CorpID))
                {
                    TokenPool[CorpID] = rel.access_token;
                }
                else
                {
                    TokenPool.Add(CorpID, rel.access_token);
                }
            }
            else
            {
                throw new BusinessBaseException(ExceptionCode.WechatCannotDelete);
            }
            access_token = rel.access_token;
        }
        #endregion

        #region 企业号二次认证成功
        /// <summary>
        /// 企业号二次认证成功
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public BaseRes AuthSuccess(string userid)
        {
            var rel = QyAPI.AuthSuccess(access_token, userid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.AuthSuccess(access_token, userid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 创建部门
        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentid"></param>
        /// <param name="order"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeptCreateRep Department_Create(string name, int parentid, int order, int id)
        {
            var rel = QyAPI.Department_Create(access_token, name, parentid, order, id);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Department_Create(access_token, name, parentid, order, id);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 更新部门
        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentid"></param>
        /// <param name="order"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseRes Department_Update(string name, int parentid, int order, int id)
        {
            var rel = QyAPI.Department_Update(access_token, name, parentid, order, id);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Department_Update(access_token, name, parentid, order, id);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 删除部门
        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseRes Department_Delete(int id)
        {
            var rel = QyAPI.Department_Delete(access_token, id);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Department_Delete(access_token, id);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取部门列表
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeptListRes Department_List(int id)
        {
            var rel = QyAPI.Department_List(access_token, id);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Department_List(access_token, id);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 创建成员
        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="position"></param>
        /// <param name="mobile"></param>
        /// <param name="gender"></param>
        /// <param name="email"></param>
        /// <param name="weixinid"></param>
        /// <returns></returns>
        public BaseRes User_Create(string userid, string name, int[] department, string position,
            string mobile, int gender, string email, string weixinid)
        {
            var rel = QyAPI.User_Create(access_token, userid, name, department, position, mobile, gender, email, weixinid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.User_Create(access_token, userid, name, department, position, mobile, gender, email, weixinid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 更新成员
        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="position"></param>
        /// <param name="mobile"></param>
        /// <param name="gender"></param>
        /// <param name="email"></param>
        /// <param name="weixinid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public BaseRes User_Update(string userid, string name, int[] department, string position,
            string mobile, int gender, string email, string weixinid, int enable)
        {
            var rel = QyAPI.User_Update(access_token, userid, name, department, position, mobile, gender, email, weixinid, enable);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.User_Update(access_token, userid, name, department, position, mobile, gender, email, weixinid, enable);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 删除成员
        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public BaseRes User_Delete(string userid)
        {
            var rel = QyAPI.User_Delete(access_token, userid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.User_Delete(access_token, userid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 批量删除成员
        /// <summary>
        /// 批量删除成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="useridlist"></param>
        /// <returns></returns>
        public BaseRes User_BatchDelete(string[] useridlist)
        {
            var rel = QyAPI.User_BatchDelete(access_token, useridlist);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.User_BatchDelete(access_token, useridlist);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取成员
        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public UserGetRes User_Get(string userid)
        {
            var rel = QyAPI.User_Get(access_token, userid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.User_Get(access_token, userid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取部门成员
        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="department_id"></param>
        /// <param name="fetch_child">1/0：是否递归获取子部门下面的成员</param>
        /// <param name="status">0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>
        /// <returns></returns>
        public UserSimpleListRes User_SimpleList(int department_id, int fetch_child, int status)
        {
            var rel = QyAPI.User_SimpleList(access_token, department_id, fetch_child, status);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.User_SimpleList(access_token, department_id, fetch_child, status);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取部门成员(详情)
        /// <summary>
        /// 获取部门成员(详情)
        /// </summary>
        /// <param name="department_id"></param>
        /// <param name="fetch_child">1/0：是否递归获取子部门下面的成员</param>
        /// <param name="status">0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>
        /// <returns></returns>
        public UserListRes User_List(int department_id, int fetch_child, int status)
        {
            var rel = QyAPI.User_List(access_token, department_id, fetch_child, status);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.User_List(access_token, department_id, fetch_child, status);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 邀请成员关注
        /// <summary>
        /// 邀请成员关注
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public InviteSendRes Invite_Send(string userid)
        {
            var rel = QyAPI.Invite_Send(access_token, userid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Invite_Send(access_token, userid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 创建标签
        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="tagname"></param>
        /// <returns></returns>
        public TagCreateRes Tag_Create(string tagname)
        {
            var rel = QyAPI.Tag_Create(access_token, tagname);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Tag_Create(access_token, tagname);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 更新标签名字
        /// <summary>
        /// 更新标签名字
        /// </summary>
        /// <param name="tagname"></param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public BaseRes Tag_Update(string tagname, int tagid)
        {
            var rel = QyAPI.Tag_Update(access_token, tagname, tagid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Tag_Update(access_token, tagname, tagid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 删除标签
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public BaseRes Tag_Delete(int tagid)
        {
            var rel = QyAPI.Tag_Delete(access_token, tagid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Tag_Delete(access_token, tagid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取标签成员
        /// <summary>
        /// 获取标签成员
        /// </summary>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public TagGetRes Tag_Get(int tagid)
        {
            var rel = QyAPI.Tag_Get(access_token, tagid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Tag_Get(access_token, tagid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 增加标签成员
        /// <summary>
        /// 增加标签成员
        /// </summary>
        /// <param name="tagid"></param>
        /// <param name="listUser"></param>
        /// <param name="listDept"></param>
        /// <returns></returns>
        public TagAddtagUsersRes Tag_AddtagUsers(int tagid, string[] listUser, int[] listDept)
        {
            var rel = QyAPI.Tag_AddtagUsers(access_token, tagid, listUser, listDept);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Tag_AddtagUsers(access_token, tagid, listUser, listDept);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 删除标签成员
        /// <summary>
        /// 删除标签成员
        /// </summary>
        /// <param name="tagid"></param>
        /// <param name="listUser"></param>
        /// <param name="listDept"></param>
        /// <returns></returns>
        public TagAddtagUsersRes Tag_DeltagUsers(int tagid, string[] listUser, int[] listDept)
        {
            var rel = QyAPI.Tag_DeltagUsers(access_token, tagid, listUser, listDept);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Tag_DeltagUsers(access_token, tagid, listUser, listDept);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取标签列表
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <returns></returns>
        public TagListRes Tag_List()
        {
            var rel = QyAPI.Tag_List(access_token);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Tag_List(access_token);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 邀请成员关注
        /// <summary>
        /// 邀请成员关注
        /// </summary>
        /// <param name="touser"></param>
        /// <param name="toparty"></param>
        /// <param name="totag"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public BatchRes Batch_InviteUser(List<string> touser, List<string> toparty, List<string> totag,
            string callbackurl, string token, string encodingaeskey)
        {
            var rel = QyAPI.Batch_InviteUser(access_token, touser, toparty, totag, callbackurl, token, encodingaeskey);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Batch_InviteUser(access_token, touser, toparty, totag, callbackurl, token, encodingaeskey);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 增量更新成员
        /// <summary>
        /// 增量更新成员
        /// </summary>
        /// <param name="media_id"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public BatchRes Batch_SyncUser(string media_id, string callbackurl, string token, string encodingaeskey)
        {
            var rel = QyAPI.Batch_SyncUser(access_token, media_id, callbackurl, token, encodingaeskey);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Batch_SyncUser(access_token, media_id, callbackurl, token, encodingaeskey);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 全量覆盖成员
        /// <summary>
        /// 全量覆盖成员
        /// </summary>
        /// <param name="media_id"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public BatchRes Batch_ReplaceUser(string media_id, string callbackurl, string token, string encodingaeskey)
        {
            var rel = QyAPI.Batch_ReplaceUser(access_token, media_id, callbackurl, token, encodingaeskey);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Batch_ReplaceUser(access_token, media_id, callbackurl, token, encodingaeskey);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 全量覆盖部门
        /// <summary>
        /// 全量覆盖部门
        /// </summary>
        /// <param name="media_id"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public BatchRes Batch_ReplaceParty(string media_id, string callbackurl, string token, string encodingaeskey)
        {
            var rel = QyAPI.Batch_ReplaceParty(access_token, media_id, callbackurl, token, encodingaeskey);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Batch_ReplaceParty(access_token, media_id, callbackurl, token, encodingaeskey);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取异步任务结果
        /// <summary>
        /// 获取异步任务结果
        /// </summary>
        /// <param name="jobid"></param>
        /// <returns></returns>
        public BatchGetResultRes Batch_GetResult(string jobid)
        {
            var rel = QyAPI.Batch_GetResult(access_token, jobid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Batch_GetResult(access_token, jobid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 上传临时素材文件
        /// <summary>
        /// 上传临时素材文件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public MediaUploadRes Media_Upload(EnumUploadType type, string file)
        {
            var rel = QyAPI.Media_Upload(access_token, type, file);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Media_Upload(access_token, type, file);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取临时素材文件
        /// <summary>
        /// 获取临时素材文件
        /// </summary>
        /// <param name="media_id"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public MediaGetRes Media_Get(string media_id, string filepath)
        {
            var rel = QyAPI.Media_Get(access_token, media_id, filepath);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Media_Get(access_token, media_id, filepath);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取企业号应用
        /// <summary>
        /// 获取企业号应用
        /// </summary>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public AgentGetRes Agent_Get(string agentid)
        {
            var rel = QyAPI.Agent_Get(access_token, agentid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Agent_Get(access_token, agentid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 设置企业号应用
        /// <summary>
        /// 设置企业号应用
        /// </summary>
        /// <param name="agentid"></param>
        /// <param name="report_location_flag"></param>
        /// <param name="logo_mediaid"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="redirect_domain"></param>
        /// <param name="isreportuser"></param>
        /// <param name="isreportenter"></param>
        /// <returns></returns>
        public BaseRes Agent_Set(string agentid, string report_location_flag, string logo_mediaid, string name,
            string description, string redirect_domain, int isreportuser, int isreportenter)
        {
            var rel = QyAPI.Agent_Set(access_token, agentid, report_location_flag, logo_mediaid, name, description, redirect_domain, isreportuser, isreportenter);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Agent_Set(access_token, agentid, report_location_flag, logo_mediaid, name, description, redirect_domain, isreportuser, isreportenter);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取应用概况列表
        /// <summary>
        /// 获取应用概况列表
        /// </summary>
        /// <returns></returns>
        public AgentListRes Agent_List()
        {
            var rel = QyAPI.Agent_List(access_token);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Agent_List(access_token);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 发送接口
        /// <summary>
        /// 发送接口
        /// </summary>
        /// <param name="msgSend"></param>
        /// <returns></returns>
        public MessageSendRes Message_Send(MessageSend msgSend)
        {
            msgSend.agentid = AgentId;
            var rel = QyAPI.Message_Send(access_token, msgSend);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Message_Send(access_token, msgSend);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 创建应用菜单
        /// <summary>
        /// 创建应用菜单
        /// </summary>
        /// <param name="listButton"></param>
        /// <returns></returns>
        public BaseRes Menu_Create(string json)
        {
            var agentid = AgentId;
            var rel = QyAPI.Menu_Create(access_token, agentid, json);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Menu_Create(access_token, agentid, json);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 删除菜单
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <returns></returns>
        public BaseRes Menu_Delete()
        {
            var agentid = AgentId;
            var rel = QyAPI.Menu_Delete(access_token, agentid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Menu_Delete(access_token, agentid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取菜单列表
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public MenuGetRes Menu_Get(string agentid)
        {
            var rel = QyAPI.Menu_Get(access_token, agentid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.Menu_Get(access_token, agentid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 根据code获取成员信息
        /// <summary>
        /// 根据code获取成员信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public UserGetUserInfoRes User_GetUserInfo(string code)
        {
            var rel = QyAPI.User_GetUserInfo(access_token, code, AgentId);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.User_GetUserInfo(access_token, code, AgentId);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region 获取微信服务器的ip段
        /// <summary>
        /// 获取微信服务器的
        /// </summary>
        /// <returns></returns>
        public GetCallBackIpRes GetCallBackIp()
        {
            var rel = QyAPI.GetCallBackIp(access_token);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.GetCallBackIp(access_token);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region userid转换成openid接口
        /// <summary>
        /// userid转换成openid接口
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="agentid"></param>
        /// <param name="openid"></param>
        /// <param name="appid"></param>
        /// <returns></returns>
        public UseridAndOpenidConvertRes User_ConvertToOpenid(string userid, string agentid)
        {
            var rel = QyAPI.User_ConvertToOpenid(access_token, userid, agentid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.User_ConvertToOpenid(access_token, userid, agentid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

        #region openid转换成userid接口
        /// <summary>
        /// openid转换成userid接口
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public UseridAndOpenidConvertRes User_ConvertToUserid(string openid)
        {
            var rel = QyAPI.User_ConvertToUserid(access_token, openid);
            if (IsAccessTokenError(rel))
            {
                rel = QyAPI.User_ConvertToUserid(access_token, openid);
                IsAccessTokenError(rel, false);
            }
            return rel;
        }
        #endregion

    }
}
