import os
import re
import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver
import GeekTime.webpage2html as web2html

# 是否去掉评论区（默认 False）
clearCommentNode = True
clearCommentNodeFullHtml = True
# 是否下载媒体资源
downloadMedia = True #and False
courseListFile = 'R:/死磕团词串记忆树.txt'
targetPath = 'r:/死磕团词串记忆树'

realDir = os.path.dirname(os.path.realpath(__file__))

def getDriver():
    # 定义chromedriver路径
    # driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
    # driver_path = 'r:\\chromedriver.exe'
    driver_path = os.environ.get("Project").replace('\\', '/') + '/AllPrivateProject/CommonDriver/ChromeDriver/chromedriver.exe'

    # 获取chrome浏览器驱动
    return webdriver.Chrome(executable_path=driver_path)

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
        zhanKai = driver.find_element_by_xpath('/html/body/div/article/section/div[2]/a')
        if zhanKai is None:
            zhanKai = driver.find_element_by_class_name('src-components-Article-index__articleMore--Nk2NZ')
            zhanKai = zhanKai.find_element_by_tag_name('a')
        if zhanKai is not None:
            # 页面滚动到指定元素
            driver.execute_script("arguments[0].scrollIntoView();", zhanKai)
            driver.implicitly_wait(5)
            zhanKai.click()
            driver.implicitly_wait(2)
    except:
        pass

# 点击页面上的 播放视频
def ClickPlayVideo(driver):
    try:
        divsVideoPlay = driver.find_elements_by_class_name('video-play-btn')
        if divsVideoPlay is not None:
            for divVideoPlay in divsVideoPlay:
                divToClick = divVideoPlay.find_element_by_tag_name('div')
                if divToClick is not None:
                    divToClick = divToClick.find_element_by_class_name('video-cover')
                    if divToClick is not None:
                        # 页面滚动到指定元素
                        driver.execute_script("arguments[0].scrollIntoView();", divToClick)

                        divToClick.click()
                        driver.implicitly_wait(5)
                        time.sleep(3)

            # 点完返回头上去
            driver.execute_script('window.scrollBy(0,-100000)')
    except:
        pass

# 滚到最底端，获取完整的网页内容
def scrollDrive2Bottom(driver):
    pageHeight_orig = driver.execute_script('return document.documentElement.scrollTop')
    while True:
        # 5000 快速滚动；1000 慢速滚动
        # 缓慢滚动有利于加载图片
        driver.execute_script('window.scrollBy(0,500)')
        time.sleep(1)
        pageHeight_new = driver.execute_script('return document.documentElement.scrollTop')

        if pageHeight_new == pageHeight_orig:
            break
        else:
            pageHeight_orig = pageHeight_new

# document.body.scrollHeight
# document.documentElement.scrollTop

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

def saveHtml(html, tarTitle, artExportPath):
    fullHtmlPath = (artExportPath + '/' + 'fullHtml' + '/').replace("//", "/")
    htmlFileName = (artExportPath + '/' + tarTitle + '.html').replace("//", "/")
    fullHtmlFileName = (fullHtmlPath + '/' + tarTitle + '.html').replace("//", "/")

    if fullHtmlPath and not os.path.exists(fullHtmlPath):
        os.makedirs(fullHtmlPath)

    # 清洗
    html = clearHtml(html, clearCommentNode)

    # 保存
    htmlFile = open(htmlFileName, 'w', encoding='UTF-8')
    htmlFile.write(html)

    # 保存 fullHtml
    fullHtml = web2html.generate(htmlFileName, comment=False, full_url=True, verbose=True)
    fullHtml = clearHtml(fullHtml, clearCommentNodeFullHtml) # 去掉评论区
    fullHtml = clearDefCSSValue(fullHtml) # 清除 fullHtml 中多余的 css 打包对象
    fullHtmlFile = open(fullHtmlFileName, 'w', encoding='UTF-8')
    fullHtmlFile.write(fullHtml)
    fullHtmlFile.close()

# 替换播放音频控件
def replaceAudioControl(html):
    # 音乐、视频播放的模板
    mediaMod = '<div class="video-play-btn" data-inited="true"><video controls="controls" src="@SourceUrl"></video></div>'

    bs = BeautifulSoup(html, "html.parser")

    for audioCube in bs.find_all("div", {"class": 'audioCube'}):
        classInfo = audioCube.find("div", {"class": 'info'})
        if classInfo.attrs['src'] is not None:
            srcUrl = classInfo.attrs['src']
            newHtml = mediaMod.replace('@SourceUrl', srcUrl)
            newNod = BeautifulSoup(newHtml, "html.parser")
            audioCube.replaceWith(newNod)

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

def processHtml(html, tarTitle):
    """
    处理 HTML 源码，生成 HTML，下载资源
    :param html: 原始网页的 html 源码
    :param tarTitle:生成文件的标题
    :return:
    """
    artExportPath = ( targetPath + '/' + tarTitle + '/').replace("//", "/")
    if artExportPath and not os.path.exists(artExportPath):
        os.makedirs(artExportPath)

    bs = BeautifulSoup(html, "html.parser")

    # 获取 音频 文件列表
    audioList = []
    for classInfo in bs.find_all("div", {"class": 'info'}):
        if classInfo.attrs['src'] is not None and classInfo.attrs['src'] not in audioList:
            audioList.append(classInfo.attrs['src'])

    # 获取 视频 文件列表
    videoList = []
    for classVideoPlayBtn in bs.find_all("div", {"class": 'video-play-btn'}):
        tagVideo = classVideoPlayBtn.find('video')
        if tagVideo is not None:
            if tagVideo.attrs['src'] is not None and tagVideo.attrs['src'] not in videoList:
                videoList.append(tagVideo.attrs['src'])


    # 写 ffmpeg 下载列表
    ffmpegCmdList = []
    oneItem = len(audioList) == 1
    i = 1
    for audioUrl in audioList:
        suffix = audioUrl[audioUrl.rfind('.'):]
        if not oneItem:
            suffix = repr(i) + suffix
        expFileName = artExportPath + 'audio' + suffix
        if not os.path.exists(expFileName):
            ffmpeg = 'ffmpeg -i %s -vcodec copy -acodec copy "%s"\n' % (audioUrl, expFileName)
            ffmpegFileName = artExportPath + "ffmpegDownList.txt"
            ffmpegListFile = open(ffmpegFileName, 'a', encoding='UTF-8')  # 有可能文件夹名称包含特殊字符，使用 gb2312 会报错
            ffmpegListFile.write(ffmpeg)
            ffmpegListFile.close()
            ffmpegCmdList.append(ffmpeg)
            i += 1

    oneItem = len(videoList) == 1
    i = 1
    for videoUrl in videoList:
        suffix = videoUrl[videoUrl.rfind('.'):]
        if not oneItem:
            suffix = repr(i) + suffix
        expFileName = artExportPath + 'video' + suffix
        if not os.path.exists(expFileName):
            ffmpeg = 'ffmpeg -i %s -vcodec copy -acodec copy "%s"\n' % (videoUrl, expFileName)
            ffmpegFileName = artExportPath + "ffmpegDownList.txt"
            ffmpegListFile = open(ffmpegFileName, 'a', encoding='UTF-8')  # gb2312
            ffmpegListFile.write(ffmpeg)
            ffmpegListFile.close()
            ffmpegCmdList.append(ffmpeg)
            i += 1

    # 替换播放音频控件
    html = replaceAudioControl(html)

    # 保存 HTML
    saveHtml(html, tarTitle, artExportPath)

    # 直接调用命令来下载
    if downloadMedia:
        for cmdLine in ffmpegCmdList:
            os.system(cmdLine)

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


            # 是否直接删除评论区
            if clearCommentNode:
                try:
                    elements = driver.find_elements_by_class_name("src-components-CommentZone-CommentZoneNew-index__commentWrapper--1Y8Bw")
                    for CommentZone in elements:
                        driver.execute_script("var element = arguments[0]; element.parentNode.removeChild(element);", CommentZone)

                    elements = driver.find_elements_by_id("lunaComment")
                    for CommentZone in elements:
                        driver.execute_script("var element = arguments[0]; element.parentNode.removeChild(element);", CommentZone)
                except:
                    pass


                # 点击页面上的 播放视频
            ClickPlayVideo(driver)

            # 滚到最底端，获取完整的网页内容
            scrollDrive2Bottom(driver)

            # 处理 HTML 源码，生成文件，下载资源
            processHtml(driver.page_source, tarTitle)
        except Exception as e:
            # print(e)
            errList.append((title, url))

        # 爬一篇文章后休息几秒钟
        catchCount += 1
        time.sleep(3)
        print("\n\n")

        # break

    # 记录爬取文章的结束时间
    end = time.time()

    print("所有文章爬取完毕！共 %d 篇，耗时 %d 秒" % (catchCount, int(end - start)))

    if len(errList) > 0:
        print("失败的抓取：")
        for title, url in errList:
            print("%s   : %s" % (title, url))

if __name__ == '__main__':

    main()


# todo 去掉下面 css 的 base 64，太大，又没用
'''
.src-components-ListEmpty-index__container--3STMO:before {
    <article class="src-components-ListEmpty-index__container--3STMO undefined"><p class="src-components-ListEmpty-index__desc--2Fa8z">还是空的，快去抢先评论吧！</p></article>

这里会有多个
.src-components-Article-ArticleContent-index__articleContent--TJtbr.src-components-Article-ArticleContent-index__forTeenager--3Y5pQ {
   
.src-components-Clock-User-index__container--HznrX

.src-pages-Error-index__container--39-lj:before

.audioCube.forTeenager .btn.play
.audioCube.forTeenager .btn.pause
.src-components-Calendar-index__simpleOpenUp--36XVT

.src-components-Calendar-index__linkRank--2eBgk:before {
.src-components-Calendar-index__linkLog--3DlfR:before {
.src-components-Calendar-index__completeCloseUp--24XA9 {
.src-components-Article-index__articleMore--Nk2NZ {
.src-components-ListLoading-index__loading--5w2A5 {
.src-pages-Article-index__commentBtnLike--1uDqJ {
.src-pages-Article-index__commentBtnLikeActive--2chyr {
.src-components-Clock-User-index__rankTitle--3Uk89
.src-components-Clock-User-index__logTitle--3_q0r {
.src-components-Clock-User-index__logTitleHideRank--39DxK {
.audioCube.normal .btn.play {
.audioCube.normal .btn.pause {
.audioCube.normal .control input[type=range]::-webkit-slider-thumb {    
.audioCube.forTeenager .control input[type=range]::-webkit-slider-thumb {
.src-components-Calendar-index__signHasClock--2m1JZ {
.src-components-Calendar-index__signNotClock--1-I7- {
.src-components-CommentZone-CommentZoneNew-index__quizLink--3zhC1:before {
.src-components-CommentZone-CommentZoneNew-index__videoLink--1AYZR:before {
.src-components-Comment-index__deleteCommentBtn--1JF3l {


    .src-components-CommentZone-CommentZoneNew-index__clockLink--5SOc-:before,
    .src-components-CommentZone-CommentZoneNew-index__missClockLink--2rcyK:before {

from bs4 import BeautifulSoup
#去除属性ul
[s.extract() for s in soup("ul")]
# 去除属性svg
[s.extract() for s in soup("svg")]
# 去除属性script
[s.extract() for s in soup("script")]
————————————————

#去除注释
comments = soup.findAll(text=lambda text: isinstance(text, Comment))
[comment.extract() for comment in comments]
'''