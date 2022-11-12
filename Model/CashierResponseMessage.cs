
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PAYJS_CSharp_SDK.Model
{
    /// <summary>
    ///  Native 扫码支付（主扫） API返回数据
    /// </summary>
    public class CashierResponseMessage
    {
        /// <summary>
        /// 0:提交失败
        /// </summary>
        public int return_code { get; set; }
        /// <summary>
        /// 0:失败
        /// </summary>

        public int status { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 失败原因，同msg
        /// </summary>
        public string return_msg { get; set; }

        public string ToJsonString()
        {
            String json = JsonSerializer.Serialize(this, MyJsonConvert.GetOptions());
            return json;
        }
    }
}
