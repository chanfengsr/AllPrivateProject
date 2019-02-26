import time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

artUrl = "https://time.geekbang.org/column/112"  # https://time.geekbang.org/column/48
artFile = '.\\demoArtList.html'  # GeekTime\demoArtList.html

artUrl = ""
if artUrl == "":  # 使用已保存的网页解析
    listFile = open(artFile, 'rt', encoding='UTF-8')
    origHtml = listFile.read()
    bs = BeautifulSoup(origHtml, "html.parser")
else:  # 直接解析原始 URL

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

    driver.get(artUrl)
    ordTextCtrl = driver.find_element_by_class_name("filter-control-text")
    if ordTextCtrl.text == "倒序":
        ordTextCtrl.click()
        time.sleep(2)

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

    bs = BeautifulSoup(driver.page_source, "html.parser")
    driver.close()

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
