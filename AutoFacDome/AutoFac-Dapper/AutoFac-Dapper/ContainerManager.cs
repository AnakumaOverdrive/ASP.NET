using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core.Lifetime;

namespace AutoFac_Dapper
{
    /// <summary>
    /// AutoFac容器管理
    /// 负责容器的生命周期和提供解决方法.
    /// </summary>
    public class ContainerManager
    {
        private readonly IContainer _container;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="container">AutoFac容器</param>
        public ContainerManager(IContainer container)
        {
            this._container = container;
        }

        /// <summary>
        ///获得一个容器
        /// </summary>
        public virtual IContainer Container
        {
            get
            {
                return _container;
            }
        }

        /// <summary>
        /// 解决
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">key</param>
        /// <param name="scope">生命周期;通过NULL自动解决当前范围</param>
        /// <returns>解决服务</returns>
        public virtual T Resolve<T>(string key = "", ILifetimeScope scope = null) where T : class
        {
            if (scope == null)
            {
                scope = Scope();
            }
            if (string.IsNullOrEmpty(key))
            {
                return scope.Resolve<T>();
            }
            return scope.ResolveKeyed<T>(key);
        }

        /// <summary>
        /// 解决
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="scope">生命周期; 通过NULL自动解决当前范围</param>
        /// <returns>解决服务</returns>
        public virtual object Resolve(Type type, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            return scope.Resolve(type);
        }

        /// <summary>
        /// 全部解决
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">key</param>
        /// <param name="scope">生命周期; 通过NULL自动解决当前范围</param>
        /// <returns>解决服务</returns>
        public virtual T[] ResolveAll<T>(string key = "", ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            if (string.IsNullOrEmpty(key))
            {
                return scope.Resolve<IEnumerable<T>>().ToArray();
            }
            return scope.ResolveKeyed<IEnumerable<T>>(key).ToArray();
        }

        /// <summary>
        /// 解决未注册的服务
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="scope">生命周期;通过NULL自动解决当前范围</param>
        /// <returns>解决服务</returns>
        public virtual T ResolveUnregistered<T>(ILifetimeScope scope = null) where T : class
        {
            return ResolveUnregistered(typeof(T), scope) as T;
        }

        /// <summary>
        ///解决未注册的服务
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="scope">生命周期;通过NULL自动解决当前范围</param>
        /// <returns>解决服务</returns>
        public virtual object ResolveUnregistered(Type type, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            var constructors = type.GetConstructors();
            foreach (var constructor in constructors)
            {
                try
                {
                    var parameters = constructor.GetParameters();
                    var parameterInstances = new List<object>();
                    foreach (var parameter in parameters)
                    {
                        var service = Resolve(parameter.ParameterType, scope);
                        if (service == null) throw new Exception("未知的依赖");
                        parameterInstances.Add(service);
                    }
                    return Activator.CreateInstance(type, parameterInstances.ToArray());
                }
                catch (Exception)
                {

                }
            }
            throw new Exception("找不到所有依赖项满足的构造函数.");
        }

        /// <summary>
        /// 尝试解决服务
        /// </summary>
        /// <param name="serviceType">类型</param>
        /// <param name="scope">生命周期; 通过NULL自动解决当前范围</param>
        /// <param name="instance">解决服务</param>
        /// <returns>指示服务是否已成功解决</returns>
        public virtual bool TryResolve(Type serviceType, ILifetimeScope scope, out object instance)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            return scope.TryResolve(serviceType, out instance);
        }

        /// <summary>
        /// 检查某些服务是否已注册（可以解决）
        /// </summary>
        /// <param name="serviceType">类型</param>
        /// <param name="scope">生命周期; 通过NULL自动解决当前范围</param>
        /// <returns>Result</returns>
        public virtual bool IsRegistered(Type serviceType, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            return scope.IsRegistered(serviceType);
        }

        /// <summary>
        /// 解决可选
        /// </summary>
        /// <param name="serviceType">类型</param>
        /// <param name="scope">生命周期; 通过NULL自动解决当前范围</param>
        /// <returns>解决服务</returns>
        public virtual object ResolveOptional(Type serviceType, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            return scope.ResolveOptional(serviceType);
        }

        /// <summary>
        ///获得当前的生命周期
        /// </summary>
        /// <returns>生命周期</returns>
        public virtual ILifetimeScope Scope()
        {
            try
            {
                //TODO Web开发的时候将这句打开,让AutoFac使用HttpContext.Current的生命周期
                //if (HttpContext.Current != null)
                //    return AutofacDependencyResolver.Current.RequestLifetimeScope;

                //当返回这样的生命范围时，您应该确信它一旦使用就会被处理（例如在日程任务中）
                //MatchingScopeLifetimeTags.RequestLifetimeScopeTag:
                //用于设置每个请求生命期范围注册的标签（例如，每个HTTP请求或每个API请求）
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
            catch (Exception)
            {
                //Fuck......
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
        }
    }
}
