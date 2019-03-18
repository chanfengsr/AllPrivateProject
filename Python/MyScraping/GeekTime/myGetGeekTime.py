import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

# Debug 状态，网页不登陆，不滚动
inDebug = True #and False

# 元素 1：文章原始标题
# 元素 2：网页地址或手工保存网页文件的绝对路径
courseList = \
    [ ('Test', 'https://time.geekbang.org/column/article/70844')]

realDir = os.path.dirname(os.path.realpath(__file__))


# 用户名、密码登录网站
def Login(driver):
    """
    用户名、密码登录网站
    :param driver: 浏览器
    :return:
    """

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

    # 使用driver打开极客时间登录页面
    print("正在登录网站...")
    login_url = 'https://account.geekbang.org/login'
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


def createPdfFile(sourceHtml, pdfFileName):
    """
    :param sourceHtml: 源 html 可以是文件或 html 源码字符串
    :param pdfFileName:pdf 文件
    :return:
    """

    # 配置PDF选项 避免中文乱码
    options = {
        'page-size': 'Letter',
        'encoding': "UTF-8",
        'custom-header': [
            ('Accept-Encoding', 'gzip')
        ]
    }

    if not sourceHtml.startswith('<') and os.path.exists(sourceHtml):
        htmlFile = open(sourceHtml, 'rt', encoding='utf-8')
        html = htmlFile.read()
        htmlFile.close()
    else:
        html = sourceHtml
    html = html.replace(r'background:#000', r'background:#fff')  # 黑色背景色转成白色
    if pdfkit.from_string(html, pdfFileName, options=options):
        print("PDF 已生成。  --> %s.pdf" % (pdfFileName))


def processHtml(html, tarTitle):
    """
    处理 HTML 源码，生成文件，生成 PDF
    :param html: 原始网页的 html 源码
    :param tarTitle:生成文件的标题
    :return:
    """

    # 生成干净的 html 的模板
    modHtml = "<html>%s<body>%s</body></html>"

    bs = BeautifulSoup(html, "html.parser")

    # 专栏名称
    # columnName = bs.select_one('a[class="title"]').text.strip()
    # columnName = tarTitle
    columnName = ''

    # 保存目录
    exportPath = ("R:\\%s\\" % columnName).replace("\\\\", "\\")
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

    # 用 html 生成 PDF 文件
    createPdfFile(targetHtml, exportPathPDF + tarTitle + '.pdf')


# 滚到最底端，获取完整的网页内容
def scrollDrive2Bottom(driver):
    pageHeight_orig = driver.execute_script('return document.body.scrollHeight')
    while True:
        driver.execute_script('window.scrollBy(0,50000)')
        time.sleep(3)
        pageHeight_new = driver.execute_script('return document.body.scrollHeight')

        if pageHeight_new == pageHeight_orig:
            break
        else:
            pageHeight_orig = pageHeight_new


def main():
    # 抓取成功的数量
    catchCount = 0

    # 抓取失败的列表
    errList = []

    t, f = courseList[0]
    isFile = os.path.exists(f)

    print("开始爬取专栏文章...")
    # 记录爬取文章的开始时间
    start = time.time()

    if isFile:
        for doc in courseList:
            title, fileFullName = doc
            tarTitle = re.sub('[\/:：*?"<>|]', '', title.strip()).replace('  ', ' ')

            try:
                file = open(fileFullName, 'rt', encoding='UTF-8')
                html = file.read()
                file.close()

                # 处理 HTML 源码，生成文件，生成 PDF
                processHtml(html, tarTitle)
            except:
                errList.append(title)

            catchCount += 1
            print("\n\n")
    else:

        # 定义chromedriver路径
        driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
        # 获取chrome浏览器驱动
        driver = webdriver.Chrome(executable_path=driver_path)

        if not inDebug:
            Login(driver)

        # 正式开始抓取
        for doc in courseList:
            title, url = doc
            tarTitle = re.sub('[\/:：*?"<>|]', '', title.strip()).replace('  ', ' ')

            try:
                print("正在抓取文章：" + tarTitle)
                driver.get(url)
                driver.implicitly_wait(3)

                # 滚到最底端，获取完整的网页内容
                if not inDebug or inDebug: # 有时候不滚到最底下会抓出来空白的
                    scrollDrive2Bottom(driver)

                # 处理 HTML 源码，生成文件，生成 PDF
                processHtml(driver.page_source, tarTitle)
            except:
                errList.append(title)

            # 爬一篇文章后休息几秒钟
            catchCount += 1
            time.sleep(5)
            print("\n\n")

    # 记录爬取文章的结束时间
    end = time.time()

    print("ffmpeg 下载列表  --> ffmpegDownList.txt")
    print("所有文章爬取完毕！共 %d 篇，耗时 %d 秒" % (catchCount, int(end - start)))

    if len(errList) > 0:
        print("失败的抓取：")
        for name in errList: print(name)


if __name__ == '__main__':
    main()
