using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UBB代码生成
{
    class CommonDefinition
    {
        /// <summary>
        /// 文字颜色模式
        /// </summary>
        public enum ColorPattern { Single, Dynamic, Rainbow, Gray, None }

        /// <summary>
        /// 全局处理结构
        /// </summary>
        public struct GlobalProcessStruct
        {
            public bool Bold;	//	粗体
            public bool Italic;	//	斜体
            public bool Underline;	//	下划线
            public bool Scored;	//	中划线
            public bool Fly;	//	飞翔
            public bool Luminescence;	//	发光
            public bool Shadow;	//	阴影
            public bool VerbatimFlash;	//	逐字闪烁
            public bool Free;	//	免费信息

            public string Alignment;	//	文本对齐
            public string Size;	//	文字大小
            public string Font;	//	文字字体
            public string BackgroundColor;	//	背景颜色
            public ColorPattern ColorPattern;	//	文字颜色模式
            public string ColorCategories;	//	文字颜色分类
            public string ColorName;	//	文字颜色名称
            public Color Color;	//	文字颜色

            public bool AsInsertCode;	//	作为添加
            public bool ContainAbove;	//	包含上面设置

            public bool Mail;	//	邮件
            public bool Link;	//	链接
            public bool Picture;	//	图片
            public bool Flash;	//	Flash
            public bool Code;	//	代码
            public bool Quote;	//	引用
            public bool Superscript;	//	上标
            public bool Subscript;	//	下标
            public bool QQ;	//	QQ
            public bool EMule;	//	电驴
            public bool Formatted;	//	已编排格式
            public string List; //  列表

            public string Show;	//	显示
            //public string Content;	//	内容
            public string MiniOrigText;	//	局部文字

            public bool LowerTags;	//	标签小写

            public string OriginalText;	//	原始文字

            public string ResultText;	//	结果文字

            public bool StartWithResultText;    //  从结果文字开始处理
        }

        /// <summary>
        /// 预定义颜色
        /// </summary>
        public enum ColorGroup { W3C16, Safe216, IE4_PreNamed, WIN }

        string[][] _astrTagTemplate = new string[][] {  
                                      #region 标签模板
new string[] { "Bold", "[B]{0}[/B]"}, 
new string[] { "Italic", "[I]{0}[/I]"}, 
new string[] { "Underline", "[U]{0}[/U]"}, 
new string[] { "Scored", "[S]{0}[/S]"}, 
new string[] { "Fly", "[FLY]{0}[/FLY]"}, 
new string[] { "Luminescence", "[GLOW=255,{0},2]{1}[/GLOW]"}, 
new string[] { "Shadow", "[SHADOW=255,{0},2]{1}[/SHADOW]"}, 
new string[] { "VerbatimFlash", "[LIGHT]{0}[/LIGHT]"}, 
new string[] { "Free", "[FREE]{0}[/FREE]"}, 

new string[] { "Alignment", "[ALIGN={0}]{1}[/ALIGN]"}, 
new string[] { "Alignment1", "[{0}]{1}[/{0}]"}, 
//new string[] { "Center", "[CENTER]{0}[/CENTER]"}, 
//new string[] { "Left", "[LEFT]{0}[/LEFT]"}, 
//new string[] { "Right", "[RIGHT]{0}[/RIGHT]"}, 
//new string[] { "Justify", "[JUSTIFY]{0}[/JUSTIFY]"}, 

new string[] { "Color", "[COLOR={0}]{1}[/COLOR]"}, 
new string[] { "Size", "[SIZE={0}]{1}[/SIZE]"}, 
new string[] { "Font", "[FONT={0}]{1}[/FONT]"}, 
new string[] { "BackgroundColor", "[BGCOLOR={0}]{1}[/BGCOLOR]"}, 

new string[] { "Mail", "[EMAIL]{0}[/EMAIL]"}, 
new string[] { "Mail1", "[EMAIL={0}]{1}[/EMAIL]"}, 
new string[] { "Link", "[URL]{0}[/URL]"}, 
new string[] { "Link1", "[URL={0}]{1}[/URL]"}, 
new string[] { "Picture", "[IMG]{0}[/IMG]"}, 
new string[] { "Flash", "[FLASH]{0}[/FLASH]"}, 
new string[] { "Code", "[CODE]{0}[/CODE]"}, 
new string[] { "Quote", "[QUOTE]{0}[/QUOTE]"}, 
new string[] { "Superscript", "[SUP]{0}[/SUP]"}, 
new string[] { "Subscript", "[SUB]{0}[/SUB]"}, 
new string[] { "EMule", "[EMULE]{0}[/EMULE]"}, 
new string[] { "QQ", "[QQ]{0}[/QQ]"}, 
new string[] { "Formatted", "[PRE]{0}[/PRE]"},
new string[] { "List", "[list]" + Environment.NewLine + "{0}[/list]"},
new string[] { "List1", "[list={0}]" + Environment.NewLine + "{1}[/list]"},
new string[] { "ListItem", "[*]{0}"}
};
                                      #endregion
        List<string[]> _lstTagTemplate = new List<string[]>();

        Dictionary<string, string> _dicTagTemplate = new Dictionary<string, string>();

        Random _Rand = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// 标签模板
        /// </summary>
        private Dictionary<string, string> TagTemplate
        {
            set { _dicTagTemplate = value; }
        }

        #region 处理分组
        //private readonly string[] _procGrpBasic = new string[] { "Bold", "Italic", "Underline", "Scored", "Fly", "Luminescence", "Shadow", "VerbatimFlash", "Free", "Alignment", "Size", "Font", "BackgroundColor" };
        //private readonly string[] _procGrpColor = new string[] { "Color" };
        //private readonly string[] _procGrpIndependent = new string[] { "Mail", "Link", "Picture", "Flash", "Code", "Quote", "Superscript", "Subscript", "QQ", "EMule", "Formatted" };
        #endregion

        public CommonDefinition()
        {
            AddTagTemplate(true);
        }

        /// <summary>
        /// 添加标签模板
        /// </summary>
        /// <param name="LowerTags">是否小写标签</param>
        private void AddTagTemplate(bool LowerTags)
        {
            _lstTagTemplate = new List<string[]>(_astrTagTemplate);

            string strKey = "";
            string strValue = "";

            _dicTagTemplate.Clear();

            foreach (string[] astrTagTemplate in _lstTagTemplate)
            {
                strKey = astrTagTemplate[0];
                strValue = LowerTags ? astrTagTemplate[1].ToLower() : astrTagTemplate[1].ToUpper();

                _dicTagTemplate.Add(strKey, strValue);
            }

        }

        /// <summary>
        /// 处理手工标签
        /// </summary>
        /// <param name="ProcessInfo">GlobalProcessStruct结构值</param>
        private void ProcessManualTags(ref GlobalProcessStruct ProcessInfo)
        {
            if (ProcessInfo.LowerTags)
            {
                ProcessInfo.Alignment = ProcessInfo.Alignment.ToLower().Replace("align_", "");
            }
            else
            {
                ProcessInfo.Alignment = ProcessInfo.Alignment.ToUpper().Replace("align_", "");
            }
        }

        /// <summary>
        /// 决定基础 或 追加组中需要参与标签的项
        /// </summary>
        /// <param name="GroupID">1或2</param>
        /// <param name="ProcessInfo">GlobalProcessStruct结构值</param>
        /// <returns></returns>
        private string[] DetermineGroupItems(int GroupID, GlobalProcessStruct ProcessInfo)
        {
            List<string> retVal = new List<string>();

            //基础部分
            if (GroupID == 1)
            {
                //斜体与字体颜色设置必须最先处理
                if (ProcessInfo.Underline && ProcessInfo.ColorPattern != ColorPattern.None && ProcessInfo.ColorPattern != ColorPattern.Single)
                {
                    switch (ProcessInfo.ColorPattern)
                    {
                        case ColorPattern.Dynamic:
                        case ColorPattern.Rainbow:
                        case ColorPattern.Gray:
                            retVal.Add("Underline,Color");
                            break;
                    }
                }
                else
                {
                    switch (ProcessInfo.ColorPattern)
                    {
                        case ColorPattern.Single:
                            if (ProcessInfo.Color.ToArgb() != Color.Black.ToArgb())
                                retVal.Add("Color");
                            break;
                        case ColorPattern.Dynamic:
                        case ColorPattern.Rainbow:
                        case ColorPattern.Gray:
                            retVal.Add("Color");
                            break;
                    }

                    if (ProcessInfo.Underline) retVal.Add("Underline");
                }

                if (ProcessInfo.Bold) retVal.Add("Bold");
                if (ProcessInfo.Italic) retVal.Add("Italic");
                if (ProcessInfo.Scored) retVal.Add("Scored");
                if (ProcessInfo.Fly) retVal.Add("Fly");
                if (ProcessInfo.Luminescence) retVal.Add("Luminescence");
                if (ProcessInfo.Shadow) retVal.Add("Shadow");
                if (ProcessInfo.VerbatimFlash) retVal.Add("VerbatimFlash");
                if (ProcessInfo.Free) retVal.Add("Free");

                if (ProcessInfo.Alignment != "")
                {
                    if (ProcessInfo.Alignment.ToLower().StartsWith("align_"))
                        retVal.Add("Alignment");
                    else
                        retVal.Add("Alignment1");
                }


                if (ProcessInfo.Size != "") retVal.Add("Size");
                if (ProcessInfo.Font != "") retVal.Add("Font");
                if (ProcessInfo.BackgroundColor.ToLower() != "white") retVal.Add("BackgroundColor");
            }

            //追加部分
            if (GroupID == 2)
            {
                if (ProcessInfo.Mail && ProcessInfo.Show == "") retVal.Add("Mail");
                if (ProcessInfo.Mail && ProcessInfo.Show != "") retVal.Add("Mail1");
                if (ProcessInfo.Link && ProcessInfo.Show == "") retVal.Add("Link");
                if (ProcessInfo.Link && ProcessInfo.Show != "") retVal.Add("Link1");

                if (ProcessInfo.Picture) retVal.Add("Picture");
                if (ProcessInfo.Flash) retVal.Add("Flash");
                if (ProcessInfo.Code) retVal.Add("Code");
                if (ProcessInfo.Quote) retVal.Add("Quote");
                if (ProcessInfo.Superscript) retVal.Add("Superscript");
                if (ProcessInfo.Subscript) retVal.Add("Subscript");
                if (ProcessInfo.EMule) retVal.Add("EMule");
                if (ProcessInfo.QQ) retVal.Add("QQ");
                if (ProcessInfo.Formatted) retVal.Add("Formatted");

                //列表必须放在最后！
                if (ProcessInfo.List != "") retVal.Add("ListItem");
            }

            return retVal.ToArray();
        }

        /// <summary>
        /// 决定需要参与的所有标签
        /// </summary>
        /// <param name="ProcessInfo">GlobalProcessStruct结构值</param>
        /// <returns></returns>
        private string[] DetermineProcessGroup(GlobalProcessStruct ProcessInfo)
        {
            List<string> retVal = new List<string>();

            if (ProcessInfo.AsInsertCode)
            {
                if (ProcessInfo.ContainAbove)
                {
                    //基础1 + 追加2
                    foreach (string var in DetermineGroupItems(1, ProcessInfo))
                    {
                        retVal.Add(var);
                    }
                    foreach (string var in DetermineGroupItems(2, ProcessInfo))
                    {
                        retVal.Add(var);
                    }
                }
                else
                {
                    //追加2
                    foreach (string var in DetermineGroupItems(2, ProcessInfo))
                    {
                        retVal.Add(var);
                    }
                }
            }
            else
            {
                //基础
                foreach (string var in DetermineGroupItems(1, ProcessInfo))
                {
                    retVal.Add(var);
                }
            }

            return retVal.ToArray();
        }

        /// <summary>
        /// 对文字添加标签
        /// </summary>
        /// <param name="TagKey">标签名</param>
        /// <param name="Text">文字</param>
        /// <param name="ProcessInfo">GlobalProcessStruct结构值</param>
        private void AddTag(string TagKey, ref string Text, GlobalProcessStruct ProcessInfo)
        {
            switch (TagKey)
            {
                case "Bold":
                case "Italic":
                case "Underline":
                case "Scored":
                case "Fly":
                case "VerbatimFlash":
                case "Free":
                case "Picture":
                case "Flash":
                case "Code":
                case "Quote":
                case "Superscript":
                case "Subscript":
                case "QQ":
                case "EMule":
                case "Formatted":
                case "Mail":
                case "Link":
                case "List":
                case "ListItem":
                    Text = string.Format(_dicTagTemplate[TagKey], Text);
                    break;
                case "Size":
                    Text = string.Format(_dicTagTemplate[TagKey], ProcessInfo.Size, Text);
                    break;
                case "Font":
                    Text = string.Format(_dicTagTemplate[TagKey], ProcessInfo.Font, Text);
                    break;
                case "BackgroundColor":
                    Text = string.Format(_dicTagTemplate[TagKey], ProcessInfo.BackgroundColor, Text);
                    break;
                case "Luminescence":
                case "Shadow":
                    Text = string.Format(_dicTagTemplate[TagKey], ProcessInfo.ColorName, Text);
                    break;
                case "Alignment":
                case "Alignment1":
                    Text = string.Format(_dicTagTemplate[TagKey], ProcessInfo.Alignment, Text);
                    break;
                case "Color":
                    switch (ProcessInfo.ColorPattern)
                    {
                        case ColorPattern.Single:
                            if (ProcessInfo.ColorCategories == "WIN")
                                Text = string.Format(_dicTagTemplate[TagKey], ColorTranslator.ToHtml(Color.FromArgb(Color.FromName(ProcessInfo.ColorName).ToArgb())), Text);
                            else
                                Text = string.Format(_dicTagTemplate[TagKey], ProcessInfo.ColorName, Text);
                            break;
                        case ColorPattern.Dynamic:
                            Text = AddDynamicColorTag(Text, ProcessInfo.ColorCategories, false);
                            break;
                        case ColorPattern.Rainbow:
                            Text = AddRainbowColorTag(Text, false);
                            break;
                        case ColorPattern.Gray:
                            Text = AddGrayColorTag(Text, false);
                            break;
                    }
                    break;
                case "Underline,Color":
                    switch (ProcessInfo.ColorPattern)
                    {
                        case ColorPattern.Dynamic:
                            Text = AddDynamicColorTag(Text, ProcessInfo.ColorCategories, true);
                            break;
                        case ColorPattern.Rainbow:
                            Text = AddRainbowColorTag(Text, true);
                            break;
                        case ColorPattern.Gray:
                            Text = AddGrayColorTag(Text, true);
                            break;
                    }
                    break;
                case "Mail1":
                case "Link1":
                    Text = string.Format(_dicTagTemplate[TagKey], ProcessInfo.MiniOrigText, Text);
                    break;
                case "List1":
                    Text = string.Format(_dicTagTemplate[TagKey], ProcessInfo.List, Text);
                    break;
            }
        }

        /// <summary>
        /// 添加动态颜色标签
        /// </summary>
        /// <param name="Text">文字</param>
        /// <param name="ColorCategories">文字颜色分类</param>
        /// <param name="isUnderline">是否要下划线</param>
        /// <returns></returns>
        private string AddDynamicColorTag(string Text, string ColorCategories, bool isUnderline)
        {
            StringBuilder retVal = new StringBuilder();
            string strTmp = "";

            Random Rand = new Random(_Rand.Next());

            int intIndexMax = 0;
            int intPreColorIndex = -1;//之前一个字符颜色下标
            int intCurColorIndex = -1;//当前字符颜色下标
            List<string> lstColor = new List<string>();

            switch (ColorCategories)
            {
                case "W3C16":
                    foreach (string[] var in ColorDefined.GetW3C16Color())
                    {
                        if (ColorTranslator.FromHtml(var[0]).ToArgb() != Color.White.ToArgb())
                            lstColor.Add(var[1]);
                    }
                    intIndexMax = lstColor.Count;
                    break;
                case "Safe216":
                    foreach (string var in ColorDefined.GetSafe216Color())
                    {
                        if (ColorTranslator.FromHtml(var).ToArgb() != Color.White.ToArgb())
                            lstColor.Add(var);
                    }
                    intIndexMax = lstColor.Count;
                    break;
                case "IE4_PreNamed":
                    foreach (string[] var in ColorDefined.GetIE4_PreNamedColor())
                    {
                        if (ColorTranslator.FromHtml(var[0]).ToArgb() != Color.White.ToArgb())
                            lstColor.Add(var[1]);
                    }
                    intIndexMax = lstColor.Count;
                    break;
                case "WIN":
                    foreach (string var in ColorDefined.GetWINColor())
                    {
                        if (Color.FromArgb(Color.FromName(var).ToArgb()).ToArgb() != Color.White.ToArgb())
                            lstColor.Add(ColorTranslator.ToHtml(Color.FromArgb(Color.FromName(var).ToArgb())));
                    }
                    intIndexMax = lstColor.Count;
                    break;
            }

            foreach (char chr in Text)
            {
                while (true)
                {
                    intCurColorIndex = Rand.Next(0, intIndexMax);

                    if (intCurColorIndex != intPreColorIndex)
                    {
                        if ((int)chr == 10 || (int)chr == 13)
                        { retVal.Append(chr); }
                        else
                        {
                            if (isUnderline)
                                strTmp = string.Format(_dicTagTemplate["Underline"], chr.ToString());
                            else
                                strTmp = chr.ToString();

                            retVal.Append(string.Format(_dicTagTemplate["Color"], lstColor[intCurColorIndex], strTmp));
                        }

                        intPreColorIndex = intCurColorIndex;

                        break;
                    }
                }
            }

            return retVal.ToString();
        }

        /// <summary>
        /// 添加彩虹色标签
        /// </summary>
        /// <param name="Text">文字</param>
        /// <param name="isUnderline">是否要下划线</param>
        /// <returns></returns>
        private string AddRainbowColorTag(string Text, bool isUnderline)
        {
            StringBuilder retVal = new StringBuilder();
            string strTmp = "";

            int index;
            int intLen = Text.Replace("\r", "").Replace("\n", "").Length;
            int R, G, B;

            int i = 1;
            foreach (char chr in Text)
            {
                if ((int)chr == 10 || (int)chr == 13)
                { retVal.Append(chr); }
                else
                {

                    index = (int)Math.Floor((double)(i * ColorDefined.GetRainbowColor().Count / intLen));

                    if (isUnderline)
                        strTmp = string.Format(_dicTagTemplate["Underline"], chr.ToString());
                    else
                        strTmp = chr.ToString();

                    index = index == 0 ? index + 1 : index;

                    R = ColorDefined.GetRainbowColor()[index - 1][0];
                    G = ColorDefined.GetRainbowColor()[index - 1][1];
                    B = ColorDefined.GetRainbowColor()[index - 1][2];

                    retVal.Append(string.Format(_dicTagTemplate["Color"], ColorTranslator.ToHtml(Color.FromArgb(R, G, B)), strTmp));

                    i++;
                }
            }

            return retVal.ToString();
        }

        /// <summary>
        /// 添加灰度色标签
        /// </summary>
        /// <param name="Text">文字</param>
        /// <param name="isUnderline">是否要下划线</param>
        /// <returns></returns>
        private string AddGrayColorTag(string Text, bool isUnderline)
        {
            StringBuilder retVal = new StringBuilder();
            string strTmp = "";

            int index;
            int intLen = Text.Replace("\r", "").Replace("\n", "").Length;
            int R, G, B;

            int i = 1;
            foreach (char chr in Text)
            {
                if ((int)chr == 10 || (int)chr == 13)
                { retVal.Append(chr); }
                else
                {

                    index = (int)Math.Floor((double)(i * (ColorDefined.GetGrayColor().Count - 100) / intLen));

                    if (isUnderline)
                        strTmp = string.Format(_dicTagTemplate["Underline"], chr.ToString());
                    else
                        strTmp = chr.ToString();

                    index = index == 0 ? index++ : index;

                    R = ColorDefined.GetGrayColor()[index - 1 + 50][0];
                    G = ColorDefined.GetGrayColor()[index - 1 + 50][1];
                    B = ColorDefined.GetGrayColor()[index - 1 + 50][2];

                    retVal.Append(string.Format(_dicTagTemplate["Color"], ColorTranslator.ToHtml(Color.FromArgb(R, G, B)), strTmp));

                    i++;
                }
            }

            return retVal.ToString();
        }

        /// <summary>
        /// 返回单元线
        /// </summary>
        /// <param name="LowerTags">是否小写标签</param>
        /// <returns></returns>
        public string GetHRLine(bool LowerTags)
        {
            if (LowerTags)
                return "[hr]";
            else
                return "[HR]";
        }

        /// <summary>
        /// 依据组添加标签
        /// </summary>
        /// <param name="ProcessInfo">GlobalProcessStruct结构值</param>
        /// <param name="ProcessGroup">决定需要参与的所有标签</param>
        /// <param name="Result">结果</param>
        private void AddTags(ref GlobalProcessStruct ProcessInfo, string[] ProcessGroup, ref string Result)
        {
            foreach (string strTagKey in ProcessGroup)
            {
                AddTag(strTagKey, ref Result, ProcessInfo);
            }
        }

        /// <summary>
        /// 初始时决定最后要显示的文字
        /// </summary>
        /// <param name="ProcessInfo">GlobalProcessStruct结构值</param>
        /// <returns></returns>
        private string DetermineShowText(ref GlobalProcessStruct ProcessInfo)
        {
            string strResult = "";

            if (ProcessInfo.AsInsertCode)
            {
                if ((ProcessInfo.Mail && ProcessInfo.Show != "") || (ProcessInfo.Link && ProcessInfo.Show != ""))
                    strResult = ProcessInfo.Show;
                else
                    strResult = ProcessInfo.MiniOrigText;
            }
            else
            {
                if (ProcessInfo.StartWithResultText)
                    strResult = ProcessInfo.ResultText;
                else
                    strResult = ProcessInfo.OriginalText;
            }

            return strResult;
        }

        /// <summary>
        /// 处理全局信息
        /// </summary>
        /// <param name="ProcessInfo">GlobalProcessStruct结构值</param>
        /// <returns>结果</returns>
        public string ProcessInformation(GlobalProcessStruct ProcessInfo)
        {
            //GlobalProcessStruct origProcessInfo = ProcessInfo;
            string strResult = DetermineShowText(ref ProcessInfo);
            string strLstProcResult = "";

            //添加标签模板
            AddTagTemplate(ProcessInfo.LowerTags);

            //决定需要参与的所有标签
            string[] astrProcessGroup = DetermineProcessGroup(ProcessInfo);

            //处理手工标签
            ProcessManualTags(ref ProcessInfo);

            if (!ProcessInfo.AsInsertCode || ProcessInfo.List == "")//无列表
            {
                AddTags(ref ProcessInfo, astrProcessGroup, ref strResult);
            }
            else//列表
            {
                StringBuilder sbLstProcResult = new StringBuilder();

                foreach (string strLine in strResult.Replace(Environment.NewLine, "\r").Split(("\r" as string).ToCharArray()))
                {
                    string strln = strLine;
                    AddTags(ref ProcessInfo, astrProcessGroup, ref strln);

                    sbLstProcResult.AppendLine(strln);
                }
                strLstProcResult = sbLstProcResult.ToString();

                if (ProcessInfo.List.ToLower() == "blank")
                    AddTag("List", ref strLstProcResult, ProcessInfo);
                else
                    AddTag("List1", ref strLstProcResult, ProcessInfo);

                strResult = strLstProcResult;
            }

            return strResult;
        }
    }
}