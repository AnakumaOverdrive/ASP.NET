using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 监控管理对象
    /// </summary>
    public class MonitorManageObj
    {
        public string MmoId { get; set; }

        /// <summary>
        /// 来源类型
        /// 0:固有属性 1:扫描获取 2:变更增加
        /// </summary>
        //public int SourceType { get; set; }

        /// <summary>
        /// 对象类型
        /// </summary>
        public string MoClass { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 管理IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 设备厂商
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// 操作系统描述
        /// </summary>
        public string Descr { get; set; }

        /// <summary>
        /// 系统OID
        /// </summary>
        public string SystemOID { get; set; }

        /// <summary>
        /// 管理等级
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// uuid
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// domain
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// 操作系统类型
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// 操作系统版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 硬件厂商
        /// </summary>
        public string HardwareVendors { get; set; }

        /// <summary>
        /// 设备标识号
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 购买批次
        /// </summary>
        public string PurchasingBatches { get; set; }

        /// <summary>
        /// 线路类型
        /// </summary>
        public string LineType { get; set; }

        /// <summary>
        /// 上行带宽
        /// </summary>
        public string Upifspeed { get; set; }

        /// <summary>
        /// 下行带宽
        /// </summary>
        public string Downifspeed { get; set; }

        /// <summary>
        /// 上行方向
        /// </summary>
        public string Updirection { get; set; }

        /// <summary>
        /// 连接设备1的{moPath}
        /// </summary>
        public string HmDevice1 { get; set; }

        /// <summary>
        /// 连接设备1端口的{moPath}
        /// </summary>
        public string Port1 { get; set; }

        /// <summary>
        /// 连接设备2的{moPath}
        /// </summary>
        public string HmDevice2 { get; set; }

        /// <summary>
        /// 连接设备2端口的{moPath}
        /// </summary>
        public string Port2 { get; set; }
    }
}
