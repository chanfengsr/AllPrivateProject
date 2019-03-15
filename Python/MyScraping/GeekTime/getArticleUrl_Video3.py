"""
简单的生产视频抓取代码
"""
import re

# Video2 取过来的， 只取 元素1
# 元素 1：文章原始标题
# 元素 2：网页地址或网页文件绝对路径
listArtUrl = [('43 | 第六章内容概述', 'https://time.geekbang.org/course/detail/153-83923'),
 ('44 | 准备模型开发环境', 'https://time.geekbang.org/course/detail/153-83924'),
 ('45 | 生成验证码数据集', 'https://time.geekbang.org/course/detail/153-83925'),
 ('46 | 输入与输出数据处理', 'https://time.geekbang.org/course/detail/153-84142'),
 ('47 | 模型结构设计', 'https://time.geekbang.org/course/detail/153-84149'),
 ('48 | 模型损失函数设计', 'https://time.geekbang.org/course/detail/153-84154'),
 ('49 | 模型训练过程分析', 'https://time.geekbang.org/course/detail/153-84160'),
 ('50 | 模型部署与效果演示', 'https://time.geekbang.org/course/detail/153-84163'),
 ('51 | 第七部分内容介绍', 'https://time.geekbang.org/course/detail/153-84661'),
 ('52 | 人脸识别问题概述', 'https://time.geekbang.org/course/detail/153-84701'),
 ('53 | 典型人脸相关数据集介绍', 'https://time.geekbang.org/course/detail/153-84704'),
 ('54 | 人脸检测算法介绍', 'https://time.geekbang.org/course/detail/153-84706'),
 ('55 | 人脸识别算法介绍', 'https://time.geekbang.org/course/detail/153-84707'),
 ('56 | 人脸检测工具介绍', 'https://time.geekbang.org/course/detail/153-84751'),
 ('57 | 解析 FaceNet 人脸识别模型', 'https://time.geekbang.org/course/detail/153-84765'),
 ('58 | 实战 FaceNet 人脸识别模型', 'https://time.geekbang.org/course/detail/153-84771'),
 ('59 | 测试与可视化分析', 'https://time.geekbang.org/course/detail/153-84948'),
 ('60 | 番外篇内容介绍', 'https://time.geekbang.org/course/detail/153-85703'),
 ('61 | TensorFlow 社区介绍', 'https://time.geekbang.org/course/detail/153-85704'),
 ('62 | TensorFlow 生态-TFX', 'https://time.geekbang.org/course/detail/153-85708'),
 ('63 | TensorFlow 生态-Kubeflow', 'https://time.geekbang.org/course/detail/153-85710'),
 ('64 | 如何参与 TensorFlow 社区开源贡献', 'https://time.geekbang.org/course/detail/153-85712'),
 ('65 | ML GDE 是 TensorFlow 社区与开发者的桥梁', 'https://time.geekbang.org/course/detail/153-85721'),
 ('66 | 课程总结', 'https://time.geekbang.org/course/detail/153-85715')]

# 与上面元素个数要一致
listM3U8 = ['https://media001.geekbang.org/144dff6383f746dc985eae32ec819646/d0b4f292de2749419fc1ddeb6154a6d9-b7f2822b08b1abaeaae4fd32ebebe058-hd.m3u8',
'https://media001.geekbang.org/c6f0c659fada4debb812d3e0192591bd/eb4e5684c4e24336b0e9143b07b81048-cb81c13dd62d72bc178f9c91efc8db67-hd.m3u8',
'https://media001.geekbang.org/f9268c7d47e644848d575266b68db75b/f3ad7a226e7b41d99b273a3f1bc67172-99593b2184a9698f0fcca25feff9263c-hd.m3u8',
'https://media001.geekbang.org/ce5b99d8260e4066809e0ad9da79270d/4d3b26f225654080837db6cc8ccc8573-039b8020d1a43acf05bdfba59906a31a-hd.m3u8',
'https://media001.geekbang.org/a4b8378a7e34401991dd5573fe6b0c76/689f652484fd4edd935a0807edea3137-d86610a18670e66b4b61cc39512e845e-hd.m3u8',
'https://media001.geekbang.org/501a2d44358744dda13d033da2e563bb/4509db18b2a844f6b7f82d9a4e52420c-cfbbfac3a06881cb2554089356518d45-hd.m3u8',
'https://media001.geekbang.org/d09ce1a9db2248909cbabc5075d51915/4cf38b80aed54065a3e3eb1d8261e71f-f29ce9fe59e5f115150a841a2f549aa5-hd.m3u8',
'https://media001.geekbang.org/912dd144a7414723a65380043131e39e/c4a5c11267494938bd430cb4fcf3f265-fddd7eac1e0dd4caaed8f44053903db6-hd.m3u8',
'https://media001.geekbang.org/e1f3ceb1deda4dd98bfa124a34bf87f2/c88d9950859647f6b6b4e769f6fb1bac-e4325928779375674832064ebbf485a5-hd.m3u8',
'https://media001.geekbang.org/70e2ed17d2134e5c805970055a9f5fd2/7f112438ac614ea6885e286c08f26b75-8f7f3bd725d27b5896185a2a68c21721-hd.m3u8',
'https://media001.geekbang.org/235c3c6ab0664f00b360cac23e380c4d/308ef78a22614ba98a589c8eb376accd-2a9df10b9c7e848d61ab67ae8e87d9da-hd.m3u8',
'https://media001.geekbang.org/73c27f540ee44836bdee9f4c76817640/36d96009936a4a8f8a3f3ad8963a1a84-df2919fb3206680484c1e0f1f0a9f4fe-hd.m3u8',
'https://media001.geekbang.org/c24cc258f76f4cad8b4a2f38fc3cd309/f358630b7b814861b662a6705998b8d2-5e0b3ddec2ff824a85b6c2b4c1b1592f-hd.m3u8',
'https://media001.geekbang.org/4298cd882011415cb9e2c857828dea9a/4aa53089aba4471788c18162b1715e02-8572357d2bce25dabbef815cd169c737-hd.m3u8',
'https://media001.geekbang.org/085446f01f9f45849538eaf5554e9bd5/930e00da2ee24a7093132cc284eca932-ccfa70fd28faf2d0ab70740082c0304e-hd.m3u8',
'https://media001.geekbang.org/e4630808e58646dd940c1569646a68af/afed01b103f44f1da65986cba1634a0c-3daedbf5ff877d27eaf99b9e58de8f28-hd.m3u8',
'https://media001.geekbang.org/e6ac2513290b4277a6c65ea2b68f5d2a/d1a7562d165d4ad9a927b9aeccfe3b13-ccaf05313aef21454d2359bdba6de2dc-hd.m3u8',
'https://media001.geekbang.org/d5f0f3e882e0496083ec83b9a0d1ff85/bd83bf372509480b9e77f6fbc2ed338f-d57af7a8d2a6d2e0b1d1defb15c81727-hd.m3u8',
'https://media001.geekbang.org/3e0b6791e43449d38eaabff1318ac641/765ab8b1999044cebbc9650843026ab6-a943aa4570eeb5f1957bd196fb8a694b-hd.m3u8',
'https://media001.geekbang.org/92a845ad02c447b790ee7a8eaaf183e3/29c48853d1314321bc15cbee1ccf0df3-9ddc0f1953fb59f22ba0fba64b30d754-hd.m3u8',
'https://media001.geekbang.org/e137e69427ed49229b62151462f999fd/6dd11dfeb1d746bc9cca28ba3b6eee97-ec503688f605713d88dcf958df010fd0-hd.m3u8',
'https://media001.geekbang.org/a1b96f2d6fc241a3ba9a445501b2e7c8/c300914964e145efafeaf43ec5f1412c-bbb611b8e6100017e9163cb724ec039d-hd.m3u8',
'https://media001.geekbang.org/c54547693a9a46c68f50870ace8b10fd/4f73f9f4012945738281eb37e442cd32-ac148ce5944af7591a8f7e3628095597-hd.m3u8',
'https://media001.geekbang.org/d21f9436e2494690998a2edd4d1e1119/56b30193a17042598167364d302c3402-e7f51e42a1433f9b551873c256812219-hd.m3u8']

fileNameMod = r'ffmpeg -i %s -vcodec copy -acodec copy "R:\%s.mp4"'

if len(listArtUrl) != len(listM3U8):
    print('元素数量不相等！')
    exit()

fileString = ""
for i, (artTitle, url) in enumerate(listArtUrl):
    fileTitle = re.sub('[\/:：*?"<>|]', '', artTitle.strip()).replace('  ', ' ')
    print(fileNameMod % (listM3U8[i], fileTitle))
    fileString = fileString + ("%s\n" % (fileNameMod % (listM3U8[i], fileTitle)))

print(fileString)
# 写文件
file = open(r'r:\a.bat', 'w', encoding='gb2312')
file.write(fileString)
file.close()
