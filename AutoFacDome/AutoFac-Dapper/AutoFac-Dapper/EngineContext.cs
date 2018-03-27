using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac_Dapper
{
    /// <summary>
    /// 引擎上下文
    /// 提供单例的引擎以供使用.
    /// </summary>
    public class EngineContext
    {
        /// <summary>
        /// 初始化工厂静态实例。
        /// </summary>
        /// <param name="forceRecreate">
        /// 即使工厂已初始化，也会创建新的工厂实例。
        /// </param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceRecreate)
        {
            if (Singleton<IEngine>.Instance == null || forceRecreate)
            {
                Singleton<IEngine>.Instance = new Engine();

                Singleton<IEngine>.Instance.Initialize();
            }
            return Singleton<IEngine>.Instance;
        }

        /// <summary>
        /// 将静态引擎实例设置为提供的引擎。
        /// 使用此方法提供自己的引擎实现。
        /// </summary>
        /// <param name="engine"> 使用的引擎 </param>
        /// <remarks> 仅使用这个方法，如果你知道你在做什么</remarks>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }

        /// <summary>
        /// 获取用于访问数据库的服务单例
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize(false);
                }
                return Singleton<IEngine>.Instance;
            }
        }
    }

    /// <summary>
    /// 一个静态编译的“单件”用于存储对象的整个应用程序域的生命周期。
    /// 在模式的意义上，并不是单一的子模式作为一个标准化的方法来存储单个实例。
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    /// <remarks>访问实例不同步.</remarks>
    public class Singleton<T> : Singleton
    {
        static T instance;

        /// <summary>
        /// 指定类型t的单个实例。
        /// 每一种类型的字典只有一个实例（在时间上）。
        /// </summary>
        public static T Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }

    /// <summary>
    /// 提供存取所有 "单例" 存储 <see cref="Singleton{T}"/>.
    /// </summary>
    public class Singleton
    {
        static Singleton()
        {
            allSingletons = new Dictionary<Type, object>();
        }

        static readonly IDictionary<Type, object> allSingletons;

        /// <summary>单例实例类型字典.</summary>
        public static IDictionary<Type, object> AllSingletons
        {
            get { return allSingletons; }
        }
    }

    /// <summary>
    /// 提供特定类型的单例列表。 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonList<T> : Singleton<IList<T>>
    {
        static SingletonList()
        {
            Singleton<IList<T>>.Instance = new List<T>();
        }

        /// <summary>
        /// 指定类型t的单个实例。
        /// 每一种类型的字典只有一个实例（在时间上）。
        /// </summary>
        public new static IList<T> Instance
        {
            get { return Singleton<IList<T>>.Instance; }
        }
    }

    /// <summary>
    /// 提供了单例字典的获得某些建和值
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>>
    {
        static SingletonDictionary()
        {
            Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// 指定类型t的单个实例。
        /// 每一种类型的字典只有一个实例（在时间上）。
        /// </summary>
        public new static IDictionary<TKey, TValue> Instance
        {
            get { return Singleton<Dictionary<TKey, TValue>>.Instance; }
        }
    }
}
