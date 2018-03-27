using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac_Dapper
{
    public interface IEngine
    {
        /// <summary>
        /// AutoFac容器管理对象
        /// </summary>
        ContainerManager ContainerManager { get; }

        /// <summary>
        /// 初始化环境中的组件和插件。
        /// </summary>
        void Initialize();

        /// <summary>
        /// 解决依赖
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;

        /// <summary>
        ///  解决依赖
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// 解决依赖
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        T[] ResolveAll<T>();
    }
}
