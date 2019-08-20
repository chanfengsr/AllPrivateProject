from selenium import webdriver
import datetime
import time,re, os

def login():
    browser.get("https://www.jd.com/")
    time.sleep(3)
    browser.find_element_by_class_name("link-login").click()
    print("请在15秒内完成扫码")
    time.sleep(15)
    browser.get("https://cart.jd.com/cart.action")
    time.sleep(3)
    now = datetime.datetime.now()
    print('login success:', now.strftime('%Y-%m-%d %H:%M:%S'))

def buy(times, choose):
    # 点击购物车里全选按钮
    if choose == 2:
        print("请手动勾选需要购买的商品")
    while True:
        now = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')
        # 对比时间，时间到的话就点击结算
        if now > times:
            if choose == 1:
                while True:
                    try:
                        # 购物车，“全选”
                        if browser.find_element_by_class_name("select-all"):
                            browser.find_element_by_class_name("select-all").click()
                            break
                    except:
                        print("找不到全选按钮")

            # 刷新一次购物车
            browser.get("https://cart.jd.com/cart.action")

            # 点击购物车，“去结算”
            try:
                if browser.find_element_by_class_name("submit-btn"):
                    browser.find_element_by_class_name("submit-btn").click()
                    print("结算成功")
            except:
                pass

            # 点击订单提交页面“提交订单”
            while True:
                try:
                    if browser.find_element_by_class_name("checkout-submit"):
                        browser.find_element_by_class_name("checkout-submit").click()
                        now1 = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')
                        print("抢购成功时间：%s" % now1)

                        time.sleep(500)
                except:
                    print("再次尝试提交订单")

            time.sleep(0.01)



if __name__ == "__main__":
    # 时间格式："2018-09-06 11:20:00.000000"
    times = "2019-08-20 00:00:00.000000" # input("请输入抢购时间，格式如(2018-09-06 11:20:00.000000):")
    realDir = os.path.dirname(os.path.realpath(__file__))
    driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
    browser = webdriver.Chrome(executable_path=driver_path)
    browser.maximize_window()
    login()
    choose = input("到时间自动勾选购物车请输入“1”，否则输入“2”：")
    buy(times, choose)