import time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

# 视频课程的目录
artUrl = "https://time.geekbang.org/course/intro/153"  # https://time.geekbang.org/column/48
artFile = '.\\*.html'  # GeekTime\demoArtList.html

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
'''

driver.get(artUrl)
driver.implicitly_wait(5)
time.sleep(3)

driver.find_element_by_class_name('course-tab-right').click()
time.sleep(1)
clickItem = driver.find_element_by_class_name('table-item-text-subtitle')
print(clickItem.text)
clickItem.click()

driver.implicitly_wait(2)
time.sleep(2)
print(driver.current_url)
driver.back()

driver.implicitly_wait(2)
time.sleep(2)
driver.find_element_by_class_name('course-tab-right').click()
time.sleep(1)
clickItem = driver.find_element_by_class_name('table-item-text-subtitle')
print(clickItem.text)
clickItem.click()
exit()

bs = BeautifulSoup(driver.page_source, "html.parser")
allList = bs.find("div", {"class": "table-wrap"})

# 章节
for chapter in allList.find_all("div", {"class": "table-list"}):
    chapterHead = chapter.find("div", {"class": "table-header"})
    chapterHeadText = chapterHead.h3
    print(chapterHeadText.get_text().strip())

    listBody = chapter.find("div", {"class": "table-body"})
    for tableItem in chapter.find_all("div", {"class": "table-item"}):
        itemText = tableItem.find("div", {"class": "table-item-text"}).p
        print(itemText.get_text().strip())

# clickItem = driver.find_element_by_xpath(r'//*[@id="app"]/div[1]/div[6]/div[2]/div[1]/div[2]/div[3]/div[1]/p')
# print(clickItem.text())



'''
artTitle = bs.find("span", {"class": "title"}).get_text().strip()
outputList = []
for artItem in bs.find_all("div", {"class": "article-item"}):
    title = artItem.find("h2", {"class": "article-item-title"}).get_text().strip()
    url = artItem.find("a", {"class": "article-item-more-text"})["data-gk-spider-link"].strip()

    tarTitle = re.sub('[\/:：*?"<>|]', '', title.strip()).replace('  ', ' ')
    tarUrl = url.replace("/column/article/", "https://time.geekbang.org/column/article/")

    outputList.append((tarTitle, tarUrl))
    artItem.find("a", {"class": "article-item-more-text"})["href"] = tarUrl
    artItem.find("a", {"class": "article-item-more-text"})["data-gk-spider-link"] = tarUrl

print(repr(outputList).replace("),", "),\n"))

[s.extract() for s in bs.find_all("script")]  # 去干净 JS
htmlFile = open('R:\\' + artTitle + '.html', 'w', encoding='utf-8')
htmlFile.write(repr(bs))
htmlFile.close()
'''
