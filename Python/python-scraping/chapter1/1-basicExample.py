from urllib.request import urlopen
#Retrieve HTML string from the URL
html = urlopen("http://www.yinwang.org/blog-cn/2015/11/21/programming-philosophy")
print(html.read())