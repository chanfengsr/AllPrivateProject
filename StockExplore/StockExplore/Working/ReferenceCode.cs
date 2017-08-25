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
    }
}
