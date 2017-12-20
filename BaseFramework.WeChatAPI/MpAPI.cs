using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeChatAPI.Entity;
using WeChatAPI.MpEntity;
using WeChatAPI.iUtil;

namespace WeChatAPI
{
    /// <summary>
    /// 微信公共平台API
    /// </summary>
    public class MpAPI : BaseAPI
    {
        #region 获取access_token
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static GetTokenRes GetToken(string appid, string secret)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
            url = string.Format(url, appid, secret);

            return GetObject<GetTokenRes>(url);
        }
        #endregion

        #region 增加客服帐号
        /// <summary>
        /// 增加客服帐号
        /// </summary>
        /// <param name="kf_account"></param>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static BaseRes KfAccount_Add(string access_token,
            string kf_account, string nickname, string password)
        {
            string url = "https://api.weixin.qq.com/customservice/kfaccount/add?access_token=";
            url += access_token;

            var post = new
            {
                kf_account = kf_account,
                nickname = nickname,
                password = password
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 修改客服帐号
        /// <summary>
        /// 修改客服帐号
        /// </summary>
        /// <param name="kf_account"></param>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static BaseRes KfAccount_Update(string access_token,
            string kf_account, string nickname, string password)
        {
            string url = "https://api.weixin.qq.com/customservice/kfaccount/update?access_token=";
            url += access_token;

            var post = new
            {
                kf_account = kf_account,
                nickname = nickname,
                password = password
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 删除客服帐号
        /// <summary>
        /// 删除客服帐号
        /// </summary>
        /// <param name="kf_account"></param>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static BaseRes KfAccount_Del(string access_token,
            string kf_account, string nickname, string password)
        {
            string url = "https://api.weixin.qq.com/customservice/kfaccount/del?access_token=";
            url += access_token;

            var post = new
            {
                kf_account = kf_account,
                nickname = nickname,
                password = password
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 设置客服帐号的头像
        /// <summary>
        /// 设置客服帐号的头像
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="kf_account"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static BaseRes KfAccount_Uploadheadimg(string access_token, string kf_account, string file)
        {
            string url = "http://api.weixin.qq.com/customservice/kfaccount/uploadheadimg?access_token={0}&kf_account={1}";
            url = string.Format(url, access_token, kf_account);

            return UploadFile<BaseRes>(file, url);
        }
        #endregion

        #region 获取所有客服账号
        /// <summary>
        /// 获取所有客服账号
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static KfAccount_GetkflistRes KfAccount_Getkflist(string access_token)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token=";
            url += access_token;

            return GetObject<KfAccount_GetkflistRes>(url);
        }
        #endregion

        #region 发送客服消息
        /// <summary>
        /// 发送客服消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msgSend"></param>
        /// <returns></returns>
        public static Custom_SendRes Custom_Send(string access_token, CustomSend msgSend)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=";
            url += access_token;

            dynamic dpost = new ExpandoObject();
            dpost.touser = msgSend.touser;
            dpost.msgtype = msgSend.msgtype;
            if (!string.IsNullOrEmpty(msgSend.kf_account))
            {
                dpost.customservice = new
                {
                    kf_account = msgSend.kf_account
                };
            }
            
            #region 转换成所所需要的json
            switch (msgSend.msgtype)
            {
                case "text":
                    {
                        dpost.text = new
                            {
                                content = msgSend.content
                            };
                        break;
                    }
                case "image":
                    {
                        dpost.image = new
                        {
                            media_id = msgSend.media_id
                        };
                        break;
                    }
                case "voice":
                    {
                        dpost.voice = new
                        {
                            media_id = msgSend.media_id
                        };
                        break;
                    }
                case "video":
                    {
                        dpost.video = new
                        {
                            media_id = msgSend.media_id,
                            thumb_media_id = msgSend.thumb_media_id,
                            title = msgSend.title,
                            description = msgSend.description
                        };
                        break;
                    }
                case "music":
                    {
                        dpost.music = new
                        {
                            title = msgSend.title,
                            description = msgSend.description,
                            musicurl = msgSend.musicurl,
                            hqmusicurl = msgSend.hqmusicurl,
                            thumb_media_id = msgSend.thumb_media_id
                        };
                        break;
                    }
                case "news":
                    {
                        dpost.news = new
                        {
                            articles = msgSend.articles
                        };
                        break;
                    }
                case "mpnews":
                    {
                        dpost.mpnews = new
                        {
                            media_id = msgSend.media_id
                        };
                        break;
                    }
                case "wxcard":
                    {
                        dpost.mpnews = new
                        {
                            card_id = msgSend.card_id,
                            card_ext = msgSend.card_ext
                        };
                        break;
                    }
            }
            #endregion
            var ps = JsonConvert.SerializeObject(dpost);
            return PostObject<Custom_SendRes>(url, ps);
        }
        #endregion

        #region 上传图文消息内的图片获取URL【订阅号与服务号认证后均可用】
        /// <summary>
        /// 上传图文消息内的图片获取URL【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Media_UploadimgRes Media_Uploadimg(string access_token, string file)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token=";
            url += access_token;

            return UploadFile<Media_UploadimgRes>(file, url);
        }
        #endregion

        #region 上传图文消息素材【订阅号与服务号认证后均可用】
        /// <summary>
        /// 上传图文消息素材【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="articles"></param>
        /// <returns></returns>
        public static Media_UploadnewsRes Media_Uploadnews(string access_token, List<ArticlesMp> articles)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token=";
            url += access_token;

            var post = new
            {
                articles = articles
            };

            return PostObject<Media_UploadnewsRes>(url, post);
        }
        #endregion

        #region 根据分组进行群发【订阅号与服务号认证后均可用】
        /// <summary>
        /// 根据分组进行群发【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="massSend"></param>
        /// <returns></returns>
        public static Mass_SendallRes Mass_Sendall_Group(string access_token, MassSend massSend)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token=";
            url += access_token;

            dynamic dpost = new ExpandoObject();
            dpost.filter = new
            {
                is_to_all = massSend.is_to_all,
                group_id = massSend.group_id
            };
            dpost.msgtype = massSend.msgtype;
            switch (massSend.msgtype)
            {
                case "mpnews":
                    dpost.mpnews = new
                    {
                        media_id = massSend.media_id
                    };
                    break;

                case "text":
                    dpost.text = new
                    {
                        content = massSend.content
                    };
                    break;
                case "voice":
                    dpost.voice = new
                    {
                        media_id = massSend.media_id
                    };
                    break;
                case "image":
                    dpost.image = new
                    {
                        media_id = massSend.media_id
                    };
                    break;
                case "mpvideo":
                    var uploadVideo = UploadVideo(access_token, massSend);
                    dpost.mpvideo = new
                    {
                        media_id = uploadVideo.media_id
                    };
                    break;
                case "wxcard":
                    dpost.wxcard = new
                    {
                        card_id = massSend.card_id
                    };
                    break;
            }

            return PostObject<Mass_SendallRes>(url, dpost);
        }
        #endregion

        #region 获取分组群发视频媒体ID
        /// <summary>
        /// 获取分组群发视频媒体ID
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="massSend"></param>
        public static UploadVideoRes UploadVideo(string access_token, MassSend massSend)
        {
            string url = "https://file.api.weixin.qq.com/cgi-bin/media/uploadvideo?access_token=";
            url += access_token;

            var post = new
            {
                media_id = massSend.media_id,
                title = massSend.title,
                description = massSend.description
            };

            return PostObject<UploadVideoRes>(url, post);
        }
        #endregion

        #region 根据OpenID列表群发【订阅号不可用，服务号认证后可用】
        /// <summary>
        /// 根据OpenID列表群发【订阅号不可用，服务号认证后可用】
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="massSend"></param>
        /// <returns></returns>
        public static Mass_SendallRes Mass_Sendall_OpenId(string access_token, MassSend massSend)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token=";
            url += access_token;

            dynamic dpost = new ExpandoObject();
            dpost.touser = massSend.touser;
            dpost.msgtype = massSend.msgtype;
            switch (massSend.msgtype)
            {
                case "mpnews":
                    dpost.mpnews = new
                    {
                        media_id = massSend.media_id
                    };
                    break;

                case "text":
                    dpost.text = new
                    {
                        content = massSend.content
                    };
                    break;
                case "voice":
                    dpost.voice = new
                    {
                        media_id = massSend.media_id
                    };
                    break;
                case "image":
                    dpost.image = new
                    {
                        media_id = massSend.media_id
                    };
                    break;
                case "video":
                    var uploadVideo = UploadVideo_OpenId(access_token, massSend);
                    dpost.video = new
                    {
                        media_id = uploadVideo.media_id,
                        title = massSend.title,
                        description = massSend.description
                    };
                    break;
                case "wxcard":
                    dpost.wxcard = new
                    {
                        card_id = massSend.card_id
                    };
                    break;
            }

            return PostObject<Mass_SendallRes>(url, dpost);
        }
        #endregion

        #region 获取OpenID列表群发视频媒体ID
        /// <summary>
        /// 获取OpenID列表群发视频媒体ID
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="massSend"></param>
        public static UploadVideoRes UploadVideo_OpenId(string access_token, MassSend massSend)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/media/uploadvideo?access_token=";
            url += access_token;

            var post = new
            {
                media_id = massSend.media_id,
                title = massSend.title,
                description = massSend.description
            };

            return PostObject<UploadVideoRes>(url, post);
        }
        #endregion

        #region 删除群发【订阅号与服务号认证后均可用】
        /// <summary>
        /// 删除群发【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msg_id"></param>
        public static BaseRes Mass_Delete(string access_token, string msg_id)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/mass/delete?access_token=";
            url += access_token;

            var post = new
            {
                msg_id = msg_id
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 预览接口【订阅号与服务号认证后均可用】
        /// <summary>
        /// 预览接口【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="massSend"></param>
        /// <param name="touser"></param>
        /// <param name="towxname"></param>
        public static Mass_SendallRes Mass_Preview(string access_token, MassSend massSend, string touser, string towxname = null)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token=";
            url += access_token;

            dynamic dpost = new ExpandoObject();
            if (string.IsNullOrEmpty(towxname))
            {
                dpost.towxname = towxname;
            }
            else
            {
                dpost.touser = touser;
            }
            switch (massSend.msgtype)
            {
                case "mpnews":
                    dpost.mpnews = new
                    {
                        media_id = massSend.media_id
                    };
                    break;
                case "text":
                    dpost.text = new
                    {
                        content = massSend.content
                    };
                    break;
                case "voice":
                    dpost.voice = new
                    {
                        media_id = massSend.media_id
                    };
                    break;
                case "image":
                    dpost.image = new
                    {
                        media_id = massSend.media_id
                    };
                    break;
                case "mpvideo":
                    var uploadVideo = UploadVideo(access_token, massSend);
                    dpost.mpvideo = new
                    {
                        media_id = uploadVideo.media_id
                    };
                    break;
                case "wxcard":
                    dpost.wxcard = new
                    {
                        card_id = massSend.card_id,
                        card_ext = massSend.card_ext
                    };
                    break;
            }

            return PostObject<Mass_SendallRes>(url, dpost);
        }
        #endregion

        #region 查询群发消息发送状态【订阅号与服务号认证后均可用】
        /// <summary>
        /// 查询群发消息发送状态【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msg_id"></param>
        public static Mass_GetRes Mass_Get(string access_token, string msg_id)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/mass/get?access_token=";
            url += access_token;

            var post = new
            {
                msg_id = msg_id
            };

            return PostObject<Mass_GetRes>(url, post);
        }
        #endregion

        // 此处开始是模版消息
        #region 设置所属行业
        /// <summary>
        /// 设置所属行业
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="industry_id1"></param>
        /// <param name="industry_id2"></param>
        /// <returns></returns>
        public static BaseRes Template_Api_set_industry(string access_token, string industry_id1, string industry_id2)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/template/api_set_industry?access_token=";
            url += access_token;

            var post = new
            {
                industry_id1 = industry_id1,
                industry_id2 = industry_id2
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 获得模板ID
        /// <summary>
        /// 获得模板ID
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="template_id_short"></param>
        public static Template_Api_add_templateRes Template_Api_add_template(string access_token, string template_id_short)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/template/api_add_template?access_token=";
            url += access_token;

            var post = new
            {
                template_id_short = template_id_short
            };

            return PostObject<Template_Api_add_templateRes>(url, post);
        }
        #endregion

        #region 发送模板消息
        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="access_token"></param>
        public static Template_SendRes Template_Send(string access_token, string touser, string template_id, Dictionary<string, TemplateData> data)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=";
            url += access_token;

            var post = new
            {
                touser = touser,
                template_id = template_id,
                url = "http://weixin.qq.com/download",
                data = data
            };

            return PostObject<Template_SendRes>(url, post);
        }
        #endregion

        // 素材管理接口
        #region 新增临时素材
        /// <summary>
        /// 新增临时素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="type"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static MediaUploadRes Media_Upload(string access_token, EnumUploadType type, string file)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";
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

        #region 获取临时素材
        /// <summary>
        /// 获取临时素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static MediaGetRes Media_Get(string access_token, string media_id, string filepath)
        {
            string filename = null;

            string url = "https://api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";
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

        // 用户管理
        #region 创建分组
        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="name"></param>
        public static Groups_CreateRes Groups_Create(string access_token, string name)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/create?access_token=";
            url += access_token;

            var post = new
            {
                group = new
                {
                    name = name
                }
            };

            return PostObject<Groups_CreateRes>(url, post);
        }
        #endregion

        #region 查询所有分组
        /// <summary>
        /// 查询所有分组
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static Groups_GetRes Groups_Get(string access_token)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/get?access_token=";
            url += access_token;

            return GetObject<Groups_GetRes>(url);
        }
        #endregion

        #region 查询用户所在分组
        /// <summary>
        /// 查询用户所在分组
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static Groups_GetidRes Groups_Getid(string access_token, string openid)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/getid?access_token=";
            url += access_token;

            var post = new
            {
                openid = openid
            };

            return PostObject<Groups_GetidRes>(url, post);
        }
        #endregion

        #region 修改分组名
        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="group"></param>
        public static BaseRes Groups_Update(string access_token, Group group)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/update?access_token=";
            url += access_token;

            var post = new
            {
                group = new
                {
                    id = group.id,
                    name = group.name
                }
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 移动用户分组
        /// <summary>
        /// 移动用户分组
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <param name="to_groupid"></param>
        public static BaseRes Groups_Members_Update(string access_token, string openid, int to_groupid)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token=";
            url += access_token;

            var post = new
            {
                openid = openid,
                to_groupid = to_groupid
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 批量移动用户分组
        /// <summary>
        /// 批量移动用户分组
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid_list"></param>
        /// <param name="to_groupid"></param>
        /// <returns></returns>
        public static BaseRes Groups_Members_Batchupdate(string access_token, List<string> openid_list, int to_groupid)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/members/batchupdate?access_token=";
            url += access_token;

            var post = new
            {
                openid_list = openid_list,
                to_groupid = to_groupid
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 删除分组
        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        public static BaseRes Groups_Delete(string access_token, int id)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/groups/delete?access_token=";
            url += access_token;

            var post = new
            {
                group = new
                {
                    id = id
                }
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 设置备注名
        /// <summary>
        /// 设置备注名
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <param name="remark"></param>
        public static BaseRes User_Info_Updateremark(string access_token, string openid, string remark)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/user/info/updateremark?access_token=";
            url += access_token;

            var post = new
            {
                openid = openid,
                remark = remark
            };

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 获取用户基本信息（包括UnionID机制）
        /// <summary>
        /// 获取用户基本信息（包括UnionID机制）
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        public static User_InfoRes User_Info(string access_token, string openid)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";
            url = string.Format(url, access_token, openid);

            return GetObject<User_InfoRes>(url);
        }
        #endregion

        #region 批量获取用户基本信息
        /// <summary>
        /// 批量获取用户基本信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openids"></param>
        public static User_InfoRes User_Info_Batchget(string access_token, List<string> openids)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token=";
            url += access_token;

            var post = new
            {
                user_list = openids.Select(a => new 
                { 
                    openid = a, 
                    lang = "zh-CN" 
                }).ToArray()
            };

            return PostObject<User_InfoRes>(url, post);
        }
        #endregion

        #region 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="next_openid"></param>
        public static User_GetRes User_Get(string access_token, string next_openid)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}";
            url = string.Format(url, access_token, next_openid);

            return GetObject<User_GetRes>(url);
        }
        #endregion

        #region 自定义菜单创建接口
        /// <summary>
        /// 自定义菜单创建接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        public static BaseRes Menu_Create(string access_token, string post)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=";
            url += access_token;

            return PostObject<BaseRes>(url, post);
        }
        #endregion

        #region 自定义菜单查询接口
        /// <summary>
        /// 自定义菜单查询接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static string Menu_Get(string access_token)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/menu/get?access_token=";
            url += access_token;

            TimeoutWebClient wc = ThreadWebClientFactory.GetWebClient();
            wc.Encoding = Encoding.UTF8;
            var json = wc.GetLoadString(url, string.Empty);

            return json;
        }
        #endregion

        #region 自定义菜单删除接口
        /// <summary>
        /// 自定义菜单删除接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static BaseRes Menu_Delete(string access_token)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=";
            url += access_token;

            return GetObject<BaseRes>(url);
        }
        #endregion

        #region 获取自定义菜单配置接口
        /// <summary>
        /// 获取自定义菜单配置接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static string Get_current_selfmenu_info(string access_token)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token=";
            url += access_token;

            TimeoutWebClient wc = ThreadWebClientFactory.GetWebClient();
            wc.Encoding = Encoding.UTF8;
            var json = wc.GetLoadString(url, string.Empty);

            return json;
        }
        #endregion

        #region 创建临时二维码请求说明
        /// <summary>
        /// 创建临时二维码请求说明
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="action_name"></param>
        /// <param name="scene_id"></param>
        /// <param name="expire_seconds"></param>
        /// <returns></returns>
        public static Qrcode_CreateRes Qrcode_Create(string access_token, string action_name, int scene_id, int expire_seconds = 604800)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=";
            url += access_token;

            var post = new
            {
                expire_seconds = expire_seconds,
                action_name = action_name,
                action_info = new
                {
                    scene = new
                    {
                        scene_id = scene_id
                    }
                }
            };

            return PostObject<Qrcode_CreateRes>(url, post);
        }
        #endregion

        #region 创建永久二维码请求说明
        /// <summary>
        /// 创建永久二维码请求说明
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="action_name"></param>
        /// <param name="scene_id"></param>
        /// <param name="scene_str"></param>
        /// <returns></returns>
        public static Qrcode_CreateRes Qrcode_Create(string access_token, string action_name, int scene_id, string scene_str)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=";
            url += access_token;

            var post = new
            {
                action_name = action_name,
                action_info = new
                {
                    scene = new
                    {
                        scene_id = scene_id,
                        scene_str = scene_str
                    }
                }
            };

            return PostObject<Qrcode_CreateRes>(url, post);
        }
        #endregion

        #region 通过ticket换取二维码
        /// <summary>
        /// 通过ticket换取二维码
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static MediaGetRes Showqrcode(string ticket, string filepath)
        {
            string filename = null;
            string url = "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=";
            url += ticket;

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

        #region 长链接转短链接接口
        /// <summary>
        /// 长链接转短链接接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="long_url"></param>
        /// <returns></returns>
        public static ShorturlRes Shorturl(string access_token, string long_url)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/shorturl?access_token=";
            url += access_token;

            var post = new
            {
                action = "long2short",
                long_url = long_url
            };

            return PostObject<ShorturlRes>(url, post);
        }
        #endregion

        // 数据统计接口
        #region 获取用户增减数据
        /// <summary>
        /// 获取用户增减数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetusersummaryRes Datacube_Getusersummary(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getusersummary?access_token=";
            url += access_token;

            return PostObject<Datacube_GetusersummaryRes>(url, p); 
        }
        #endregion

        #region 获取累计用户数据
        /// <summary>
        /// 获取累计用户数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetusersummaryRes Datacube_Getusercumulate(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getusercumulate?access_token=";
            url += access_token;

            return PostObject<Datacube_GetusersummaryRes>(url, p); 
        }
        #endregion

        #region 获取图文群发每日数据
        /// <summary>
        /// 获取图文群发每日数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetarticlesummaryRes Datacube_Getarticlesummary(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getarticlesummary?access_token=";
            url += access_token;

            return PostObject<Datacube_GetarticlesummaryRes>(url, p); 
        }
        #endregion

        #region 获取图文群发总数据
        /// <summary>
        /// 获取图文群发总数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        public static Datacube_GetarticletotalRes Datacube_Getarticletotal(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getarticletotal?access_token=";
            url += access_token;

            return PostObject<Datacube_GetarticletotalRes>(url, p); 
        }
        #endregion

        #region 获取图文统计数据
        /// <summary>
        /// 获取图文统计数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        public static Datacube_GetuserreadRes Datacube_Getuserread(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getuserread?access_token=";
            url += access_token;

            return PostObject<Datacube_GetuserreadRes>(url, p);
        }
        #endregion

        #region 获取图文统计分时数据
        /// <summary>
        /// 获取图文统计分时数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        public static Datacube_GetuserreadhourRes Datacube_Getuserreadhour(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getuserreadhour?access_token=";
            url += access_token;

            return PostObject<Datacube_GetuserreadhourRes>(url, p);
        }
        #endregion

        #region 获取图文分享转发数据
        /// <summary>
        /// 获取图文分享转发数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        public static Datacube_GetusershareRes Datacube_Getusershare(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getusershare?access_token=";
            url += access_token;

            return PostObject<Datacube_GetusershareRes>(url, p);
        }
        #endregion

        #region 获取图文分享转发分时数据
        /// <summary>
        /// 获取图文分享转发分时数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        public static Datacube_GetusersharehourRes Datacube_Getusersharehour(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getusersharehour?access_token=";
            url += access_token;

            return PostObject<Datacube_GetusersharehourRes>(url, p);
        }
        #endregion

        #region 获取消息发送概况数据
        /// <summary>
        /// 获取消息发送概况数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetupstreammsgRes Datacube_Getupstreammsg(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getupstreammsg?access_token=";
            url += access_token;

            return PostObject<Datacube_GetupstreammsgRes>(url, p);
        }
        #endregion

        #region 获取消息分送分时数据
        /// <summary>
        /// 获取消息分送分时数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetupstreammsghourRes Datacube_Getupstreammsghour(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getupstreammsghour?access_token=";
            url += access_token;

            return PostObject<Datacube_GetupstreammsghourRes>(url, p);
        }
        #endregion

        #region 获取消息发送周数据
        /// <summary>
        /// 获取消息发送周数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetupstreammsgweekRes Datacube_Getupstreammsgweek(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getupstreammsgweek?access_token=";
            url += access_token;

            return PostObject<Datacube_GetupstreammsgweekRes>(url, p);
        }
        #endregion

        #region 获取消息发送月数据
        /// <summary>
        /// 获取消息发送月数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetupstreammsgmonthRes Datacube_Getupstreammsgmonth(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getupstreammsgmonth?access_token=";
            url += access_token;

            return PostObject<Datacube_GetupstreammsgmonthRes>(url, p);
        }
        #endregion

        #region 获取消息发送分布数据
        /// <summary>
        /// 获取消息发送分布数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetupstreammsgdistRes Datacube_Getupstreammsgdist(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getupstreammsgdist?access_token=";
            url += access_token;

            return PostObject<Datacube_GetupstreammsgdistRes>(url, p);
        }
        #endregion

        #region 获取消息发送分布周数据
        /// <summary>
        /// 获取消息发送分布周数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetupstreammsgdistweekRes Datacube_Getupstreammsgdistweek(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getupstreammsgdistweek?access_token=";
            url += access_token;

            return PostObject<Datacube_GetupstreammsgdistweekRes>(url, p);
        }
        #endregion

        #region 获取消息发送分布月数据
        /// <summary>
        /// 获取消息发送分布月数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetupstreammsgdistmonthRes Datacube_Getupstreammsgdistmonth(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getupstreammsgdistmonth?access_token=";
            url += access_token;

            return PostObject<Datacube_GetupstreammsgdistmonthRes>(url, p);
        }
        #endregion

        #region 获取接口分析数据
        /// <summary>
        /// 获取接口分析数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetinterfacesummaryRes Datacube_Getinterfacesummary(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getinterfacesummary?access_token=";
            url += access_token;

            return PostObject<Datacube_GetinterfacesummaryRes>(url, p);
        }
        #endregion

        #region 获取接口分析分时数据
        /// <summary>
        /// 获取接口分析分时数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Datacube_GetinterfacesummaryhourRes Datacube_Getinterfacesummaryhour(string access_token, DatacubeParams p)
        {
            string url = "https://api.weixin.qq.com/datacube/getinterfacesummaryhour?access_token=";
            url += access_token;

            return PostObject<Datacube_GetinterfacesummaryhourRes>(url, p);
        }
        #endregion

    }
}
