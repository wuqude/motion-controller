using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiketang.com.DAL
{
        /// <summary>
        /// 注册表
        /// </summary>
        public class Regedit
        {
            private const string SUB_KEY = "SOFTWARE";
            private static readonly RegistryKey HKML;
            private static readonly RegistryKey SOFTWARE;

            static Regedit()
            {
                //Win10 读写LocalMachine权限，没有访问权限
                HKML = Registry.CurrentUser;
                SOFTWARE = HKML.OpenSubKey(SUB_KEY, true);
            }

            /// <summary>
            /// 读取数据
            /// </summary>
            /// <param name="node">节点</param>
            /// <param name="name">名称</param>
            /// <returns></returns>
            public static object GetData(string node, string name)
            {
                RegistryKey tmp = SOFTWARE.OpenSubKey(node, true);
                return tmp?.GetValue(name);
            }

            /// <summary>
            /// 写入值
            /// </summary>
            /// <param name="node">节点</param>
            /// <param name="name">名称</param>
            /// <param name="value">值</param>
            public static void AddItem(string node, string name, object value)
            {
                RegistryKey tmp = SOFTWARE.CreateSubKey(node);
                tmp?.SetValue(name, value);
            }
        
    }
}
