using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CSC.Core
{
    /// <summary>
    /// 数据上下文工厂
    /// </summary>
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前线程的数据上下文
        /// </summary>
        /// <returns>数据上下文</returns>
        public static CSCContext CurrentContext()
        {
            CSCContext _nContext = CallContext.GetData("CSCContext") as CSCContext;
            if (_nContext == null)
            {
                _nContext = new CSCContext();
                CallContext.SetData("CSCContext", _nContext);
            }
            return _nContext;
        }
    }
}
