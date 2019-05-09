import time, re, os
from bs4 import BeautifulSoup

artFile = '.\\demoArtList.html'  # GeekTime\demoArtList.html

listFile = open(artFile, 'rt', encoding='UTF-8')
origHtml = listFile.read()
listFile.close()
bs = BeautifulSoup(origHtml, "html.parser")

outputList = []
for artItem in bs.find_all("div", {"class": "_3c2pu66u_0"}):
    if not artItem.find("a"):
        continue

    title = artItem.find("a").get_text().strip()
    url = 'https:' + artItem.find("a")["href"].strip()
    outputList.append((title, url))

print(repr(outputList).replace("),", "),\n"))