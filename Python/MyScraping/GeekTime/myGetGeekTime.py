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
        ("01 程序员如何用技术变现（上）", "https://time.geekbang.org/column/article/183")
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
