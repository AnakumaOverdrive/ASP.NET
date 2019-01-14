using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class DeviceInfo
    {
        /// <summary>
        /// 设备ID，唯一性标识一个设备。
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 设备标签。
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// 设备IP 地址。
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// 掩码。
        /// </summary>
        public string mask { get; set; }

        /// <summary>
        /// 请参考设备状态值说明。
        /// 设备状态。-1: unmanage 0: unknown 1: normal 2: warning 3: minor 4: major 5: critical
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 状态说明
        /// </summary>
        public string statusDesc { get; set; }

        /// <summary>
        /// 系统名称。
        /// </summary>
        public string sysName { get; set; }

        /// <summary>
        /// 联系人。
        /// </summary>
        public string contact { get; set; }

        /// <summary>
        /// 位置。
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// sysOID。
        /// </summary>
        public string sysOid { get; set; }

        /// <summary>
        /// 运行时间。
        /// </summary>
        public string runtime { get; set; }

        /// <summary>
        /// 最后轮询时间。
        /// 字符串（String）类型，格式为 yyyy-MM-dd HH:mm:ss。
        /// </summary>
        public string lastPoll { get; set; }

        /// <summary>
        /// 登录方式。0：无，1：Telnet，2：SSH。
        /// </summary>
        public int loginType { get; set; }

        /// <summary>
        /// 系统描述。
        /// </summary>
        public string sysDescription { get; set; }

        /// <summary>
        /// 设备类型ID。
        /// </summary>
        public int categoryId { get; set; }

        /// <summary>
        /// 是否支持Ping操作。
        /// </summary>
        public bool supportPing { get; set; }

        /// <summary>
        /// SNMP模板ID。
        /// </summary>
        public int snmpTmplId { get; set; }

        /// <summary>
        /// TELNET模板ID。
        /// </summary>
        public int telnetTmplId { get; set; }

        /// <summary>
        /// SSH模板ID。
        /// </summary>
        public int sshTmplId { get; set; }

        /// <summary>
        /// 下级网管的登录端口
        /// 如果此元素不存在，则使用系统管理中全局Web网管配置。
        /// </summary>
        public long webMgrPort { get; set; }

        /// <summary>
        /// 配置轮询时间。单位为分钟。
        /// </summary>
        public int configPollTime { get; set; }

        /// <summary>
        /// 状态轮询时间间隔。单位为秒。
        /// </summary>
        public int statePollTime { get; set; }

        /// <summary>
        /// 设备服务。
        /// 元素类型，可有多个元素。请参考查询设备服务监控信息的API文档。
        /// </summary>
        public object deviceService { get; set; }

        /// <summary>
        /// 设备符号ID
        /// API中写着:大整数（BigInteger）类型。
        /// </summary>
        public long symbolId { get; set; }

        /// <summary>
        /// 设备符号名称。
        /// </summary>
        public string symbolName { get; set; }

        /// <summary>
        /// 设备符号类型。
        /// </summary>
        public int symbolType { get; set; }

        /// <summary>
        /// 设备符号描述。
        /// </summary>
        public string symbolDesc { get; set; }

        /// <summary>
        /// 设备符号级别。
        /// </summary>
        public int symbolLevel { get; set; }

        /// <summary>
        /// 设备父符号ID。
        /// API中写着:大整数（BigInteger）类型。
        /// </summary>
        public long parentId { get; set; }

        /// <summary>
        /// 设备类型名称。
        /// </summary>
        public string typeName { get; set; }

        /// <summary>
        /// 视图类型。1：IP视图；3：自定义视图的根符号id；11：自定义视图我的网络拓扑视图id；514：虚拟视图的根符号id；
        /// API中写着:大整数（BigInteger）类型。
        /// </summary>
        public long viewType { get; set; }

        /// <summary>
        /// 符号对应的图标。
        /// </summary>
        public string iconFileName { get; set; }

        /// <summary>
        /// x位置坐标。
        /// API中写着:大整数（BigInteger）类型。
        /// </summary>
        public long positionX { get; set; }

        /// <summary>
        /// y位置坐标。
        /// API中写着:大整数（BigInteger）类型。
        /// </summary>
        public string positionY { get; set; }

        /// <summary>
        /// 显示标志。0: visible 1: hidden
        /// </summary>
        public int visibleFlag { get; set; }

        /// <summary>
        /// 设备状态图标文件。
        /// </summary>
        public string statusImg { get; set; }

        /// <summary>
        /// 设备bin文件。
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// MAC地址。
        /// </summary>
        public string mac { get; set; }

        /// <summary>
        /// 设备类型图标文件。
        /// </summary>
        public string categoryImg { get; set; }

        /// <summary>
        /// 设备厂商图标文件。
        /// </summary>
        public string vendorImg { get; set; }

        /// <summary>
        /// 设备符号的子符号个数。
        /// </summary>
        public int childrenNum { get; set; }

        /// <summary>
        /// 边缘子网标识。
        /// </summary>
        public int vergeNet { get; set; }

        /// <summary>
        /// 物理名称。
        /// </summary>
        public string phyName { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        public string phyCreateTime { get; set; }

        /// <summary>
        /// 创建者。
        /// </summary>
        public string phyCreator { get; set; }

        /// <summary>
        /// 附加Unicode。
        /// </summary>
        public string appendUnicode { get; set; }

        /// <summary>
        /// SNMP模板 URI。
        /// </summary>
        public string snmpTmpl { get; set; }

        /// <summary>
        /// TELNET模板 URI。
        /// </summary>
        public string telnetTmpl { get; set; }

        /// <summary>
        /// 	SSH模板 URI。
        /// </summary>
        public string sshTmpl { get; set; }

        /// <summary>
        /// 设备系列 URI。
        /// </summary>
        public string series { get; set; }

        /// <summary>
        /// 设备型号 URI。
        /// </summary>
        public string model { get; set; }

        /// <summary>
        /// 设备接口列表 URI。
        /// </summary>
        public string interfaces { get; set; }

        /// <summary>
        /// 设备类型 URI。
        /// </summary>
        public string category { get; set; }

        /// <summary>
        /// link
        /// </summary>
        public DeviceInfoList Link { get; set; }

        /// <summary>
        /// 设备主机名或 IP 地址。
        /// </summary>
        public string nameOrIp { get; set; }
    }

    public class DeviceInfoList
    {
        public string op { get; set; }

        public string rel { get; set; }

        public string href { get; set; }
    }
}
