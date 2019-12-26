import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver
import requests
from urllib.request import urlopen, urlretrieve, pathname2url
from turtle import *
import GeekTime.webpage2html as web2html
from termcolor import colored


def clearDefCSSValue123(html):
    suffixReg = "[^\{]*\{[^\}]*\}"
    perfixRegNodList = [".src-components-Clock-User-index__container--HznrX",
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

    ret2 = ''

    for nod in perfixRegNodList:
        regExp = nod + suffixReg
        # html = re.sub(regExp, '', html)

        match = re.findall(regExp, html)
        if match is None or len(match) == 0:
            print(regExp)
        else:
            for m in match:
                ret2 += m + "\n"

            html = re.sub(regExp, '', html)

    return ret2


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
        [s.extract() for s in
         bs.find_all("article", {"class": "src-components-CommentZone-CommentZoneNew-index__commentWrapper--1Y8Bw"})]

    return repr(bs)


# dir /s/b *.html > h.txt
def tempClear():
    fileList = ["R:/全民英语背诵营 代码抓取 Html/Day 1 课后练习/fullHtml/Day 1 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 1带读训练 Find Your Greatness （发现你的伟大）/fullHtml/Day 1带读训练 Find Your Greatness （发现你的伟大）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 1亮解单词 Find Your Greatness (发现你的伟大)/fullHtml/Day 1亮解单词 Find Your Greatness (发现你的伟大).html",
"R:/全民英语背诵营 代码抓取 Html/Day 1文本精讲 Find Your Greatness (发现你的伟大)/fullHtml/Day 1文本精讲 Find Your Greatness (发现你的伟大).html",
"R:/全民英语背诵营 代码抓取 Html/Day 2带读训练 Ideas Are Scary（想法是可怕的）/fullHtml/Day 2带读训练 Ideas Are Scary（想法是可怕的）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 2课后练习/fullHtml/Day 2课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 2亮解单词 Ideas Are Scary（想法是可怕的）/fullHtml/Day 2亮解单词 Ideas Are Scary（想法是可怕的）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 2文本精讲 Ideas Are Scary（想法是可怕的）/fullHtml/Day 2文本精讲 Ideas Are Scary（想法是可怕的）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 3 课后练习/fullHtml/Day 3 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 3带读训练 Airplane Announcement（民航播音稿）上篇/fullHtml/Day 3带读训练 Airplane Announcement（民航播音稿）上篇.html",
"R:/全民英语背诵营 代码抓取 Html/Day 3亮解单词 Airplane Announcement（民航播音稿）上篇/fullHtml/Day 3亮解单词 Airplane Announcement（民航播音稿）上篇.html",
"R:/全民英语背诵营 代码抓取 Html/Day 3文本精讲 Airplane Announcement（民航播音稿）上篇/fullHtml/Day 3文本精讲 Airplane Announcement（民航播音稿）上篇.html",
"R:/全民英语背诵营 代码抓取 Html/Day 4 课后练习/fullHtml/Day 4 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 4带读训练 Airplane Announcement（民航播音稿）下篇/fullHtml/Day 4带读训练 Airplane Announcement（民航播音稿）下篇.html",
"R:/全民英语背诵营 代码抓取 Html/Day 4亮解单词 Airplane Announcement（民航播音稿）下篇/fullHtml/Day 4亮解单词 Airplane Announcement（民航播音稿）下篇.html",
"R:/全民英语背诵营 代码抓取 Html/Day 4文本精讲 Airplane Announcement（民航播音稿）下篇/fullHtml/Day 4文本精讲 Airplane Announcement（民航播音稿）下篇.html",
"R:/全民英语背诵营 代码抓取 Html/Day 5 课后练习/fullHtml/Day 5 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 5带读训练 The Astronomer （天文学家）/fullHtml/Day 5带读训练 The Astronomer （天文学家）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 5亮解单词 The Astronomer （天文学家）/fullHtml/Day 5亮解单词 The Astronomer （天文学家）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 5文本精讲 The Astronomer （天文学家）/fullHtml/Day 5文本精讲 The Astronomer （天文学家）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 6 课后练习/fullHtml/Day 6 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 6带读训练 The Donkey in the Lion’s Skin（披着狮子皮的驴）/fullHtml/Day 6带读训练 The Donkey in the Lion’s Skin（披着狮子皮的驴）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 6亮解单词 The Donkey in the Lion’s Skin （披着狮子皮的驴）/fullHtml/Day 6亮解单词 The Donkey in the Lion’s Skin （披着狮子皮的驴）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 6文本精讲 The Donkey in the Lion’s Skin （披着狮子皮的驴）/fullHtml/Day 6文本精讲 The Donkey in the Lion’s Skin （披着狮子皮的驴）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 7 课后练习/fullHtml/Day 7 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 7带读训练 How to Be Proactive （做事如何积极主动）/fullHtml/Day 7带读训练 How to Be Proactive （做事如何积极主动）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 7亮解单词 How to Be Proactive （做事如何积极主动）/fullHtml/Day 7亮解单词 How to Be Proactive （做事如何积极主动）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 7文本精讲 How to Be Proactive （做事如何积极主动）/fullHtml/Day 7文本精讲 How to Be Proactive （做事如何积极主动）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 8 课后练习/fullHtml/Day 8 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 8带读训练 Eat That Frog （吃掉那只青蛙）/fullHtml/Day 8带读训练 Eat That Frog （吃掉那只青蛙）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 8亮解单词 Eat That Frog （吃掉那只青蛙）/fullHtml/Day 8亮解单词 Eat That Frog （吃掉那只青蛙）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 8文本精讲 Eat That Frog （吃掉那只青蛙）/fullHtml/Day 8文本精讲 Eat That Frog （吃掉那只青蛙）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 9 课后练习/fullHtml/Day 9 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 9带读训练 Resident Evil - Opening scene （生化危机—开场白）/fullHtml/Day 9带读训练 Resident Evil - Opening scene （生化危机—开场白）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 9亮解单词 Resident Evil - Opening scene （生化危机—开场白）/fullHtml/Day 9亮解单词 Resident Evil - Opening scene （生化危机—开场白）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 9文本精讲 Resident Evil - Opening scene （生化危机—开场白）/fullHtml/Day 9文本精讲 Resident Evil - Opening scene （生化危机—开场白）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 10 课后练习/fullHtml/Day 10 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 10带读训练 Shrek 1 - Opening Scene （怪物史莱克1—开场白）/fullHtml/Day 10带读训练 Shrek 1 - Opening Scene （怪物史莱克1—开场白）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 10亮解单词 Shrek 1 - Opening Scene （怪物史莱克1—开场白）/fullHtml/Day 10亮解单词 Shrek 1 - Opening Scene （怪物史莱克1—开场白）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 10文本精讲 Shrek 1 - Opening Scene （怪物史莱克1—开场白）/fullHtml/Day 10文本精讲 Shrek 1 - Opening Scene （怪物史莱克1—开场白）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 11 课后练习/fullHtml/Day 11 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 11带读训练 ILM-Creating the Impossible （工业光魔-创造不可能）（1）/fullHtml/Day 11带读训练 ILM-Creating the Impossible （工业光魔-创造不可能）（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 11亮解单词 ILM-Creating the Impossible （工业光魔-创造不可能）（1）/fullHtml/Day 11亮解单词 ILM-Creating the Impossible （工业光魔-创造不可能）（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 11文本精讲 ILM-Creating the Impossible （工业光魔-创造不可能）（1）/fullHtml/Day 11文本精讲 ILM-Creating the Impossible （工业光魔-创造不可能）（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 12 课后练习/fullHtml/Day 12 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 12带读训练 ILM-Creating the Impossible （工业光魔-创造不可能）（2）/fullHtml/Day 12带读训练 ILM-Creating the Impossible （工业光魔-创造不可能）（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 12亮解单词 ILM-Creating the Impossible （工业光魔-创造不可能）（2）/fullHtml/Day 12亮解单词 ILM-Creating the Impossible （工业光魔-创造不可能）（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 12文本精讲 ILM-Creating the Impossible （工业光魔-创造不可能）（2）/fullHtml/Day 12文本精讲 ILM-Creating the Impossible （工业光魔-创造不可能）（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 13 课后练习/fullHtml/Day 13 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 13带读训练 Start With Why （《从为什么开始》）（1）/fullHtml/Day 13带读训练 Start With Why （《从为什么开始》）（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 13亮解单词 Start With Why （《从为什么开始》）（1）/fullHtml/Day 13亮解单词 Start With Why （《从为什么开始》）（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 13文本精讲 Start With Why （《从为什么开始》）（1）/fullHtml/Day 13文本精讲 Start With Why （《从为什么开始》）（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 14 课后练习/fullHtml/Day 14 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 14带读训练 Start With Why （《从为什么开始》）（2）/fullHtml/Day 14带读训练 Start With Why （《从为什么开始》）（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 14亮解单词 Start With Why （《从为什么开始》）（2）/fullHtml/Day 14亮解单词 Start With Why （《从为什么开始》）（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 14文本精讲 Start With Why （《从为什么开始》）（2）/fullHtml/Day 14文本精讲 Start With Why （《从为什么开始》）（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 15 课后练习/fullHtml/Day 15 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 15带读训练 Barack Obama Presidential Victory Speech, 2008（2008年奥巴马当选演讲）（节选）/fullHtml/Day 15带读训练 Barack Obama Presidential Victory Speech, 2008（2008年奥巴马当选演讲）（节选）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 15亮解单词 Barack Obama Presidential Victory Speech, 2008（2008年奥巴马当选演讲）（节选）/fullHtml/Day 15亮解单词 Barack Obama Presidential Victory Speech, 2008（2008年奥巴马当选演讲）（节选）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 15文本精讲 Barack Obama Presidential Victory Speech, 2008（2008年奥巴马当选演讲）（节选）/fullHtml/Day 15文本精讲 Barack Obama Presidential Victory Speech, 2008（2008年奥巴马当选演讲）（节选）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 16 带读训练 NAACP Image Awards Acceptance Speech 美国有色人种奖获奖感言（节选）/fullHtml/Day 16 带读训练 NAACP Image Awards Acceptance Speech 美国有色人种奖获奖感言（节选）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 16 课后练习/fullHtml/Day 16 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 16 亮解单词 NAACP Image Awards Acceptance Speech 美国有色人种奖获奖感言（节选）/fullHtml/Day 16 亮解单词 NAACP Image Awards Acceptance Speech 美国有色人种奖获奖感言（节选）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 16 文本精讲 NAACP Image Awards Acceptance Speech 美国有色人种奖获奖感言（节选）/fullHtml/Day 16 文本精讲 NAACP Image Awards Acceptance Speech 美国有色人种奖获奖感言（节选）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 17 课后练习/fullHtml/Day 17 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 17带读训练 Cross-cultural Communication（跨文化交流）（1）/fullHtml/Day 17带读训练 Cross-cultural Communication（跨文化交流）（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 17亮解单词 Cross-cultural Communication（跨文化交流）（1）/fullHtml/Day 17亮解单词 Cross-cultural Communication（跨文化交流）（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 17文本精讲 Cross-cultural Communication（跨文化交流）（1）/fullHtml/Day 17文本精讲 Cross-cultural Communication（跨文化交流）（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 18 课后练习/fullHtml/Day 18 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 18带读训练 Cross-cultural Communication（跨文化交流）（2）/fullHtml/Day 18带读训练 Cross-cultural Communication（跨文化交流）（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 18亮解单词 Cross-cultural Communication（跨文化交流）（2）/fullHtml/Day 18亮解单词 Cross-cultural Communication（跨文化交流）（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 18文本精讲 Cross-cultural Communication（跨文化交流）（2）/fullHtml/Day 18文本精讲 Cross-cultural Communication（跨文化交流）（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 19 课后练习/fullHtml/Day 19 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 19带读训练 Audrey Hepburn（奥黛丽•赫本）/fullHtml/Day 19带读训练 Audrey Hepburn（奥黛丽•赫本）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 19亮解单词 Audrey Hepburn（奥黛丽•赫本）/fullHtml/Day 19亮解单词 Audrey Hepburn（奥黛丽•赫本）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 19文本精讲 Audrey Hepburn（奥黛丽•赫本）/fullHtml/Day 19文本精讲 Audrey Hepburn（奥黛丽•赫本）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 20 课后练习/fullHtml/Day 20 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 20带读训练 Heinz - The Ketchup Kings（亨氏—番茄酱之王）/fullHtml/Day 20带读训练 Heinz - The Ketchup Kings（亨氏—番茄酱之王）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 20亮解单词 Heinz - The Ketchup Kings（亨氏—番茄酱之王）/fullHtml/Day 20亮解单词 Heinz - The Ketchup Kings（亨氏—番茄酱之王）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 20文本精讲 Heinz - The Ketchup Kings（亨氏—番茄酱之王）/fullHtml/Day 20文本精讲 Heinz - The Ketchup Kings（亨氏—番茄酱之王）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 21 课后练习/fullHtml/Day 21 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 21带读训练 Waken（醒来）/fullHtml/Day 21带读训练 Waken（醒来）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 21亮解单词 Waken（醒来）/fullHtml/Day 21亮解单词 Waken（醒来）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 21文本精讲 Waken（醒来）/fullHtml/Day 21文本精讲 Waken（醒来）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 22 课后练习/fullHtml/Day 22 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 22带读训练 Share the Spirit of Olympic Games（共享奥运精神）/fullHtml/Day 22带读训练 Share the Spirit of Olympic Games（共享奥运精神）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 22亮解单词 Share the Spirit of Olympic Games（共享奥运精神）/fullHtml/Day 22亮解单词 Share the Spirit of Olympic Games（共享奥运精神）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 22文本精讲 Share the Spirit of Olympic Games（共享奥运精神）/fullHtml/Day 22文本精讲 Share the Spirit of Olympic Games（共享奥运精神）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 23 课后练习/fullHtml/Day 23 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 23带读训练 Stephen Fry - On Depression（斯蒂芬·弗雷—论抑郁）/fullHtml/Day 23带读训练 Stephen Fry - On Depression（斯蒂芬·弗雷—论抑郁）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 23亮解单词 Stephen Fry - On Depression（斯蒂芬·弗雷—论抑郁）/fullHtml/Day 23亮解单词 Stephen Fry - On Depression（斯蒂芬·弗雷—论抑郁）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 23文本精讲 Stephen Fry - On Depression（斯蒂芬·弗雷—论抑郁）/fullHtml/Day 23文本精讲 Stephen Fry - On Depression（斯蒂芬·弗雷—论抑郁）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 24 课后练习/fullHtml/Day 24 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 24带读训练 Alexandre Dumas - Wait and Hope（亚历山大·仲马—等待和希望）/fullHtml/Day 24带读训练 Alexandre Dumas - Wait and Hope（亚历山大·仲马—等待和希望）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 24亮解单词 Alexandre Dumas - Wait and Hope（亚历山大·仲马—等待和希望）/fullHtml/Day 24亮解单词 Alexandre Dumas - Wait and Hope（亚历山大·仲马—等待和希望）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 24文本精讲 Alexandre Dumas - Wait and Hope（亚历山大·仲马—等待和希望）/fullHtml/Day 24文本精讲 Alexandre Dumas - Wait and Hope（亚历山大·仲马—等待和希望）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 25 课后练习/fullHtml/Day 25 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 25带读训练 HBO - The Complete OSCARS Experience（HBO电视网 — 奥斯卡全方位体验）/fullHtml/Day 25带读训练 HBO - The Complete OSCARS Experience（HBO电视网 — 奥斯卡全方位体验）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 25亮解单词 HBO - The Complete OSCARS Experience（HBO电视网 — 奥斯卡全方位体验）/fullHtml/Day 25亮解单词 HBO - The Complete OSCARS Experience（HBO电视网 — 奥斯卡全方位体验）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 25文本精讲 HBO - The Complete OSCARS Experience（HBO电视网 — 奥斯卡全方位体验）/fullHtml/Day 25文本精讲 HBO - The Complete OSCARS Experience（HBO电视网 — 奥斯卡全方位体验）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 26 课后练习/fullHtml/Day 26 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 26带读训练 Reality TV - Big Brother（真人秀—《老大哥》）/fullHtml/Day 26带读训练 Reality TV - Big Brother（真人秀—《老大哥》）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 26亮解单词 Reality TV - Big Brother（真人秀—《老大哥》）/fullHtml/Day 26亮解单词 Reality TV - Big Brother（真人秀—《老大哥》）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 26文本精讲 Reality TV - Big Brother（真人秀—《老大哥》）/fullHtml/Day 26文本精讲 Reality TV - Big Brother（真人秀—《老大哥》）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 27 课后练习/fullHtml/Day 27 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 27带读训练 Police Arrest a Parrot（警方逮捕了一只鹦鹉）/fullHtml/Day 27带读训练 Police Arrest a Parrot（警方逮捕了一只鹦鹉）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 27亮解单词 Police Arrest a Parrot（警方逮捕了一只鹦鹉）/fullHtml/Day 27亮解单词 Police Arrest a Parrot（警方逮捕了一只鹦鹉）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 27文本精讲 Police Arrest a Parrot（警方逮捕了一只鹦鹉）/fullHtml/Day 27文本精讲 Police Arrest a Parrot（警方逮捕了一只鹦鹉）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 28 课后练习/fullHtml/Day 28 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 28带读训练 Labrador guns down its owner（拉布拉多枪击主人）/fullHtml/Day 28带读训练 Labrador guns down its owner（拉布拉多枪击主人）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 28亮解单词 Labrador guns down its owner（拉布拉多枪击主人）/fullHtml/Day 28亮解单词 Labrador guns down its owner（拉布拉多枪击主人）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 28文本精讲 Labrador guns down its owner（拉布拉多枪击主人）/fullHtml/Day 28文本精讲 Labrador guns down its owner（拉布拉多枪击主人）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 29 课后练习/fullHtml/Day 29 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 29带读训练 The Picture of Dorian Gray（《道林格雷的画像》）/fullHtml/Day 29带读训练 The Picture of Dorian Gray（《道林格雷的画像》）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 29亮解单词 The Picture of Dorian Gray（《道林格雷的画像》）/fullHtml/Day 29亮解单词 The Picture of Dorian Gray（《道林格雷的画像》）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 29文本精讲 The Picture of Dorian Gray（《道林格雷的画像》）/fullHtml/Day 29文本精讲 The Picture of Dorian Gray（《道林格雷的画像》）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 30带读训练 Animal Farm（《动物农场》）/fullHtml/Day 30带读训练 Animal Farm（《动物农场》）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 30课后练习/fullHtml/Day 30课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 30亮解单词 Animal Farm（《动物农场》）/fullHtml/Day 30亮解单词 Animal Farm（《动物农场》）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 30文本精讲 Animal Farm（《动物农场》）/fullHtml/Day 30文本精讲 Animal Farm（《动物农场》）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 31 课后练习/fullHtml/Day 31 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 31带读训练 Think Different （非同凡想）/fullHtml/Day 31带读训练 Think Different （非同凡想）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 31亮解单词 Think Different （非同凡想）/fullHtml/Day 31亮解单词 Think Different （非同凡想）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 31文本精讲 Think Different （非同凡想）/fullHtml/Day 31文本精讲 Think Different （非同凡想）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 32 课后练习/fullHtml/Day 32 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 32带读训练 Mercedes-Benz - The best or nothing（梅赛德斯-奔驰唯有最好）/fullHtml/Day 32带读训练 Mercedes-Benz - The best or nothing（梅赛德斯-奔驰唯有最好）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 32亮解单词 Mercedes-Benz - The best or nothing（梅赛德斯-奔驰唯有最好）/fullHtml/Day 32亮解单词 Mercedes-Benz - The best or nothing（梅赛德斯-奔驰唯有最好）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 32文本精讲 Mercedes-Benz - The best or nothing（梅赛德斯-奔驰唯有最好）/fullHtml/Day 32文本精讲 Mercedes-Benz - The best or nothing（梅赛德斯-奔驰唯有最好）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 33 课后练习/fullHtml/Day 33 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 33带读训练 IHG（洲际酒店集团）/fullHtml/Day 33带读训练 IHG（洲际酒店集团）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 33亮解单词 IHG（洲际酒店集团）/fullHtml/Day 33亮解单词 IHG（洲际酒店集团）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 33文本精讲 IHG（洲际酒店集团）/fullHtml/Day 33文本精讲 IHG（洲际酒店集团）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 34 课后练习/fullHtml/Day 34 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 34带读训练 Nick's Manhattan Beach （尼克的曼哈顿海滩餐厅）/fullHtml/Day 34带读训练 Nick's Manhattan Beach （尼克的曼哈顿海滩餐厅）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 34亮解单词 Nick's Manhattan Beach （尼克的曼哈顿海滩餐厅）/fullHtml/Day 34亮解单词 Nick's Manhattan Beach （尼克的曼哈顿海滩餐厅）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 34文本精讲 Nick's Manhattan Beach （尼克的曼哈顿海滩餐厅）/fullHtml/Day 34文本精讲 Nick's Manhattan Beach （尼克的曼哈顿海滩餐厅）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 35 课后练习/fullHtml/Day 35 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 35带读训练 The Ass and His Purchaser （驴和买主）/fullHtml/Day 35带读训练 The Ass and His Purchaser （驴和买主）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 35亮解单词 The Ass and His Purchaser （驴和买主）/fullHtml/Day 35亮解单词 The Ass and His Purchaser （驴和买主）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 35文本精讲 The Ass and His Purchaser （驴和买主）/fullHtml/Day 35文本精讲 The Ass and His Purchaser （驴和买主）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 36 课后练习/fullHtml/Day 36 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 36带读训练 Mercury and The Sculptor （墨丘利和雕刻师）/fullHtml/Day 36带读训练 Mercury and The Sculptor （墨丘利和雕刻师）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 36亮解单词 Mercury and The Sculptor （墨丘利和雕刻师）/fullHtml/Day 36亮解单词 Mercury and The Sculptor （墨丘利和雕刻师）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 36文本精讲 Mercury and The Sculptor （墨丘利和雕刻师）/fullHtml/Day 36文本精讲 Mercury and The Sculptor （墨丘利和雕刻师）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 37 课后练习/fullHtml/Day 37 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 37带读训练 Clash of the Titans Opening Scene （《诸神之战》开场）/fullHtml/Day 37带读训练 Clash of the Titans Opening Scene （《诸神之战》开场）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 37亮解单词 Clash of the Titans Opening Scene （《诸神之战》开场）/fullHtml/Day 37亮解单词 Clash of the Titans Opening Scene （《诸神之战》开场）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 37文本精讲 Clash of the Titans Opening Scene （《诸神之战》开场）/fullHtml/Day 37文本精讲 Clash of the Titans Opening Scene （《诸神之战》开场）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 38 课后练习/fullHtml/Day 38 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 38带读训练 Transformers Opening Scene （《变形金刚》开场）/fullHtml/Day 38带读训练 Transformers Opening Scene （《变形金刚》开场）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 38亮解单词 Transformers Opening Scene （《变形金刚》开场）/fullHtml/Day 38亮解单词 Transformers Opening Scene （《变形金刚》开场）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 38文本精讲 Transformers Opening Scene （《变形金刚》开场）/fullHtml/Day 38文本精讲 Transformers Opening Scene （《变形金刚》开场）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 39 课后练习/fullHtml/Day 39 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 39带读训练 The Lord of the Rings - The Prologue （《魔戒》序言）/fullHtml/Day 39带读训练 The Lord of the Rings - The Prologue （《魔戒》序言）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 39亮解单词 The Lord of the Rings - The Prologue （《魔戒》序言）/fullHtml/Day 39亮解单词 The Lord of the Rings - The Prologue （《魔戒》序言）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 39文本精讲 The Lord of the Rings - The Prologue （《魔戒》序言）/fullHtml/Day 39文本精讲 The Lord of the Rings - The Prologue （《魔戒》序言）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 40 带读训练 · Zootopia-Judy Hopps’ Speech 疯狂动物城—兔子警官的演讲/fullHtml/Day 40 带读训练 · Zootopia-Judy Hopps’ Speech 疯狂动物城—兔子警官的演讲.html",
"R:/全民英语背诵营 代码抓取 Html/Day 40 亮解单词 Zootopia-Judy Hopps’ Speech 疯狂动物城—兔子警官的演讲/fullHtml/Day 40 亮解单词 Zootopia-Judy Hopps’ Speech 疯狂动物城—兔子警官的演讲.html",
"R:/全民英语背诵营 代码抓取 Html/Day 40课后练习/fullHtml/Day 40课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 40文本精讲 Zootopia-Judy Hopps’ Speech 疯狂动物城—兔子警官的演讲/fullHtml/Day 40文本精讲 Zootopia-Judy Hopps’ Speech 疯狂动物城—兔子警官的演讲.html",
"R:/全民英语背诵营 代码抓取 Html/Day 41 带读训练 Face Change Bravely 勇敢面对改变/fullHtml/Day 41 带读训练 Face Change Bravely 勇敢面对改变.html",
"R:/全民英语背诵营 代码抓取 Html/Day 41 课后练习/fullHtml/Day 41 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 41 亮解单词 Face Change Bravely 勇敢面对改变/fullHtml/Day 41 亮解单词 Face Change Bravely 勇敢面对改变.html",
"R:/全民英语背诵营 代码抓取 Html/Day 41文本精讲Face Change Bravely 勇敢面对改变/fullHtml/Day 41文本精讲Face Change Bravely 勇敢面对改变.html",
"R:/全民英语背诵营 代码抓取 Html/Day 42 带读训练Persist, and Anything is Within Your Reach 坚持，你就能成功/fullHtml/Day 42 带读训练Persist, and Anything is Within Your Reach 坚持，你就能成功.html",
"R:/全民英语背诵营 代码抓取 Html/Day 42 课后练习/fullHtml/Day 42 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 42 亮解单词 Persist, and Anything is Within Your Reach 坚持，你就能成功/fullHtml/Day 42 亮解单词 Persist, and Anything is Within Your Reach 坚持，你就能成功.html",
"R:/全民英语背诵营 代码抓取 Html/Day 42 文本精讲 Persist, and Anything is Within Your Reach 坚持，你就能成功/fullHtml/Day 42 文本精讲 Persist, and Anything is Within Your Reach 坚持，你就能成功.html",
"R:/全民英语背诵营 代码抓取 Html/Day 43 带读训练David and Goliath Underdogs, Misfits, and the Art of Battling Giants (1) 《逆转弱者如何找到优势，反败为胜》（1）/fullHtml/Day 43 带读训练David and Goliath Underdogs, Misfits, and the Art of Battling Giants (1) 《逆转弱者如何找到优势，反败为胜》（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 43 课后练习/fullHtml/Day 43 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 43 亮解单词David and Goliath Underdogs, Misfits, and the Art of Battling Giants (1) 《逆转弱者如何找到优势，反败为胜》（1）/fullHtml/Day 43 亮解单词David and Goliath Underdogs, Misfits, and the Art of Battling Giants (1) 《逆转弱者如何找到优势，反败为胜》（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 43 文本精讲David and Goliath Underdogs, Misfits, and the Art of Battling Giants (1) 《逆转弱者如何找到优势，反败为胜》（1）/fullHtml/Day 43 文本精讲David and Goliath Underdogs, Misfits, and the Art of Battling Giants (1) 《逆转弱者如何找到优势，反败为胜》（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 44 带读训练 David and Goliath Underdogs, Misfits, and the Art of Battling Giants （2）/fullHtml/Day 44 带读训练 David and Goliath Underdogs, Misfits, and the Art of Battling Giants （2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 44 课后练习/fullHtml/Day 44 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 44 亮解单词David and Goliath Underdogs, Misfits, and the Art of Battling Giants (2)/fullHtml/Day 44 亮解单词David and Goliath Underdogs, Misfits, and the Art of Battling Giants (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day 44 文本精讲 David and Goliath Underdogs, Misfits, and the Art of Battling Giants (2)/fullHtml/Day 44 文本精讲 David and Goliath Underdogs, Misfits, and the Art of Battling Giants (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day 45 带读训练 The Road to Character《品格之路》（1）/fullHtml/Day 45 带读训练 The Road to Character《品格之路》（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 45 课后练习/fullHtml/Day 45 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 45 亮解单词 The Road to Character《品格之路》（1）/fullHtml/Day 45 亮解单词 The Road to Character《品格之路》（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 45 文本精讲 The Road to Character《品格之路》（1）/fullHtml/Day 45 文本精讲 The Road to Character《品格之路》（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 46 带读训练 The Road to Character《品格之路》（2）/fullHtml/Day 46 带读训练 The Road to Character《品格之路》（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 46 课后练习/fullHtml/Day 46 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 46 亮解单词 The Road to Character《品格之路》（2）/fullHtml/Day 46 亮解单词 The Road to Character《品格之路》（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 46 文本精讲 The Road to Character《品格之路》（2）/fullHtml/Day 46 文本精讲 The Road to Character《品格之路》（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 47 带读训练 Martin Luther King Jr. - I Have A Dream (Excerpts)/fullHtml/Day 47 带读训练 Martin Luther King Jr. - I Have A Dream (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day 47 课后练习/fullHtml/Day 47 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 47 亮解单词 Martin Luther King Jr. - I Have A Dream (Excerpts)/fullHtml/Day 47 亮解单词 Martin Luther King Jr. - I Have A Dream (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day 47 文本精讲 Martin Luther King Jr. - I Have A Dream (Excerpts)/fullHtml/Day 47 文本精讲 Martin Luther King Jr. - I Have A Dream (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day 48 带读训练 John F. Kennedy Presidential Inaugural Speech (Excerpts)/fullHtml/Day 48 带读训练 John F. Kennedy Presidential Inaugural Speech (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day 48 课后练习/fullHtml/Day 48 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 48 亮解单词 John F. Kennedy Presidential Inaugural Speech (Excerpts)/fullHtml/Day 48 亮解单词 John F. Kennedy Presidential Inaugural Speech (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day 48 文本精讲 John F. Kennedy Presidential Inaugural Speech (Excerpts)/fullHtml/Day 48 文本精讲 John F. Kennedy Presidential Inaugural Speech (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day 49 带读训练 Truman Announces Hiroshima Bombing (1)/fullHtml/Day 49 带读训练 Truman Announces Hiroshima Bombing (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day 49 课后练习/fullHtml/Day 49 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 49 亮解单词 Truman Announces Hiroshima Bombing (1)/fullHtml/Day 49 亮解单词 Truman Announces Hiroshima Bombing (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day 49 文本精讲 Truman Announces Hiroshima Bombing (1)/fullHtml/Day 49 文本精讲 Truman Announces Hiroshima Bombing (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day 50 带读训练 Truman Announces Hiroshima Bombing (2)/fullHtml/Day 50 带读训练 Truman Announces Hiroshima Bombing (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day 50 课后练习/fullHtml/Day 50 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 50 亮解单词 Truman Announces Hiroshima Bombing (2)/fullHtml/Day 50 亮解单词 Truman Announces Hiroshima Bombing (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day 50 文本精讲 Truman Announces Hiroshima Bombing (2)/fullHtml/Day 50 文本精讲 Truman Announces Hiroshima Bombing (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day 51 带读训练 The unanimous Declaration of the thirteen united States of America (Excerpt)/fullHtml/Day 51 带读训练 The unanimous Declaration of the thirteen united States of America (Excerpt).html",
"R:/全民英语背诵营 代码抓取 Html/Day 51 课后练习/fullHtml/Day 51 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 51 亮解单词 The unanimous Declaration of the thirteen united States of America (Excerpt)/fullHtml/Day 51 亮解单词 The unanimous Declaration of the thirteen united States of America (Excerpt).html",
"R:/全民英语背诵营 代码抓取 Html/Day 51 文本精讲 The unanimous Declaration of the thirteen united States of America (Excerpt)/fullHtml/Day 51 文本精讲 The unanimous Declaration of the thirteen united States of America (Excerpt).html",
"R:/全民英语背诵营 代码抓取 Html/Day 52 带读训练 The History of Slavery In America/fullHtml/Day 52 带读训练 The History of Slavery In America.html",
"R:/全民英语背诵营 代码抓取 Html/Day 52 课后练习/fullHtml/Day 52 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 52 亮解单词 The History of Slavery In America/fullHtml/Day 52 亮解单词 The History of Slavery In America.html",
"R:/全民英语背诵营 代码抓取 Html/Day 52 文本精讲 The History of Slavery In America 来源杨亮/fullHtml/Day 52 文本精讲 The History of Slavery In America 来源杨亮.html",
"R:/全民英语背诵营 代码抓取 Html/Day 53 带读训练 Henry Ford/fullHtml/Day 53 带读训练 Henry Ford.html",
"R:/全民英语背诵营 代码抓取 Html/Day 53 课后练习/fullHtml/Day 53 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 53 亮解单词 Henry Ford/fullHtml/Day 53 亮解单词 Henry Ford.html",
"R:/全民英语背诵营 代码抓取 Html/Day 53 文本精讲 Henry Ford/fullHtml/Day 53 文本精讲 Henry Ford.html",
"R:/全民英语背诵营 代码抓取 Html/Day 54 带读训练 Liberace/fullHtml/Day 54 带读训练 Liberace.html",
"R:/全民英语背诵营 代码抓取 Html/Day 54 课后练习/fullHtml/Day 54 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 54 亮解单词 Liberace/fullHtml/Day 54 亮解单词 Liberace.html",
"R:/全民英语背诵营 代码抓取 Html/Day 54 文本精讲 Liberace/fullHtml/Day 54 文本精讲 Liberace.html",
"R:/全民英语背诵营 代码抓取 Html/Day 55 带读训练 Dale Carnegie - A Man of Influence/fullHtml/Day 55 带读训练 Dale Carnegie - A Man of Influence.html",
"R:/全民英语背诵营 代码抓取 Html/Day 55 课后练习/fullHtml/Day 55 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 55 亮解单词 Dale Carnegie - A Man of Influence/fullHtml/Day 55 亮解单词 Dale Carnegie - A Man of Influence.html",
"R:/全民英语背诵营 代码抓取 Html/Day 55 文本精讲 Dale Carnegie - A Man of Influence/fullHtml/Day 55 文本精讲 Dale Carnegie - A Man of Influence.html",
"R:/全民英语背诵营 代码抓取 Html/Day 56 带读训练 Arnold Schwarzenegger/fullHtml/Day 56 带读训练 Arnold Schwarzenegger.html",
"R:/全民英语背诵营 代码抓取 Html/Day 56 课后练习/fullHtml/Day 56 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 56 亮解单词 Arnold Schwarzenegger/fullHtml/Day 56 亮解单词 Arnold Schwarzenegger.html",
"R:/全民英语背诵营 代码抓取 Html/Day 56 文本精讲 Arnold Schwarzenegger/fullHtml/Day 56 文本精讲 Arnold Schwarzenegger.html",
"R:/全民英语背诵营 代码抓取 Html/Day 57 带读训练 Love’s Philosophy/fullHtml/Day 57 带读训练 Love’s Philosophy.html",
"R:/全民英语背诵营 代码抓取 Html/Day 57 课后练习/fullHtml/Day 57 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 57 亮解单词 Love’s Philosophy/fullHtml/Day 57 亮解单词 Love’s Philosophy.html",
"R:/全民英语背诵营 代码抓取 Html/Day 57 文本精讲 Love’s Philosophy/fullHtml/Day 57 文本精讲 Love’s Philosophy.html",
"R:/全民英语背诵营 代码抓取 Html/Day 58 带读训练 How Do I Love Thee/fullHtml/Day 58 带读训练 How Do I Love Thee.html",
"R:/全民英语背诵营 代码抓取 Html/Day 58 课后练习/fullHtml/Day 58 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 58 亮解单词 How Do I Love Thee/fullHtml/Day 58 亮解单词 How Do I Love Thee.html",
"R:/全民英语背诵营 代码抓取 Html/Day 58 文本精讲 How Do I Love Thee/fullHtml/Day 58 文本精讲 How Do I Love Thee.html",
"R:/全民英语背诵营 代码抓取 Html/Day 59 带读训练 Ann Landers—On Class/fullHtml/Day 59 带读训练 Ann Landers—On Class.html",
"R:/全民英语背诵营 代码抓取 Html/Day 59 课后练习/fullHtml/Day 59 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 59 亮解单词 Ann Landers—On Class/fullHtml/Day 59 亮解单词 Ann Landers—On Class.html",
"R:/全民英语背诵营 代码抓取 Html/Day 59 文本精讲 Ann Landers—On Class/fullHtml/Day 59 文本精讲 Ann Landers—On Class.html",
"R:/全民英语背诵营 代码抓取 Html/Day 60 带读训练 Albert Einstein—Never Lose a Holy Curiosity/fullHtml/Day 60 带读训练 Albert Einstein—Never Lose a Holy Curiosity.html",
"R:/全民英语背诵营 代码抓取 Html/Day 60 课后练习/fullHtml/Day 60 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 60 亮解单词 Albert Einstein—Never Lose a Holy Curiosity/fullHtml/Day 60 亮解单词 Albert Einstein—Never Lose a Holy Curiosity.html",
"R:/全民英语背诵营 代码抓取 Html/Day 60 文本精讲 Albert Einstein—Never Lose a Holy Curiosity/fullHtml/Day 60 文本精讲 Albert Einstein—Never Lose a Holy Curiosity.html",
"R:/全民英语背诵营 代码抓取 Html/Day 61 带读训练 East of Eden (Excerpt)/fullHtml/Day 61 带读训练 East of Eden (Excerpt).html",
"R:/全民英语背诵营 代码抓取 Html/Day 61 课后练习/fullHtml/Day 61 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 61 亮解单词 East of Eden (Excerpt)/fullHtml/Day 61 亮解单词 East of Eden (Excerpt).html",
"R:/全民英语背诵营 代码抓取 Html/Day 61 文本精讲 East of Eden (Excerpt)/fullHtml/Day 61 文本精讲 East of Eden (Excerpt).html",
"R:/全民英语背诵营 代码抓取 Html/Day 62 带读训练 In Search of Lost Time (Excerpt)/fullHtml/Day 62 带读训练 In Search of Lost Time (Excerpt).html",
"R:/全民英语背诵营 代码抓取 Html/Day 62 课后练习/fullHtml/Day 62 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 62 亮解单词 In Search of Lost Time (Excerpt)/fullHtml/Day 62 亮解单词 In Search of Lost Time (Excerpt).html",
"R:/全民英语背诵营 代码抓取 Html/Day 62 文本精讲 In Search of Lost Time (Excerpt)/fullHtml/Day 62 文本精讲 In Search of Lost Time (Excerpt).html",
"R:/全民英语背诵营 代码抓取 Html/Day 63 带读训练 Bottlenose Dolphins/fullHtml/Day 63 带读训练 Bottlenose Dolphins.html",
"R:/全民英语背诵营 代码抓取 Html/Day 63 课后练习/fullHtml/Day 63 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 63 亮解单词 Bottlenose Dolphins/fullHtml/Day 63 亮解单词 Bottlenose Dolphins.html",
"R:/全民英语背诵营 代码抓取 Html/Day 63 文本精讲 Bottlenose Dolphins/fullHtml/Day 63 文本精讲 Bottlenose Dolphins.html",
"R:/全民英语背诵营 代码抓取 Html/Day 64 带读训练 Jesus Christ Lizard/fullHtml/Day 64 带读训练 Jesus Christ Lizard.html",
"R:/全民英语背诵营 代码抓取 Html/Day 64 课后练习/fullHtml/Day 64 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 64 亮解单词 Jesus Christ Lizard/fullHtml/Day 64 亮解单词 Jesus Christ Lizard.html",
"R:/全民英语背诵营 代码抓取 Html/Day 64 文本精讲 Jesus Christ Lizard/fullHtml/Day 64 文本精讲 Jesus Christ Lizard.html",
"R:/全民英语背诵营 代码抓取 Html/Day 65 带读训练 Chameleon/fullHtml/Day 65 带读训练 Chameleon.html",
"R:/全民英语背诵营 代码抓取 Html/Day 65 课后练习/fullHtml/Day 65 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 65 亮解单词 Chameleon/fullHtml/Day 65 亮解单词 Chameleon.html",
"R:/全民英语背诵营 代码抓取 Html/Day 65 文本精讲 Chameleon/fullHtml/Day 65 文本精讲 Chameleon.html",
"R:/全民英语背诵营 代码抓取 Html/Day 66 带读训练 The Venus flytrap/fullHtml/Day 66 带读训练 The Venus flytrap.html",
"R:/全民英语背诵营 代码抓取 Html/Day 66 课后练习/fullHtml/Day 66 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 66 亮解单词 The Venus flytrap/fullHtml/Day 66 亮解单词 The Venus flytrap.html",
"R:/全民英语背诵营 代码抓取 Html/Day 66 文本精讲 The Venus flytrap/fullHtml/Day 66 文本精讲 The Venus flytrap.html",
"R:/全民英语背诵营 代码抓取 Html/Day 67 带读训练 Welcome to IMAX/fullHtml/Day 67 带读训练 Welcome to IMAX.html",
"R:/全民英语背诵营 代码抓取 Html/Day 67 课后练习/fullHtml/Day 67 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 67 亮解单词 Welcome to IMAX/fullHtml/Day 67 亮解单词 Welcome to IMAX.html",
"R:/全民英语背诵营 代码抓取 Html/Day 67 文本精讲 Welcome to IMAX/fullHtml/Day 67 文本精讲 Welcome to IMAX.html",
"R:/全民英语背诵营 代码抓取 Html/Day 68 带读训练 VR Motion Chairs/fullHtml/Day 68 带读训练 VR Motion Chairs.html",
"R:/全民英语背诵营 代码抓取 Html/Day 68 课后练习/fullHtml/Day 68 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 68 亮解单词 VR Motion Chairs/fullHtml/Day 68 亮解单词 VR Motion Chairs.html",
"R:/全民英语背诵营 代码抓取 Html/Day 68 文本精讲 VR Motion Chairs/fullHtml/Day 68 文本精讲 VR Motion Chairs.html",
"R:/全民英语背诵营 代码抓取 Html/Day 69 带读训练 Christianity/fullHtml/Day 69 带读训练 Christianity.html",
"R:/全民英语背诵营 代码抓取 Html/Day 69 课后练习/fullHtml/Day 69 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 69 亮解单词Christianity/fullHtml/Day 69 亮解单词Christianity.html",
"R:/全民英语背诵营 代码抓取 Html/Day 69 文本精讲 Christianity/fullHtml/Day 69 文本精讲 Christianity.html",
"R:/全民英语背诵营 代码抓取 Html/Day 70 亮解单词 Christianity2/fullHtml/Day 70 亮解单词 Christianity2.html",
"R:/全民英语背诵营 代码抓取 Html/Day 70 文本精讲 Christianity2/fullHtml/Day 70 文本精讲 Christianity2.html",
"R:/全民英语背诵营 代码抓取 Html/Day 70带读训练Christianity (2)/fullHtml/Day 70带读训练Christianity (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day 70课后练习/fullHtml/Day 70课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 71带读训练 Shrek 2—Opening Scene/fullHtml/Day 71带读训练 Shrek 2—Opening Scene.html",
"R:/全民英语背诵营 代码抓取 Html/Day 71课后练习/fullHtml/Day 71课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 71亮解单词 Shrek 2—Opening Scene/fullHtml/Day 71亮解单词 Shrek 2—Opening Scene.html",
"R:/全民英语背诵营 代码抓取 Html/Day 71文本精讲 Shrek 2—Opening Scene/fullHtml/Day 71文本精讲 Shrek 2—Opening Scene.html",
"R:/全民英语背诵营 代码抓取 Html/Day 72 亮解单词 X-men Prologues Compilation/fullHtml/Day 72 亮解单词 X-men Prologues Compilation.html",
"R:/全民英语背诵营 代码抓取 Html/Day 72带读训练 X-men Prologues Compilation/fullHtml/Day 72带读训练 X-men Prologues Compilation.html",
"R:/全民英语背诵营 代码抓取 Html/Day 72课后练习/fullHtml/Day 72课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 72文本精讲 X-men Prologues Compilation/fullHtml/Day 72文本精讲 X-men Prologues Compilation.html",
"R:/全民英语背诵营 代码抓取 Html/Day 73Hercules 带读训练/fullHtml/Day 73Hercules 带读训练.html",
"R:/全民英语背诵营 代码抓取 Html/Day 73Hercules 课后练习/fullHtml/Day 73Hercules 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 73亮解单词 Hercules/fullHtml/Day 73亮解单词 Hercules.html",
"R:/全民英语背诵营 代码抓取 Html/Day 73文本精讲Hercules/fullHtml/Day 73文本精讲Hercules.html",
"R:/全民英语背诵营 代码抓取 Html/Day 74带读训练 Earthlings/fullHtml/Day 74带读训练 Earthlings.html",
"R:/全民英语背诵营 代码抓取 Html/Day 74课后练习/fullHtml/Day 74课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 74亮解单词 Earthlings/fullHtml/Day 74亮解单词 Earthlings.html",
"R:/全民英语背诵营 代码抓取 Html/Day 74文本精讲 Earthlings/fullHtml/Day 74文本精讲 Earthlings.html",
"R:/全民英语背诵营 代码抓取 Html/Day 82 课后练习/fullHtml/Day 82 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 83 文本精讲 Gettysburg Address/fullHtml/Day 83 文本精讲 Gettysburg Address.html",
"R:/全民英语背诵营 代码抓取 Html/Day 84 课后练习/fullHtml/Day 84 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 84 文本精讲 Order of the Day/fullHtml/Day 84 文本精讲 Order of the Day.html",
"R:/全民英语背诵营 代码抓取 Html/Day 85 课后练习/fullHtml/Day 85 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 85 文本精讲 Fight For Liberty（1）/fullHtml/Day 85 文本精讲 Fight For Liberty（1）.html",
"R:/全民英语背诵营 代码抓取 Html/Day 86 课后练习/fullHtml/Day 86 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 87 文本精讲 Titanic (1)/fullHtml/Day 87 文本精讲 Titanic (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day 88 课后练习/fullHtml/Day 88 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 88 文本精讲 Titanic (2)/fullHtml/Day 88 文本精讲 Titanic (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day 89 课后练习/fullHtml/Day 89 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 89 文本精讲 Cancer/fullHtml/Day 89 文本精讲 Cancer.html",
"R:/全民英语背诵营 代码抓取 Html/Day 90 课后练习/fullHtml/Day 90 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 90 文本精讲 AIDS/fullHtml/Day 90 文本精讲 AIDS.html",
"R:/全民英语背诵营 代码抓取 Html/Day 91 带读训练 Solitude/fullHtml/Day 91 带读训练 Solitude.html",
"R:/全民英语背诵营 代码抓取 Html/Day 91 课后练习/fullHtml/Day 91 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 91 文本精讲 Solitude/fullHtml/Day 91 文本精讲 Solitude.html",
"R:/全民英语背诵营 代码抓取 Html/Day 91亮解单词 Solitude/fullHtml/Day 91亮解单词 Solitude.html",
"R:/全民英语背诵营 代码抓取 Html/Day 92 带读训练 If—/fullHtml/Day 92 带读训练 If—.html",
"R:/全民英语背诵营 代码抓取 Html/Day 92 文本精讲 If—/fullHtml/Day 92 文本精讲 If—.html",
"R:/全民英语背诵营 代码抓取 Html/Day 93 课后练习/fullHtml/Day 93 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 94 课后练习/fullHtml/Day 94 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 96 文本精讲 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (2)/fullHtml/Day 96 文本精讲 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day 99 带读训练The Moon and Sixpence - The Story Of Paul Gauguin/fullHtml/Day 99 带读训练The Moon and Sixpence - The Story Of Paul Gauguin.html",
"R:/全民英语背诵营 代码抓取 Html/Day 99 课后练习/fullHtml/Day 99 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 99 亮解单词 The Moon and Sixpence - The Story Of Paul Gauguin/fullHtml/Day 99 亮解单词 The Moon and Sixpence - The Story Of Paul Gauguin.html",
"R:/全民英语背诵营 代码抓取 Html/Day 99 文本精讲 The Moon and Sixpence - The Story Of Paul Gauguin/fullHtml/Day 99 文本精讲 The Moon and Sixpence - The Story Of Paul Gauguin.html",
"R:/全民英语背诵营 代码抓取 Html/Day 100 带读训练 Vincent van Gogh - Lust for Life 文森特·梵高渴望生活/fullHtml/Day 100 带读训练 Vincent van Gogh - Lust for Life 文森特·梵高渴望生活.html",
"R:/全民英语背诵营 代码抓取 Html/Day 100 课后练习/fullHtml/Day 100 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day 100 亮解单词 Vincent van Gogh - Lust for Life 文森特·梵高渴望生活/fullHtml/Day 100 亮解单词 Vincent van Gogh - Lust for Life 文森特·梵高渴望生活.html",
"R:/全民英语背诵营 代码抓取 Html/Day 100 文本精讲 Vincent van Gogh - Lust for Life 文森特·梵高渴望生活/fullHtml/Day 100 文本精讲 Vincent van Gogh - Lust for Life 文森特·梵高渴望生活.html",
"R:/全民英语背诵营 代码抓取 Html/Day75 带读训练 Michelangelo - artist and man (1)/fullHtml/Day75 带读训练 Michelangelo - artist and man (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day75 课后练习/fullHtml/Day75 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day75 亮解单词 Michelangelo - artist and man (1)/fullHtml/Day75 亮解单词 Michelangelo - artist and man (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day75 文本精讲 Michelangelo - artist and man (1)/fullHtml/Day75 文本精讲 Michelangelo - artist and man (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day76 课后练习/fullHtml/Day76 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day76带读训练 Michelangelo - artist and man (2)/fullHtml/Day76带读训练 Michelangelo - artist and man (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day76亮解单词Michelangelo - artist and man (2)/fullHtml/Day76亮解单词Michelangelo - artist and man (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day76文本精讲Michelangelo - artist and man (2)/fullHtml/Day76文本精讲Michelangelo - artist and man (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day77带读训练 Michelangelo - artist and man (3)/fullHtml/Day77带读训练 Michelangelo - artist and man (3).html",
"R:/全民英语背诵营 代码抓取 Html/Day77课后练习/fullHtml/Day77课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day77亮解单词 Michelangelo - artist and man (3)/fullHtml/Day77亮解单词 Michelangelo - artist and man (3).html",
"R:/全民英语背诵营 代码抓取 Html/Day77文本精讲 Michelangelo - artist and man (3)/fullHtml/Day77文本精讲 Michelangelo - artist and man (3).html",
"R:/全民英语背诵营 代码抓取 Html/Day78带读训练 Mark Twain & His Amazing Adventures/fullHtml/Day78带读训练 Mark Twain & His Amazing Adventures.html",
"R:/全民英语背诵营 代码抓取 Html/Day78课后练习/fullHtml/Day78课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day78亮解单词 Mark Twain & His Amazing Adventures/fullHtml/Day78亮解单词 Mark Twain & His Amazing Adventures.html",
"R:/全民英语背诵营 代码抓取 Html/Day78文本精讲 Mark Twain & His Amazing Adventures/fullHtml/Day78文本精讲 Mark Twain & His Amazing Adventures.html",
"R:/全民英语背诵营 代码抓取 Html/Day79 带读训练 The Summing Up (Excerpts)/fullHtml/Day79 带读训练 The Summing Up (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day79 课后练习/fullHtml/Day79 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day79 亮解单词 The Summing Up (Excerpts)/fullHtml/Day79 亮解单词 The Summing Up (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day79 文本精讲 The Summing Up (Excerpts)/fullHtml/Day79 文本精讲 The Summing Up (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day80 带读训练 Three Days to See (Excerpts)/fullHtml/Day80 带读训练 Three Days to See (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day80 课后练习/fullHtml/Day80 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day80 亮解单词 Three Days to See (Excerpts)/fullHtml/Day80 亮解单词 Three Days to See (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day80 文本精讲 Three Days to See (Excerpts)/fullHtml/Day80 文本精讲 Three Days to See (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day81 带读训练 More Was Never Enough (Excerpts)/fullHtml/Day81 带读训练 More Was Never Enough (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day81 课后练习/fullHtml/Day81 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day81 亮解单词 More Was Never Enough (Excerpts)/fullHtml/Day81 亮解单词 More Was Never Enough (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day81 文本精讲 More Was Never Enough (Excerpts)/fullHtml/Day81 文本精讲 More Was Never Enough (Excerpts).html",
"R:/全民英语背诵营 代码抓取 Html/Day82 带读训练 Youth/fullHtml/Day82 带读训练 Youth.html",
"R:/全民英语背诵营 代码抓取 Html/Day82 亮解单词 Youth/fullHtml/Day82 亮解单词 Youth.html",
"R:/全民英语背诵营 代码抓取 Html/Day82 文本精讲 Youth/fullHtml/Day82 文本精讲 Youth.html",
"R:/全民英语背诵营 代码抓取 Html/Day83 带读训练 Gettysburg Address/fullHtml/Day83 带读训练 Gettysburg Address.html",
"R:/全民英语背诵营 代码抓取 Html/Day83 课后练习/fullHtml/Day83 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day83 亮解单词 Gettysburg Address/fullHtml/Day83 亮解单词 Gettysburg Address.html",
"R:/全民英语背诵营 代码抓取 Html/Day84 带读训练 Order of the Day/fullHtml/Day84 带读训练 Order of the Day.html",
"R:/全民英语背诵营 代码抓取 Html/Day84 亮解单词 Order of the Day/fullHtml/Day84 亮解单词 Order of the Day.html",
"R:/全民英语背诵营 代码抓取 Html/Day85 带读训练 Fight For Liberty (1)/fullHtml/Day85 带读训练 Fight For Liberty (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day85 亮解单词 Fight For Liberty (1)/fullHtml/Day85 亮解单词 Fight For Liberty (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day86 带读训练 Fight For Liberty (2)/fullHtml/Day86 带读训练 Fight For Liberty (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day86 亮解单词 Fight For Liberty (2)/fullHtml/Day86 亮解单词 Fight For Liberty (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day86 文本精讲 Fight For Liberty (2)/fullHtml/Day86 文本精讲 Fight For Liberty (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day87 带读训练 Titanic (1)/fullHtml/Day87 带读训练 Titanic (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day87 课后练习/fullHtml/Day87 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day87 亮解单词 Titanic (1)/fullHtml/Day87 亮解单词 Titanic (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day88 带读训练 Titanic（2）/fullHtml/Day88 带读训练 Titanic（2）.html",
"R:/全民英语背诵营 代码抓取 Html/Day88 亮解单词 Titanic (2)/fullHtml/Day88 亮解单词 Titanic (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day89 带读训练 Cancer/fullHtml/Day89 带读训练 Cancer.html",
"R:/全民英语背诵营 代码抓取 Html/Day89 亮解单词 Cancer/fullHtml/Day89 亮解单词 Cancer.html",
"R:/全民英语背诵营 代码抓取 Html/Day90 带读训练 AIDS/fullHtml/Day90 带读训练 AIDS.html",
"R:/全民英语背诵营 代码抓取 Html/Day90 亮解单词 AIDS/fullHtml/Day90 亮解单词 AIDS.html",
"R:/全民英语背诵营 代码抓取 Html/Day92 课后练习/fullHtml/Day92 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day92 亮解单词 If—/fullHtml/Day92 亮解单词 If—.html",
"R:/全民英语背诵营 代码抓取 Html/Day93 带读训练 Outliers - The Story of Success (1)/fullHtml/Day93 带读训练 Outliers - The Story of Success (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day93 亮解单词 Outliers - The Story of Success (1)/fullHtml/Day93 亮解单词 Outliers - The Story of Success (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day93 文本精讲 Outliers - The Story of Success (1)/fullHtml/Day93 文本精讲 Outliers - The Story of Success (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day94 带读训练 Outliers - The Story of Success (2)/fullHtml/Day94 带读训练 Outliers - The Story of Success (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day94 亮解单词 Outliers - The Story of Success (2)/fullHtml/Day94 亮解单词 Outliers - The Story of Success (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day94 文本精讲 Outliers - The Story of Success (2)/fullHtml/Day94 文本精讲 Outliers - The Story of Success (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day95 带读训练 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (1)/fullHtml/Day95 带读训练 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day95 课后练习/fullHtml/Day95 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day95 亮解单词 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (1)/fullHtml/Day95 亮解单词 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day95 文本精讲 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (1)/fullHtml/Day95 文本精讲 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (1).html",
"R:/全民英语背诵营 代码抓取 Html/Day96 带读训练 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (2)/fullHtml/Day96 带读训练 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day96 课后练习/fullHtml/Day96 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day96 亮解单词 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (2)/fullHtml/Day96 亮解单词 The Attention Merchants —The Epic Scramble to Get Inside Our Heads (2).html",
"R:/全民英语背诵营 代码抓取 Html/Day97 带读训练 DJI - Introducing the Phantom 4/fullHtml/Day97 带读训练 DJI - Introducing the Phantom 4.html",
"R:/全民英语背诵营 代码抓取 Html/Day97 课后练习/fullHtml/Day97 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day97 亮解单词 DJI - Introducing the Phantom 4/fullHtml/Day97 亮解单词 DJI - Introducing the Phantom 4.html",
"R:/全民英语背诵营 代码抓取 Html/Day97 文本精讲 DJI - Introducing the Phantom 4/fullHtml/Day97 文本精讲 DJI - Introducing the Phantom 4.html",
"R:/全民英语背诵营 代码抓取 Html/Day98 带读训练 DJI - Introducing the Mavic Air/fullHtml/Day98 带读训练 DJI - Introducing the Mavic Air.html",
"R:/全民英语背诵营 代码抓取 Html/Day98 课后练习/fullHtml/Day98 课后练习.html",
"R:/全民英语背诵营 代码抓取 Html/Day98 亮解单词 DJI - Introducing the Mavic Air/fullHtml/Day98 亮解单词 DJI - Introducing the Mavic Air.html",
"R:/全民英语背诵营 代码抓取 Html/Day98 文本精讲 DJI - Introducing the Mavic Air/fullHtml/Day98 文本精讲 DJI - Introducing the Mavic Air.html",
"R:/全民英语背诵营 代码抓取 Html/导语 全民英语背诵营·一背解千愁/fullHtml/导语 全民英语背诵营·一背解千愁.html"]
    tot = len(fileList)
    cur = 0
    for fName in fileList:
        f = open(fName, 'r', encoding='UTF-8')
        html = f.read()
        f.close()
        html = clearHtml(html, True)
        html = clearDefCSSValue(html)
        f = open(fName, 'w', encoding='UTF-8')
        f.write(html)
        f.close()

        cur += 1
        print('%s' % (cur / tot * 100) + '%')


tempClear()
print('Done')
exit()

f = open('r:/Day1.html', 'r', encoding='UTF-8')
html = f.read()
f.close()
html = clearDefCSSValue123(html)
f = open('r:/Clear.html', 'w', encoding='UTF-8')
f.write(html)
f.close()
exit()

f = open('r:/Day2.html', 'r', encoding='UTF-8')
html = f.read()
regExp = ".src-components-Calendar-index__linkRank--2eBgk[^\{]+\{[^\}]+\}"
regExp = ".src-components-CommentZone-CommentZoneNew-index__clockLink--5SOc-:[^\{]+\{[^\}]+\}"
match = re.findall(regExp, html)
print(len(match))
print(match[0])
# print(re.sub(regExp, '', html))
f.close()

exit()

f = open('r:/Day1.html', 'r', encoding='UTF-8')
html = f.read()
f.close()
bs = BeautifulSoup(html, "html.parser")
for sty in bs.find_all('style', {"type": 'text/css'}):
    print(sty)
    bs.css
    for delSty in sty.find_all('ipadxw'):
        print(delSty)

    break
exit()

driverFileName = os.environ.get("Project").replace('\\',
                                                   '/') + '/AllInGitHub/CommonDriver/ChromeDriver/chromedriver.exe'
print(driverFileName)
print(os.path.exists(driverFileName))
exit()

print(os.environ.get("Project"))  # 系统 Path
print(os.getcwd())  # 当前目录
exit()

os.system(
    'ffmpeg -i http://ydschool-video.nosdn.127.net/156747737223901+E38-1%C2%B7+Transformers+Opening+Scene%E3%80%8A%E5%8F%98%E5%BD%A2%E9%87%91%E5%88%9A%E3%80%8B%E5%BC%80%E5%9C%BA%EF%BC%88%E6%96%87%E6%9C%AC%E7%B2%BE%E8%AE%B2%EF%BC%89.mp3 -vcodec copy -acodec copy "R:\\Day 38文本精讲 Transformers Opening Scene （《变形金刚》开场）\\audio1.mp3"')
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
