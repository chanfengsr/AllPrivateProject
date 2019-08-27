#!/usr/bin/python3
#coding:utf-8
import time
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions as EC
#下面填入京东的用户名以及密码
jd_up={"ue":"","pd":""}

chrome_options = Options()
# 不加载图片提升速度
prefs = {"profile.managed_default_content_settings.images":2}
# 无界面配置，需要验证码时需要注释掉
chrome_options.add_argument("--headless")
chrome_options.add_experimental_option("prefs",prefs)

chrome=webdriver.Chrome(chrome_options=chrome_options)
chrome.get(url="https://passport.jd.com/new/login.aspx?")
print("loginPageSuucess")
chrome.find_element_by_xpath("//*[@id=\"content\"]/div/div[1]/div/div[2]/a").click()
User=chrome.find_element_by_id("loginname")
User.clear()
User.send_keys(jd_up["ue"])
Passwd=chrome.find_element_by_id("nloginpwd")
Passwd.clear()
Passwd.send_keys(jd_up["pd"])
# 如果有验证码的话注释下面这行代码并把time.sleep(5)的注释去掉，自己输入验证码点登录
chrome.find_element_by_id("loginsubmit").click()
# time.sleep(5)
while True:
    try:
        chrome.get(url="https://item.jd.com/5001209.html")
        btn = chrome.find_element_by_id("choose-btn-ko")
        WebDriverWait(chrome, 1, 0.5).until(EC.element_to_be_clickable((By.ID,'choose-btn-ko')))
        btn.click()
        time.sleep(2)
        WebDriverWait(chrome, 2, 0.5).until(EC.invisibility_of_element_located((By.CSS_SELECTOR, "#payAndShipEditDiv")))
        chrome.find_elements_by_css_selector("#saveConsigneeTitleDiv")[0].click()
        WebDriverWait(chrome, 2, 0.5).until(EC.visibility_of_element_located((By.CSS_SELECTOR, "#payAndShipEditDiv")))
        chrome.find_elements_by_css_selector("#payAndShipEditDiv > div.form-btn.group > a > span")[0].click()
        chrome.find_element_by_id("order-submit").click()
        print("抢购成功")
        break
    except:
        # chrome.quit()
        print("还未开始抢购")
