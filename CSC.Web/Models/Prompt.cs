using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSC.Web.Models
{
    /// <summary>
    /// 提示模型类Prompt
    ///在进行操作的时候经常会需要对操作成功、失败、发生错误进行提示。
    /// </summary>
    public class Prompt
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 按钮组
        /// </summary>
        public List<string> Buttons { get; set; }
    }
}