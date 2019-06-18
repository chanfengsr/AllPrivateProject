"""
简单的生产视频抓取代码
"""
import re

# Video2 取过来的， 只取 元素1
# 元素 1：文章原始标题
# 元素 2：网页地址或网页文件绝对路径
listArtUrl = [('46 | 构建Restful服务', 'https://time.geekbang.org/course/detail/160-91446'),
              ('47 | 性能分析工具', 'https://time.geekbang.org/course/detail/160-91253'),
              ('48 | 性能调优示例', 'https://time.geekbang.org/course/detail/160-91255'),
              ('49 | 别让性能被锁住', 'https://time.geekbang.org/course/detail/160-91258'),
              ('50 | GC友好的代码', 'https://time.geekbang.org/course/detail/160-91261'),
              ('51 | 高效字符串连接', 'https://time.geekbang.org/course/detail/160-91264'),
              ('52 | 面向错误的设计', 'https://time.geekbang.org/course/detail/160-91265'),
              ('53 | 面向恢复的设计', 'https://time.geekbang.org/course/detail/160-91270'),
              ('54 | Chaos Engineering', 'https://time.geekbang.org/course/detail/160-91299'),
              ('55 | 结束语', 'https://time.geekbang.org/course/detail/160-91302')]

# 与上面元素个数要一致
listM3U8 = [
    'https://media001.geekbang.org/a31b1471633f4bad983d8e54e8a6e7ab/fcfe56a188714c2c890ba5b770eafd79-bc7fef95260040368f0f8764561b05f4-hd.m3u8',
    'https://media001.geekbang.org/f8dfe4d7814e4ee7957b90c8868d09c5/cd2d78a03be546808e3a833cac99e00a-3c0bc1fe980ed526029af68dc90f793c-hd.m3u8',
    'https://media001.geekbang.org/136e686400b84494a15556a6b6acf70e/56d8b5328ec9422c953ce2cdfc9b937c-4c5e64837b35fa2eb47892c9b397544f-hd.m3u8',
    'https://media001.geekbang.org/460e45b750f349f3923bc02f4199efa3/20b1f22d22864fd890135ecf9878fbfb-4531fcb9279be160d26913c6496e869c-hd.m3u8',
    'https://media001.geekbang.org/0d47426c7c504f95889aa4991c1b316b/981e8728202f42b2a4362dc838221767-8ce80321726fe0b4d1e1e6fe9f5b0b00-hd.m3u8',
    'https://media001.geekbang.org/1d2875a760d543eb952fe77a39ebb1ac/94cc7c46fb3e428aa7f5b4f63f862fdb-9092390d7d37649d35058eee7aba1f31-hd.m3u8',
    'https://media001.geekbang.org/1568b283d16046ccbf264a84863d780a/304996e5a7c44ad08b77196c73b43e66-11b2c3e162e4398f5d8e147aff573bf1-hd.m3u8',
    'https://media001.geekbang.org/263b73292f9c4f269048e7f56c250355/7d68271c0ba04c4eb838f232eddd1b63-d4b1d9209a43a24e496a5da75bb7c6aa-hd.m3u8',
    'https://media001.geekbang.org/a867a94c05854016926c7247f111ed3e/7336703c1ebe4c30abc0795197111c12-483cb2e07aae4bde690189522fd3c416-hd.m3u8',
    'https://media001.geekbang.org/5486881477e44734bb00215220b146af/1b4daba291674bb09e7752a4aa5be3ba-d36dc91c2e24fa8fd7af05a923e6aea8-hd.m3u8'
    ]

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
