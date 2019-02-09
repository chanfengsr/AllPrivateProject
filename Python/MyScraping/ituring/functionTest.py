# from MyScraping.ituring.ScrapITuring import ScrapITuring
from ituring.ScrapITuring import ScrapITuring
import os
import hashlib
import re
import html
from bs4 import BeautifulSoup
import urllib
from urllib.request import urlretrieve, pathname2url
from selenium import webdriver
import time


artUrlList = {'Name': 'Zara', 'Age': 7, 'Class': 'First'}
artUrlList['School'] = "RUNOOB"
print(artUrlList)
exit()

st = ScrapITuring("深入理解C#（第3版）", True)
html = st.ScrapOrigHtml("http://www.ituring.com.cn/article/72365")
outFile = open("r:\\LINQ简介_orig.html", 'wt', encoding = 'UTF-8')
outFile.write(html)
outFile.close()
print("done.")
exit()

driver = webdriver.PhantomJS('.\\phantomjs.exe')
driver.get("///R:/LINQ%E7%AE%80%E4%BB%8B_orig.html")
time.sleep(2)
# print(driver.find_element_by_id('content').text)
print(driver.page_source)
driver.close()
driver.quit()
exit()


st = ScrapITuring("深入理解C#（第3版）", True)
exampleHtml = open('ExampleOrigHtml.html', 'rt', encoding = 'UTF-8')
html = exampleHtml.read()
exampleHtml.close()
st.webpageHtml = html
# st.ScrapWebpage2File("(046)  5.5　匿名方法中的捕获变量","", True)

# html = st.ScrapHtml("http://www.ituring.com.cn/article/72605")

print(st.FormatHtml(html))
# print(html)
