"""
用于获取摘要和回复
"""
import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.common.keys import Keys

inDebug = True  and False

# 元素 1：文章原始标题
# 元素 2：网页地址或手工保存网页文件的绝对路径
listArtUrl = [('01 | Go语言课程介绍', 'https://time.geekbang.org/course/detail/160-84335'),
              ('02 | 内容综述', 'https://time.geekbang.org/course/detail/160-84354'),
              ('03 | Go 语言简介：历史背景、发展现状及语言特性', 'https://time.geekbang.org/course/detail/160-84355'),
              ('04 | 编写第一个Go程序', 'https://time.geekbang.org/course/detail/160-84356'),
              ('05 | 变量、常量以及与其他语言的差异', 'https://time.geekbang.org/course/detail/160-84357'),
              ('06 | 数据类型', 'https://time.geekbang.org/course/detail/160-84358'),
              ('07 | 运算符', 'https://time.geekbang.org/course/detail/160-84359'),
              ('08 | 条件和循环', 'https://time.geekbang.org/course/detail/160-84360'),
              ('09 | 数组和切片', 'https://time.geekbang.org/course/detail/160-84361'),
              ('10 | Map 声明、元素访问及遍历', 'https://time.geekbang.org/course/detail/160-84629'),
              ('11 | Map与工厂模式，在Go语言中实现Set', 'https://time.geekbang.org/course/detail/160-84630'),
              ('12 | 字符串', 'https://time.geekbang.org/course/detail/160-85348'),
              ('13 | Go 语言的函数', 'https://time.geekbang.org/course/detail/160-85350'),
              ('14 | 可变参数和 defer', 'https://time.geekbang.org/course/detail/160-85466'),
              ('15 | 行为的定义和实现', 'https://time.geekbang.org/course/detail/160-85465'),
              ('16 | Go语言的相关接口', 'https://time.geekbang.org/course/detail/160-85770'),
              ('17 | 扩展与复用', 'https://time.geekbang.org/course/detail/160-85776'),
              ('18 | 不一样的接口类型，一样的多态', 'https://time.geekbang.org/course/detail/160-85777'),
              ('19 | 编写好的错误处理', 'https://time.geekbang.org/course/detail/160-85953'),
              ('20 | panic和recover', 'https://time.geekbang.org/course/detail/160-85954'),
              ('21 | 构建可复用的模块（包）', 'https://time.geekbang.org/course/detail/160-85955'),
              ('22 | 依赖管理', 'https://time.geekbang.org/course/detail/160-85956'),
              ('23 | 协程机制', 'https://time.geekbang.org/course/detail/160-86799'),
              ('24 | 共享内存并发机制', 'https://time.geekbang.org/course/detail/160-86537'),
              ('25 | CSP并发机制', 'https://time.geekbang.org/course/detail/160-86538'),
              ('26 | 多路选择和超时', 'https://time.geekbang.org/course/detail/160-86539'),
              ('27 | channel的关闭和广播', 'https://time.geekbang.org/course/detail/160-86540'),
              ('28 | 任务的取消', 'https://time.geekbang.org/course/detail/160-85957'),
              ('29 | Context与任务取消', 'https://time.geekbang.org/course/detail/160-85958'),
              ('30 | 只运行一次', 'https://time.geekbang.org/course/detail/160-86541'),
              ('31 | 仅需任意任务完成', 'https://time.geekbang.org/course/detail/160-86544'),
              ('32 | 所有任务完成', 'https://time.geekbang.org/course/detail/160-86545'),
              ('33 | 对象池', 'https://time.geekbang.org/course/detail/160-87730'),
              ('34 | sync.pool 对象缓存', 'https://time.geekbang.org/course/detail/160-87731'),
              ('35 | 单元测试', 'https://time.geekbang.org/course/detail/160-87732'),
              ('36 | Benchmark', 'https://time.geekbang.org/course/detail/160-87733'),
              ('37 | BDD', 'https://time.geekbang.org/course/detail/160-87734'),
              ('38 | 反射编程', 'https://time.geekbang.org/course/detail/160-87797'),
              ('39 | 万能程序', 'https://time.geekbang.org/course/detail/160-88531'),
              ('40 | 不安全编程', 'https://time.geekbang.org/course/detail/160-88539'),
              ('41 | 实现pipe-filter framework', 'https://time.geekbang.org/course/detail/160-88542'),
              ('42 | 实现micro-kernel framework', 'https://time.geekbang.org/course/detail/160-88543'),
              ('43 | 内置JSON解析', 'https://time.geekbang.org/course/detail/160-88544'),
              ('44 | easyjson', 'https://time.geekbang.org/course/detail/160-88545'),
              ('45 | HTTP服务', 'https://time.geekbang.org/course/detail/160-88546')]

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


# 保存 HTML 文件
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


# 点击页面上的 “展开”
def ExpTag(driver):
    try:
        zhanKai = driver.find_element_by_xpath("//span[text()=\"展开\"]")
        while zhanKai is not None:
            # 页面滚动到指定元素
            driver.execute_script("arguments[0].scrollIntoView();", zhanKai)

            # 再往上翻一点点，否则可能会被登录 DIV 挡住
            driver.execute_script('window.scrollBy(0,-200)')

            zhanKai.click()

            driver.implicitly_wait(1)
            time.sleep(1)

            zhanKai = driver.find_element_by_xpath("//span[text()=\"展开\"]")
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
