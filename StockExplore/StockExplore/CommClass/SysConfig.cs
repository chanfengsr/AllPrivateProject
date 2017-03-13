using System;
using System.Linq;
using System.Xml;
using System.IO;

namespace StockExplore
{
    /// <summary>系统读写配置文件
    /// </summary>
    public class SysConfig
    {
        private const string _configFileFolderName = "ConfigFile";
        private const string _configFileName = "SystemConfig.xml";

        #region 基本操作函数

        /// <summary>
        /// 得到程序工作目录
        /// </summary>
        /// <returns></returns>
        public static string GetWorkDirectory()
        {
            try
            {
                return Path.GetDirectoryName(typeof (SysConfig).Assembly.Location) + "\\" + _configFileFolderName;
            }
            catch
            {
                return System.Windows.Forms.Application.StartupPath + "\\" + _configFileFolderName;
            }
        }

        /// <summary>
        /// 判断字符串是否为空串
        /// </summary>
        /// <param name="szString">目标字符串</param>
        /// <returns>true:为空串;false:非空串</returns>
        private static bool IsEmptyString(string szString)
        {
            if (szString == null)
                return true;
            if (szString.Trim() == string.Empty)
                return true;
            return false;
        }

        /// <summary>
        /// 创建一个制定根节点名的XML文件
        /// </summary>
        /// <param name="szFileName">XML文件</param>
        /// <param name="szRootName">根节点名</param>
        /// <returns>bool</returns>
        private static bool CreateXmlFile(string szFileName, string szRootName)
        {
            if (szFileName == null || szFileName.Trim() == "")
                return false;
            if (szRootName == null || szRootName.Trim() == "")
                return false;

            XmlDocument clsXmlDoc = new XmlDocument();
            clsXmlDoc.AppendChild(clsXmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null));
            clsXmlDoc.AppendChild(clsXmlDoc.CreateNode(XmlNodeType.Element, szRootName, ""));
            try
            {
                clsXmlDoc.Save(szFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 从XML文件获取对应的XML文档对象
        /// </summary>
        /// <param name="szXmlFile">XML文件</param>
        /// <returns>XML文档对象</returns>
        private static XmlDocument GetXmlDocument(string szXmlFile)
        {
            if (IsEmptyString(szXmlFile))
                return null;
            if (!File.Exists(szXmlFile))
                return null;
            XmlDocument clsXmlDoc = new XmlDocument();
            try
            {
                clsXmlDoc.Load(szXmlFile);
            }
            catch
            {
                return null;
            }
            return clsXmlDoc;
        }

        /// <summary>
        /// 将XML文档对象保存为XML文件
        /// </summary>
        /// <param name="clsXmlDoc">XML文档对象</param>
        /// <param name="szXmlFile">XML文件</param>
        /// <returns>bool:保存结果</returns>
        private static bool SaveXmlDocument(XmlDocument clsXmlDoc, string szXmlFile)
        {
            if (clsXmlDoc == null)
                return false;
            if (IsEmptyString(szXmlFile))
                return false;
            try
            {
                if (File.Exists(szXmlFile))
                    File.Delete(szXmlFile);
            }
            catch
            {
                return false;
            }
            try
            {
                clsXmlDoc.Save(szXmlFile);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取XPath指向的单一XML节点
        /// </summary>
        /// <param name="clsRootNode">XPath所在的根节点</param>
        /// <param name="szXPath">XPath表达式</param>
        /// <returns>XmlNode</returns>
        private static XmlNode SelectXmlNode(XmlNode clsRootNode, string szXPath)
        {
            if (clsRootNode == null || IsEmptyString(szXPath))
                return null;
            try
            {
                return clsRootNode.SelectSingleNode(szXPath);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取XPath指向的XML节点集
        /// </summary>
        /// <param name="clsRootNode">XPath所在的根节点</param>
        /// <param name="szXPath">XPath表达式</param>
        /// <returns>XmlNodeList</returns>
        private static XmlNodeList SelectXmlNodes(XmlNode clsRootNode, string szXPath)
        {
            if (clsRootNode == null || IsEmptyString(szXPath))
                return null;
            try
            {
                return clsRootNode.SelectNodes(szXPath);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 创建一个XmlNode并添加到文档
        /// </summary>
        /// <param name="clsParentNode">父节点</param>
        /// <param name="szNodeName">结点名称</param>
        /// <returns>XmlNode</returns>
        private static XmlNode CreateXmlNode(XmlNode clsParentNode, string szNodeName)
        {
            try
            {
                XmlDocument clsXmlDoc = null;
                if (clsParentNode.GetType() != typeof (XmlDocument))
                    clsXmlDoc = clsParentNode.OwnerDocument;
                else
                    clsXmlDoc = clsParentNode as XmlDocument;
                XmlNode clsXmlNode = clsXmlDoc.CreateNode(XmlNodeType.Element, szNodeName, string.Empty);
                if (clsParentNode.GetType() == typeof (XmlDocument))
                {
                    clsXmlDoc.LastChild.AppendChild(clsXmlNode);
                }
                else
                {
                    clsParentNode.AppendChild(clsXmlNode);
                }
                return clsXmlNode;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>树形结构创建XmlNode并添加到文档
        /// </summary>
        /// <param name="szRootTreeList">从二级根节点至旗下节点的名称</param>
        /// <param name="clsXmlDoc">XML文档对象</param>
        /// <returns>新XML文档对象</returns>
        public static XmlDocument CreateXmlTreeNodes(string[] szRootTreeList, XmlDocument clsXmlDoc)
        {
            string sCurPath = ".", sParentPath = ".";
            string curNodeName = string.Empty;
            string[] aParentRoot = new string[szRootTreeList.Length - 1];

            for (int i = 0; i < szRootTreeList.Length; i++)
            {
                curNodeName = szRootTreeList[i];
                sCurPath += "//" + szRootTreeList[i];


                if (i < szRootTreeList.Length - 1)
                {
                    sParentPath += "//" + szRootTreeList[i];
                    aParentRoot[i] = szRootTreeList[i];
                }
            }

            if (SelectXmlNode(clsXmlDoc, sParentPath) == null)
                clsXmlDoc = CreateXmlTreeNodes(aParentRoot, clsXmlDoc);

            CreateXmlNode(SelectXmlNode(clsXmlDoc, sParentPath), curNodeName);

            return clsXmlDoc;
        }

        /// <summary>删除树形结构所指的第一个节点
        /// </summary>
        /// <param name="szRootTreeList">从二级根节点至旗下节点的名称</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        /// <returns></returns>
        public static bool RemoveNode(string[] szRootTreeList,string configFilePath="")
        {
            string szConfigFile = configFilePath.Trim() == "" ? string.Format("{0}\\{1}", GetWorkDirectory(), _configFileName) : configFilePath.Trim();

            if (!File.Exists(szConfigFile))
                if (!CreateXmlFile(szConfigFile, "SystemConfig"))
                    return false;

            if (szRootTreeList.Length == 0)
                return false;

            XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);
            string sCurPath = ".", sParentPath = ".";

            for (int i = 0; i < szRootTreeList.Length; i++)
            {
                sCurPath += "//" + szRootTreeList[i];

                if (i < szRootTreeList.Length - 1)
                    sParentPath += "//" + szRootTreeList[i];
            }

            XmlNode parentNode = SelectXmlNode(clsXmlDoc, sParentPath);
            XmlNode currentNode = SelectXmlNode(clsXmlDoc, sCurPath);

            if (parentNode == null || currentNode==null)
                return false;

            parentNode.RemoveChild(currentNode);
            SaveXmlDocument(clsXmlDoc, szConfigFile);
            return true;
        }

        /// <summary>
        /// 设置指定节点中指定属性的值
        /// </summary>
        /// <param name="clsXmlNode">XML节点</param>
        /// <param name="szAttrName">属性名</param>
        /// <param name="szAttrValue">属性值</param>
        /// <returns>bool</returns>
        private static bool SetXmlAttr(XmlNode clsXmlNode, string szAttrName, string szAttrValue)
        {
            if (clsXmlNode == null)
                return false;
            if (IsEmptyString(szAttrName))
                return false;
            if (IsEmptyString(szAttrValue))
                szAttrValue = string.Empty;
            XmlAttribute clsAttrNode = clsXmlNode.Attributes.GetNamedItem(szAttrName) as XmlAttribute;
            if (clsAttrNode == null)
            {
                XmlDocument clsXmlDoc = clsXmlNode.OwnerDocument;
                if (clsXmlDoc == null)
                    return false;
                clsAttrNode = clsXmlDoc.CreateAttribute(szAttrName);
                clsXmlNode.Attributes.Append(clsAttrNode);
            }
            clsAttrNode.Value = szAttrValue;
            return true;
        }

        /// <summary>获取XPath指向的XML节点名称集合
        /// </summary>
        /// <param name="clsRootNode">XPath所在的根节点</param>
        /// <returns></returns>
        private static string[] GetChildNodeNames(XmlNode clsRootNode)
        {
            XmlNodeList nodes = clsRootNode.ChildNodes;
            string[] retVal = new string[nodes.Count];
    
            for (int i = 0; i < nodes.Count; i++)
                retVal[i] = nodes[i].Name;

            return retVal;
        }

        /// <summary>获取旗下子节点的名称集合
        /// </summary>
        /// <param name="szRootTreeList">从二级根节点至旗下节点的名称</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        /// <returns></returns>
        public static string[] GetChildNodeNames(string[] szRootTreeList, string configFilePath = "")
        {
            string szConfigFile = configFilePath.Trim() == "" ? string.Format("{0}\\{1}", GetWorkDirectory(), _configFileName) : configFilePath.Trim();

            if (!File.Exists(szConfigFile))
                if (!CreateXmlFile(szConfigFile, "SystemConfig"))
                    return new string[]{};

            if (szRootTreeList.Length == 0)
                return new string[] { };

            XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);
            string sRoot = szRootTreeList.Aggregate(".", (current, t) => current + ("//" + t));

            return GetChildNodeNames(SelectXmlNode(clsXmlDoc, sRoot));
        }

        #endregion 基本操作函数

        #region 配置文件的读取和写入

        /// <summary>
        ///  读取指定的配置文件中指定Key的值
        /// </summary>
        /// <param name="szSeRootName">二级根节点名称</param>
        /// <param name="szKeyName">读取的Key名称</param>
        /// <param name="nDefaultValue">指定的Key不存在时,返回的值</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        /// <returns>Key值</returns>
        public static int GetConfigData(string szSeRootName, string szKeyName, int nDefaultValue, string configFilePath = "")
        {
            string szValue = GetConfigData(szSeRootName, szKeyName, nDefaultValue.ToString(), configFilePath);
            try
            {
                return int.Parse(szValue);
            }
            catch
            {
                return nDefaultValue;
            }
        }

        /// <summary>
        ///  读取指定的配置文件中指定Key的值
        /// </summary>
        /// <param name="szSeRootName">二级根节点名称</param>
        /// <param name="szKeyName">读取的Key名称</param>
        /// <param name="fDefaultValue">指定的Key不存在时,返回的值</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        /// <returns>Key值</returns>
        public static float GetConfigData(string szSeRootName, string szKeyName, float fDefaultValue, string configFilePath = "")
        {
            string szValue = GetConfigData(szSeRootName, szKeyName, fDefaultValue.ToString(), configFilePath);
            try
            {
                return float.Parse(szValue);
            }
            catch
            {
                return fDefaultValue;
            }
        }

        /// <summary>
        ///  读取指定的配置文件中指定Key的值
        /// </summary>
        /// <param name="szSeRootName">二级根节点名称</param>
        /// <param name="szKeyName">读取的Key名称</param>
        /// <param name="bDefaultValue">指定的Key不存在时,返回的值</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        /// <returns>Key值</returns>
        public static bool GetConfigData(string szSeRootName, string szKeyName, bool bDefaultValue, string configFilePath = "")
        {
            string szValue = GetConfigData(szSeRootName, szKeyName, bDefaultValue.ToString(), configFilePath);
            try
            {
                return bool.Parse(szValue);
            }
            catch
            {
                return bDefaultValue;
            }
        }

        /// <summary>
        ///  读取指定的配置文件中指定Key的值
        /// </summary>
        /// <param name="szSeRootName">二级根节点名称</param>
        /// <param name="szKeyName">读取的Key名称</param>
        /// <param name="szDefaultValue">指定的Key不存在时,返回的值</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        /// <returns>Key值</returns>
        public static string GetConfigData(string szSeRootName, string szKeyName, string szDefaultValue, string configFilePath = "")
        {
            string szConfigFile = configFilePath.Trim() == "" ? string.Format("{0}\\{1}", GetWorkDirectory(), _configFileName) : configFilePath.Trim();

            if (!File.Exists(szConfigFile))
            {
                return szDefaultValue;
            }

            XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);
            if (clsXmlDoc == null)
                return szDefaultValue;

            string szXPath = string.Format(".//{0}//key[@name='{1}']", szSeRootName, szKeyName);
            XmlNode clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
            if (clsXmlNode == null)
            {
                return szDefaultValue;
            }

            XmlNode clsValueAttr = clsXmlNode.Attributes.GetNamedItem("value");
            if (clsValueAttr == null)
                return szDefaultValue;
            return clsValueAttr.Value;
        }

        /// <summary>
        ///  保存指定Key的值到指定的配置文件中
        /// </summary>
        /// <param name="szSeRootName">二级根节点名称</param>
        /// <param name="szKeyName">要被修改值的Key名称</param>
        /// <param name="szValue">新修改的值</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        public static bool WriteConfigData(string szSeRootName, string szKeyName, string szValue, string configFilePath = "")
        {
            string szConfigFile = configFilePath.Trim() == "" ? string.Format("{0}\\{1}", GetWorkDirectory(), _configFileName) : configFilePath.Trim();

            if (!File.Exists(szConfigFile))
                if (!CreateXmlFile(szConfigFile, "SystemConfig"))
                    return false;

            XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);

            string szXPath = string.Format(".//{0}//key[@name='{1}']", szSeRootName, szKeyName);
            XmlNode clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
            if (clsXmlNode == null)
            {
                //先判断是否已有二级根节点
                szXPath = string.Format(".//{0}", szSeRootName);
                clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
                if (clsXmlNode == null)
                    clsXmlNode = CreateXmlNode(clsXmlDoc, szSeRootName);

                clsXmlNode = CreateXmlNode(clsXmlNode, "key");
            }
            if (!SetXmlAttr(clsXmlNode, "name", szKeyName))
                return false;
            if (!SetXmlAttr(clsXmlNode, "value", szValue))
                return false;

            return SaveXmlDocument(clsXmlDoc, szConfigFile);
        }

        #endregion 配置文件的读取和写入

        //Add in 2015-2-11
        #region 三级及多级的配置读写

        /// <summary>读取指定的配置文件中指定Key的值
        /// </summary>
        /// <param name="szRootTreeList">从二级根节点至旗下节点的名称</param>
        /// <param name="szKeyName">读取的Key名称</param>
        /// <param name="szDefaultValue">指定的Key不存在时,返回的值</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        /// <returns>Key值</returns>
        public static string GetConfigData(string[] szRootTreeList, string szKeyName, string szDefaultValue, string configFilePath = "")
        {
            string szConfigFile = configFilePath.Trim() == "" ? string.Format("{0}\\{1}", GetWorkDirectory(), _configFileName) : configFilePath.Trim();

            if (!File.Exists(szConfigFile))
                return szDefaultValue;

            if (szRootTreeList.Length == 0)
                return szDefaultValue;

            XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);
            if (clsXmlDoc == null)
                return szDefaultValue;

            string sRoot = szRootTreeList.Aggregate(".", (current, rt) => current + ( "//" + rt ));
            sRoot += "//key[@name='{0}']";

            string szXPath = string.Format(sRoot, szKeyName);
            XmlNode clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
            if (clsXmlNode == null)
                return szDefaultValue;

            XmlNode clsValueAttr = clsXmlNode.Attributes.GetNamedItem("value");
            if (clsValueAttr == null)
                return szDefaultValue;

            return clsValueAttr.Value;
        }

        /// <summary>
        ///  读取指定的配置文件中指定Key的值
        /// </summary>
        /// <param name="szRootTreeList">从二级根节点至旗下节点的名称</param>
        /// <param name="szKeyName">读取的Key名称</param>
        /// <param name="nDefaultValue">指定的Key不存在时,返回的值</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        /// <returns>Key值</returns>
        public static int GetConfigData(string[] szRootTreeList, string szKeyName, int nDefaultValue, string configFilePath = "")
        {
            string szValue = GetConfigData(szRootTreeList, szKeyName, nDefaultValue.ToString(), configFilePath);
            try
            {
                return int.Parse(szValue);
            }
            catch
            {
                return nDefaultValue;
            }
        }

        /// <summary>
        ///  读取指定的配置文件中指定Key的值
        /// </summary>
        /// <param name="szRootTreeList">从二级根节点至旗下节点的名称</param>
        /// <param name="szKeyName">读取的Key名称</param>
        /// <param name="fDefaultValue">指定的Key不存在时,返回的值</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        /// <returns>Key值</returns>
        public static float GetConfigData(string[] szRootTreeList, string szKeyName, float fDefaultValue, string configFilePath = "")
        {
            string szValue = GetConfigData(szRootTreeList, szKeyName, fDefaultValue.ToString(), configFilePath);
            try
            {
                return float.Parse(szValue);
            }
            catch
            {
                return fDefaultValue;
            }
        }

        /// <summary>
        ///  读取指定的配置文件中指定Key的值
        /// </summary>
        /// <param name="szRootTreeList">从二级根节点至旗下节点的名称</param>
        /// <param name="szKeyName">读取的Key名称</param>
        /// <param name="bDefaultValue">指定的Key不存在时,返回的值</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        /// <returns>Key值</returns>
        public static bool GetConfigData(string[] szRootTreeList, string szKeyName, bool bDefaultValue, string configFilePath = "")
        {
            string szValue = GetConfigData(szRootTreeList, szKeyName, bDefaultValue.ToString(), configFilePath);
            try
            {
                return bool.Parse(szValue);
            }
            catch
            {
                return bDefaultValue;
            }
        }

        /// <summary>保存指定Key的值到指定的配置文件中
        /// </summary>
        /// <param name="szRootTreeList">从二级根节点至旗下节点的名称</param>
        /// <param name="szKeyName">要被修改值的Key名称</param>
        /// <param name="szValue">新修改的值</param>
        /// <param name="configFilePath">配置文件完整路径（为空则取默认值）</param>
        public static bool WriteConfigData(string[] szRootTreeList, string szKeyName, string szValue, string configFilePath = "")
        {
            string szConfigFile = configFilePath.Trim() == "" ? string.Format("{0}\\{1}", GetWorkDirectory(), _configFileName) : configFilePath.Trim();

            if (!File.Exists(szConfigFile))
                if (!CreateXmlFile(szConfigFile, "SystemConfig"))
                    return false;

            if (szRootTreeList.Length == 0)
                return false;

            XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);

            string sRoot = szRootTreeList.Aggregate(".", (current, t) => current + ( "//" + t ));
            string sCurPath = sRoot;
            sRoot += "//key[@name='{0}']";

            string szXPath = string.Format(sRoot, szKeyName);
            XmlNode clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
            if (clsXmlNode == null)
            {
                //没有节点的话按照树形结构创建
                if (SelectXmlNode(clsXmlDoc, sCurPath) == null)
                    clsXmlDoc = CreateXmlTreeNodes(szRootTreeList, clsXmlDoc);
                
                clsXmlNode = SelectXmlNode(clsXmlDoc, sCurPath);
                clsXmlNode = CreateXmlNode(clsXmlNode, "key");
            }

            if (!SetXmlAttr(clsXmlNode, "name", szKeyName))
                return false;
            if (!SetXmlAttr(clsXmlNode, "value", szValue))
                return false;
      
            return SaveXmlDocument(clsXmlDoc, szConfigFile);
        }

        #endregion 三级及多级的配置读写
    }
}