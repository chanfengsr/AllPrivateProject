# https://detail.tmall.com/item.htm?id=586750895922
from selenium import webdriver
import datetime
import time, re, os

# input("请输入抢购时间，格式如(2018-09-06 11:20:00.000000):")
byTime = "2019-03-01 15:00:00.000000"
# 物品主页
itemUrl = "https://detail.tmall.com/item.htm?id=586750895922"


def login():
    # 打开淘宝登录页，并进行扫码登录
    driver.get("https://www.taobao.com")
    time.sleep(3)
    if driver.find_element_by_link_text("亲，请登录"):
        driver.find_element_by_link_text("亲，请登录").click()
        print("请在15秒内完成扫码")
        time.sleep(15)
    time.sleep(3)
    now = datetime.datetime.now()
    print('login success:', now.strftime('%Y-%m-%d %H:%M:%S'))

    time.sleep(10)
    # 登陆后直接打开购买商品的页面
    driver.get(itemUrl)
    time.sleep(5)


def buy():
    i = 0
    # 到时点击 “立即购买” / 每隔 1 秒钟尝试下
    while True:
        now = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')
        # 对比时间，时间到的话就点击结算
        if now > byTime:
            if driver.find_element_by_link_text("立即购买"):
                driver.find_element_by_link_text("立即购买").click()
                break
        time.sleep(0.1)

    # 提交订单
    """
    完成 “立即购买” 后会进入提交订单的页面
    因为 只有当网页加载完成后才能点击
    所以下面依然使用一个循环
    并且在循环中使用try 防止报错
    """
    while True:
        try:
            if driver.find_element_by_link_text("提交订单"):
                driver.find_element_by_link_text("提交订单").click()
        except:
            time.sleep(1)
    print('All Done.')


if __name__ == "__main__":
    realDir = os.path.dirname(os.path.realpath(__file__))
    driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
    driver = webdriver.Chrome(executable_path=driver_path)
    driver.maximize_window()
    login()
    buy()
