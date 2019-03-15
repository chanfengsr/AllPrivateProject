"""
用于获取摘要和回复
"""
import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.common.keys import Keys

inDebug = True

# 元素 1：文章原始标题
# 元素 2：网页地址或手工保存网页文件的绝对路径
listArtUrl =  [('01 | 课程内容综述', 'https://time.geekbang.org/course/detail/153-76556')]

realDir = os.path.dirname(os.path.realpath(__file__))

# 用户名、密码登录网站
def Login(driver):
    if inDebug:
        return

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

def SaveFile(artTitle, orgHtml):
    # 保存目录
    exportPath = "R:\\"

    # 生成干净的 html 的模板
    modHtml = "<html>%s<body><h3>%s</h3>%s%s</body></html>"

    fileTitle = re.sub('[\/:：*?"<>|]', '', artTitle.strip()).replace('  ', ' ')

    # 获取到网页完整内容
    bs = BeautifulSoup(orgHtml, "html.parser")

    # 只获取干净的摘要和留言 html 并保存
    [s.extract() for s in bs.find_all("script")]  # 去干净 JS
    headHtml = bs.find("head")
    contentBoxHtml = bs.find("div", {"class": "content-box"})
    commentsHtml = bs.find("div", {"class": "extra"})
    noCommentsHtml = bs.find("div", {"class": "lNgript7_1"})  # 可能过段时间会变
    if contentBoxHtml is None: contentBoxHtml = ''
    if noCommentsHtml is not None: commentsHtml = ''

    # 跳过，不输出
    if contentBoxHtml == '' and commentsHtml == '':
        return

    targetHtml = modHtml % (headHtml, artTitle, contentBoxHtml, commentsHtml)
    htmlFile = open(exportPath + fileTitle + '.html', 'w', encoding='utf-8')
    htmlFile.write(targetHtml)
    htmlFile.close()

'''
点击页面上的 “展开”
'''
def ExpTag(driver):
    # driver.findElement(By.xpath("//div[text()=\"A\"]")).click();//点击A（如果是span，就把div改为span）

    try:
        zhanK = driver.find_element_by_xpath("//span[text()=\"展开\"]")
        while zhanK is not None:
            # .send_keys(Keys.DOWN)
            zhanK.send_keys(Keys.DOWN)

            zhanK.click()

            driver.implicitly_wait(3)
            time.sleep(3)

            zhanK = driver.find_element_by_xpath("//span[text()=\"展开\"]")
    except:
        pass

t, f = listArtUrl[0]
isFile = os.path.exists(f)
errList = []

if isFile:
    # 直接提取手工保存的网页原始文件
    for doc in listArtUrl:
        title, fileName = doc
        if os.path.exists(fileName):
            try:
                f = open(fileName, 'rt', encoding='UTF-8')
                origHtml = f.read()
                f.close()
                SaveFile(title, origHtml)
                print('%s --> Done.' % (title))
            except:
                errList.append(title)
else:
    # 定义 chromedriver 路径
    driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'

    # 获取chrome浏览器驱动
    driver = webdriver.Chrome(executable_path=driver_path)

    # 调试可注释
    Login(driver)

    for doc in listArtUrl:
        title, url = doc

        print("正在抓取：" + title)
        driver.get(url)
        driver.implicitly_wait(3)
        time.sleep(3)

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

        # 点击页面上的 “展开”
        ExpTag(driver)

        try:
            SaveFile(title, driver.page_source)
            print("Done.")
        except:
            errList.append(title)

    driver.close()

if len(errList) > 0:
    print('失败的抓取：')
    for name in errList:
        print(name)
