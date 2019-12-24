import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver
import requests
from urllib.request import urlopen, urlretrieve, pathname2url
from turtle import *
import GeekTime.webpage2html as web2html
from termcolor import colored


driverFileName = os.environ.get("Project").replace('\\', '/') + '/AllInGitHub/CommonDriver/ChromeDriver/chromedriver.exe'
print(driverFileName)
print(os.path.exists(driverFileName))
exit()

print(os.environ.get("Project")) # 系统 Path
print(os.getcwd()) # 当前目录
exit()

os.system('ffmpeg -i http://ydschool-video.nosdn.127.net/156747737223901+E38-1%C2%B7+Transformers+Opening+Scene%E3%80%8A%E5%8F%98%E5%BD%A2%E9%87%91%E5%88%9A%E3%80%8B%E5%BC%80%E5%9C%BA%EF%BC%88%E6%96%87%E6%9C%AC%E7%B2%BE%E8%AE%B2%EF%BC%89.mp3 -vcodec copy -acodec copy "R:\\Day 38文本精讲 Transformers Opening Scene （《变形金刚》开场）\\audio1.mp3"')
exit()

str = 'http://ydschool-video.nosdn.127.net/156747737223901+E38-1%C2%B7+Transformers+Opening+Scene%E3%80%8A%E5%8F%98%E5%BD%A2%E9%87%91%E5%88%9A%E3%80%8B%E5%BC%80%E5%9C%BA%EF%BC%88%E6%96%87%E6%9C%AC%E7%B2%BE%E8%AE%B2%EF%BC%89.mp3'
print(str.rfind('.'))
print(len(str))
print(str[str.rfind('.'):])
exit()

print('Origin color')
print(colored('grey', 'grey'))
print(colored('red', 'red'))
print(colored('green', 'green'))
print(colored('yellow', 'yellow'))
print(colored('blue', 'blue'))
print(colored('magenta', 'magenta'))
print(colored('cyan', 'cyan'))
print(colored('white', 'white'))
exit()

print('Origin color')
colors = ['grey', 'red', 'green', 'yellow', 'blue', 'magenta', 'cyan', 'white']
for color in colors:
    web2html.log(color, color)
exit()

# 替换标签图标路径
htmlPath = r'r:\Html'
i = 0
if not os.path.exists(htmlPath):
    print('%s not exists.' % (htmlPath))
    exit()
fileList = [i for i in os.listdir(htmlPath) if
            os.path.isfile(os.path.join(htmlPath, i)) and os.path.splitext(i)[1].lower() == '.html']
for file in fileList:
    htmlFileName = os.path.join(htmlPath, file)
    htmlFile = open(htmlFileName, 'r', encoding='UTF-8')
    html = htmlFile.read()
    htmlFile.close()

    html = html.replace('="//static001.', '="https://static001.')  # 替换标签图标路径
    htmlFile = open(htmlFileName, 'w', encoding='UTF-8')
    htmlFile.write(html)
    htmlFile.close()
    i += 1

print('%s Done.' % i)
exit()

forward(100)
left(120)
forward(100)
left(120)
forward(100)
time.sleep(3)
exit()

realDir = os.path.dirname(os.path.realpath(__file__))
driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
driver = webdriver.Chrome()  # executable_path=driver_path
driver.get("https://www.baidu.com/")
driver.implicitly_wait(3)
time.sleep(3)

# driver.execute_script('document.getElementById(“kw”).value="Microsoft"')
driver.find_element_by_id('kw').send_keys('SAG')
driver.find_element_by_id('su').click()

time.sleep(5)
driver.close()
exit()


# 方法一：os.listdir
# 遍历filepath下所有文件，包括子目录
def gci(filepath):
    files = os.listdir(filepath)
    for fi in files:
        fi_d = os.path.join(filepath, fi)
        if os.path.isdir(fi_d):
            gci(fi_d)
        else:
            print(os.path.join(filepath, fi_d))


# 方法二：os.walk
# for fpathe,dirs,fs in os.walk('r:\\'):
#   for f in fs:
#     print (os.path.join(fpathe,f))

h = [i for i in os.listdir('r:\\') if
     os.path.isfile(os.path.join('r:\\', i)) and os.path.splitext(i)[1].lower() == '.html']
print(h)
for i in os.listdir('r:\\'):
    fullName = os.path.join('r:\\', i)
    if os.path.isfile(fullName) and os.path.splitext(i)[1].lower() == '.html':
        print(i)

exit()

# 配置PDF选项 避免中文乱码
options = {
    'page-size': 'Letter',
    'encoding': "UTF-8",
    'custom-header': [
        ('Accept-Encoding', 'gzip')
    ]
}
fileName = r"r:\a.pdf"
file = open(r'r:\a.html', 'rt', encoding='utf-8')
origHtml = file.read()
file.close()
origHtml = origHtml.replace(r'background:#000', r'background:#fff')
pdfkit.from_string(origHtml, fileName, options=options)
print('Done')
exit()

f = open('r:\\1.py', 'rt', encoding='UTF-8')
ers = f.read()
f.close()
ers = ers.replace(chr(8203), '')
for s in ers:
    print("%s-->%s" % (s, ord(s)))
print(ers)
exit()

url = "https://leetcode-cn.com/problems/two-sum/"
html = urlopen(url)
bs = BeautifulSoup(html, "html.parser")
print(bs)
exit()

# 生成干净的 html 的模板
modHtml = "<html>%s<body><h3>03 | 如何计算算法的复杂度</h3>%s%s</body></html>"

f = open('r:\\03.html', 'rt', encoding='UTF-8')
origHtml = f.read()

# 获取到网页完整内容
bs = BeautifulSoup(origHtml, "html.parser")

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
    exit()

targetHtml = modHtml % (headHtml, contentBoxHtml, commentsHtml)
htmlFile = open('r:\\03 如何计算算法的复杂度.html', 'w', encoding='utf-8')
htmlFile.write(targetHtml)
htmlFile.close()
print("Done.")
exit()

dicArtUrl = {}
# 定义 chromedriver 路径
realDir = os.path.dirname(os.path.realpath(__file__))
# driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
driver_path = realDir + r'\..\..\virtualEnv\phantomjs-2.1.1-windows\bin\phantomjs.exe'

#
setHeadScript = "localStorage.setItem('profiles', JSON.stringify([{                " + \
                "  title: 'Selenium', hideComment: true, appendMode: '',           " + \
                "  headers: [                                                      " + \
                "    {enabled: true, name: 'User-Agent', value: 'Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.96 Safari/537.36', comment: ''}  " + \
                "  ],                                                              " + \
                "  respHeaders: [],                                                " + \
                "  filters: []                                                     " + \
                "}]));                                                             "

# 获取chrome浏览器驱动
driver = webdriver.PhantomJS(driver_path)
driver.execute_script(setHeadScript)
driver.get(r'https://time.geekbang.org/course/detail/130-41531')
driver.implicitly_wait(2)
time.sleep(2)

print(driver.page_source)
print('Done.')

url = r'https://time.geekbang.org/course/detail/130-41531'

headersBasic = {
    "User-Agent": "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.96 Safari/537.36",
    # "User-Agent": "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E) ",
    "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
    "Accept-Encoding": "gzip, deflate",
    "Accept-Language": "zh-CN,zh;q=0.8,en;q=0.6"
}
