# from MyScraping.ituring.ScrapITuring import ScrapITuring
from ituring.ScrapITuring import ScrapITuring
import time

st = ScrapITuring("算法的乐趣", addHeader = False)
bookCatalog = "http://www.ituring.com.cn/book/1605"
# st.CoverPicURL = ""
pageType = "bookHead"  # bookHead / artCollect / bookCatalog / ul-box
step = 0

catchCatalog = True if step == 1 else False
onlyStep1 = True if step == 1 else False

if pageType == "artCollect":
    st.AddHeader = True

# st.AddHeader = True

if step == 0 or catchCatalog:
    if len(bookCatalog) == 0:
        exampleHtml = open('.//BookCatalog//图解HTTP.html', 'rt', encoding = 'UTF-8')
        html = exampleHtml.read()
        exampleHtml.close()
        st.webpageHtml = html
    else:
        st.ScrapOrigHtml(bookCatalog)

        # nf = open("r:\\a.txt", 'wt', encoding = 'UTF-8')
        # nf.write(st.webpageHtml)
        # nf.close()

    pageList = st.GetArticleList(pageType = pageType)

    if st.CoverPicURL != "":
        st.DownloadCoverPic()

if step == 0 or not catchCatalog:
    if step != 0:
        pageList = []

    # 生成关联前后章节的节点，目的是用于出错重试
    pageListRelate = []
    idx = 0
    while idx < len(pageList):
        prevArt = pageList[idx - 1] if idx > 0 else ("", "")
        nextArt = pageList[idx + 1] if idx < len(pageList) - 1 else ("", "")
        pageListRelate.append((pageList[idx], prevArt, nextArt))
        idx += 1

    maxTryCount = 5
    lstErrMsg = []
    lstError = []
    loopCount = 1
    scrapList = pageListRelate.copy()

    while loopCount == 1 or (loopCount <= maxTryCount and len(lstError) > 0):
        if loopCount > 1:
            scrapList = lstError.copy()
            time.sleep(10)

        lstError.clear()

        for pageItem in scrapList:
            tCur, tPrev, tNext = pageItem
            curName, curUrl = tCur
            prevName, prevUrl = tPrev
            nextName, nextUrl = tNext

            try:
                st.ScrapWebpage2File(curName, curUrl, prevName, nextName, onlyStep1)
            except Exception as ex:
                print(ex)

                if loopCount == maxTryCount:
                    lstErrMsg.append("(r\"%s\", \"%s\")," % (curName, curUrl))
                else:
                    lstError.append(pageItem)
        loopCount += 1

    if len(lstErrMsg) > 0:
        print("Erro list:")
        for errExpt in lstErrMsg:
            print(errExpt)

    st.Close()

exit()
