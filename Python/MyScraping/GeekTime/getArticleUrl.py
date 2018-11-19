import time, re, os
from bs4 import BeautifulSoup

# demoArtList.html
listFile = open('demoArtList.html', 'rt', encoding='UTF-8')
origHtml = listFile.read()
bs = BeautifulSoup(origHtml, "html.parser")

outputList = []
for artItem in bs.find_all("div", {"class": "article-item"}):
    title = artItem.find("h2", {"class": "article-item-title"}).get_text().strip()
    url = artItem.find("a", {"class": "article-item-more-text"})["data-gk-spider-link"].strip()

    tarTitle = re.sub('[\/:：*?"<>|]', '', title.strip()).replace('  ', ' ')
    tarUrl = url.replace("/column/article/", "https://time.geekbang.org/column/article/")

    outputList.append((tarTitle, tarUrl))
    artItem.find("a", {"class": "article-item-more-text"})["href"] = tarUrl
    artItem.find("a", {"class": "article-item-more-text"})["data-gk-spider-link"] = tarUrl

print(repr(outputList).replace("),", "),\n"))

[s.extract() for s in bs.find_all("script")]  # 去干净 JS
htmlFile = open('R:\\' + 'new' + '.html', 'w', encoding='utf-8')
htmlFile.write(repr(bs))
htmlFile.close()
