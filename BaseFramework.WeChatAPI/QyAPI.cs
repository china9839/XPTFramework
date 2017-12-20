using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeChatAPI.Entity;
using WeChatAPI.iUtil;

namespace WeChatAPI
{
    /// <summary>
    /// 微信企业号API
    /// </summary>
    public class QyAPI : BaseAPI
    {
        #region 获取Token字符串
        /// <summary>
        /// 获取Token字符串
        /// </summary>
        /// <param name="corpid"></param>
        /// <param name="corpsecret"></param>
        /// <returns></returns>
        public static GetTokenRes GetToken(string corpid, string corpsecret)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}";
            url = string.Format(url, corpid, corpsecret);

            return GetObject<GetTokenRes>(url);
        }
        #endregion

        #region 企业号二次认证成功
        /// <summary>
        /// 企业号二次认证成功
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static BaseRes AuthSuccess(string access_token, string userid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/authsucc?access_token={0}&userid={1}";
            url = string.Format(url, access_token, userid);

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 创建部门
        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="name"></param>
        /// <param name="parentid"></param>
        /// <param name="order"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DeptCreateRep Department_Create(string access_token,
            string name, int parentid, int order, int id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token=";
            url += access_token;

            var post = new
            {
                name = name,
                parentid = parentid,
                order = order,
                id = id
            };

            return PostObject<DeptCreateRep>(url, post);
        }
        #endregion

        #region 更新部门
        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="name"></param>
        /// <param name="parentid"></param>
        /// <param name="order"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BaseRes Department_Update(string access_token,
            string name, int parentid, int order, int id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/department/update?access_token=";
            url += access_token;

            var post = new
            {
                name = name,
                parentid = parentid,
                order = order,
                id = id
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 删除部门
        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BaseRes Department_Delete(string access_token, int id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/department/delete?access_token={0}&id={1}";
            url = string.Format(url, access_token, id); ;

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 获取部门列表
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DeptListRes Department_List(string access_token, int id)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={0}&id={1}";
            url = string.Format(url, access_token, id); ;

            return GetObject<DeptListRes>(url);
        }
        #endregion

        #region 创建成员
        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="position"></param>
        /// <param name="mobile"></param>
        /// <param name="gender"></param>
        /// <param name="email"></param>
        /// <param name="weixinid"></param>
        /// <returns></returns>
        public static BaseRes User_Create(string access_token,
            string userid, string name, int[] department, string position,
            string mobile, int gender, string email, string weixinid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token=";
            url += access_token;

            var post = new
            {
                userid = userid,
                name = name,
                department = department,
                position = position,
                mobile = mobile,
                gender = gender,
                email = email,
                weixinid = weixinid
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 更新成员
        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="access_token"></param>
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
        public static BaseRes User_Update(string access_token,
            string userid, string name, int[] department, string position,
            string mobile, int gender, string email, string weixinid, int enable)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token=";
            url += access_token;

            var post = new
            {
                userid = userid,
                name = name,
                department = department,
                position = position,
                mobile = mobile,
                gender = gender,
                email = email,
                weixinid = weixinid,
                enable = enable
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 删除成员
        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static BaseRes User_Delete(string access_token, string userid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/delete?access_token={0}&userid={1}";
            url = string.Format(url, access_token, userid);

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 删除成员
        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="useridlist"></param>
        /// <returns></returns>
        public static BaseRes User_BatchDelete(string access_token, string[] useridlist)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/batchdelete?access_token=";
            url += access_token;

            var post = new
            {
                useridlist = useridlist
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 获取成员
        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static UserGetRes User_Get(string access_token, string userid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}";
            url = string.Format(url, access_token, userid);

            return GetObject<UserGetRes>(url);
        }
        #endregion

        #region 获取部门成员
        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="department_id"></param>
        /// <param name="fetch_child">1/0：是否递归获取子部门下面的成员</param>
        /// <param name="status">0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>
        /// <returns></returns>
        public static UserSimpleListRes User_SimpleList(string access_token,
            int department_id, int fetch_child, int status)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token={0}&department_id={1}&fetch_child={2}&status={3}";
            url = string.Format(url, access_token, department_id, fetch_child, status);

            return GetObject<UserSimpleListRes>(url);
        }
        #endregion

        #region 获取部门成员(详情)
        /// <summary>
        /// 获取部门成员(详情)
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="department_id"></param>
        /// <param name="fetch_child">1/0：是否递归获取子部门下面的成员</param>
        /// <param name="status">0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>
        /// <returns></returns>
        public static UserListRes User_List(string access_token,
            int department_id, int fetch_child, int status)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/list?access_token={0}&department_id={1}&fetch_child={2}&status={3}";
            url = string.Format(url, access_token, department_id, fetch_child, status);

            return GetObject<UserListRes>(url);
        }
        #endregion

        #region 邀请成员关注
        /// <summary>
        /// 邀请成员关注
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static InviteSendRes Invite_Send(string access_token, string userid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/invite/send?access_token=";
            url += access_token;

            var post = new
            {
                userid = userid
            };

            return PostObject<InviteSendRes>(url, post);
        }
        #endregion

        #region 创建标签
        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagname"></param>
        /// <returns></returns>
        public static TagCreateRes Tag_Create(string access_token, string tagname)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/create?access_token=";
            url += access_token;

            var post = new
            {
                tagname = tagname
            };

            return PostObject<TagCreateRes>(url, post);
        }
        #endregion

        #region 更新标签名字
        /// <summary>
        /// 更新标签名字
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagname"></param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public static BaseRes Tag_Update(string access_token, string tagname, int tagid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/update?access_token=";
            url += access_token;

            var post = new
            {
                tagid = tagid,
                tagname = tagname
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 删除标签
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public static BaseRes Tag_Delete(string access_token, int tagid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/delete?access_token={0}&tagid={1}";
            url = string.Format(url, access_token, tagid);

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 获取标签成员
        /// <summary>
        /// 获取标签成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public static TagGetRes Tag_Get(string access_token, int tagid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/get?access_token={0}&tagid={1}";
            url = string.Format(url, access_token, tagid);

            return GetObject<TagGetRes>(url);
        }
        #endregion

        #region 增加标签成员
        /// <summary>
        /// 增加标签成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagid"></param>
        /// <param name="listUser"></param>
        /// <param name="listDept"></param>
        /// <returns></returns>
        public static TagAddtagUsersRes Tag_AddtagUsers(string access_token, int tagid, string[] listUser, int[] listDept)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/addtagusers?access_token=";
            url += access_token;

            var post = new
            {
                tagid = tagid,
                userlist = listUser,
                partylist = listDept
            };

            return PostObject<TagAddtagUsersRes>(url, post);
        }
        #endregion

        #region 删除标签成员
        /// <summary>
        /// 删除标签成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagid"></param>
        /// <param name="listUser"></param>
        /// <param name="listDept"></param>
        /// <returns></returns>
        public static TagAddtagUsersRes Tag_DeltagUsers(string access_token, int tagid, string[] listUser, int[] listDept)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/deltagusers?access_token=";
            url += access_token;

            var post = new
            {
                tagid = tagid,
                userlist = listUser,
                partylist = listDept
            };

            return PostObject<TagAddtagUsersRes>(url, post);
        }
        #endregion

        #region 获取标签列表
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static TagListRes Tag_List(string access_token)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/list?access_token=";
            url += access_token;

            return GetObject<TagListRes>(url);
        }
        #endregion

        #region 邀请成员关注
        /// <summary>
        /// 邀请成员关注
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="touser"></param>
        /// <param name="toparty"></param>
        /// <param name="totag"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public static BatchRes Batch_InviteUser(string access_token,
            List<string> touser, List<string> toparty, List<string> totag,
            string callbackurl, string token, string encodingaeskey)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/inviteuser?access_token=";
            url += access_token;

            if (touser == null)
            {
                touser = new List<string>();
            }
            if (toparty == null)
            {
                toparty = new List<string>();
            }
            if (totag == null)
            {
                totag = new List<string>();
            }

            var post = new
            {
                touser = string.Join("|", touser),
                toparty = string.Join("|", toparty),
                totag = string.Join("|", totag),
                callback = new
                {
                    url = callbackurl,
                    token = token,
                    encodingaeskey = encodingaeskey
                }
            };

            return PostObject<BatchRes>(url, post);
        }
        #endregion

        #region 增量更新成员
        /// <summary>
        /// 增量更新成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public static BatchRes Batch_SyncUser(string access_token,
            string media_id, string callbackurl, string token, string encodingaeskey)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/syncuser?access_token=";
            url += access_token;

            var post = new
            {
                media_id = media_id,
                callback = new
                {
                    url = callbackurl,
                    token = token,
                    encodingaeskey = encodingaeskey
                }
            };

            return PostObject<BatchRes>(url, post);
        }
        #endregion

        #region 全量覆盖成员
        /// <summary>
        /// 全量覆盖成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public static BatchRes Batch_ReplaceUser(string access_token,
            string media_id, string callbackurl, string token, string encodingaeskey)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/replaceuser?access_token=";
            url += access_token;

            var post = new
            {
                media_id = media_id,
                callback = new
                {
                    url = callbackurl,
                    token = token,
                    encodingaeskey = encodingaeskey
                }
            };

            return PostObject<BatchRes>(url, post);
        }
        #endregion

        #region 全量覆盖部门
        /// <summary>
        /// 全量覆盖部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <param name="callbackurl"></param>
        /// <param name="token"></param>
        /// <param name="encodingaeskey"></param>
        /// <returns></returns>
        public static BatchRes Batch_ReplaceParty(string access_token,
            string media_id, string callbackurl, string token, string encodingaeskey)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/replaceparty?access_token=";
            url += access_token;

            var post = new
            {
                media_id = media_id,
                callback = new
                {
                    url = callbackurl,
                    token = token,
                    encodingaeskey = encodingaeskey
                }
            };

            return PostObject<BatchRes>(url, post);
        }
        #endregion

        #region 获取异步任务结果
        /// <summary>
        /// 获取异步任务结果
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="jobid"></param>
        /// <returns></returns>
        public static BatchGetResultRes Batch_GetResult(string access_token, string jobid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/getresult?access_token={0}&jobid={1}";
            url = string.Format(url, access_token, jobid);

            return GetObject<BatchGetResultRes>(url);
        }
        #endregion

        #region 上传临时素材文件
        /// <summary>
        /// 上传临时素材文件
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="type"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static MediaUploadRes Media_Upload(string access_token, EnumUploadType type, string file)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";
            url = string.Format(url, access_token, type);

            TimeoutWebClient wc = ThreadWebClientFactory.GetWebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var bytes = wc.UploadFile(url, "POST", file);
            string json = Encoding.UTF8.GetString(bytes);

            MediaUploadRes res = JsonConvert.DeserializeObject<MediaUploadRes>(json);
            if (string.IsNullOrEmpty(res.errcode))
            {
                res.errcode = "0";
            }
            return res;
        }
        #endregion

        #region 获取临时素材文件
        /// <summary>
        /// 获取临时素材文件
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static MediaGetRes Media_Get(string access_token, string media_id, string filepath)
        {
            string filename = null;

            string url = "https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";
            url = string.Format(url, access_token, media_id);

            TimeoutWebClient wc = ThreadWebClientFactory.GetWebClient();
            wc.DownloadFile(url, filepath);

            string disposition = wc.ResponseHeaders["Content-disposition"];
            if (string.IsNullOrEmpty(disposition))
            {
                string json = System.IO.File.ReadAllText(filepath);
                return JsonConvert.DeserializeObject<MediaGetRes>(json);
            }
            else
            {
                filename = StringHelper.SubString(disposition, "filename=\"", "\"");
            }

            return new MediaGetRes() { errcode = "0", filename = filename };
        }
        #endregion

        #region 获取企业号应用
        /// <summary>
        /// 获取企业号应用
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public static AgentGetRes Agent_Get(string access_token, string agentid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/agent/get?access_token={0}&agentid={1}";
            url = string.Format(url, access_token, agentid);

            return GetObject<AgentGetRes>(url);
        }
        #endregion

        #region 设置企业号应用
        /// <summary>
        /// 设置企业号应用
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <param name="report_location_flag"></param>
        /// <param name="logo_mediaid"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="redirect_domain"></param>
        /// <param name="isreportuser"></param>
        /// <param name="isreportenter"></param>
        /// <returns></returns>
        public static BaseRes Agent_Set(string access_token,
            string agentid, string report_location_flag, string logo_mediaid, string name,
            string description, string redirect_domain, int isreportuser, int isreportenter)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/agent/set?access_token=";
            url += access_token;

            var post = new
            {
                agentid = agentid,
                report_location_flag = report_location_flag,
                logo_mediaid = logo_mediaid,
                name = name,
                description = description,
                redirect_domain = redirect_domain,
                isreportuser = isreportuser,
                isreportenter = isreportenter
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 获取应用概况列表
        /// <summary>
        /// 获取应用概况列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static AgentListRes Agent_List(string access_token)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/agent/list?access_token=";
            url += access_token;

            return GetObject<AgentListRes>(url);
        }
        #endregion

        #region 发送接口
        /// <summary>
        /// 发送接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msgSend"></param>
        /// <returns></returns>
        public static MessageSendRes Message_Send(string access_token, MessageSend msgSend)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=";
            url += access_token;

            string ps = "";
            #region 转换成所所需要的json
            switch (msgSend.msgtype)
            {
                case "text":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            text = new
                            {
                                content = msgSend.content
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "image":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            image = new
                            {
                                media_id = msgSend.media_id
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "voice":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            voice = new
                            {
                                media_id = msgSend.media_id
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "video":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            video = new
                            {
                                media_id = msgSend.media_id,
                                title = msgSend.title,
                                description = msgSend.description
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "file":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            file = new
                            {
                                media_id = msgSend.media_id
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "news":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            news = new
                            {
                                articles = msgSend.articles
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

                case "mpnews":
                    {
                        var post = new
                        {
                            touser = msgSend.touser,
                            toparty = msgSend.toparty,
                            totag = msgSend.totag,
                            msgtype = msgSend.msgtype,
                            agentid = msgSend.agentid,
                            safe = msgSend.safe,

                            mpnews = new
                            {
                                articles = msgSend.articlesMp
                            }
                        };
                        ps = JsonConvert.SerializeObject(post);
                        break;
                    }

            }
            #endregion

            return PostObject<MessageSendRes>(url, ps);

        }
        #endregion

        #region 创建应用菜单
        /// <summary>
        /// 创建应用菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <param name="listButton"></param>
        /// <returns></returns>
        public static BaseRes Menu_Create(string access_token, string agentid, string json)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/menu/create?access_token={0}&agentid={1}";
            url = string.Format(url, access_token, agentid);

            return PostObject<BaseRes>(url, json);
        }
        #endregion

        #region 删除菜单
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public static BaseRes Menu_Delete(string access_token, string agentid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/menu/delete?access_token={0}&agentid={1}";
            url = string.Format(url, access_token, agentid);

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 获取菜单列表
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public static MenuGetRes Menu_Get(string access_token, string agentid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/menu/get?access_token={0}&agentid={1}";
            url = string.Format(url, access_token, agentid);

            return GetObject<MenuGetRes>(url);
        }
        #endregion

        #region 根据code获取成员信息
        /// <summary>
        /// 根据code获取成员信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public static UserGetUserInfoRes User_GetUserInfo(string access_token, string code, string agentid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}";
            url = string.Format(url, access_token, code);

            return GetObject<UserGetUserInfoRes>(url);
        }
        #endregion

        #region 获取微信服务器的ip段
        /// <summary>
        /// 获取微信服务器的
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static GetCallBackIpRes GetCallBackIp(string access_token)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/getcallbackip?access_token=";
            url += access_token;

            return GetObject<GetCallBackIpRes>(url);
        }
        #endregion

        #region userid转换成openid接口
        /// <summary>
        /// userid转换成openid接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <param name="agentid"></param>
        /// <param name="openid"></param>
        /// <param name="appid"></param>
        /// <returns></returns>
        public static UseridAndOpenidConvertRes User_ConvertToOpenid(string access_token,
            string userid, string agentid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/convert_to_openid?access_token={0}";
            url = string.Format(url, access_token);

            if (string.IsNullOrEmpty(agentid))
            {
                agentid = string.Empty;
            }
            
            var post = new
            {
                userid = userid,
                agentid = agentid
            };

            return PostObject<UseridAndOpenidConvertRes>(url, post);
        }
        #endregion

        #region openid转换成userid接口
        /// <summary>
        /// openid转换成userid接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static UseridAndOpenidConvertRes User_ConvertToUserid(string access_token, string openid)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/convert_to_userid?access_token={0}";
            url = string.Format(url, access_token);

            var post = new
            {
                openid = openid
            };

            return PostObject<UseridAndOpenidConvertRes>(url, post);
        }
        #endregion
    }
}
