using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PAYJS_CSharp_SDK.Model
{
    /// <summary>
    /// 收银台支付请求
    /// </summary>
    public class CashierRequestMessage
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public String mchid { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public int total_fee { get; set; }
        /// <summary>
        /// 用户端自主生成的订单号，在用户端要保证唯一性
        /// </summary>
        public String out_trade_no { get; set; }
        /// <summary>
        /// 订单标题
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 用户自定义数据，在notify的时候会原样返回
        /// </summary>
        public string attch { get; set; }
        /// <summary>
        /// 接收微信支付异步通知的回调地址。必须为可直接访问的URL，不能带参数、session验证、csrf验证。留空则不通知
        /// </summary>
        public string notify_url { get; set; }
        /// <summary>
        /// 用户支付成功后，前端跳转地址
        /// </summary>
        public string callback_url { get; set; }
        /// <summary>
        /// auto=1：无需点击支付按钮，自动发起支付。默认手动点击发起支付
        /// </summary>
        public bool? auto { get; set; }

        /// <summary>
        /// hide=1：隐藏收银台背景界面。默认显示背景界面（这里hide为1时，自动忽略auto参数）
        /// </summary>
        public bool? hide { get; set; } 
        /// <summary>
        /// 收银台显示的logo图片url
        /// </summary>
        public string logo { get; set; }
        /// <summary>
        /// 数据签名
        /// </summary>
        public string sign { get; set; }
        public string ToJsonString()
        {
            String json = JsonSerializer.Serialize(this, MyJsonConvert.GetOptions());
            return json;
        }
        public Dictionary<string, string> GetApiParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param["total_fee"] = this.total_fee.ToString();
            param["out_trade_no"] = this.out_trade_no.ToString(); ;
            param["body"] = this.body;
            param["attch"] = this.attch;
            //可选项目
            if (!String.IsNullOrEmpty(this.notify_url))
            {
                param["notify_url"] = this.notify_url;
            }
            if (!string.IsNullOrEmpty(this.callback_url))
            {
                param["callback_url"] = this.callback_url;
            }
            if (auto!=null)
            {
                param["auto"] = this.auto.Value.ToString();
            }
            if (hide != null)
            {
                param["hide"] = this.hide.Value.ToString();
            }
            if (!string.IsNullOrEmpty(this.logo))
            {
                param["logo"] = this.logo;
            }

            return param;
        }
    }
}
