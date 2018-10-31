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

baseUrl = "http://www.ituring.com.cn"
illegalNameChar = r"[\/\\\:\*\?\"\<\>\|]"


# noinspection PyBroadException
class ScrapITuring():
    AccountVerified = False
    TargetFolder = "r:\\"
    contentClassId = ("markdown-body", "post-text")
    navHeaderClass = (("li", "nav-header", True), ("div", "rounded-box", False))

    headersBasic = {
        "User-Agent": "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36",
        # "User-Agent": "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E) ",
        "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
        "Accept-Encoding": "gzip, deflate",
        "Accept-Language": "zh-CN,zh;q=0.8,en;q=0.6"
    }
    session = requests.session()
    fileNum = 1;
    webpageHtml = ""
    cssDict = {}
    picDict = {}
    artName = ""
    webBrowser = None

    CoverPicURL = ""

    def __init__ (self, bookName = "", addHeader = False):
        self.BookName = bookName
        self.AddHeader = addHeader

        moduleFile = open("ModulePage.html", 'rt', encoding = 'UTF-8')
        self.modulePage = moduleFile.read()
        moduleFile.close()

    def Close(self):
        try:
            if self.webBrowser is not None:
                self.webBrowser.quit()

            self.session.close()
        except:
            pass

    # 登录网站
    def LoginAccount (self):
        try:
            urlLogon = "http://www.ituring.com.cn/account/logon"

            # Get Cookies Token
            s = self.session.get(urlLogon, headers = self.headersBasic)
            origCookies = s.cookies
            origCookiesDic = origCookies.get_dict()

            # Get input form Token
            bsObj = BeautifulSoup(s.text, "html.parser")
            inputTagToken = bsObj.find("input", {"name": "__RequestVerificationToken"})

            print("CookiesToken: %s" % origCookiesDic["__RequestVerificationToken"])
            print("InputFormToken: %s" % inputTagToken.attrs["value"])

            params = {'UserName': 'chanfengsr',
                      'Password': '0319026',
                      'RememberMe': 'false',
                      '__RequestVerificationToken': inputTagToken.attrs["value"]
                      }

            headersLogon = self.headersBasic.copy()
            headersLogon["Cookie"] = "iTuringAnonymousUser=%s;__RequestVerificationToken=%s" \
                                     % (origCookiesDic["iTuringAnonymousUser"],
                                        origCookiesDic["__RequestVerificationToken"])

            # login...
            time.sleep(3)
            s = self.session.post(urlLogon, params, headers = headersLogon)
            print("Login cookies:")
            print(s.headers)

            self.AccountVerified = True
        except Exception as ex:
            print(ex)

    # 生成文件名前的序号
    def GetFileNum (self, fileNum = None):
        if fileNum is not None:
            self.fileNum = fileNum

        self.fileNum += 1

        # return ("0" + repr(self.fileNum - 1))[-2:]
        return ("00" + repr(self.fileNum - 1))[-3:]

    # 抓网页内容
    def ScrapOrigHtml (self, artUrl):
        if not self.AccountVerified:
            self.LoginAccount()

        if not self.AccountVerified:
            print("Web site login failed.")
            return

        time.sleep(3)
        s = self.session.get(artUrl, headers = self.headersBasic)
        self.webpageHtml = s.text

        return self.webpageHtml

    def FormatHtml (self, pageHtml, onlyRepScript = False):
        pageHtml = pageHtml.replace("<script src=\"/", "<script src=\"http://www.ituring.com.cn/")
        # pageHtml = pageHtml.replace("href=\"/\"", "href=\"http://www.ituring.com.cn\"")
        # pageHtml = pageHtml.replace("href=\"/", "href=\"http://www.ituring.com.cn/")
        # pageHtml = pageHtml.replace("src=\"/", "src=\"http://www.ituring.com.cn/")

        if onlyRepScript:
            return pageHtml
        else:
            # 查看原图 功能调用JS时会自动实现
            '''
            bs = BeautifulSoup(pageHtml, "html.parser")

            insStr = "<a href=\"%s\" target=\"_blank\" class=\"img-origin\">[+]查看原图</a></p>"
            imgTagList = bs.findAll("img")
            for imgTag in imgTagList:
                if imgTag.attrs["src"].strip().endswith(".small"):
                    tagIns = BeautifulSoup(insStr % imgTag.attrs["src"].replace(".small", ".big"), "html.parser")
                    imgTag.parent.append(tagIns)

            return repr(bs)
            '''
            return pageHtml

    # 获得文章实体
    def GetArticleContent (self, pageHtml = None):
        if (pageHtml is None):
            pageHtml = self.webpageHtml

        bs = BeautifulSoup(pageHtml, "html.parser")
        for classId in self.contentClassId:
            tag = bs.find("div", {"class": classId})
            if (tag is not None):
                return repr(tag)

        return pageHtml

    # 书名
    def GetBookName (self, pageHtml = None):
        if len(self.BookName) > 0:
            return self.BookName

        if pageHtml is None:
            pageHtml = self.webpageHtml

        bs = BeautifulSoup(pageHtml, "html.parser")
        for nhC in self.navHeaderClass:
            tagName, classId, singleElement = nhC

            tag = bs.find(tagName, {"class": classId})
            if tag is not None:
                if singleElement:
                    self.BookName = tag.get_text().strip()
                else:
                    self.BookName = tag.find("a").get_text().strip()

            if (len(self.BookName) > 0):
                break

        return self.BookName

    def __GetArticleList_bookCatalog (self, pageHtml):
        artList = []
        bs = BeautifulSoup(pageHtml, "html.parser")

        if bs.find("div", {"class": "tab-pane active"}).find("tbody") == None:
            listTr = bs.find("div", {"class": "tab-pane active"}).find("table").findAll("tr")
        else:
            listTr = bs.find("div", {"class": "tab-pane active"}).tbody.findAll("tr")

        for tagtr in listTr:
            tagtd = tagtr.find("td")
            # print("(r\"(%s)%s\", \"%s\")," % (self.GetFileNum(), tagtd.get_text().strip(), self.GetAbsoluteURL(tagtd.a.attrs["href"])))
            artList.append(("(%s)%s" % (self.GetFileNum(), tagtd.get_text().strip()), self.GetAbsoluteURL(tagtd.a.attrs["href"])))

        return artList

    def __GetArticleList_ulbox (self, pageHtml):
        artList = []
        bs = BeautifulSoup(pageHtml, "html.parser")

        listA = bs.find("ul", {"class": "ul-box"}).findAll("a")
        for tagA in listA:
            if self.GetAbsoluteURL(tagA.attrs["href"]).find("article/") > -1:
                # print("(r\"(%s)%s\", \"%s\")," % (self.GetFileNum(), tagA.get_text().strip(), self.GetAbsoluteURL(tagA.attrs["href"])))
                artList.append(("(%s)%s" % (self.GetFileNum(), tagA.get_text().strip()), self.GetAbsoluteURL(tagA.attrs["href"])))

        return artList

    def __GetArticleList_artCollect (self, pageHtml):
        artList = []
        # fmtString = "(r\"(%s)%s\", \"%s\"),"
        # fmtStringSub = "(r\"(%s)  %s\", \"%s\"),"

        bs = BeautifulSoup(pageHtml, "html.parser")
        lstDivMinibook = bs.findAll("div", {"class", "minibook-item"})
        for tagMinibook in lstDivMinibook:
            tagH3 = tagMinibook.find("a", {"class", "question-hyperlink"})
            # print(fmtString % (self.GetFileNum(), tagH3.get_text().strip(), self.GetAbsoluteURL(tagH3.attrs["href"])))
            artList.append(("(%s)%s" % (self.GetFileNum(), tagH3.get_text().strip()), self.GetAbsoluteURL(tagH3.attrs["href"])))

            lstSub = tagMinibook.find("ul").findAll("li")
            for tagSub in lstSub:
                tagA = tagSub.a
                # print(fmtStringSub % (self.GetFileNum(), tagA.get_text().strip(), self.GetAbsoluteURL(tagA.attrs["href"])))
                artList.append(("(%s)  %s" % (self.GetFileNum(), tagA.get_text().strip()), self.GetAbsoluteURL(tagA.attrs["href"])))

        return artList

    def __GetArticleList_bookHead(self, pageHtml):
        artList = []

        bs = BeautifulSoup(pageHtml, "html.parser")
        trList = bs.find("table", {"class", "table table-striped"}).findAll("tr")
        for tr in trList:
            td = tr.td
            tagA = td.a
            artList.append(("(%s)%s" % (self.GetFileNum(), tagA.get_text().strip()), self.GetAbsoluteURL(tagA.attrs["href"])))

        # 获取封面大图路径
        tagA = bs.find("div", {"class", "book-cover-box wide"}).a
        if tagA is not None:
            self.CoverPicURL = self.GetAbsoluteURL(tagA.attrs["href"])

        return artList

    def GetArticleList (self, pageType = "bookHead", pageHtml = None):
        if pageHtml is None:
            pageHtml = self.webpageHtml

        if pageType == "bookHead":
            artListOrig = self.__GetArticleList_bookHead(pageHtml)
        elif pageType == "bookCatalog":
            artListOrig = self.__GetArticleList_bookCatalog(pageHtml)
        elif pageType == "ul-box":
            artListOrig = self.__GetArticleList_ulbox(pageHtml)
        elif pageType == "artCollect":
            artListOrig = self.__GetArticleList_artCollect(pageHtml)

        fmtString = "(r\"%s\", \"%s\"),"
        for art in artListOrig:
            curArtName, curArtUrl = art
            print(fmtString % (curArtName, curArtUrl))

        return artListOrig

    # 生成下载文件夹
    def CreatDownloadFolder (self):
        self.GetBookName()
        self.BookFolder = (self.TargetFolder + "\\" + re.sub(illegalNameChar, "_", self.BookName)).replace("\\\\", "\\")
        self.TempBookFolder = self.BookFolder + "\\temp"
        self.CssFolder = (self.BookFolder + "\\" + "Css").replace("\\\\", "\\")
        self.AccessoriesFolder = (self.BookFolder + "\\" + "Accessories").replace("\\\\", "\\")

        if not os.path.exists(self.TempBookFolder):
            os.makedirs(self.TempBookFolder)

        if not os.path.exists(self.CssFolder):
            os.makedirs(self.CssFolder)

        if not os.path.exists(self.AccessoriesFolder):
            os.makedirs(self.AccessoriesFolder)

    # 实际下载路径
    def GetAbsoluteURL (self, source):
        if source.startswith("http://www."):
            url = "http://" + source[11:]
        elif source.startswith("http://"):
            url = source
        elif source.startswith("www."):
            url = "http://" + source[4:]
        elif source.startswith("/"):
            url = baseUrl + source
        else:
            url = baseUrl + "/" + source

        # if baseUrl not in url:
        #     return None

        return url

    # 替换后的本地路径
    def GetPicLocalPath (self, md5, origHref, absolute = False):
        if origHref.endswith(".gif"):
            absolutePath = self.AccessoriesFolder + "\\" + md5 + ".gif"
        elif origHref.endswith(".png"):
            absolutePath = self.AccessoriesFolder + "\\" + md5 + ".png"
        elif origHref.endswith(".swf"):
            absolutePath = self.AccessoriesFolder + "\\" + md5 + ".swf"
        else:
            absolutePath = self.AccessoriesFolder + "\\" + md5 + ".jpg"

        if absolute:
            return absolutePath
        else:
            return absolutePath.replace(self.BookFolder, "")

    # 获取 Css 及 Picture 待下 Dict
    # cssDict{md5Val:[url, localFilePath]}
    # picDict{md5Val:[url, localFilePath]}
    def GetDownloadDic (self, articleHtml = None):
        if articleHtml is None:
            articleHtml = self.GetArticleContent()

        cssDict = {}
        bs = BeautifulSoup(self.webpageHtml, "html.parser")
        cssTag = bs.find("link", {"rel": "stylesheet"})
        if (cssTag is not None):
            url = cssTag.attrs["href"].strip()
            md5Val = hashlib.md5(url.encode()).hexdigest()
            cssDict[md5Val] = [url, ("%s\\%s.css" % (self.CssFolder, md5Val))]

        picDict = {}
        bs = BeautifulSoup(articleHtml, "html.parser")
        imgList = bs.findAll("img")
        for imgTag in imgList:
            url = imgTag.attrs["src"]
            md5Val = md5Val = hashlib.md5(url.encode()).hexdigest()
            picDict[md5Val] = [url, self.GetPicLocalPath(md5Val, url, True)]

        imgList = bs.findAll("a", {"class": "img-origin"})
        for imgTag in imgList:
            url = imgTag.attrs["href"]
            md5Val = md5Val = hashlib.md5(url.encode()).hexdigest()
            picDict[md5Val] = [url, self.GetPicLocalPath(md5Val, url, True)]

        return [cssDict, picDict]

    # 下载 CSS 及 图片
    def DownloadFile(self):
        for kMd5, [vOrigUrl, vLocalPath] in self.cssDict.items():
            if not os.path.exists(vLocalPath):
                urlretrieve(self.GetAbsoluteURL(vOrigUrl), vLocalPath)

        for kMd5, [vOrigUrl, vLocalPath] in self.picDict.items():
            if not os.path.exists(vLocalPath):
                urlretrieve(self.GetAbsoluteURL(vOrigUrl), vLocalPath)

    # 下载封面
    def DownloadCoverPic(self):
        if self.CoverPicURL != "":
            self.CreatDownloadFolder()

            coverPicLocPath = self.BookFolder + "\\Cover.jpg";
            if not os.path.exists(coverPicLocPath):
                urlretrieve(self.CoverPicURL, coverPicLocPath)

    # 替换原始的 css、图片 链接
    def ReplaceOrigUrl (self, contHtml):
        for kMd5, [vOrigUrl, vLocalPath] in self.cssDict.items():
            contHtml = contHtml.replace(vOrigUrl, vLocalPath.replace(self.BookFolder, "."))

        for kMd5, [vOrigUrl, vLocalPath] in self.picDict.items():
            contHtml = contHtml.replace(vOrigUrl, vLocalPath.replace(self.BookFolder, "."))

        return contHtml

    # 物理文件名
    def ScrapFileName(self, artName, folderPath = ''):
        if len(folderPath) > 0:
            return "%s\\%s.html" % (folderPath, re.sub(illegalNameChar, "_", artName))
        else:
            return "%s.html" % re.sub(illegalNameChar, "_", artName)

    # 第一步：抓取最原始的网页至临时目录（待加载 JS 格式化代码风格）
    def ScrapWebpage2File_step1 (self, artName, artUrl):
        if len(self.BookName) > 0:
            self.CreatDownloadFolder()
            fileName = self.ScrapFileName(artName, self.TempBookFolder)
            if os.path.exists(fileName):
                print("已抓取 < %s.html >" % artName, end = '     ')
                return

        if not self.AccountVerified:
            self.LoginAccount()

        if not self.AccountVerified:
            print("Web site login failed.")
            return

        print("正在抓取 < %s.html >" % artName, end = '     ')
        self.ScrapOrigHtml(artUrl)
        self.CreatDownloadFolder()

        fileName = self.ScrapFileName(artName, self.TempBookFolder)
        if os.path.exists(fileName):
            os.remove(fileName)
        fileOutput = open(fileName, 'wt', encoding = 'UTF-8')
        fileOutput.write(self.FormatHtml(self.webpageHtml, True))
        fileOutput.close()

        print("（抓取完成）", end = '     ')

    # 第二步：用 PhantomJS 加载已下载的原始网页
    def ScrapWebpage2File_step2 (self, artName):
        if self.webBrowser is None:
            self.webBrowser = webdriver.PhantomJS('.\\phantomjs.exe')

        tempFileName = self.ScrapFileName(artName, self.TempBookFolder)
        if os.path.exists(tempFileName):
            tempFile2Name = "%s.html" % tempfile.mktemp()
            shutil.copyfile(tempFileName, tempFile2Name)

            self.webBrowser.get(pathname2url(tempFile2Name))
            time.sleep(1)
            os.remove(tempFile2Name)
            self.webpageHtml = self.FormatHtml(self.webBrowser.page_source)
            print("（完成JS格式化）", end = '     ')
        else:
            print("（没有原始网页文件）")
            raise Exception("没有原始网页文件。")

    # 第三步：格式化操作， 并保存
    def ScrapWebpage2File_step3 (self, artName, prevName = "", nextName = ""):
        self.artName = artName[artName.index(")") + 1:].strip()
        artContent = self.GetArticleContent(self.webpageHtml)

        [self.cssDict, self.picDict] = self.GetDownloadDic(artContent)
        self.DownloadFile()

        # replace css
        cssLineMod = "<link href=\".%s\" rel=\"stylesheet\">\r"
        cssStr = ""
        for kMd5, [_, vLocalPath] in self.cssDict.items():
            cssStr += cssLineMod % vLocalPath.replace(self.BookFolder, "")

        # 替换原始的 css、图片 链接
        artContent = self.ReplaceOrigUrl(artContent)

        # html转义字符
        htmlArtName = html.escape(self.artName)

        newHtml = self.modulePage.replace("<!--@articleDiv-->", artContent)
        newHtml = newHtml.replace("<!--@title-->", htmlArtName)
        newHtml = newHtml.replace("<!--@header-->", "<h2>%s</h2>" % htmlArtName if self.AddHeader else "")
        newHtml = newHtml.replace("<!--@style-->", cssStr)

        # 处理最后的左右导航
        bs = BeautifulSoup(newHtml, "html.parser")
        if prevName == "" and nextName == "":
            bs.find("div", {"id": "navNext"}).extract()
        else:
            if prevName == "":
                bs.find("td", {"id": "PreHref"}).extract()
                bs.find("td", {"id": "ArtPreview"}).extract()
            else:
                bs.find("td", {"id": "PreHref"}).a["href"] = pathname2url("./%s" % self.ScrapFileName(prevName))
                bs.find("td", {"id": "ArtPreview"}).b.string = prevName[prevName.index(')') + 1:].strip()

            if nextName == "":
                bs.find("td", {"id": "NextHref"}).extract()
                bs.find("td", {"id": "ArtNext"}).extract()
            else:
                bs.find("td", {"id": "NextHref"}).a["href"] = pathname2url("./%s" % self.ScrapFileName(nextName))
                bs.find("td", {"id": "ArtNext"}).b.string = nextName[nextName.index(')') + 1:].strip()

        newHtml = str(bs)

        fileName = self.ScrapFileName(artName, self.BookFolder)
        if os.path.exists(fileName):
            os.remove(fileName)
        fileOutput = open(fileName, 'wt', encoding = 'UTF-8')
        fileOutput.write(newHtml)
        fileOutput.close()

        print("（格式化完成）", end = '     ')

    # main function
    def ScrapWebpage2File (self, artName, artUrl, prevName = "", nextName = "", onlyStep1 = False ):
        self.ScrapWebpage2File_step1(artName, artUrl)

        if not onlyStep1:
            self.ScrapWebpage2File_step2(artName)
            self.ScrapWebpage2File_step3(artName, prevName, nextName)

        print("done.")
