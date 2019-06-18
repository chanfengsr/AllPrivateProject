import time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

# 第一个视频的网址
firstUrl = "https://time.geekbang.org/course/detail/160-84335"
firstUrl = "https://time.geekbang.org/course/detail/160-88546"

realDir = os.path.dirname(os.path.realpath(__file__))
driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'

driver = webdriver.Chrome() # executable_path=driver_path

driver.get(firstUrl)
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
