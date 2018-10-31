# http://quote.eastmoney.com/stocklist.html
from urllib.request import urlopen
from bs4 import BeautifulSoup


showST = False
html = urlopen(r"http://quote.eastmoney.com/stocklist.html")
bs = BeautifulSoup(html, "html.parser", from_encoding = "gb18030")
stkList = bs.findAll("a", {"target": "_blank"})
for stkTag in stkList:
    tag = stkTag.get_text() # Like 华英农业(002321)
    if tag.find("(60") > 0 or tag.find("(30") > 0:
        if showST:
            print(tag)
        else:
            if tag.find("ST") == -1:
                print(tag)