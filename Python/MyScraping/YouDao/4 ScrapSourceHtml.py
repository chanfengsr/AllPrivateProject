import os
import re
import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

courseListFile = 'R:\\21天英语口语实战蜕变营·音频轻学.txt'

realDir = os.path.dirname(os.path.realpath(__file__))

def getDriver():
    # 定义chromedriver路径
    driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
    driver_path = 'r:\\chromedriver.exe'

    # 获取chrome浏览器驱动
    return webdriver.Chrome(executable_path=driver_path)  # executable_path=driver_path

# 读取文件 -> (title, url)
def file2List(fileName):
    ret = []
    title, url = '', ''

    if os.path.exists(fileName) and os.path.isfile(fileName):
        f = open(fileName, encoding = 'UTF-8')
        for line in f:
            line = line.strip()
            if line.__len__() > 0:
                if line.startswith('https') and title.__len__() > 0:
                    url = line
                    ret.append((title, url))
                else:
                    title = line

    return ret

# 点击页面上的 “展开”
def ExpTag(driver):
    try:
        # zhanKai = driver.find_element_by_xpath("//span[text()=\"展开\"]")
        zhanKai = driver.find_element_by_xpath("//div[text()=\"展开全文\"]")

        if zhanKai is not None:
            zhanKai.click()
    except:
        pass


# 滚到最底端，获取完整的网页内容
def scrollDrive2Bottom(driver):
    pass

def processHtml(html, tarTitle):
    """
    处理 HTML 源码，生成文件，生成 PDF
    :param html: 原始网页的 html 源码
    :param tarTitle:生成文件的标题
    :return:
    """
    pass

def main():
    # 抓取成功的数量
    catchCount = 0

    # 抓取失败的列表
    errList = []

    driver = getDriver()

    courseList = file2List(courseListFile)

    print("开始爬取专栏文章...")
    # 记录爬取文章的开始时间
    start = time.time()

    for title, url in courseList:
        tarTitle = re.sub('[\/:：*?"<>|]', '', title.strip()).replace('  ', ' ')

        try:
            print("正在抓取文章：" + tarTitle)
            driver.get(url)
            driver.implicitly_wait(5)
            time.sleep(3)

            # 点击页面上的 “展开”
            ExpTag(driver)

            # 滚到最底端，获取完整的网页内容
            scrollDrive2Bottom(driver)

            # 处理 HTML 源码，生成文件，生成 PDF
            processHtml(driver.page_source, tarTitle)
        except:
            errList.append(title)

        # 爬一篇文章后休息几秒钟
        catchCount += 1
        time.sleep(1)
        print("\n\n")

        # todo Delete
        break

    # 记录爬取文章的结束时间
    end = time.time()

    print("所有文章爬取完毕！共 %d 篇，耗时 %d 秒" % (catchCount, int(end - start)))

    if len(errList) > 0:
        print("失败的抓取：")
        for name in errList: print(name)

if __name__ == '__main__':
    main()