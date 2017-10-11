using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StockExplore
{
    internal class ReferenceCode
    {
        // 读取日线文件
        public static void Main1(string[] args)
        {
            const int lineLength = 32;
            using (var reader = new BinaryReader(File.OpenRead(@"C:\new_tdx\vipdoc\sh\lday\sh999999.day")))     //  C:\new_tdx\vipdoc\sz\lday\sz399001.day
            {
                long len = reader.BaseStream.Length / lineLength;
                for (int i = 0; i < len; i++)
                {
                    int beg = i * lineLength;
                    int offset = beg;

                    // 下面的 Seek 都可以不要！
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    string date = reader.ReadUInt32().ToString();

                    offset += 4;
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    string open = reader.ReadUInt32().ToString();

                    offset += 4;
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    string high = reader.ReadUInt32().ToString();

                    offset += 4;
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    string low = reader.ReadUInt32().ToString();

                    offset += 4;
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    string close = reader.ReadUInt32().ToString();

                    offset += 4;
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    string amount = reader.ReadSingle().ToString("0.00");

                    offset += 4;
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    string vol = reader.ReadUInt32().ToString();

                    offset += 4;
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    string reservation = reader.ReadUInt32().ToString();

                    string msg = string.Format("{0} : {1} : {2} : {3} : {4} : {5} : {6} : {7} ", date, open, high, low, close, amount, vol, reservation);
                    Console.WriteLine(msg);

                }
            }

            Console.ReadKey(false);
        }

        // 读取板块数据
        public static void Main2(string[] args)
        {
            // block_gn.dat
            // block_zs.dat
            // block_fg.dat
            using (var reader = new BinaryReader(File.OpenRead(@"D:\通达信超赢版\T0002\hq_cache\block_gn.dat")))
            {
                // 文件信息
                string fileInfoStr = Encoding.Default.GetString(reader.ReadBytes(64)).TrimEnd('\0');
                Console.WriteLine("文件信息：{0}", fileInfoStr);

                int indexStart = reader.ReadInt32(); // 板块索引信息起始位置
                int bkInfoStart = reader.ReadInt32(); // 板块记录信息起始位置
                Console.WriteLine("板块索引信息起始位置：{0}", indexStart);
                Console.WriteLine("板块记录信息起始位置：{0}", bkInfoStart);

                reader.BaseStream.Seek(indexStart, SeekOrigin.Begin);
                // 索引名称
                string indexName = Encoding.Default.GetString(reader.ReadBytes(64)).TrimEnd('\0');
                Console.WriteLine("索引名称：{0}", indexName);

                reader.BaseStream.Seek(bkInfoStart, SeekOrigin.Begin);
                // 板块数量
                int bkCount = reader.ReadInt16();
                Console.WriteLine("板块数量：{0}", bkCount);

                // 第一个版块的起始位置为0x182h。
                int offect = bkInfoStart + 2;
                for (int i = 0; i < bkCount; i++)
                {
                    reader.BaseStream.Seek(offect, SeekOrigin.Begin);
                    // 板块名称
                    string bkName = Encoding.Default.GetString(reader.ReadBytes(9)).TrimEnd('\0');
                    // 证券数量
                    int stockCount = reader.ReadInt16();
                    // 板块级别 
                    int bkLevel = reader.ReadInt16();

                    Console.WriteLine("板块名称：{0}     证券数量：{1}    板块级别：{2}", bkName, stockCount, bkLevel);

                    // 每个板块最多包括400只股票。(2813 -9 - 2 - 2) / 7 =  400
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < 400; j++)
                    {
                        string stockCode = Encoding.Default.GetString(reader.ReadBytes(7)).TrimEnd('\0');
                        if (stockCode.Length == 0)
                            break;

                        sb.Append(stockCode + ", ");
                    }
                    Console.WriteLine(sb.ToString());

                    Console.WriteLine(Environment.NewLine);

                    offect += 2813; // 每个板块占的长度为2813个字节。
                }
            }

            Console.ReadKey(false);
        }

        // 读取股票代码名称文件
        public static void Main3(string[] args)
        {
            /*
             * 通达信V6股票代码文件格式分析
             http://blog.csdn.net/starsky2006/article/details/5863438

                （1）、文件头部信息	
                数据含义	数据类型
                IP地址	Char[40]
                未知	word
                日期	Integer
                时间	Integer
	
                （2）、股票代码格式	
                数据含义	数据类型
                股票代码	Char[9]
                未知	byte
                未知	word
                未知	single
                未知	Integer
                未知	Integer
                股票名称	Char[18]
                未知	Integer
                未知	Char[186]
                昨日收盘	single
                未知	byte
                未知	Integer
                名称缩写	Char[9]
                注意：	
                1）、每250个字节为一个记录。	
             */

            /*
             我测试下来：每314个字节为一个记录
             */

            const string fileName = @"C:\new_tdx\T0002\hq_cache\szm.tnf";

            using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
            {
                // Console.WriteLine(string.Format("{0}"));
                string strIp = Encoding.Default.GetString(reader.ReadBytes(40)).TrimEnd('\0');
                Console.WriteLine(strIp);

                Console.WriteLine("可能是某个数量：{0}", reader.ReadInt16()); // 7709
                Console.WriteLine("日期：{0}", reader.ReadInt32());
                Console.WriteLine("时间：{0}", reader.ReadInt32());

                Console.WriteLine();

                int count = (int)((reader.BaseStream.Length - 50) / 314);
                for (int i = 0; i < count; i++)
                {
                    string stkCode = Encoding.Default.GetString(reader.ReadBytes(9)).TrimEnd('\0');
                    reader.ReadBytes(12); // 未知区域
                    string stkName = Encoding.Default.GetString(reader.ReadBytes(18)).Trim('\0');
                    reader.ReadBytes(246); // 未知区域
                    string shortName = Encoding.Default.GetString(reader.ReadBytes(9)).TrimEnd('\0');
                    reader.ReadBytes(20); // 未知区域

                    if (stkCode.StartsWith("3991")) //stkCode.StartsWith("999")  || stkCode.StartsWith("000")    stkName.Contains("指")
                    {
                        Console.WriteLine("行号：{0}", i + 1);
                        Console.WriteLine("股票代码：{0}", stkCode);
                        Console.WriteLine("股票名称：{0}", stkName);
                        Console.WriteLine("名称缩写：{0}", shortName);
                        Console.WriteLine("Position：{0}", reader.BaseStream.Position);

                        Console.WriteLine();
                    }
                }

                Console.WriteLine("Position：{0}", reader.BaseStream.Length);
            }

            Console.ReadKey(false);
        }
    }
}
