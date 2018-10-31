from urllib.request import urlopen
from bs4 import BeautifulSoup


for i in range(1000, 1500):
    try:
        url = (r"http://www.baidao.com/ns/%s/index.html") % i
        html = urlopen(url)

        if html is not None:
            bsObj = BeautifulSoup(html, "html.parser")
            webTitle = bsObj.find("title")

            if webTitle is not None:
                # if webTitle.get_text().find("边") > -1:
                #     print(url + "-" + webTitle.get_text())
                print(url + " - " + webTitle.get_text())
    except:
        pass
exit()


html = urlopen(r"http://www.baidao.com/ns/747/index.html")
bsObj = BeautifulSoup(html, "html.parser")
webTitle = bsObj.find("title")

print(webTitle.get_text())

