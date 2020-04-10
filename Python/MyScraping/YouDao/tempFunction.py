import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver
import requests
from urllib.request import urlopen, urlretrieve, pathname2url
from turtle import *
import GeekTime.webpage2html as web2html
from termcolor import colored


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
# mode con cp select=65001
# chcp 65001 就是换成UTF-8代码页
# chcp 936 可以换回默认的GBK
# chcp 437 是美国英语

# 保存 fullHtml
fileNameList = ["X:/抓取的课/死磕团思维导图/死磕团思维导图  No.3-5 - V类词串记忆树旋转与空/fullHtml/死磕团思维导图  No.3-5 - V类词串记忆树旋转与空.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 C类词串攻坚战更多的包容与环绕（2）/fullHtml/死磕团思维导图 C类词串攻坚战更多的包容与环绕（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.10 - R类词串记忆树从绽放到回归/fullHtml/死磕团思维导图 No.10 - R类词串记忆树从绽放到回归.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.10-B类词串B类词的延伸/fullHtml/死磕团思维导图 No.10-B类词串B类词的延伸.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.11- R类词串记忆树回归的发散/fullHtml/死磕团思维导图 No.11- R类词串记忆树回归的发散.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.12 - C类词串包容一切的C (1)/fullHtml/死磕团思维导图 No.12 - C类词串包容一切的C (1).html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.12 - R类词串记忆树其它R词/fullHtml/死磕团思维导图 No.12 - R类词串记忆树其它R词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.13 - C类词串包容一切的C(2)/fullHtml/死磕团思维导图 No.13 - C类词串包容一切的C(2).html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.13 - C类词串记忆树包容一切的C（1）/fullHtml/死磕团思维导图 No.13 - C类词串记忆树包容一切的C（1）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.14 - C类词串记忆树包容一切的C（2）/fullHtml/死磕团思维导图 No.14 - C类词串记忆树包容一切的C（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.14-C类词串从包容到覆盖/fullHtml/死磕团思维导图 No.14-C类词串从包容到覆盖.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.15 - C类词串从包容到中心/fullHtml/死磕团思维导图 No.15 - C类词串从包容到中心.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.15 - C类词串记忆树从包容到覆盖/fullHtml/死磕团思维导图 No.15 - C类词串记忆树从包容到覆盖.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.16 - C类词串攻坚战从co到com、con（1）/fullHtml/死磕团思维导图 No.16 - C类词串攻坚战从co到com、con（1）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.16 - C类词串记忆树从包容到中心/fullHtml/死磕团思维导图 No.16 - C类词串记忆树从包容到中心.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.17 - A类词串记忆树ab-远离的逻辑/fullHtml/死磕团思维导图 No.17 - A类词串记忆树ab-远离的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.17 - C类词串更多的包容与环绕/fullHtml/死磕团思维导图 No.17 - C类词串更多的包容与环绕.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.18 - A类词串记忆树ac的逻辑/fullHtml/死磕团思维导图 No.18 - A类词串记忆树ac的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.18 - C类词串更多的包容与环绕 (2)/fullHtml/死磕团思维导图 No.18 - C类词串更多的包容与环绕 (2).html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.19 - A类词串记忆树ad-靠近的逻辑/fullHtml/死磕团思维导图 No.19 - A类词串记忆树ad-靠近的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2 - A类词串ab-远离的逻辑/fullHtml/死磕团思维导图 No.2 - A类词串ab-远离的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2 - P类词串记忆树pro- 和pre-/fullHtml/死磕团思维导图 No.2 - P类词串记忆树pro- 和pre-..html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-1 - C类词串攻坚战从co到com、con/fullHtml/死磕团思维导图 No.2-1 - C类词串攻坚战从co到com、con.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-1 - D类词串记忆树dis-/fullHtml/死磕团思维导图 No.2-1 - D类词串记忆树dis-.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-10 - F类词串记忆树F逻辑图谱/fullHtml/死磕团思维导图 No.2-10 - F类词串记忆树F逻辑图谱.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-11 - F类词串记忆树从fess到fort/fullHtml/死磕团思维导图 No.2-11 - F类词串记忆树从fess到fort.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-12 - F类词串记忆树F图谱逻辑延伸/fullHtml/死磕团思维导图 No.2-12 - F类词串记忆树F图谱逻辑延伸.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-12 - F类词串记忆树F逻辑图谱/fullHtml/死磕团思维导图 No.2-12 - F类词串记忆树F逻辑图谱.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-14 - F类词串记忆树从fort到fess/fullHtml/死磕团思维导图 No.2-14 - F类词串记忆树从fort到fess.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-14 - G类词的逻辑（1）/fullHtml/死磕团思维导图 No.2-14 - G类词的逻辑（1）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-15 - G类词的逻辑（2）/fullHtml/死磕团思维导图 No.2-15 - G类词的逻辑（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-16 - F类词串记忆树F图谱逻辑延伸/fullHtml/死磕团思维导图 No.2-16 - F类词串记忆树F图谱逻辑延伸.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-17 - H类词串记忆树H逻辑起源探秘/fullHtml/死磕团思维导图 No.2-17 - H类词串记忆树H逻辑起源探秘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-18 - E类词延伸从E到En/fullHtml/死磕团思维导图 No.2-18 - E类词延伸从E到En.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-18 - H类词串记忆树从向上到居住/fullHtml/死磕团思维导图 No.2-18 - H类词串记忆树从向上到居住.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-19 - E类词延伸常用高阶E类词/fullHtml/死磕团思维导图 No.2-19 - E类词延伸常用高阶E类词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-19 - H类词串记忆树抽象的高/fullHtml/死磕团思维导图 No.2-19 - H类词串记忆树抽象的高.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 no.2-2 - C类词串攻坚战更多的包容与环绕/fullHtml/死磕团思维导图 no.2-2 - C类词串攻坚战更多的包容与环绕.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-2 - D类词串记忆树de-/fullHtml/死磕团思维导图 No.2-2 - D类词串记忆树de-.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-21 - L类词串记忆树线条之美说起/fullHtml/死磕团思维导图 No.2-21 - L类词串记忆树线条之美说起.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-22 - L类词串记忆树其他L词/fullHtml/死磕团思维导图 No.2-22 - L类词串记忆树其他L词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-25 - R类词串记忆树进阶的R词/fullHtml/死磕团思维导图 No.2-25 - R类词串记忆树进阶的R词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-5 - E类词串记忆树ex-向外和出去（1）/fullHtml/死磕团思维导图 No.2-5 - E类词串记忆树ex-向外和出去（1）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-6 - E类词串记忆树ex-向外和出去（2）/fullHtml/死磕团思维导图 No.2-6 - E类词串记忆树ex-向外和出去（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-7 - E类词串记忆树en-产生力量/fullHtml/死磕团思维导图 No.2-7 - E类词串记忆树en-产生力量.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-8 - E类词串攻坚战/fullHtml/死磕团思维导图 No.2-8 - E类词串攻坚战.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.2-9 - M类词串记忆树M构词初体验/fullHtml/死磕团思维导图 No.2-9 - M类词串记忆树M构词初体验.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.20 - H类词串记忆树H逻辑起源探秘/fullHtml/死磕团思维导图 No.20 - H类词串记忆树H逻辑起源探秘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.21 - H类词串记忆树从向上到居住/fullHtml/死磕团思维导图 No.21 - H类词串记忆树从向上到居住.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.22 - T类词串记忆树T逻辑起源探秘/fullHtml/死磕团思维导图 No.22 - T类词串记忆树T逻辑起源探秘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.23 - T类词串记忆树从过程到tent、tran、tract/fullHtml/死磕团思维导图 No.23 - T类词串记忆树从过程到tent、tran、tract.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.24 - T类词串记忆树ta和te的逻辑/fullHtml/死磕团思维导图 No.24 - T类词串记忆树ta和te的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.25 - T类词串记忆树关于time 与过程的扩张/fullHtml/死磕团思维导图 No.25 - T类词串记忆树关于time 与过程的扩张.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.26 - E类词串记忆树从e到ex/fullHtml/死磕团思维导图 No.26 - E类词串记忆树从e到ex.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.27 - E类词串记忆树从ex到en/fullHtml/死磕团思维导图 No.27 - E类词串记忆树从ex到en.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3 - A类词串ac的逻辑/fullHtml/死磕团思维导图 No.3 - A类词串ac的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3 - P类词串记忆树pose的逻辑/fullHtml/死磕团思维导图 No.3 - P类词串记忆树pose的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-1 - I类词记忆树前缀im/fullHtml/死磕团思维导图 No.3-1 - I类词记忆树前缀im.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-1 - L类词串记忆树L类词惯用法/fullHtml/死磕团思维导图 No.3-1 - L类词串记忆树L类词惯用法.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-10 - L类词串记忆树线条逻辑的延伸/fullHtml/死磕团思维导图 No.3-10 - L类词串记忆树线条逻辑的延伸.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-11 - L类词复盘/fullHtml/死磕团思维导图 No.3-11 - L类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-12 - M类词串记忆树M构词初体验/fullHtml/死磕团思维导图 No.3-12 - M类词串记忆树M构词初体验.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-13 - M类词串记忆树M类词汇进阶/fullHtml/死磕团思维导图 No.3-13 - M类词串记忆树M类词汇进阶.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-14 - M类词复盘/fullHtml/死磕团思维导图 No.3-14 - M类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-16 - N类词串记忆树/fullHtml/死磕团思维导图 No.3-16 - N类词串记忆树.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-17 - N类词复盘/fullHtml/死磕团思维导图 No.3-17 - N类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-2 - B类词串记忆树B的逻辑初探/fullHtml/死磕团思维导图 No.3-2 - B类词串记忆树B的逻辑初探.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-2 - I类词记忆树前缀il、前缀in/fullHtml/死磕团思维导图 No.3-2 - I类词记忆树前缀il、前缀in.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-21 - I类词记忆树il、in、ir、im词根/fullHtml/死磕团思维导图 No.3-21 - I类词记忆树il、in、ir、im词根.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-3 - I类词复盘/fullHtml/死磕团思维导图 No.3-3 - I类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-30 - B类词串记忆树进击的木头/fullHtml/死磕团思维导图 No.3-30 - B类词串记忆树进击的木头.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-4 -J类词串记忆树J词逻辑初探/fullHtml/死磕团思维导图 No.3-4 -J类词串记忆树J词逻辑初探.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-5 -J类词串记忆树-ject- 和 -ju-/fullHtml/死磕团思维导图 No.3-5 -J类词串记忆树-ject- 和 -ju-.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-6 - V类词串记忆树特辑《V字仇杀队》/fullHtml/死磕团思维导图 No.3-6 - V类词串记忆树特辑《V字仇杀队》.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-6 -J类词串记忆树 其他J类词/fullHtml/死磕团思维导图 No.3-6 -J类词串记忆树 其他J类词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-7 - J类词复盘/fullHtml/死磕团思维导图 No.3-7 - J类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-8 - L类词串记忆树线条之美说起（1）/fullHtml/死磕团思维导图 No.3-8 - L类词串记忆树线条之美说起（1）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.3-9 - L类词串记忆树线条之美说起（2）/fullHtml/死磕团思维导图 No.3-9 - L类词串记忆树线条之美说起（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4 - A类词串ad-靠近的逻辑/fullHtml/死磕团思维导图 No.4 - A类词串ad-靠近的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4 - P类词串记忆树其他P词（1）/fullHtml/死磕团思维导图 No.4 - P类词串记忆树其他P词（1）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-1 - B类词串记忆树B类词的延伸/fullHtml/死磕团思维导图 No.4-1 - B类词串记忆树B类词的延伸.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-1 - O类词串记忆树/fullHtml/死磕团思维导图 No.4-1 - O类词串记忆树.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-10 - R类词串记忆树R的核心逻辑/fullHtml/死磕团思维导图 No.4-10 - R类词串记忆树R的核心逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-10 - 词汇巡礼L及M类词/fullHtml/死磕团思维导图 No.4-10 - 词汇巡礼L及M类词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-11 - R类词串记忆树R类词汇进阶/fullHtml/死磕团思维导图 No.4-11 - R类词串记忆树R类词汇进阶.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-12 - R类词串记忆树re-/fullHtml/死磕团思维导图 No.4-12 - R类词串记忆树re-.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-13 - R类词串记忆树其他R词/fullHtml/死磕团思维导图 No.4-13 - R类词串记忆树其他R词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-13 - 词汇巡礼F类词回顾/fullHtml/死磕团思维导图 No.4-13 - 词汇巡礼F类词回顾.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-14 - R类词复盘/fullHtml/死磕团思维导图 No.4-14 - R类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-15 - S类词串记忆树str-/fullHtml/死磕团思维导图 No.4-15 - S类词串记忆树str-.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-16 - S类词串记忆树st-（1）/fullHtml/死磕团思维导图 No.4-16 - S类词串记忆树st-（1）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-17 - S类词串记忆树st-（2）/fullHtml/死磕团思维导图 No.4-17 - S类词串记忆树st-（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-18 - S类词串记忆树sc-/fullHtml/死磕团思维导图 No.4-18 - S类词串记忆树sc-.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-19 - S类词串记忆树se-和其他S词/fullHtml/死磕团思维导图 No.4-19 - S类词串记忆树se-和其他S词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-2 - M类词串记忆树M类词汇进阶/fullHtml/死磕团思维导图 No.4-2 - M类词串记忆树M类词汇进阶.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-2 - O类词复盘/fullHtml/死磕团思维导图 No.4-2 - O类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-20 - S类词复盘/fullHtml/死磕团思维导图 No.4-20 - S类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-23 - 词汇巡礼曲折的Z和im类词/fullHtml/死磕团思维导图 No.4-23 - 词汇巡礼曲折的Z和im类词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-24 - 词汇巡礼前缀im类词/fullHtml/死磕团思维导图 No.4-24 - 词汇巡礼前缀im类词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-27 - W类词串记忆树曲折扭曲的W/fullHtml/死磕团思维导图 No.4-27 - W类词串记忆树曲折扭曲的W.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-28 - W类词串记忆树曲折扭曲的W（2）/fullHtml/死磕团思维导图 No.4-28 - W类词串记忆树曲折扭曲的W（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-3 - P类词串记忆树pro- 和pre-/fullHtml/死磕团思维导图 No.4-3 - P类词串记忆树pro- 和pre-.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-4 - P类词串记忆树-pose/fullHtml/死磕团思维导图 No.4-4 - P类词串记忆树-pose.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-5 - P类词串记忆树per-和pe-/fullHtml/死磕团思维导图 No.4-5 - P类词串记忆树per-和pe-.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-6 - P类词串记忆树其他P词（1）/fullHtml/死磕团思维导图 No.4-6 - P类词串记忆树其他P词（1）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-7 - P类词串记忆树其他P词（2）/fullHtml/死磕团思维导图 No.4-7 - P类词串记忆树其他P词（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-8 - P类词串记忆树其他P词（3）/fullHtml/死磕团思维导图 No.4-8 - P类词串记忆树其他P词（3）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-9 - P类词复盘/fullHtml/死磕团思维导图 No.4-9 - P类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.4-9 - 词汇巡礼（F类词）/fullHtml/死磕团思维导图 No.4-9 - 词汇巡礼（F类词）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5 - A类词串词根ag&al/fullHtml/死磕团思维导图 No.5 - A类词串词根ag&al.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5 - P类词串记忆树其他P词（2）/fullHtml/死磕团思维导图 No.5 - P类词串记忆树其他P词（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-10 - T类词串记忆树time的延伸及其他T词/fullHtml/死磕团思维导图 No.5-10 - T类词串记忆树time的延伸及其他T词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-11 - T类词复盘/fullHtml/死磕团思维导图 No.5-11 - T类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-12 - V类词串记忆树旋转与空/fullHtml/死磕团思维导图 No.5-12 - V类词串记忆树旋转与空.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-13 - V类词串记忆树看/fullHtml/死磕团思维导图 No.5-13 - V类词串记忆树看.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-14 - V类词复盘/fullHtml/死磕团思维导图 No.5-14 - V类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-15 - W类词串记忆树曲折扭曲的W（1）/fullHtml/死磕团思维导图 No.5-15 - W类词串记忆树曲折扭曲的W（1）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-16 - A类词和ob的逻辑/fullHtml/死磕团思维导图 No.5-16 - A类词和ob的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-16 - W类词串记忆树曲折扭曲的W（2）/fullHtml/死磕团思维导图 No.5-16 - W类词串记忆树曲折扭曲的W（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-17 - W类词复盘/fullHtml/死磕团思维导图 No.5-17 - W类词复盘.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-17 - 词汇巡礼N类词的延伸&O类词的逻辑/fullHtml/死磕团思维导图 No.5-17 - 词汇巡礼N类词的延伸&O类词的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-18 - Z类词串记忆树之字形的Z/fullHtml/死磕团思维导图 No.5-18 - Z类词串记忆树之字形的Z.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-19 - 词汇巡礼C类、N类、S类词的逻辑延伸/fullHtml/死磕团思维导图 No.5-19 - 词汇巡礼C类、N类、S类词的逻辑延伸.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-22 - G类词的逻辑（1）/fullHtml/死磕团思维导图 No.5-22 - G类词的逻辑（1）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-23 - 词汇巡礼G类词的逻辑（2）/fullHtml/死磕团思维导图 No.5-23 - 词汇巡礼G类词的逻辑（2）.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-3 - 词汇巡礼R类词、词根sc/fullHtml/死磕团思维导图 No.5-3 - 词汇巡礼R类词、词根sc.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-4 - 词汇巡礼str类词/fullHtml/死磕团思维导图 No.5-4 - 词汇巡礼str类词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-7 - T类词串记忆树T的逻辑起源/fullHtml/死磕团思维导图 No.5-7 - T类词串记忆树T的逻辑起源.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-8 - T类词串记忆树常见T词词根/fullHtml/死磕团思维导图 No.5-8 - T类词串记忆树常见T词词根.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.5-9 - T类词串记忆树ta-和te-/fullHtml/死磕团思维导图 No.5-9 - T类词串记忆树ta-和te-.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.6 - A类词串词根am及其他A类词/fullHtml/死磕团思维导图 No.6 - A类词串词根am及其他A类词.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.6 - J类词串记忆树扔 - 从jab说起/fullHtml/死磕团思维导图 No.6 - J类词串记忆树扔 - 从jab说起.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.7.J类词串记忆树从扔到判断 - ject的深入发展/fullHtml/死磕团思维导图 No.7.J类词串记忆树从扔到判断 - ject的深入发展.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.8 - B类词串B的逻辑初探/fullHtml/死磕团思维导图 No.8 - B类词串B的逻辑初探.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.8 - J类词串记忆树ju的逻辑/fullHtml/死磕团思维导图 No.8 - J类词串记忆树ju的逻辑.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.9 - B类词串进击的木头/fullHtml/死磕团思维导图 No.9 - B类词串进击的木头.html",
"X:/抓取的课/死磕团思维导图/死磕团思维导图 No.9 - R类词串记忆树绽放之美 - R核心逻辑/fullHtml/死磕团思维导图 No.9 - R类词串记忆树绽放之美 - R核心逻辑.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 NO.10.R类词串记忆树从绽放到回归/fullHtml/死磕团 NO.10.R类词串记忆树从绽放到回归.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.11 - R类词串记忆树回归的发散/fullHtml/死磕团 No.11 - R类词串记忆树回归的发散.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.12 - R类词串记忆树其它R词/fullHtml/死磕团 No.12 - R类词串记忆树其它R词.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.13 - C类词串记忆树包容一切的C（1）/fullHtml/死磕团 No.13 - C类词串记忆树包容一切的C（1）.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.14 - C类词串记忆树包容一切的C（2）/fullHtml/死磕团 No.14 - C类词串记忆树包容一切的C（2）.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.15 - C类词串记忆树从包容到覆盖/fullHtml/死磕团 No.15 - C类词串记忆树从包容到覆盖.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.16 - C类词串记忆树从包容到中心/fullHtml/死磕团 No.16 - C类词串记忆树从包容到中心.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.17 - A类词串记忆树ab-远离的逻辑/fullHtml/死磕团 No.17 - A类词串记忆树ab-远离的逻辑.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.18 - A类词串记忆树ac的逻辑/fullHtml/死磕团 No.18 - A类词串记忆树ac的逻辑.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.19 - A类词串记忆树ad-靠近的逻辑/fullHtml/死磕团 No.19 - A类词串记忆树ad-靠近的逻辑.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2 - A类词串记忆树ab-远离的逻辑/fullHtml/死磕团 No.2 - A类词串记忆树ab-远离的逻辑.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2 - P类词串记忆树pro- 和pre-/fullHtml/死磕团 No.2 - P类词串记忆树pro- 和pre-..html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-1 - C类词串攻坚战从co到com、con/fullHtml/死磕团 No.2-1 - C类词串攻坚战从co到com、con.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-12 - F类词串记忆树F逻辑图谱/fullHtml/死磕团 No.2-12 - F类词串记忆树F逻辑图谱.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-14 - F类词串记忆树从fort到fess/fullHtml/死磕团 No.2-14 - F类词串记忆树从fort到fess.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-16 - F类词串记忆树F图谱逻辑延伸/fullHtml/死磕团 No.2-16 - F类词串记忆树F图谱逻辑延伸.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-18 - E类词延伸从E到En/fullHtml/死磕团 No.2-18 - E类词延伸从E到En.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-19 - E类词延伸常用高阶E类词/fullHtml/死磕团 No.2-19 - E类词延伸常用高阶E类词.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-2 - C类词串攻坚战更多的包容与环绕/fullHtml/死磕团 No.2-2 - C类词串攻坚战更多的包容与环绕.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-21 - L类词串记忆树线条之美说起/fullHtml/死磕团 No.2-21 - L类词串记忆树线条之美说起.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-22 - L类词串记忆树其他L词/fullHtml/死磕团 No.2-22 - L类词串记忆树其他L词.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-25 - R类词串记忆树进阶的R词/fullHtml/死磕团 No.2-25 - R类词串记忆树进阶的R词.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-3 - C类词串攻坚战更多的包容与环绕（2）/fullHtml/死磕团 No.2-3 - C类词串攻坚战更多的包容与环绕（2）.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2-9 - M类词串记忆树M构词初体验/fullHtml/死磕团 No.2-9 - M类词串记忆树M构词初体验.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.20 - H类词串记忆树H逻辑起源探秘/fullHtml/死磕团 No.20 - H类词串记忆树H逻辑起源探秘.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.21 - H类词串记忆树从向上到居住/fullHtml/死磕团 No.21 - H类词串记忆树从向上到居住.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.22 - T类词串记忆树T逻辑起源探秘/fullHtml/死磕团 No.22 - T类词串记忆树T逻辑起源探秘.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.23 - T类词串记忆树从过程到tent、tran、tract/fullHtml/死磕团 No.23 - T类词串记忆树从过程到tent、tran、tract.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.24 - T类词串记忆树ta和te的逻辑/fullHtml/死磕团 No.24 - T类词串记忆树ta和te的逻辑.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.25 - T类词串记忆树关于time 与过程的扩张/fullHtml/死磕团 No.25 - T类词串记忆树关于time 与过程的扩张.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.26 - E类词串记忆树从e到ex/fullHtml/死磕团 No.26 - E类词串记忆树从e到ex.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.2撸词回炉 - P类词串记忆树pro- 和pre-/fullHtml/死磕团 No.2撸词回炉 - P类词串记忆树pro- 和pre-..html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.3 - P类词串记忆树pose的逻辑/fullHtml/死磕团 No.3 - P类词串记忆树pose的逻辑.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.3-1 - L类词串记忆树L类词惯用法/fullHtml/死磕团 No.3-1 - L类词串记忆树L类词惯用法.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.3-2 - B类词串记忆树B的逻辑初探/fullHtml/死磕团 No.3-2 - B类词串记忆树B的逻辑初探.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.3-21 - I类词记忆树il、in、ir、im词根/fullHtml/死磕团 No.3-21 - I类词记忆树il、in、ir、im词根.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.3-30 - B类词串记忆树进击的木头/fullHtml/死磕团 No.3-30 - B类词串记忆树进击的木头.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.3-5 - V类词串记忆树旋转与空/fullHtml/死磕团 No.3-5 - V类词串记忆树旋转与空.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.3-6 - V类词串记忆树特辑《V字仇杀队》/fullHtml/死磕团 No.3-6 - V类词串记忆树特辑《V字仇杀队》.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.4 - P类词串记忆树其他P词（1）/fullHtml/死磕团 No.4 - P类词串记忆树其他P词（1）.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.4-1 - B类词串记忆树B类词的延伸/fullHtml/死磕团 No.4-1 - B类词串记忆树B类词的延伸.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.4-10 - 词汇巡礼L及M类词/fullHtml/死磕团 No.4-10 - 词汇巡礼L及M类词.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.4-13 - 词汇巡礼F类词回顾/fullHtml/死磕团 No.4-13 - 词汇巡礼F类词回顾.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.4-2 - M类词串记忆树M类词汇进阶/fullHtml/死磕团 No.4-2 - M类词串记忆树M类词汇进阶.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.4-23 - 词汇巡礼曲折的Z和im类词/fullHtml/死磕团 No.4-23 - 词汇巡礼曲折的Z和im类词.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.4-24 - 词汇巡礼前缀im类词/fullHtml/死磕团 No.4-24 - 词汇巡礼前缀im类词.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.4-27 - W类词串记忆树曲折扭曲的W/fullHtml/死磕团 No.4-27 - W类词串记忆树曲折扭曲的W.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.4-28 - W类词串记忆树曲折扭曲的W（2）/fullHtml/死磕团 No.4-28 - W类词串记忆树曲折扭曲的W（2）.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.4-9 - 词汇巡礼（F类词）/fullHtml/死磕团 No.4-9 - 词汇巡礼（F类词）.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.5 - P类词串记忆树其他P词（2）/fullHtml/死磕团 No.5 - P类词串记忆树其他P词（2）.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.5-16 - A类词和ob的逻辑/fullHtml/死磕团 No.5-16 - A类词和ob的逻辑.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.5-17 - 词汇巡礼N类词的延伸&O类词的逻辑/fullHtml/死磕团 No.5-17 - 词汇巡礼N类词的延伸&O类词的逻辑.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.5-19 - 词汇巡礼C类、N类、S类词的逻辑延伸/fullHtml/死磕团 No.5-19 - 词汇巡礼C类、N类、S类词的逻辑延伸.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.5-22 - G类词的逻辑（1）/fullHtml/死磕团 No.5-22 - G类词的逻辑（1）.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.5-23 - 词汇巡礼G类词的逻辑（2）/fullHtml/死磕团 No.5-23 - 词汇巡礼G类词的逻辑（2）.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.5-3 - 词汇巡礼R类词、词根sc/fullHtml/死磕团 No.5-3 - 词汇巡礼R类词、词根sc.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.5-4 - 词汇巡礼str类词/fullHtml/死磕团 No.5-4 - 词汇巡礼str类词.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.6 - J类词串记忆树扔 - 从jab说起/fullHtml/死磕团 No.6 - J类词串记忆树扔 - 从jab说起.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 NO.7.J类词串记忆树从扔到判断 - ject的深入发展/fullHtml/死磕团 NO.7.J类词串记忆树从扔到判断 - ject的深入发展.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 NO.8.J类词串记忆树ju的逻辑/fullHtml/死磕团 NO.8.J类词串记忆树ju的逻辑.html",
"X:/抓取的课/死磕团词串记忆树/死磕团 No.9 - R类词串记忆树绽放之美 - R核心逻辑/fullHtml/死磕团 No.9 - R类词串记忆树绽放之美 - R核心逻辑.html",
"X:/抓取的课/零基础/零基础 专题词汇——商务类/fullHtml/零基础 专题词汇——商务类.html",
"X:/抓取的课/零基础/零基础 专题词汇——政治类/fullHtml/零基础 专题词汇——政治类.html",
"X:/抓取的课/零基础/零基础 专题词汇——文化类/fullHtml/零基础 专题词汇——文化类.html",
"X:/抓取的课/零基础/零基础 专题词汇——新闻媒体类/fullHtml/零基础 专题词汇——新闻媒体类.html",
"X:/抓取的课/零基础/零基础 专题词汇——经济类/fullHtml/零基础 专题词汇——经济类.html",
"X:/抓取的课/零基础/零基础 公式配套练习 1/fullHtml/零基础 公式配套练习 1.html",
"X:/抓取的课/零基础/零基础 公式配套练习 2/fullHtml/零基础 公式配套练习 2.html",
"X:/抓取的课/零基础/零基础 公式配套练习 3/fullHtml/零基础 公式配套练习 3.html",
"X:/抓取的课/零基础/零基础 公式配套练习 4/fullHtml/零基础 公式配套练习 4.html",
"X:/抓取的课/零基础/零基础 句法概念扫盲——主语 Subject/fullHtml/零基础 句法概念扫盲——主语 Subject.html",
"X:/抓取的课/零基础/零基础 句法概念扫盲——同位语 Appositive/fullHtml/零基础 句法概念扫盲——同位语 Appositive.html",
"X:/抓取的课/零基础/零基础 句法概念扫盲——定语 Attributive/fullHtml/零基础 句法概念扫盲——定语 Attributive.html",
"X:/抓取的课/零基础/零基础 句法概念扫盲——宾语 Object/fullHtml/零基础 句法概念扫盲——宾语 Object.html",
"X:/抓取的课/零基础/零基础 句法概念扫盲——插入语 Parenthesis/fullHtml/零基础 句法概念扫盲——插入语 Parenthesis.html",
"X:/抓取的课/零基础/零基础 句法概念扫盲——状语 Adverbial/fullHtml/零基础 句法概念扫盲——状语 Adverbial.html",
"X:/抓取的课/零基础/零基础 句法概念扫盲——谓语 Predicate/fullHtml/零基础 句法概念扫盲——谓语 Predicate.html",
"X:/抓取的课/零基础/零基础 情景词汇——交通出行/fullHtml/零基础 情景词汇——交通出行.html",
"X:/抓取的课/零基础/零基础 情景词汇——兴趣爱好/fullHtml/零基础 情景词汇——兴趣爱好.html",
"X:/抓取的课/零基础/零基础 情景词汇——初次见面/fullHtml/零基础 情景词汇——初次见面.html",
"X:/抓取的课/零基础/零基础 情景词汇——动物Animals/fullHtml/零基础 情景词汇——动物Animals.html",
"X:/抓取的课/零基础/零基础 情景词汇——国家、城市/fullHtml/零基础 情景词汇——国家、城市.html",
"X:/抓取的课/零基础/零基础 情景词汇——季节、气候/fullHtml/零基础 情景词汇——季节、气候.html",
"X:/抓取的课/零基础/零基础 情景词汇——家庭成员/fullHtml/零基础 情景词汇——家庭成员.html",
"X:/抓取的课/零基础/零基础 情景词汇——建筑物/fullHtml/零基础 情景词汇——建筑物.html",
"X:/抓取的课/零基础/零基础 情景词汇——我爱我家/fullHtml/零基础 情景词汇——我爱我家.html",
"X:/抓取的课/零基础/零基础 情景词汇——看病、去医院/fullHtml/零基础 情景词汇——看病、去医院.html",
"X:/抓取的课/零基础/零基础 情景词汇——职业&工作/fullHtml/零基础 情景词汇——职业&工作.html",
"X:/抓取的课/零基础/零基础 情景词汇——节庆假日/fullHtml/零基础 情景词汇——节庆假日.html",
"X:/抓取的课/零基础/零基础 情景词汇——超市、购物/fullHtml/零基础 情景词汇——超市、购物.html",
"X:/抓取的课/零基础/零基础 情景词汇——食物/fullHtml/零基础 情景词汇——食物.html",
"X:/抓取的课/零基础/零基础 经典美文重现 1/fullHtml/零基础 经典美文重现 1.html",
"X:/抓取的课/零基础/零基础 经典美文重现 2/fullHtml/零基础 经典美文重现 2.html",
"X:/抓取的课/零基础/零基础 经典美文重现 3/fullHtml/零基础 经典美文重现 3.html",
"X:/抓取的课/零基础/零基础 词法概念扫盲——代词 pron/fullHtml/零基础 词法概念扫盲——代词 pron..html",
"X:/抓取的课/零基础/零基础 词法概念扫盲——副词 adv/fullHtml/零基础 词法概念扫盲——副词 adv..html",
"X:/抓取的课/零基础/零基础 词法概念扫盲——动词 v/fullHtml/零基础 词法概念扫盲——动词 v..html",
"X:/抓取的课/零基础/零基础 词法概念扫盲——名词 n/fullHtml/零基础 词法概念扫盲——名词 n..html",
"X:/抓取的课/零基础/零基础 词法概念扫盲——形容词 adj/fullHtml/零基础 词法概念扫盲——形容词 adj..html",
"X:/抓取的课/零基础/零基础 词法概念扫盲——感叹词 int/fullHtml/零基础 词法概念扫盲——感叹词 int..html",
"X:/抓取的课/零基础/零基础 词法概念扫盲——数词 num/fullHtml/零基础 词法概念扫盲——数词 num..html",
"X:/抓取的课/零基础/零基础 语法概念扫盲——介词 prep/fullHtml/零基础 语法概念扫盲——介词 prep..html",
"X:/抓取的课/零基础/零基础 语法概念扫盲——冠词 art/fullHtml/零基础 语法概念扫盲——冠词 art..html",
"X:/抓取的课/零基础/零基础 语法概念扫盲——连词 conj/fullHtml/零基础 语法概念扫盲——连词 conj..html",
"X:/抓取的课/零基础/零基础 音标不再怕！ ——爆破音/fullHtml/零基础 音标不再怕！ ——爆破音.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——单元音eæ/fullHtml/零基础 音标不再怕！——单元音eæ.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——单元音uː ʊ/fullHtml/零基础 音标不再怕！——单元音uː ʊ.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——单元音ɔː ɒ/fullHtml/零基础 音标不再怕！——单元音ɔː ɒ.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——单元音ə ɜː/fullHtml/零基础 音标不再怕！——单元音ə ɜː.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——双元音 ɪə eə ʊə/fullHtml/零基础 音标不再怕！——双元音 ɪə eə ʊə.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——双元音aʊ əʊ/fullHtml/零基础 音标不再怕！——双元音aʊ əʊ.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——双元音aɪ eɪ ɔɪ/fullHtml/零基础 音标不再怕！——双元音aɪ eɪ ɔɪ.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——摩擦音、塞擦音/fullHtml/零基础 音标不再怕！——摩擦音、塞擦音.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——认识音标/fullHtml/零基础 音标不再怕！——认识音标.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——近音/fullHtml/零基础 音标不再怕！——近音.html",
"X:/抓取的课/零基础/零基础 音标不再怕！——鼻辅音/fullHtml/零基础 音标不再怕！——鼻辅音.html",
"X:/抓取的课/零基础/零基础 音标不在怕！——单元音 iː i/fullHtml/零基础 音标不在怕！——单元音 iː i.html",
"X:/抓取的课/零基础/零基础小白补给站 句法概念扫盲——主语 Subject/fullHtml/零基础小白补给站 句法概念扫盲——主语 Subject.html",
"X:/抓取的课/零基础/零基础小白补给站 句法概念扫盲——同位语 Appositive/fullHtml/零基础小白补给站 句法概念扫盲——同位语 Appositive.html",
"X:/抓取的课/零基础/零基础小白补给站 句法概念扫盲——定语 Attributive/fullHtml/零基础小白补给站 句法概念扫盲——定语 Attributive.html",
"X:/抓取的课/零基础/零基础小白补给站 句法概念扫盲——宾语 Object/fullHtml/零基础小白补给站 句法概念扫盲——宾语 Object.html",
"X:/抓取的课/零基础/零基础小白补给站 句法概念扫盲——插入语 Parenthesis/fullHtml/零基础小白补给站 句法概念扫盲——插入语 Parenthesis.html",
"X:/抓取的课/零基础/零基础小白补给站 句法概念扫盲——状语 Adverbial/fullHtml/零基础小白补给站 句法概念扫盲——状语 Adverbial.html",
"X:/抓取的课/零基础/零基础小白补给站 句法概念扫盲——谓语 Predicate/fullHtml/零基础小白补给站 句法概念扫盲——谓语 Predicate.html",
"X:/抓取的课/零基础/零基础小白补给站 词法概念扫盲——代词 Pronoun/fullHtml/零基础小白补给站 词法概念扫盲——代词 Pronoun.html",
"X:/抓取的课/零基础/零基础小白补给站 词法概念扫盲——副词 Adverb/fullHtml/零基础小白补给站 词法概念扫盲——副词 Adverb.html",
"X:/抓取的课/零基础/零基础小白补给站 词法概念扫盲——动词 Verb/fullHtml/零基础小白补给站 词法概念扫盲——动词 Verb.html",
"X:/抓取的课/零基础/零基础小白补给站 词法概念扫盲——名词 Noun/fullHtml/零基础小白补给站 词法概念扫盲——名词 Noun.html",
"X:/抓取的课/零基础/零基础小白补给站 词法概念扫盲——形容词 Adjective/fullHtml/零基础小白补给站 词法概念扫盲——形容词 Adjective.html",
"X:/抓取的课/零基础/零基础小白补给站 词法概念扫盲——感叹词 Interjection/fullHtml/零基础小白补给站 词法概念扫盲——感叹词 Interjection.html",
"X:/抓取的课/零基础/零基础小白补给站 词法概念扫盲——数词 Numeral/fullHtml/零基础小白补给站 词法概念扫盲——数词 Numeral.html",
"X:/抓取的课/零基础/零基础小白补给站 语法概念扫盲——介词 Preposition/fullHtml/零基础小白补给站 语法概念扫盲——介词 Preposition.html",
"X:/抓取的课/零基础/零基础小白补给站 语法概念扫盲——冠词 Article/fullHtml/零基础小白补给站 语法概念扫盲——冠词 Article.html",
"X:/抓取的课/零基础/零基础小白补给站 语法概念扫盲——连词 Conjunction/fullHtml/零基础小白补给站 语法概念扫盲——连词 Conjunction.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——单元音eæ/fullHtml/零基础小白补给站 音标不再怕！——单元音eæ.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——单元音uː ʊ/fullHtml/零基础小白补给站 音标不再怕！——单元音uː ʊ.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——单元音ɔː ɒ/fullHtml/零基础小白补给站 音标不再怕！——单元音ɔː ɒ.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——单元音ə ɜː/fullHtml/零基础小白补给站 音标不再怕！——单元音ə ɜː.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——双元音 ɪə eə ʊə/fullHtml/零基础小白补给站 音标不再怕！——双元音 ɪə eə ʊə.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——双元音aʊ əʊ/fullHtml/零基础小白补给站 音标不再怕！——双元音aʊ əʊ.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——双元音aɪ eɪ ɔɪ/fullHtml/零基础小白补给站 音标不再怕！——双元音aɪ eɪ ɔɪ.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——摩擦音、塞擦音/fullHtml/零基础小白补给站 音标不再怕！——摩擦音、塞擦音.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——爆破音/fullHtml/零基础小白补给站 音标不再怕！——爆破音.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——认识音标/fullHtml/零基础小白补给站 音标不再怕！——认识音标.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——近音/fullHtml/零基础小白补给站 音标不再怕！——近音.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不再怕！——鼻辅音/fullHtml/零基础小白补给站 音标不再怕！——鼻辅音.html",
"X:/抓取的课/零基础/零基础小白补给站 音标不在怕！——单元音 iː i/fullHtml/零基础小白补给站 音标不在怕！——单元音 iː i.html",
"X:/抓取的课/零基础/零基础补给站 句法概念扫盲——同位语 Appositive/fullHtml/零基础补给站 句法概念扫盲——同位语 Appositive.html",
"X:/抓取的课/零基础/零基础补给站 句法概念扫盲——谓语 Predicate/fullHtml/零基础补给站 句法概念扫盲——谓语 Predicate.html",
"X:/抓取的课/零基础/零基础补给站 音标不再怕！——鼻辅音/fullHtml/零基础补给站 音标不再怕！——鼻辅音.html"]
errList = []
for htmlFileName in fileNameList:
    try:
        # htmlFileName =  'r:/a.html'
        fullHtml = web2html.generate(htmlFileName, comment=False, full_url=True, verbose=True)
        fullHtml = clearHtml(fullHtml, True)  # 去掉评论区
        fullHtml = clearDefCSSValue(fullHtml)  # 清除 fullHtml 中多余的 css 打包对象

        if len(fullHtml) > 0:
            fullHtmlFile = open(htmlFileName, 'w', encoding='UTF-8')
            # fullHtmlFile = open('r:/b.html', 'w', encoding='UTF-8')
            fullHtmlFile.write(fullHtml)
            fullHtmlFile.close()
    except Exception as e:
        errList.append((htmlFileName, repr(e)))

for err in errList:
    print("%s\n%s\n" % err)

exit()


cmdList = []
f = open('r:/cp.txt', encoding = 'UTF-8')
for line in f:
    cmdList.append(line)
f.close()
for cmd in cmdList:
    print(cmd)
    os.system(cmd)
exit()
