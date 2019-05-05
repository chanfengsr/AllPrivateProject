"""
用于获取视频列表
"""
import time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

# 视频课程的目录
artUrl = "https://time.geekbang.org/course/intro/153"

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

# 定义 chromedriver 路径
driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
# 获取chrome浏览器驱动
driver = webdriver.Chrome(executable_path=driver_path)

'''
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
'''

driver.get(artUrl)
driver.implicitly_wait(5)
time.sleep(3)

driver.find_element_by_class_name('course-tab-right').click()
time.sleep(1)

bs = BeautifulSoup(driver.page_source, "html.parser")
allList = bs.find("div", {"class": "table-wrap"})

# 章节
dicArtUrl = {}
for chapter in allList.find_all("div", {"class": "table-list"}):
    chapterHead = chapter.find("div", {"class": "table-header"})
    chapterHeadText = chapterHead.h3
    print(chapterHeadText.get_text().strip())

    listBody = chapter.find("div", {"class": "table-body"})
    for tableItem in chapter.find_all("div", {"class": "table-item"}):
        itemText = tableItem.find("div", {"class": "table-item-text"}).p
        artTitle = itemText.get_text().strip()
        dicArtUrl[artTitle] = ''  # 初始设为空值
        print(artTitle)

# 下面方法有问题，因此找到第一篇的地址就直接退出了
i = dicArtUrl.__len__()
while '' in dicArtUrl.values():
    for clickItem in driver.find_elements_by_class_name('table-item-text-subtitle'):
        artTitle = clickItem.text
        if artTitle in dicArtUrl.keys() and dicArtUrl[artTitle] == '':
            clickItem.click()
            driver.implicitly_wait(2)
            time.sleep(2)

            # 获取到文章 URL
            dicArtUrl[artTitle] = driver.current_url

            driver.back()
            driver.implicitly_wait(2)
            time.sleep(2)
            driver.find_element_by_class_name('course-tab-right').click()
            time.sleep(1)
            break
    break
    i -= 1
    if i <= 0:
        break

# 以上方法有问题，以下从第一篇开始往后点
driver.get(dicArtUrl[artTitle])
driver.implicitly_wait(3)
time.sleep(3)

# 文章总数
artCount = len(driver.find_element_by_class_name('video-list').find_elements_by_tag_name('li'))

listArtUrl = []
findCurLoc = False  # 找到当前网页的位置
for i in range(artCount):
    videoList = driver.find_element_by_class_name('video-list')
    for t in videoList.find_elements_by_tag_name('li'):
        if findCurLoc:  # 点击下一篇
            t.click()
            driver.implicitly_wait(1)
            time.sleep(1)
            findCurLoc = False
            break

        # print('%s : %s' % (t.text,t.get_attribute('class')))
        if t.get_attribute('class') == 'on':  # 找到当前位置了,准备点击下一篇
            findCurLoc = True
            artTitle = driver.find_element_by_class_name('vplayer').find_element_by_class_name('title').text
            artTitle = artTitle.replace('当前播放:','').strip()
            # dicArtUrl[artTitle] = driver.current_url
            listArtUrl.append((artTitle,driver.current_url))

# 完成找到所有 URL
print(repr(listArtUrl).replace("),", "),\n"))
