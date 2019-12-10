import time
import random
import shutil
import tempfile
import os
import re
import hashlib
import requests
import html
from urllib.request import urlretrieve, pathname2url
from bs4 import BeautifulSoup
from selenium import webdriver

headersBasic = {
	"User-Agent": "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36",
	# "User-Agent": "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E) ",
	"Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
	"Accept-Encoding": "gzip, deflate",
	"Accept-Language": "zh-CN,zh;q=0.8,en;q=0.6"
}

urlPerfix = "https://c.youdao.com/article/index.html?pid="

fileName = r'r:\\course.txt'

webBrowser = webdriver.PhantomJS('r:\\phantomjs.exe')

# 当前到存在的 40000
subFixRng = range(16096, 40000, 1)
for i in subFixRng:
	url = urlPerfix + repr(i)
	webBrowser.get(url)
	bs = BeautifulSoup(webBrowser.page_source, "html.parser")
	title = bs.find("title").text

	if title.strip() != '':
		print(title)
		print(url)
		print()

	if not (title.strip() == ''
			or title.find("登录-有道精品课") > -1
			or title.find("不存在") > -1
			or title.find("出错") > -1
			or title.find("undefined") > -1):
		file = open(fileName, 'a+', encoding='UTF-8')
		file.write(title + '\r' + url + '\r\r')
		file.close()

	# time.sleep(1)

webBrowser.quit()

print('All done.')