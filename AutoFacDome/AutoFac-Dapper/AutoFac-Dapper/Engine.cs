using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AutoFac_Dapper
{
    /// <summary>
    /// 引擎
    /// 负责初始化注册依赖,提供AutoFac容器管理对象.
    /// </summary>
    public class Engine : IEngine
    {
        /// <summary>
        /// AutoFac容器管理对象
        /// </summary>
        private ContainerManager _containerManager;

        #region ContainerManager
        
        /// <summary>
        /// 得到AutoFac容器管理对象
        /// </summary>
        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        /// <summary>
        /// 解决依赖关系
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }

        /// <summary>
        /// 解决依赖
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        /// <summary>
        ///  解决依赖
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }
        #endregion

        /// <summary>
        /// 注册依赖
        /// </summary>
        protected void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            var dependencyRegistrar = new DependencyRegistrar();
            dependencyRegistrar.Register(builder);

            var container = builder.Build();
            this._containerManager = new ContainerManager(container);

            //builder.Update(container);
        }

        /// <summary>
        /// 初始化环境组件和插件。
        /// </summary>
        public void Initialize()
        {
            RegisterDependencies();
        }
    }
}
