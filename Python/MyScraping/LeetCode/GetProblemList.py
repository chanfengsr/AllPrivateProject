import os, sys
from urllib.request import urlopen
from bs4 import BeautifulSoup

def getProblemList():
     contentFile = r".\Content.html"
     if not os.path.exists(contentFile):
         exit()

     f = open(contentFile, 'rt', encoding='UTF-8')
     html = f.read()
     f.close()
     bs = BeautifulSoup(html, "html.parser")
     rec = bs.find("tbody", {"class": "reactable-data"})

     pList = []
     pNo = ""  # 题号
     pZh = ""  # 中文名
     pEn = ""  # 英文名
     pHref = ""  # 链接
     for tr in rec.find_all("tr"):
         i = 1
         for td in tr.find_all("td"):
             if i == 2:
                 pNo = td.text
             elif i == 3:
                 pEn = td["value"]

                 aTag = td.div.a
                 pZh = aTag.text
                 pHref = aTag["href"]

             i += 1
             if i > 3: break

         pList.append((pNo, pZh, pEn, pHref))
         # break
     return pList

if __name__ == '__main__':
    pList = getProblemList()
    print(pList)
