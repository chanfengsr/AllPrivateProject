from selenium import webdriver
import datetime
import time,re, os

inDebug = True and False

def login():
    browser.get("https://www.jd.com/")
    browser.implicitly_wait(30)
    browser.find_element_by_class_name("link-login").click()
    print("请在15秒内完成扫码登录")
    time.sleep(15)
    browser.get("https://cart.jd.com/cart.action")
    browser.implicitly_wait(20)
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
                        if not browser.find_element_by_id("toggle-checkboxes_up").get_property('checked'):
                            browser.find_element_by_id("toggle-checkboxes_up").click()
                            browser.implicitly_wait(5)
                        else:
                            break
                    except:
                        print("找不到全选按钮")

            # 点击购物车，“去结算”
            try:
                if browser.find_element_by_class_name("submit-btn"):
                    browser.find_element_by_class_name("submit-btn").click()
            except:
                pass

            # 点击订单提交页面“提交订单”
            while True:
                try:
                    if browser.find_element_by_class_name("checkout-submit"):
                        browser.find_element_by_class_name("checkout-submit").click()
                        now1 = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')
                        print("提交订单时间：%s" % now1)

                        time.sleep(0.1)
                except:
                    print("再次尝试提交订单")

            time.sleep(0.01)

def Test():
    realDir = os.path.dirname(os.path.realpath(__file__))
    driver_path = r'D:\Project\AllInGitHub\CommonDriver\ChromeDriver\chromedriver.exe'
    browser = webdriver.Chrome(executable_path=driver_path)
    # browser.maximize_window()
    browser.get("https://item.jd.com/30646311745.html")
    browser.find_element_by_id("InitCartUrl").click()
    browser.get("https://cart.jd.com/cart.action")
    priceSum = browser.find_element_by_class_name('price-sum')
    if priceSum:
        sumStr = priceSum.find_element_by_tag_name('em').text
        if float(sumStr.lstrip('¥')) > 0:
            if browser.find_element_by_id("toggle-checkboxes_up"):
                browser.find_element_by_id("toggle-checkboxes_up").click()
                browser.implicitly_wait(300)


        print(browser.find_element_by_id("toggle-checkboxes_up").get_property('checked'))
        if browser.find_element_by_class_name("submit-btn"):
            browser.find_element_by_class_name("submit-btn").click()

    print('Done.')
    time.sleep(300)


if __name__ == "__main__":
    if inDebug:
        Test()
        exit()

    # 时间格式："2018-09-06 11:20:00.000000"
    times = "2019-08-20 00:00:00.000000" # input("请输入抢购时间，格式如(2018-09-06 11:20:00.000000):")
    realDir = os.path.dirname(os.path.realpath(__file__))
    driver_path = os.environ.get("Project") + r'\AllInGitHub\CommonDriver\ChromeDriver\chromedriver.exe'

    choose = input("到时间自动勾选购物车请输入“1”，事先手动勾选输入“2”：")
    browser = webdriver.Chrome(executable_path=driver_path)
    browser.maximize_window()
    login()
    buy(times, choose)