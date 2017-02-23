using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CSC.Web
{
    /// <summary>
    /// 通用类
    /// </summary>
    public class General
    {
        /// <summary>
        /// 获取模型错误
        /// 部分内容是通过AJAX方法提交，如果提交时客户端没有进行验证，在服务器端进行验证时会将错误信息保存在ModelState中，这里的方法来获取ModelState的错误信息，以便反馈给客户端。
        /// </summary>
        /// <param name="modelState">模型状态</param>
        /// <returns></returns>
        public static string GetModelErrorString(ModelStateDictionary modelState)
        {
            StringBuilder _sb = new StringBuilder();
            var _ErrorModelState = modelState.Where(m => m.Value.Errors.Count() > 0);
            foreach (var item in _ErrorModelState)
            {
                foreach (var modelError in item.Value.Errors)
                {
                    _sb.AppendLine(modelError.ErrorMessage);
                }
            }
            return _sb.ToString();
        }
    }
}