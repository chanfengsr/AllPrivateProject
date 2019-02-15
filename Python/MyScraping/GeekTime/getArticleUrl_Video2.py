"""
用于获取摘要和回复
"""
import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

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

realDir = os.path.dirname(os.path.realpath(__file__))

# 用户名、密码登录网站
def Login(driver):
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
    commentsHtml = bs.find("div", {"class": "comments"})
    noCommentsHtml = bs.find("div", {"class": "no-comment"})
    if contentBoxHtml is None: contentBoxHtml = ''
    if commentsHtml is None or noCommentsHtml is not None: commentsHtml = ''

    # 跳过，不输出
    if contentBoxHtml == '' and commentsHtml == '':
        return

    targetHtml = modHtml % (headHtml, artTitle, contentBoxHtml, commentsHtml)
    htmlFile = open(exportPath + fileTitle + '.html', 'w', encoding='utf-8')
    htmlFile.write(targetHtml)
    htmlFile.close()

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
    # Login(driver)

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

        try:
            SaveFile(title, driver.page_source)
            print("Done.")
        except:
            errList.append(title)

if len(errList) > 0:
    print('失败的抓取：')
    for name in errList:
        print(name)
