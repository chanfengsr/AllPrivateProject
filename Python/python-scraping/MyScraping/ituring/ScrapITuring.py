import time
import requests
import os
import re
import hashlib
import html
from urllib.request import urlretrieve
from bs4 import BeautifulSoup

baseUrl = "http://www.ituring.com.cn"
illegalNameChar = r"[\/\\\:\*\?\"\<\>\|]"

class ScrapITuring():
    AccountVerified = False
    TargetFolder = "r:\\"
    contentClassId = ("markdown-body", "post-text")
    navHeaderClass = (("li","nav-header", True), ("div", "rounded-box", False))

    headersBasic = {
        "User-Agent": "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36",
        #"User-Agent": "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E) ",
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

    def __init__(self, bookName = "", addHeader = False):
        self.BookName = bookName
        self.AddHeader = addHeader

        moduleFile = open("ModulePage.html", 'rt', encoding = 'UTF-8')
        self.modulePage = moduleFile.read()
        moduleFile.close()

    # 登录网站
    def LoginAccount(self):
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
                      'RememberMe': 'false'
                , '__RequestVerificationToken': inputTagToken.attrs["value"]
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
    def GetFileNum(self, fileNum = None):
        if fileNum is not None:
            self.fileNum = fileNum

        self.fileNum += 1

        # return ("0" + repr(self.fileNum - 1))[-2:]
        return ("00" + repr(self.fileNum - 1))[-3:]

    # 抓网页内容
    def ScrapHtml(self, atrUrl):
        if not self.AccountVerified:
            self.LoginAccount()

        if not self.AccountVerified:
            print("Web site login failed.")
            return

        time.sleep(3)
        s = self.session.get(atrUrl, headers = self.headersBasic) #
        self.webpageHtml = self.FormatHtml(s.text)
        return self.webpageHtml

    def FormatHtml(self, pageHtml):
        bs = BeautifulSoup(pageHtml, "html.parser")
        insStr = "<a href=\"%s\" target=\"_blank\" class=\"img-origin\">[+]查看原图</a></p>"

        imgTagList = bs.findAll("img")
        for imgTag in imgTagList:
            if imgTag.attrs["src"].strip().endswith(".small"):
                tagIns = BeautifulSoup(insStr % imgTag.attrs["src"].replace(".small", ".big"), "html.parser")
                imgTag.parent.append(tagIns)

        return repr(bs)

    # 获得文章实体
    def GetArticleContent(self, pageHtml = None):
        if (pageHtml is None):
            pageHtml = self.webpageHtml

        bs = BeautifulSoup(pageHtml, "html.parser")
        for classId in self.contentClassId:
            tag = bs.find("div", {"class":classId})
            if (tag is not None):
                return repr(tag)

        return pageHtml

    # 书名
    def GetBookName(self, pageHtml = None):
        if pageHtml is None:
            pageHtml = self.webpageHtml

        if len(self.BookName) > 0:
            return self.BookName

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

    def __GetArticleList_bookCatalog(self, pageHtml):
        bs = BeautifulSoup(pageHtml, "html.parser")
        listTr = bs.find("div",{"class":"tab-pane active"}).tbody.findAll("tr")
        for tagtr in listTr:
            tagtd = tagtr.find("td")

            print("(r\"(%s)%s\", \"%s\")," % (self.GetFileNum(), tagtd.get_text().strip(), self.GetAbsoluteURL(tagtd.a.attrs["href"])))

    def __GetArticleList_artCollect(self, pageHtml):
        fmtString = "(r\"(%s)%s\", \"%s\"),"
        fmtStringSub = "(r\"(%s)  %s\", \"%s\"),"

        bs = BeautifulSoup(pageHtml, "html.parser")
        lstDivMinibook = bs.findAll("div", {"class","minibook-item"})
        for tagMinibook in lstDivMinibook:
            tagH3 = tagMinibook.find("a", {"class","question-hyperlink"})
            print(fmtString % (self.GetFileNum(), tagH3.get_text().strip(), self.GetAbsoluteURL(tagH3.attrs["href"])))

            lstSub = tagMinibook.find("ul").findAll("li")
            for tagSub in lstSub:
                tagA = tagSub.a
                print(fmtStringSub % (self.GetFileNum(), tagA.get_text().strip(), self.GetAbsoluteURL(tagA.attrs["href"])))

    def GetArticleList(self, pageType = "bookCatalog", pageHtml = None):
        if pageHtml is None:
            pageHtml = self.webpageHtml

        if pageType == "bookCatalog":
            self.__GetArticleList_bookCatalog(pageHtml)
        else:
            self.__GetArticleList_artCollect(pageHtml)

    # 生成下载文件夹
    def CreatDownloadFolder(self):
        self.GetBookName()
        self.BookFolder =  (self.TargetFolder + "\\" + re.sub(illegalNameChar, "_", self.BookName)).replace("\\\\", "\\")
        self.CssFolder = (self.BookFolder + "\\" + "Css").replace("\\\\", "\\")
        self.AccessoriesFolder = (self.BookFolder + "\\" + "Accessories").replace("\\\\", "\\")

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
    def GetPicLocalPath(self, md5, origHref, absolute = False):
        if (origHref.endswith(".gif")):
            absolutePath = self.AccessoriesFolder + "\\" + md5 + ".gif"
        else:
            absolutePath = self.AccessoriesFolder + "\\" + md5 + ".jpg"

        if (absolute):
            return absolutePath
        else:
            return absolutePath.replace(self.BookFolder, "")

    # 获取 Css 及 Picture 待下 Dict
    def GetDownloadDic(self, articleHtml = None):
        if (articleHtml is None):
            articleHtml = self.GetArticleContent()

        cssDict = {}
        bs = BeautifulSoup(self.webpageHtml, "html.parser")
        cssTag = bs.find("link", {"rel":"stylesheet"})
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

        imgList = bs.findAll("a", {"class":"img-origin"})
        for imgTag in imgList:
            url = imgTag.attrs["href"]
            md5Val = md5Val = hashlib.md5(url.encode()).hexdigest()
            picDict[md5Val] = [url, self.GetPicLocalPath(md5Val, url, True)]

        return [cssDict, picDict]

    # 下载 CSS 及 图片
    def DownloadFile(self):
        for kMd5, [vOrigUrl, vLocalPath] in self.cssDict.items():
            if (not os.path.exists(vLocalPath)):
                urlretrieve(self.GetAbsoluteURL(vOrigUrl), vLocalPath)

        for kMd5, [vOrigUrl, vLocalPath] in self.picDict.items():
            if (not os.path.exists(vLocalPath)):
                urlretrieve(self.GetAbsoluteURL(vOrigUrl), vLocalPath)

    # 替换原始的 css、图片 链接
    def ReplaceOrigUrl(self, contHtml):
        for kMd5, [vOrigUrl, vLocalPath] in self.cssDict.items():
            contHtml = contHtml.replace(vOrigUrl, vLocalPath.replace(self.BookFolder, "."))

        for kMd5, [vOrigUrl, vLocalPath] in self.picDict.items():
            contHtml = contHtml.replace(vOrigUrl, vLocalPath.replace(self.BookFolder, "."))

        return contHtml

    # main function
    def ScrapWebpage2File(self, artName, atrUrl, scraped = False):
        self.artName = artName[artName.index(")") + 1:].strip()

        if not scraped:
            if not self.AccountVerified:
                self.LoginAccount()

            if not self.AccountVerified:
                print("Web site login failed.")
                return

            print("正在抓取 < %s.html >" % artName, end = '     ')
            self.ScrapHtml(atrUrl)
        else:
            print("正在生成文件 < %s.html >" % artName, end = '     ')

        artContent = self.GetArticleContent(self.webpageHtml)

        self.CreatDownloadFolder()
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

        fileName = "%s\\%s.html" % (self.BookFolder, re.sub(illegalNameChar, "_", artName))
        if (os.path.exists(fileName)):
            os.remove(fileName)
        fileOutput = open(fileName, 'wt', encoding = 'UTF-8')
        fileOutput.write(newHtml)
        fileOutput.close()

        print("（完成）")