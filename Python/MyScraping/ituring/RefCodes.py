'''
http://www.ituring.com.cn/account/logon
name="UserName"
name="Password"
name="RememberMe"
name="__RequestVerificationToken"
http://www.ituring.com.cn/article/65009
'''
import time
import requests
from bs4 import BeautifulSoup

urlLogon = "http://www.ituring.com.cn/account/logon"
urlArticle = "http://www.ituring.com.cn/article/65009"

headersBasic = {
    "User-Agent": "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36",
    "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8",
    "Accept-Encoding" : "gzip, deflate",
    "Accept-Language" : "zh-CN,zh;q=0.8,en;q=0.6"
    }

session = requests.session()

# Get Cookies Token
s = session.get(urlLogon, headers = headersBasic)
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
          ,'__RequestVerificationToken': inputTagToken.attrs["value"]
          }

headersLogon = headersBasic.copy()
headersLogon["Cookie"] = "iTuringAnonymousUser=%s;__RequestVerificationToken=%s"\
                         % (origCookiesDic["iTuringAnonymousUser"], origCookiesDic["__RequestVerificationToken"])

# login...
time.sleep(3)
s = session.post(urlLogon, params, headers = headersLogon)
print("Login cookies:")
print(s.headers)

time.sleep(1)
s = session.get(urlArticle, headers = headersBasic)
print(s.text)
