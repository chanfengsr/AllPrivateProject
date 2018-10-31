from MyScraping.ituring.ScrapITuring import ScrapITuring
import os
import hashlib



st = ScrapITuring("深入理解C#（第3版）", True)

if 1 == 0:
    # st.ScrapHtml("")
    exampleHtml = open('Catalog1.html', 'rt', encoding = 'UTF-8')
    html = exampleHtml.read()
    exampleHtml.close()
    st.webpageHtml = html

    st.GetArticleList(pageType = "artCollect") # artCollect bookCatalog

    # st.ScrapWebpage2File("(046)  5.5　匿名方法中的捕获变量","", True)
else:
    pageList = [
        (r"(037)  4.2　System.Nullable<T>和System.Nullable", "http://www.ituring.com.cn/article/72593")
    ]

    lstErro = []
    for pageItem in pageList:
        artName, artUrl = pageItem

        try:
            st.ScrapWebpage2File(artName, artUrl)
        except Exception as ex:
            print(ex)
            lstErro.append("(r\"%s\", \"%s\")," % (artName, artUrl))

    if len(lstErro) > 0:
        print("Erro list:")
        for errExpt in lstErro:
            print(errExpt)