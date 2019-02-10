import time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

dicArtUrl = {}
# 定义 chromedriver 路径
realDir = os.path.dirname(os.path.realpath(__file__))
driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
# 获取chrome浏览器驱动

driver = webdriver.Chrome(executable_path=driver_path)
driver.get(r'https://time.geekbang.org/course/detail/130-41531')
driver.implicitly_wait(2)
time.sleep(2)

driver.delete_all_cookies()
driver.stop_client()
print(driver.page_source)
print('Done.')