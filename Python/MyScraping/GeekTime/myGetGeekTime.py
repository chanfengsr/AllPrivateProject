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
    [
        ("00 开篇词 洞悉技术的本质，享受科技的乐趣", "https://time.geekbang.org/column/article/181"),
        ("01 程序员如何用技术变现（上）", "https://time.geekbang.org/column/article/183"),
        ("02 程序员如何用技术变现（下）", "https://time.geekbang.org/column/article/185"),
        ("03 Equifax信息泄露始末", "https://time.geekbang.org/column/article/281"),
        ("04 从Equifax信息泄露看数据安全", "https://time.geekbang.org/column/article/285"),
        ("05 何为技术领导力？", "https://time.geekbang.org/column/article/288"),
        ("06 如何才能拥有技术领导力？", "https://time.geekbang.org/column/article/291"),
        ("07 推荐阅读：每个程序员都该知道的知识", "https://time.geekbang.org/column/article/471"),
        ("08 Go语言，Docker和新技术", "https://time.geekbang.org/column/article/294"),
        ("09 答疑解惑：渴望、热情和选择", "https://time.geekbang.org/column/article/540"),
        ("10 如何成为一个大家愿意追随的Leader？", "https://time.geekbang.org/column/article/297"),
        ("11 程序中的错误处理：错误返回码和异常捕捉", "https://time.geekbang.org/column/article/675"),
        ("12 程序中的错误处理：异步编程和最佳实践", "https://time.geekbang.org/column/article/693"),
        ("13 魔数 0x5f3759df", "https://time.geekbang.org/column/article/730"),
        ("14 推荐阅读：机器学习101", "https://time.geekbang.org/column/article/862"),
        ("15 时间管理：同扭曲时间的事儿抗争", "https://time.geekbang.org/column/article/995"),
        ("16 时间管理：投资赚取时间", "https://time.geekbang.org/column/article/997"),
        ("17 故障处理最佳实践：应对故障", "https://time.geekbang.org/column/article/1059"),
        ("18 故障处理最佳实践：故障改进", "https://time.geekbang.org/column/article/1064"),
        ("19 答疑解惑：我们应该能够识别的表象和本质", "https://time.geekbang.org/column/article/865"),
        ("20 Git协同工作流，你该怎样选", "https://time.geekbang.org/column/article/2440"),
        ("21 分布式系统架构的冰与火", "https://time.geekbang.org/column/article/1411"),
        ("22 从亚马逊的实践，谈分布式系统的难点", "https://time.geekbang.org/column/article/1505"),
        ("23 分布式系统的技术栈", "https://time.geekbang.org/column/article/1512"),
        ("24 分布式系统关键技术：全栈监控", "https://time.geekbang.org/column/article/1513"),
        ("25 分布式系统关键技术：服务调度", "https://time.geekbang.org/column/article/1604"),
        ("26 分布式系统关键技术：流量与数据调度", "https://time.geekbang.org/column/article/1609"),
        ("27 洞悉PaaS平台的本质", "https://time.geekbang.org/column/article/1610"),
        ("28 推荐阅读：分布式系统架构经典资料", "https://time.geekbang.org/column/article/2080"),
        ("29 推荐阅读：分布式数据调度相关论文", "https://time.geekbang.org/column/article/2421"),
        ("30 编程范式游记（1）- 起源", "https://time.geekbang.org/column/article/301"),
        ("31 编程范式游记（2）- 泛型编程", "https://time.geekbang.org/column/article/303"),
        ("32 编程范式游记（3） - 类型系统和泛型的本质", "https://time.geekbang.org/column/article/2017"),
        ("33 编程范式游记（4）- 函数式编程", "https://time.geekbang.org/column/article/2711"),
        ("34 编程范式游记（5）- 修饰器模式", "https://time.geekbang.org/column/article/2723"),
        ("35 编程范式游记（6）- 面向对象编程", "https://time.geekbang.org/column/article/2729"),
        ("36 编程范式游记（7）- 基于原型的编程范式", "https://time.geekbang.org/column/article/2741"),
        ("37 编程范式游记（8）- Go 语言的委托模式", "https://time.geekbang.org/column/article/2748"),
        ("38 编程范式游记（9）- 编程的本质", "https://time.geekbang.org/column/article/2751"),
        ("39 编程范式游记（10）- 逻辑编程范式", "https://time.geekbang.org/column/article/2752"),
        ("40 编程范式游记（11）- 程序世界里的编程范式", "https://time.geekbang.org/column/article/2754"),
        ("41 弹力设计篇之“认识故障和弹力设计”", "https://time.geekbang.org/column/article/3912"),
        ("42 弹力设计篇之“隔离设计”", "https://time.geekbang.org/column/article/3917"),
        ("43 弹力设计篇之“异步通讯设计”", "https://time.geekbang.org/column/article/3926"),
        ("44 弹力设计篇之“幂等性设计”", "https://time.geekbang.org/column/article/4050"),
        ("45 弹力设计篇之“服务的状态”", "https://time.geekbang.org/column/article/4086"),
        ("46 弹力设计篇之“补偿事务”", "https://time.geekbang.org/column/article/4087"),
        ("47 弹力设计篇之“重试设计”", "https://time.geekbang.org/column/article/4121"),
        ("48 弹力设计篇之“熔断设计”", "https://time.geekbang.org/column/article/4241"),
        ("49 弹力设计篇之“限流设计”", "https://time.geekbang.org/column/article/4245"),
        ("50 弹力设计篇之“降级设计”", "https://time.geekbang.org/column/article/4252")
    ]


def main():
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

    # 用户名密码
    userId = ""
    password = ""
    if os.path.exists("password.txt"):
        pFile = open("password.txt")
        userId = pFile.readline().strip()
        password = pFile.readline().strip()
        pFile.close()
    if userId == "": userId = input("UserId:")
    if password == "": password = input("Password:")

    # 定义chromedriver路径
    driver_path = r'..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
    # 获取chrome浏览器驱动
    driver = webdriver.Chrome(executable_path=driver_path)

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

        # 获取 m3u8 文件地址
        m3u8 = bs.find("audio")
        if m3u8 is not None:
            ffmpeg = 'ffmpeg -i %s -vcodec copy -acodec copy "R:\%s.mp4"\n' % (m3u8["src"], tarTitle)

            # 写 ffmpeg 下载列表
            ffmpegListFile = open('R:\\ffmpegDownList.txt', 'a', encoding='gb2312')
            ffmpegListFile.write(ffmpeg)
            ffmpegListFile.close()

        # 获取干净的 html 并保存
        [s.extract() for s in bs.find_all("script")]  # 去干净 JS
        headHtml = bs.find("head")
        bodyDivHtml = bs.find("div", {"id": "app"})
        targetHtml = modHtml % (headHtml, bodyDivHtml)
        htmlFile = open('R:\\' + tarTitle + '.html', 'w', encoding='utf-8')
        htmlFile.write(targetHtml)
        htmlFile.close()
        print("Html 抓取完成。  --> %s.html" % (tarTitle))

        # 用 html 生成 PDF 文件
        print("正在生成 PDF...")
        if pdfkit.from_string(targetHtml, 'R:\\' + tarTitle + '.pdf', options=options):
            print("PDF 已生成。  --> %s.pdf" % (tarTitle))

        # 爬一篇文章后休息几秒钟
        time.sleep(10)
        print("\n\n")

    # 记录爬取文章的结束时间
    end = time.time()

    print("ffmpeg 下载列表: ffmpegDownList.txt")

    print("所有文章爬取完毕！共耗时" + str(int(end - start)) + "秒")


if __name__ == '__main__':
    main()
