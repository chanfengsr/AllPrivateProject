import os
import os.path
import urllib
from urllib.request import urlopen, urlretrieve, pathname2url
import hashlib
import re
import html
from bs4 import BeautifulSoup
import random
import shutil
import tempfile
import math
import time
import datetime
from selenium import webdriver
import pdfkit, time, re


def main():

    '''
    # 定义chromedriver路径
    driver_path = r'..\virtualEnv\chromedriver_2.43\chromedriver.exe'
    # 获取chrome浏览器驱动
    driver = webdriver.Chrome(executable_path=driver_path)
    # driver.get('https://time.geekbang.org/column/article/39972')
    driver.get('r:\\b.html')
    bs = BeautifulSoup(driver.page_source, "html.parser")
    '''

    # 配置PDF选项 避免中文乱码
    options = {
        'page-size': 'Letter',
        'encoding': "UTF-8",
        'custom-header': [
            ('Accept-Encoding', 'gzip')
        ]
    }


    modFile = open('GeekTime/demo.html','rt', encoding='UTF-8')
    origHtml = modFile.read()
    bs = BeautifulSoup(origHtml, "html.parser")
    [s.extract() for s in bs.find_all("script")]

    title = bs.find("h1", {"class": "article-title"}).get_text().strip()
    tarTitle = re.sub('[\/:：*?"<>|]', '', title).replace('  ', ' ')

    ffmpegList = []
    m3u8 = bs.find("audio")
    if m3u8 is not None:
        ffmpegList.append(m3u8["src"]+"\n")
        ffmpegList.append(m3u8["src"]+"\n")
        ffmpegList.append(m3u8["src"]+"\n")

    # 写 ffmpeg 下载列表
    ffmpegListFile = open('R:\\ffmpegDownList.txt', 'w', encoding='utf-8')
    # ffmpegListFile.write(repr(ffmpegList))
    ffmpegListFile.writelines(ffmpegList)
    ffmpegListFile.close()


    modHtml = "<html>%s<body>%s</body></html>"
    headHtml = bs.find("head")
    bodyDivHtml = bs.find("div", {"id": "app"})
    targetHtml = modHtml % (headHtml, bodyDivHtml)

    # Write to html
    fileObj = open('R:\\' + tarTitle + '.html', 'w', encoding='utf-8')
    fileObj.write(targetHtml)
    fileObj.close()

    pdfkit.from_string(targetHtml, 'R:\\' + tarTitle + '.pdf', options=options)

    print('Done.')


if __name__ == '__main__':
    main()
