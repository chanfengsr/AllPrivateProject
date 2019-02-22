"""
简单的生产视频抓取代码
"""
import re

# Video2 取过来的， 只取 元素1
# 元素 1：文章原始标题
# 元素 2：网页地址或网页文件绝对路径
listArtUrl = [('01 | 课程内容综述', 'https://time.geekbang.org/course/detail/153-76547'),
              ('02 | 第一章内容概述', 'https://time.geekbang.org/course/detail/153-76546'),
              ('03 | TensorFlow产生的历史必然性', 'https://time.geekbang.org/course/detail/153-76548'),
              ('04 | TensorFlow与Jeff Dean的那些事', 'https://time.geekbang.org/course/detail/153-76549'),
              ('05 | TensorFlow的应用场景', 'https://time.geekbang.org/course/detail/153-76550'),
              ('06 | TensorFlow的落地应用', 'https://time.geekbang.org/course/detail/153-76551'),
              ('07 | TensorFlow的发展现状', 'https://time.geekbang.org/course/detail/153-76552'),
              ('08 | 第二章内容概述', 'https://time.geekbang.org/course/detail/153-76553'),
              ('09 | 搭建你的TensorFlow开发环境', 'https://time.geekbang.org/course/detail/153-76554'),
              ('10 | Hello TensorFlow', 'https://time.geekbang.org/course/detail/153-76555'),
              ('11 | 在交互环境中使用TensorFlow', 'https://time.geekbang.org/course/detail/153-76556'),
              ('12 | 在容器中使用TensorFlow', 'https://time.geekbang.org/course/detail/153-76557'),
              ('13 | 第三章内容概述', 'https://time.geekbang.org/course/detail/153-76954'),
              ('14 | TensorFlow模块与架构介绍', 'https://time.geekbang.org/course/detail/153-76955'),
              ('15 | TensorFlow数据流图介绍', 'https://time.geekbang.org/course/detail/153-76956'),
              ('16 | 张量（Tensor）是什么（上）', 'https://time.geekbang.org/course/detail/153-77203'),
              ('17 | 张量（Tensor）是什么（下）', 'https://time.geekbang.org/course/detail/153-77204'),
              ('18 | 变量（Variable）是什么（上）', 'https://time.geekbang.org/course/detail/153-77205'),
              ('19 | 变量（Variable）是什么（下）', 'https://time.geekbang.org/course/detail/153-77207'),
              ('20 | 操作（Operation）是什么（上）', 'https://time.geekbang.org/course/detail/153-77209'),
              ('21 | 操作（Operation）是什么（下）', 'https://time.geekbang.org/course/detail/153-77210'),
              ('22 | 会话（Session）是什么', 'https://time.geekbang.org/course/detail/153-77212'),
              ('23 | 优化器（Optimizer）是什么', 'https://time.geekbang.org/course/detail/153-77215'),
              ('24 | 第四章内容概述', 'https://time.geekbang.org/course/detail/153-78978'),
              ('25 | 房价预测模型的前置知识', 'https://time.geekbang.org/course/detail/153-78981'),
              ('26 | 房价预测模型介绍', 'https://time.geekbang.org/course/detail/153-78979'),
              ('27 | 房价预测模型之数据处理', 'https://time.geekbang.org/course/detail/153-79136'),
              ('28 | 房价预测模型之创建与训练', 'https://time.geekbang.org/course/detail/153-79138'),
              ('29 | TensorBoard 可视化工具介绍', 'https://time.geekbang.org/course/detail/153-79411'),
              ('30 | 使用 TensorBoard 可视化数据流图', 'https://time.geekbang.org/course/detail/153-80135'),
              ('31 | 实战房价预测模型：数据分析与处理', 'https://time.geekbang.org/course/detail/153-80136'),
              ('32 | 实战房价预测模型：创建与训练', 'https://time.geekbang.org/course/detail/153-80137'),
              ('33 | 实战房价预测模型：可视化数据流图', 'https://time.geekbang.org/course/detail/153-80142'),
              ('34 | 第五章内容概述', 'https://time.geekbang.org/course/detail/153-81594'),
              ('35 | 手写体数字数据集 MNIST 介绍（上）', 'https://time.geekbang.org/course/detail/153-81596'),
              ('36 | 手写体数字数据集 MNIST 介绍（下）', 'https://time.geekbang.org/course/detail/153-81598'),
              ('37 | MNIST Softmax 网络介绍（上）', 'https://time.geekbang.org/course/detail/153-81600'),
              ('38 | MNIST Softmax 网络介绍（下）', 'https://time.geekbang.org/course/detail/153-81602'),
              ('39 | 实战MNIST Softmax网络（上）', 'https://time.geekbang.org/course/detail/153-81843'),
              ('40 | 实战MNIST Softmax网络（下）', 'https://time.geekbang.org/course/detail/153-81844'),
              ('41 | MNIST CNN网络介绍', 'https://time.geekbang.org/course/detail/153-81845'),
              ('42 | 实战MNIST CNN网络', 'https://time.geekbang.org/course/detail/153-81846')]

# 与上面元素个数要一致
listM3U8 = ['https://res001.geekbang.org/media/video/ba/b2/babdfac3470ee5e7c9e476399ba37db2/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/59/f2/5987e8794a41ed2b2423bfcfe54b77f2/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/c3/55/c3a8365e28d646fbb36c04c1bf72fa55/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/6b/8b/6b30cb499b10b711872b856c8213908b/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/87/69/87b8cff8478d513ef689c5598044fa69/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/f3/f4/f32d0240adb31b8aaddf7ee571d160f4/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/e0/02/e02b227a2ef3c04ddfb6b26ba86fb402/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/92/06/92b14c198f767fd8553edf0545eb9806/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/63/e5/63a87f9995cafc75c3bdbe690fd3c0e5/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/74/8e/740297f76b2f60e2601b928c217aa18e/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/37/15/372720b1aee9d8b2193dce6e39e37d15/hd/hd.m3u8',
            'https://res001.geekbang.org/media/video/f4/b1/f4b56c936ebdbdec26def3034a97fab1/hd/hd.m3u8',
            'https://media001.geekbang.org/793dcba1e2554f869ac70050828d2314/cd66d73fe82d44d394920a5379e1f1a6-ec2f99f815941e19180f88887fec7f10-hd.m3u8',
            'https://media001.geekbang.org/853291b8623249e28e038d0cd58d2c1f/f6e1d72904354fb5839661158b7b58e4-4594cae298db82914838e86c14041444-hd.m3u8',
            'https://media001.geekbang.org/b7085e6b927c4a43ac9d155cf6567e85/24f82028eed54617a5b467c24f689626-24831f0a891b5510af2c66721f8d8d3d-hd.m3u8',
            'https://media001.geekbang.org/6397630c560e49179438e0d0a1a9ee86/d0ff0e6975f449cda37413a4f6c6e978-4d4807ab6d88f2fdac47a349718c8a45-hd.m3u8',
            'https://media001.geekbang.org/5b0efa2e24184ceaa64a03ed799560dc/46ac34744a804e41a82318d50d6eb4b6-c264ac7e86866c04cb0271e05c806e63-hd.m3u8',
            'https://media001.geekbang.org/42d0b31acab242caa55c31fb3f163f63/39d62103aabf4f099258de375549a750-a32a97d5f440fbcd12b3a2f635111544-hd.m3u8',
            'https://media001.geekbang.org/0a04f5ee501c43ccb3d125c59091ee15/060474570d5c4737acd3bf19c9334220-cdcfa0ea527d445241a04d0f9d2f3af0-hd.m3u8',
            'https://media001.geekbang.org/07897a96a22347da838ba9c0c4ff28bd/648efde237534bf8ba0a2877d914472e-6dd5276c8f8842046a59e8a8948155cb-hd.m3u8',
            'https://media001.geekbang.org/60ea304f15304efe85ffce8ceb5e8201/8c025f0e7e3e45bbb7673bf53aa639ee-306ede9326535e12ec09d4400a3d63df-hd.m3u8',
            'https://media001.geekbang.org/8720b69298c34663a526fa9435d18d5e/2fe76065997a464084e23bbb9fc232a1-2b6bb51a49fb8eb6c231f4aa5530bf7e-hd.m3u8',
            'https://media001.geekbang.org/6f9ef728cbb04b598a949945068cd2c7/1173732f577540a08e66742530d22f90-abdb32d8084d39c1d048788e3e7f2c3b-hd.m3u8',
            'https://media001.geekbang.org/3c34783e9a0843ce88b1132b6db6fb57/d3b1e6b07bfa4bc387bcc08da6a009ce-bb7ff63ad90f823badc4a9bfe54ce434-hd.m3u8',
            'https://media001.geekbang.org/0b52deeb91f748c5bf55b555ba26f13c/12dbf1f0bf914c4b819b085208fc33e7-ed1d420c0c7ebdb0e02a498c56005153-hd.m3u8',
            'https://media001.geekbang.org/5a3a8d3bc8de40fc8fa96531a1eee813/10c1154c3ce140b5a1b5f04d1e8cd2a2-287aa8279d60f25eeb56bbe1bb77bc65-hd.m3u8',
            'https://media001.geekbang.org/9ad86ca59f3c4cf7aca41dc6b88bf102/93102cce8a1141578457f55457334d69-0c70ba6eb5cd17d925414dc36c1498e0-hd.m3u8',
            'https://media001.geekbang.org/98c4e555ac874000945bed7243f009cd/d8224c977eb24db089616b256208515a-203a4a8809cfd0475b7c0a00b5413e62-hd.m3u8',
            'https://media001.geekbang.org/d36c795a903a42b3a537698cc7f4c27e/9b843892a9e445a8b8d64ecc6fe1e012-bf668daf1d7f73de30f7edf754d084b6-hd.m3u8',
            'https://media001.geekbang.org/2aaf5388d0d840a4bfbaee0ff09dd98f/9cc67c8071b444848ea96090a71bf9aa-e319a4deb749912a8b50fa0ad8e4c215-hd.m3u8',
            'https://media001.geekbang.org/12ee370fa826439095ad93110db09981/19c3a713bc604d0286df462f8daa5c35-7be97c39ce7dbdd101c02328612ed953-hd.m3u8',
            'https://media001.geekbang.org/6cdd37689e1d44bb82fab48fe75ef78e/a7eb33eeee654f1abcfaf9171a4d05c4-0f1a49607e0dad4105257fc8407accce-hd.m3u8',
            'https://media001.geekbang.org/6e17e563f41e47c9bd8c64d61f9fea7e/d655cbb0272b4eae9f008041ed1a13c7-bc2991b91bc588c80b07962436a341f1-hd.m3u8',
            'https://media001.geekbang.org/d7ce659467cd4a379da5cf3e5c9d05b3/7fc83e5cb8ba4d53bdb83f4861770b64-c1a75103bddcd23450b86e5d238bc235-hd.m3u8',
            'https://media001.geekbang.org/e3ce8b5b8d5d4a9f8ca0c09f50d7e5c7/9750164a32824f438b44c9522b5e4da9-8d5cab4852f9aa21688245eafc5555d1-hd.m3u8',
            'https://media001.geekbang.org/cbe9403f04be401cb7f449a777bda378/da2a0e2b69524846b63734215c312f72-3a58958262933bc85b8f135754293c65-hd.m3u8',
            'https://media001.geekbang.org/e32be30e734343778b009cd355c4227d/e645172da2474e9ba5a69ecc454ac3fb-a0e0ff0e9125d4f041011ef0328470b5-hd.m3u8',
            'https://media001.geekbang.org/761fb5d0f51d489ea8987505862a341b/d8e4b48717424f028292d9b60974915f-03319566859ba62830383237fa171c09-hd.m3u8',
            'https://media001.geekbang.org/060e54bffd2d46509f11ac159353128c/7c1dca64668d4f8ea16348b6322cacd9-54c148356043a53004feecf278d7fa9e-hd.m3u8',
            'https://media001.geekbang.org/409f288e7a6342889d7030f7fae43877/329fa0b24a8d4a1f9b23d5428ed240a1-9a8913129b97570f6cd9a740cc07eff7-hd.m3u8',
            'https://media001.geekbang.org/5789a0016e674e6b898430ed421584e8/49cc76f16c024d9d8a8acf02575eeb9b-6ab90a8f6262338f01a647b9f1b9ac67-hd.m3u8',
            'https://media001.geekbang.org/fc06b61f06a24c11ad75c59595ee08b8/7917b326efc14af59028d76df7d24b84-1bc980150559348387dad391489dee02-hd.m3u8']

fileNameMod = r'ffmpeg -i %s -vcodec copy -acodec copy "R:\%s.mp4"'

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
