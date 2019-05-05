"""
简单的生产视频抓取代码
"""
import re

# Video2 取过来的， 只取 元素1
# 元素 1：文章原始标题
# 元素 2：网页地址或网页文件绝对路径
listArtUrl = [('01 | Go语言课程介绍', 'https://time.geekbang.org/column/article/84335'),
 ('02 | 内容综述', 'https://time.geekbang.org/column/article/84354'),
 ('03 | Go 语言简介：历史背景、发展现状及语言特性', 'https://time.geekbang.org/column/article/84355'),
 ('04 | 编写第一个Go程序', 'https://time.geekbang.org/column/article/84356'),
 ('05 | 变量、常量以及与其他语言的差异', 'https://time.geekbang.org/column/article/84357'),
 ('06 | 数据类型', 'https://time.geekbang.org/column/article/84358'),
 ('07 | 运算符', 'https://time.geekbang.org/column/article/84359'),
 ('08 | 条件和循环', 'https://time.geekbang.org/column/article/84360'),
 ('09 | 数组和切片', 'https://time.geekbang.org/column/article/84361'),
 ('10 | Map 声明、元素访问及遍历', 'https://time.geekbang.org/column/article/84629'),
 ('11 | Map与工厂模式，在Go语言中实现Set', 'https://time.geekbang.org/column/article/84630'),
 ('12 | 字符串', 'https://time.geekbang.org/column/article/85348'),
 ('13 | Go 语言的函数', 'https://time.geekbang.org/column/article/85350'),
 ('14 | 可变参数和 defer', 'https://time.geekbang.org/column/article/85466'),
 ('15 | 行为的定义和实现', 'https://time.geekbang.org/column/article/85465'),
 ('16 | Go语言的相关接口', 'https://time.geekbang.org/column/article/85770'),
 ('17 | 扩展与复用', 'https://time.geekbang.org/column/article/85776'),
 ('18 | 不一样的接口类型，一样的多态', 'https://time.geekbang.org/column/article/85777'),
 ('19 | 编写好的错误处理', 'https://time.geekbang.org/column/article/85953'),
 ('20 | panic和recover', 'https://time.geekbang.org/column/article/85954'),
 ('21 | 构建可复用的模块（包）', 'https://time.geekbang.org/column/article/85955'),
 ('22 | 依赖管理', 'https://time.geekbang.org/column/article/85956'),
 ('23 | 协程机制', 'https://time.geekbang.org/column/article/86799'),
 ('24 | 共享内存并发机制', 'https://time.geekbang.org/column/article/86537'),
 ('25 | CSP并发机制', 'https://time.geekbang.org/column/article/86538'),
 ('26 | 多路选择和超时', 'https://time.geekbang.org/column/article/86539'),
 ('27 | channel的关闭和广播', 'https://time.geekbang.org/column/article/86540'),
 ('28 | 任务的取消', 'https://time.geekbang.org/column/article/85957'),
 ('29 | Context与任务取消', 'https://time.geekbang.org/column/article/85958'),
 ('30 | 只运行一次', 'https://time.geekbang.org/column/article/86541'),
 ('31 | 仅需任意任务完成', 'https://time.geekbang.org/column/article/86544'),
 ('32 | 所有任务完成', 'https://time.geekbang.org/column/article/86545'),
 ('33 | 对象池', 'https://time.geekbang.org/column/article/87730'),
 ('34 | sync.pool 对象缓存', 'https://time.geekbang.org/column/article/87731'),
 ('35 | 单元测试', 'https://time.geekbang.org/column/article/87732'),
 ('36 | Benchmark', 'https://time.geekbang.org/column/article/87733'),
 ('37 | BDD', 'https://time.geekbang.org/column/article/87734'),
 ('38 | 反射编程', 'https://time.geekbang.org/column/article/87797'),
 ('39 | 万能程序', 'https://time.geekbang.org/column/article/88531'),
 ('40 | 不安全编程', 'https://time.geekbang.org/column/article/88539'),
 ('41 | 实现pipe-filter framework', 'https://time.geekbang.org/column/article/88542'),
 ('42 | 实现micro-kernel framework', 'https://time.geekbang.org/column/article/88543'),
 ('43 | 内置JSON解析', 'https://time.geekbang.org/column/article/88544'),
 ('44 | easyjson', 'https://time.geekbang.org/column/article/88545'),
 ('45 | HTTP服务', 'https://time.geekbang.org/column/article/88546')]

# 与上面元素个数要一致
listM3U8 = ['https://media001.geekbang.org/1e3a867b2592424e9d402a7413d46220/6ea405cfa8314a418389be58e8511a9a-f882ae8b20fb62d562e2f0ab8f8a9e37-hd.m3u8',
'https://media001.geekbang.org/d581a75772ee41f4b0f63218d12043a0/ca611b77389d41758ca1dc28ca63c44e-1de91cc8bafaf18f23c2ca187ef4f8f3-hd.m3u8',
'https://media001.geekbang.org/c07fd233dd404ed2ba18aa0fe7b7c530/47530485c4ac49d6ae60199a3f33212b-e4944ef2a938b9f70af8f931397837e4-hd.m3u8',
'https://media001.geekbang.org/297803d3641b414ebdc916d74119e93b/0141f8f46fb94389b28117d5f32f7d67-e6da6ac063dc45bc5dd6a1ea57de60ec-hd.m3u8',
'https://media001.geekbang.org/61ccbdddb16142c2b804bc0845872ad8/1c207d8400a947fba6cdf15ffaa3a440-1bcedc0748dc6f31d2a8d82d1cf823a3-hd.m3u8',
'https://media001.geekbang.org/f1eb2112cd21442eb22fefaa1a62ed2b/3ac4c59524be433081bfcf886c58b4c9-f1eebb52e3958e794d3299aca8ffcc0b-hd.m3u8',
'https://media001.geekbang.org/e6733ace0e1b424bbeb9c89590127778/6291262276754c68ab16616e74bd5b33-105c03f064db21c98bf322589f082713-hd.m3u8',
'https://media001.geekbang.org/9d840dcb55fa461e91b918e6dacb8c19/51caa4148db04b53b859fdcce943e4be-d62255e938c81a006191debfc66839c6-hd.m3u8',
'https://media001.geekbang.org/55f4f98114df4785a5494fad1308f1fa/1cdbecea55b64592b89ed1d4b55ba05c-c70003150e1eeb42f7dee86fc9ffa9e6-hd.m3u8',
'https://media001.geekbang.org/38de1a9ab3c14e6f86d25c8277c7c774/44bebbdcacfa4589b4b81b1ce81040aa-99b325f435420626a115b9adbb912854-hd.m3u8',
'https://media001.geekbang.org/5f362548dcdf4d1697cd08b3fc9b6dc0/8d95642acf34408f8279413ed6170190-7ba72d046d272f94be76e25d627903a6-hd.m3u8',
'https://media001.geekbang.org/8f854bae6ca044d8b7da09ef1744f89f/41f1a687d67647509907f1fede1583c5-6913ad4f5ec42bdbe1b1853a6d0a993e-hd.m3u8',
'https://media001.geekbang.org/05f679c668774bf1b7e3f3b409040936/da679316242442f0adebacecef6fa184-6d03c5c42cd9939adf470e80480e0c92-hd.m3u8',
'https://media001.geekbang.org/ab96a03f817441f0a74f007adb933723/5b9b6bceb293427cba56c9a1e1b24d0f-1106b04af81b41538dbdc91ba69442d1-hd.m3u8',
'https://media001.geekbang.org/bd8e15a5899047539d3fcba08080c195/e7c264770e6f4f57bc4ae67b37d5543a-c0a6aab935fef5ab66fa4352e55a6b4c-hd.m3u8',
'https://media001.geekbang.org/76c1de2da08e4559a72ca71f82989237/b016b8f323dc4bd5a58f4ba974e892d3-09676a752dfe03d431457aa9cf49408c-hd.m3u8',
'https://media001.geekbang.org/8cf78e2158114fd28758ab70f47bf1ef/1967fe11d7924386a009b9528c96346a-9bf92a149c0bdd38cbf3a49c8dcff66c-hd.m3u8',
'https://media001.geekbang.org/a907c895309f4faa8ed917090c57ee52/23f5e38a5da244e3acf56894d78eb039-5cc211b93af43a7b98438f78bef820ff-hd.m3u8',
'https://media001.geekbang.org/bc346aa973144db5ad49bcbe0e72b831/0284214987f64a2fa5596df4075307b4-f1fc5b6b161ec4ffd0c5a9a719e9bf76-hd.m3u8',
'https://media001.geekbang.org/61f878e98b4941f992c785d1fb65e55b/f0aca5691be44a798a1a5910b8d2e6f3-0ba2e601068f40fc8541e8c9dc399ade-hd.m3u8',
'https://media001.geekbang.org/228f713a08364dd8b7eefaaa5f68ae45/1e1f4c01d1114a2b93bbd3980db3c022-6c268d1b085f243b8f8515adef22bf3b-hd.m3u8',
'https://media001.geekbang.org/2531379bf291417b875ae200dca783c6/528b0c3e59384605a3f3e9dd4d9d4e1f-7af6c7100cf859937a74472cf355713e-hd.m3u8',
'https://media001.geekbang.org/798b0536f31248408fc6a7bf4c1c0d5e/69c0a48c4bdb4f8ebcc951f00241fbba-2177cd127dd4957306e794b444b416f4-hd.m3u8',
'https://media001.geekbang.org/b91941d15b0b4ec4a82754b999173502/46310207fa0b4fae9de6d2c3fd5546a1-2f57546d288c284dc0e22bcbcd12443c-hd.m3u8',
'https://media001.geekbang.org/6ecdf682aea048d7ab1b5b7548036766/b3d384f9c4764240ab57a8e2ad5246ca-afd2d5fb4ed8598f40962848b68f36a8-hd.m3u8',
'https://media001.geekbang.org/50dcd7b32c9145d1a8edce0105300c5d/8af551d2e5864022884df887192946fa-6819aa68616b2a790091609d3d037860-hd.m3u8',
'https://media001.geekbang.org/5d9142df4f6f4ec58bc11db5343cb5b7/3d8d59b964794dbea573a7530a927cd0-1b260d081cf25c6303af7ba6eff2ff5a-hd.m3u8',
'https://media001.geekbang.org/ed08f6a7b8d54cf68c01c39ac7f71476/fd3a1cfec5f1406aa15f5d4dbb151aed-d5de938f0f849100aec0efa100d34a3b-hd.m3u8',
'https://media001.geekbang.org/20a2dc60314c433fb0940d56378f1b35/93b35479b7f942f782be1ff203e775ae-373e6f1570051b6c6813ee17d79d38d0-hd.m3u8',
'https://media001.geekbang.org/3526bd30897c4f218e753c8c7a8fd684/6acf5f1be7374b9c8ce76908dea5c93c-e44a41f1aafdf35ead8bfa131989f919-hd.m3u8',
'https://media001.geekbang.org/e3424a2a8bbf4a99b4dea5254dd98ef3/0523622aa3484e07a110d9a785c351b2-b9e7263a9e2159295aac274a6b210928-hd.m3u8',
'https://media001.geekbang.org/2f4b5846ffc2434fb2347d3f96f36e3a/de05d1d31949424dad3410f25dee9914-58372ecde30956f3f9c9469e6b3576c6-hd.m3u8',
'https://media001.geekbang.org/91d7efcd9f5e4dcea91113c910c7fc2c/3320818a574942a5a17490c2957c7c5c-d03aec69bf6eb759a7de470aa6072f4a-hd.m3u8',
'https://media001.geekbang.org/b822644217254ca0988140bba945f9c6/072d7ba16527468ca88d9693d94c7ae5-d31b9c133c723fb937cd895d1f0f94f7-hd.m3u8',
'https://media001.geekbang.org/6b71506550704ef7ada4b7715b0ba559/225c1dd6159242e39ff24e4318ded2c4-a5b7c7aff8920218713f1a4875537c53-hd.m3u8',
'https://media001.geekbang.org/506ae5bce5ff4a43a514aa044a483eb0/15f30b440ecb4a7eafdfe3bcb76dcce6-2207215295c05986fe6500f5c1e79500-hd.m3u8',
'https://media001.geekbang.org/5a12a32546974eccabed528af29dce8a/1f0ae45d39d3449b9dccf8b2d064866f-3fa59ed00d0f2c7316f0899ee8cd75d0-hd.m3u8',
'https://media001.geekbang.org/0b32cf2875cc4dcda3232faf269f4048/17366bf339bf4adb9a0862307bf1f85c-f4da217dbd466074af32a2da7ec67977-hd.m3u8',
'https://media001.geekbang.org/b3e81cd54e4140269db45cc0bcef1526/82a3ec59f82648e9bb5cd95ba5385ada-6612bbaac9afaad4ba0d4aabfd9c48e6-hd.m3u8',
'https://media001.geekbang.org/28a1a6075c3a4ea5b835089c2e1b1f77/917bda4b2b44448194499f189618a03e-47bd888555fc5817c987dd21d49541d9-hd.m3u8',
'https://media001.geekbang.org/ca5cb39b39c14e84a78ed48a804d3bb2/a9ea5f33b5914f03a1d19373f9870d52-44f4dd8174d0279ed32713ba2670d9be-hd.m3u8',
'https://media001.geekbang.org/2e66a5ea20ce446a9c6a8acbd092f204/53bff52d8c0d4c98b85e5011b35bd215-842468d7440af921b35e024c78f22092-hd.m3u8',
'https://media001.geekbang.org/14d00c50d5234b4ca6ab0037df27353d/fda8b9a403514b7fab1fd859fe539e89-2166bb77fabd8d44dff7a4e610bb044f-hd.m3u8',
'https://media001.geekbang.org/299b49fcd45d4a00b19b2e8747b65a7e/6f957d4689964d3bb83548e21cef31b4-b767d80bd4d114dc6d7a81d9981ce987-hd.m3u8',
'https://media001.geekbang.org/a3d04d9f25374339922d6afdca9a4bac/bacd6db3e0744dd2bd9a09266e9b02c5-d66cbd6ebb142977922acfc887ca097e-hd.m3u8']

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
