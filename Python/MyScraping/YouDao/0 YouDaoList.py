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

headersBasic = {
	"User-Agent": "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36",
	# "User-Agent": "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E) ",
	"Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
	"Accept-Encoding": "gzip, deflate",
	"Accept-Language": "zh-CN,zh;q=0.8,en;q=0.6"
}

urlPerfix = "https://ke.youdao.com/course/detail/"
session = requests.session()
fileName = r'r:\\course.txt'

subFixRng = range(50000, 26346, -1)
for i in subFixRng:
	url = urlPerfix + repr(i)
	s = session.get(url)
	bs = BeautifulSoup(s.text, "html.parser")
	title = bs.find("title").text

	if title.find("不存在") > 0 or title.find("出错") > 0:
		pass
	else:
		print(title)
		print(url)
		print()

		file = open(fileName, 'a+', encoding='UTF-8')
		file.write(title + '\r' + url + '\r\r')
		file.close()

	# time.sleep(1)
