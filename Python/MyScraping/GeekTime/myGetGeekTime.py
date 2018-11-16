from selenium import webdriver
import pdfkit, time, re
from bs4 import BeautifulSoup

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
        ("02 程序员如何用技术变现（下）", "https://time.geekbang.org/column/article/185")
    ]


def main():

    # 配置PDF选项 避免中文乱码
    options = {
        'page-size': 'Letter',
        'encoding': "UTF-8",
        'custom-header': [
            ('Accept-Encoding', 'gzip')
        ]
    }
    # 定义chromedriver路径
    driver_path = r'..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
    # 获取chrome浏览器驱动
    driver = webdriver.Chrome(executable_path=driver_path)
    # 使用driver打开极客时间登录页面
    login_url = 'https://account.geekbang.org/signin'
    driver.get(login_url)

    # 输入手机号
    driver.find_element_by_class_name("nw-input").send_keys("18576614172")
    # 输入密码
    driver.find_element_by_class_name("input").send_keys("KevinWong#Libra@1995")
    # 点击登录按钮
    driver.find_element_by_class_name("mybtn").click()
    # 为了使ajax加载完成 此处使用隐式等待让程序等待5秒钟
    driver.implicitly_wait(5)

    print("正在爬取专栏文章，并生成PDF文件...")
    # 记录爬取文章的开始时间
    start = time.time()

    # 正式开始抓取
    for doc in courseList:
        title, url = doc
        tarTitle = re.sub('[\/:：*?"<>|]', '', title).replace('  ', ' ')
        driver.get(url)

        # 滚到最底端，获取完整的网页内容
        pageHeight_orig = driver.execute_script('return document.body.scrollHeight')
        while True:
            driver.execute_script('window.scrollBy(0,10000)')
            time.sleep(3)
            pageHeight_new = driver.execute_script('return document.body.scrollHeight')

            if pageHeight_new == pageHeight_orig:
                break
            else:
                pageHeight_orig = pageHeight_new

        bs = BeautifulSoup(driver.page_source, "html.parser")


    # 记录爬取文章的结束时间
    end = time.time()
    print("所有文章爬取完毕！共耗时" + str(int(end - start)) + "秒")


if __name__ == '__main__':
    main()
