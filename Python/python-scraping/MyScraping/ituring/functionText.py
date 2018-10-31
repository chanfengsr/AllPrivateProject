from MyScraping.ituring.ScrapITuring import ScrapITuring
import os
import hashlib
import re
import html
from bs4 import BeautifulSoup

st = ScrapITuring("深入理解C#（第3版）", True)
exampleHtml = open('ExampleOrigHtml.html', 'rt', encoding = 'UTF-8')
html = exampleHtml.read()
exampleHtml.close()
st.webpageHtml = html
# st.ScrapWebpage2File("(046)  5.5　匿名方法中的捕获变量","", True)

# html = st.ScrapHtml("http://www.ituring.com.cn/article/72605")

print( st.FormatHtml(html))
# print(html)
