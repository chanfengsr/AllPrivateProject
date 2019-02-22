import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

'''
# 获取 m3u8 文件地址
ffmpegList=[]
m3u8 = driver.find_element_by_tag_name('audio').get_attribute('src')
ffmpeg = 'ffmpeg -i %s -vcodec copy -acodec copy "R:\%s.mp4"' % (m3u8, raw_title)
ffmpegList.append(ffmpeg)

# 滚到最底端
pageHeight_orig = driver.execute_script('return document.body.scrollHeight')
while True:
    driver.execute_script('window.scrollBy(0,10000)')
    driver.implicitly_wait(2)
    time.sleep(3)
    pageHeight_new = driver.execute_script('return document.body.scrollHeight')

    if pageHeight_new == pageHeight_orig:
        break
    else:
        pageHeight_orig = pageHeight_new

# Write to html
modHtml = "<html>%s<body>%s</body></html>"
headHtml = bs.find("head")
bodyDivHtml = bs.find("div", {"id": "app"})
targetHtml = modHtml % (headHtml, bodyDivHtml)
    
fileObj = open('R:\\' + raw_title + '.html', 'w', encoding='utf-8')
fileObj.write(targetHtml)
fileObj.close()
'''

courseList = \
    [('35 Trie树如何实现搜索引擎的搜索关键词提示功能？', 'https://time.geekbang.org/column/article/72414'),
     ('36 AC自动机如何用多模式串匹配实现敏感词过滤功能？', 'https://time.geekbang.org/column/article/72810'),
     ('37 贪心算法如何用贪心算法实现Huffman压缩编码？', 'https://time.geekbang.org/column/article/73188'),
     ('38 分治算法谈一谈大规模计算框架MapReduce中的分治思想', 'https://time.geekbang.org/column/article/73503'),
     ('不定期福利第三期 测一测你的算法阶段学习成果', 'https://time.geekbang.org/column/article/73786'),
     ('39 回溯算法从电影《蝴蝶效应》中学习回溯算法的核心思想', 'https://time.geekbang.org/column/article/74287'),
     ('40 初识动态规划如何巧妙解决“双十一”购物时的凑单问题？', 'https://time.geekbang.org/column/article/74788'),
     ('不定期福利第四期 刘超我是怎么学习《数据结构与算法之美》的？', 'https://time.geekbang.org/column/article/75197'),
     ('41 动态规划理论一篇文章带你彻底搞懂最优子结构、无后效性和重复子问题', 'https://time.geekbang.org/column/article/75702'),
     ('42 动态规划实战如何实现搜索引擎中的拼写纠错功能？', 'https://time.geekbang.org/column/article/75794'),
     ('43 拓扑排序如何确定代码源文件的编译依赖关系？', 'https://time.geekbang.org/column/article/76207'),
     ('44 最短路径地图软件是如何计算出最优出行路径的？', 'https://time.geekbang.org/column/article/76468'),
     ('45 位图如何实现网页爬虫中的URL去重功能？', 'https://time.geekbang.org/column/article/76827'),
     ('46 概率统计如何利用朴素贝叶斯算法过滤垃圾短信？', 'https://time.geekbang.org/column/article/77142'),
     ('47 向量空间如何实现一个简单的音乐推荐系统？', 'https://time.geekbang.org/column/article/77457'),
     ('48 B+树MySQL数据库索引是如何实现的？', 'https://time.geekbang.org/column/article/77830'),
     ('49 搜索如何用A搜索算法实现游戏中的寻路功能？', 'https://time.geekbang.org/column/article/78175'),
     ('50 索引如何在海量数据中快速查找某个数据？', 'https://time.geekbang.org/column/article/78449'),
     ('51 并行算法如何利用并行处理提高算法的执行效率？', 'https://time.geekbang.org/column/article/78795'),
     ('52 算法实战（一）剖析Redis常用数据类型对应的数据结构', 'https://time.geekbang.org/column/article/79159'),
     ('53 算法实战（二）剖析搜索引擎背后的经典数据结构和算法', 'https://time.geekbang.org/column/article/79433'),
     ('54 算法实战（三）剖析高性能队列Disruptor背后的数据结构和算法', 'https://time.geekbang.org/column/article/79871'),
     ('55 算法实战（四）剖析微服务接口鉴权限流背后的数据结构和算法', 'https://time.geekbang.org/column/article/80388'),
     ('56 算法实战（五）如何用学过的数据结构和算法实现一个短网址系统？', 'https://time.geekbang.org/column/article/80850'),
     ('春节7天练 Day 1数组和链表', 'https://time.geekbang.org/column/article/80456'),
     ('春节7天练 Day 2栈、队列和递归', 'https://time.geekbang.org/column/article/80457'),
     ('春节7天练 Day 3排序和二分查找', 'https://time.geekbang.org/column/article/80458')]


def main():
    # 抓取成功的数量
    catchCount = 0

    # 生成干净的 html 的模板
    modHtml = "<html>%s<body>%s</body></html>"

    # 配置PDF选项 避免中文乱码
    options = {
        'page-size': 'Letter',
        'encoding': "UTF-8",
        'custom-header': [
            ('Accept-Encoding', 'gzip')
        ]
    }

    realDir = os.path.dirname(os.path.realpath(__file__))

    # 用户名密码
    userId = ""
    password = ""
    pwdFilePath = realDir + '\\password.txt'
    if os.path.exists(pwdFilePath):
        pFile = open(pwdFilePath)
        userId = pFile.readline().strip()
        password = pFile.readline().strip()
        pFile.close()
    if userId == "": userId = input("UserId:")
    if password == "": password = input("Password:")

    # 定义chromedriver路径
    driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
    # 获取chrome浏览器驱动
    driver = webdriver.Chrome(executable_path=driver_path)

    ''''''
    # 使用driver打开极客时间登录页面
    print("正在登录网站...")
    login_url = 'https://account.geekbang.org/signin'
    driver.get(login_url)

    # 输入手机号
    driver.find_element_by_class_name("nw-input").send_keys(userId)
    # 输入密码
    driver.find_element_by_class_name("input").send_keys(password)
    # 点击登录按钮
    driver.find_element_by_class_name("mybtn").click()
    # 为了使ajax加载完成 此处使用隐式等待让程序等待5秒钟
    driver.implicitly_wait(5)
    time.sleep(3)
    print("已登录。")

    print("开始爬取专栏文章...")
    # 记录爬取文章的开始时间
    start = time.time()

    # 正式开始抓取
    for doc in courseList:
        title, url = doc
        tarTitle = re.sub('[\/:：*?"<>|]', '', title.strip()).replace('  ', ' ')

        print("正在抓取文章：" + tarTitle)
        driver.get(url)

        # 滚到最底端，获取完整的网页内容
        pageHeight_orig = driver.execute_script('return document.body.scrollHeight')
        while True:
            driver.execute_script('window.scrollBy(0,50000)')
            time.sleep(3)
            pageHeight_new = driver.execute_script('return document.body.scrollHeight')

            if pageHeight_new == pageHeight_orig:
                break
            else:
                pageHeight_orig = pageHeight_new

        # 获取到网页完整内容
        bs = BeautifulSoup(driver.page_source, "html.parser")

        # 专栏名称
        # columnName = bs.select_one('a[class="title"]').text.strip()
        # columnName = tarTitle
        columnName = ''

        # 保存目录
        exportPath = "R:\\%s\\" % columnName
        exportPathPDF = exportPath + "PDF\\"
        exportPathHTML = exportPath + "HTML\\"
        if not os.path.exists(exportPathPDF):
            os.makedirs(exportPathPDF)
        if not os.path.exists(exportPathHTML):
            os.makedirs(exportPathHTML)

        # 获取 m3u8 文件地址
        m3u8 = bs.find("audio")
        if m3u8 is not None:
            ffmpeg = 'ffmpeg -i %s -vcodec copy -acodec copy "%s.mp4"\n' % (m3u8["src"], tarTitle)

            # 写 ffmpeg 下载列表
            ffmpegListFile = open(exportPath + "ffmpegDownList.txt", 'a', encoding='gb2312')
            ffmpegListFile.write(ffmpeg)
            ffmpegListFile.close()

        # 获取干净的 html 并保存
        [s.extract() for s in bs.find_all("script")]  # 去干净 JS
        headHtml = bs.find("head")
        bodyDivHtml = bs.find("div", {"id": "app"})
        targetHtml = modHtml % (headHtml, bodyDivHtml)
        htmlFile = open(exportPathHTML + tarTitle + '.html', 'w', encoding='utf-8')
        htmlFile.write(targetHtml)
        htmlFile.close()
        print("Html 抓取完成。  --> %s.html" % (tarTitle))

        '''
        # 用 html 生成 PDF 文件
        print("正在生成 PDF...")
        if pdfkit.from_string(targetHtml.replace(r'background:#000',r'background:#fff'), exportPathPDF + tarTitle + '.pdf', options=options):
            print("PDF 已生成。  --> %s.pdf" % (tarTitle))
        '''

        # 爬一篇文章后休息几秒钟
        catchCount += 1
        time.sleep(5)
        print("\n\n")

    # 记录爬取文章的结束时间
    end = time.time()

    print("ffmpeg 下载列表  --> ffmpegDownList.txt")
    print("所有文章爬取完毕！共 %d 篇，耗时 %d 秒" % (catchCount, int(end - start)))


if __name__ == '__main__':
    main()
