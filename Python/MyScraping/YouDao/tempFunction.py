import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver
import requests
from urllib.request import urlopen, urlretrieve, pathname2url
from turtle import *
import GeekTime.webpage2html as web2html
from termcolor import colored

cmdList = []
f = open('r:/cp.txt', encoding = 'UTF-8')
for line in f:
    cmdList.append(line)
f.close()
for cmd in cmdList:
    print(cmd)
    os.system(cmd)
exit()


# 清洗
def clearHtml(html, clearComment):
    bs = BeautifulSoup(html, "html.parser")

    # 去掉 script
    [s.extract() for s in bs.find_all("script")]

    # 去掉 noscript
    [s.extract() for s in bs.find_all("noscript")]

    # 去掉 DIV imgzoom_pack
    [s.extract() for s in bs.find_all("div", {"class": "imgzoom_pack"})]

    # 去掉 footer
    [s.extract() for s in bs.find_all("footer")]

    # 去掉 评论
    if clearComment:
        [s.extract() for s in # 评论区
         bs.find_all("article", {"class": "src-components-CommentZone-CommentZoneNew-index__commentWrapper--1Y8Bw"})]
        [s.extract() for s in # “今日作业”
         bs.find_all("div", {"class": "src-components-CommentZone-CommentZoneNew-index__linkWrapper--A3jeo"})]
        [s.extract() for s in # 评论区
         bs.find_all("div", {"class": "luna-comment lunacomment-web"})]
        [s.extract() for s in  # 评论区
         bs.find_all("div", {"id": "lunaComment"})]

    return repr(bs)
# 清除 fullHtml 中多余的 css 打包对象
def clearDefCSSValue(html):
    suffixReg = "[^\{]*\{[^\}]*\}"
    perfixRegNodList = [".src-components-ListEmpty-index__container--3STMO:",
                        ".src-components-Article-ArticleContent-index__articleContent--TJtbr.src-components-Article-ArticleContent-index__forTeenager--3Y5pQ",
                        ".src-components-Clock-User-index__container--HznrX",
                        ".src-pages-Error-index__container--39-lj:",
                        ".audioCube.forTeenager .btn.play",
                        ".audioCube.forTeenager .btn.pause",
                        ".src-components-Calendar-index__simpleOpenUp--36XVT",
                        ".src-components-Calendar-index__linkRank--2eBgk",
                        ".src-components-Calendar-index__linkLog--3DlfR:",
                        ".src-components-Calendar-index__completeCloseUp--24XA9",
                        ".src-components-Article-index__articleMore--Nk2NZ",
                        ".src-components-ListLoading-index__loading--5w2A5",
                        ".src-pages-Article-index__commentBtnLike--1uDqJ",
                        ".src-pages-Article-index__commentBtnLikeActive--2chyr",
                        ".src-components-Clock-User-index__rankTitle--3Uk89",
                        ".src-components-Clock-User-index__logTitle--3_q0r",
                        ".src-components-Clock-User-index__logTitleHideRank--39DxK",
                        ".audioCube.normal .btn.play",
                        ".audioCube.normal .btn.pause",
                        ".audioCube.normal .control input\[type=range\]::-webkit-slider-thumb",
                        ".audioCube.forTeenager .control input\[type=range\]::-webkit-slider-thumb",
                        ".src-components-Calendar-index__signHasClock--2m1JZ",
                        ".src-components-Calendar-index__signNotClock--1-I7-",
                        ".src-components-CommentZone-CommentZoneNew-index__quizLink--3zhC1:",
                        ".src-components-CommentZone-CommentZoneNew-index__videoLink--1AYZR:",
                        ".src-components-Comment-index__deleteCommentBtn--1JF3l",
                        ".src-components-CommentZone-CommentZoneNew-index__clockLink--5SOc-:",
                        ".src-components-CommentZone-CommentZoneNew-index__missClockLink--2rcyK:"]

    for nod in perfixRegNodList:
        regExp = nod + suffixReg
        html = re.sub(regExp, '', html)

    return html

# mode con cp select=936
# 保存 fullHtml
fileNameList = ["X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 PG词根74-79/fullHtml/漫画词汇 PG词根74-79.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 PG词根80-84/fullHtml/漫画词汇 PG词根80-84.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 PG词汇85-90/fullHtml/漫画词汇 PG词汇85-90.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 RTV词根107-111/fullHtml/漫画词汇 RTV词根107-111.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 RTV词根112-115/fullHtml/漫画词汇 RTV词根112-115.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 RTV词根116-120/fullHtml/漫画词汇 RTV词根116-120.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 SU词根103-106/fullHtml/漫画词汇 SU词根103-106.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 SU词根91-97/fullHtml/漫画词汇 SU词根91-97.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 SU词根98-102/fullHtml/漫画词汇 SU词根98-102.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 核心词根10-12/fullHtml/漫画词汇 核心词根10-12.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 核心词根24-27/fullHtml/漫画词汇 核心词根24-27.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 核心词根33-37/fullHtml/漫画词汇 核心词根33-37.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 核心词根38-42/fullHtml/漫画词汇 核心词根38-42.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 核心词根43-48/fullHtml/漫画词汇 核心词根43-48.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 核心词根49-53/fullHtml/漫画词汇 核心词根49-53.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 核心词根5-9/fullHtml/漫画词汇 核心词根5-9.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 核心词根54-60/fullHtml/漫画词汇 核心词根54-60.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 次重要词根1-20/fullHtml/漫画词汇 次重要词根1-20.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 次重要词根101-120/fullHtml/漫画词汇 次重要词根101-120.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 次重要词根21-40/fullHtml/漫画词汇 次重要词根21-40.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 次重要词根41-60/fullHtml/漫画词汇 次重要词根41-60.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 次重要词根61-80/fullHtml/漫画词汇 次重要词根61-80.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇 次重要词根81-100/fullHtml/漫画词汇 次重要词根81-100.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇DEF首字母词根（156词）/fullHtml/漫画词汇DEF首字母词根（156词）.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇核心词根61-66/fullHtml/漫画词汇核心词根61-66.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇核心词根67-73/fullHtml/漫画词汇核心词根67-73.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第一次作业——后缀/fullHtml/漫画词汇第一次作业——后缀.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第七次课作业/fullHtml/漫画词汇第七次课作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第三次作业/fullHtml/漫画词汇第三次作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第九次作业/fullHtml/漫画词汇第九次作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第二次作业——前缀/fullHtml/漫画词汇第二次作业——前缀.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第五次作业/fullHtml/漫画词汇第五次作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第八次作业/fullHtml/漫画词汇第八次作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第六次课作业/fullHtml/漫画词汇第六次课作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第十一次作业/fullHtml/漫画词汇第十一次作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第十三次课作业/fullHtml/漫画词汇第十三次课作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第十二次作业/fullHtml/漫画词汇第十二次作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第十五次作业/fullHtml/漫画词汇第十五次作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第十四次课作业/fullHtml/漫画词汇第十四次课作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第十次作业/fullHtml/漫画词汇第十次作业.html",
"X:/OneDrive_SAGlobal/OneDrive - SAGlobal/temp/有道抓课/抓取的课/漫画词汇/漫画词汇第四次作业/fullHtml/漫画词汇第四次作业.html"]
errList = []
for htmlFileName in fileNameList:
    try:
        # htmlFileName =  'r:/a.html'
        fullHtml = web2html.generate(htmlFileName, comment=False, full_url=True, verbose=True)
        fullHtml = clearHtml(fullHtml, True)  # 去掉评论区
        fullHtml = clearDefCSSValue(fullHtml)  # 清除 fullHtml 中多余的 css 打包对象
        fullHtmlFile = open(htmlFileName, 'w', encoding='UTF-8')
        # fullHtmlFile = open('r:/b.html', 'w', encoding='UTF-8')
        fullHtmlFile.write(fullHtml)
        fullHtmlFile.close()
    except Exception as e:
        errList.append((htmlFileName, repr(e)))

for err in errList:
    print("%s\n%s\n" % err)