"""
Function：利用Python的Selenium库爬取极客时间付费课程并保存为PDF文件
Author：KevinWong
Time： 2018年9月30日20:48:38
https://mp.weixin.qq.com/s/RxBagi0HB01NbUrZDQ4ViQ
"""
from selenium import webdriver
import pdfkit, time, re


def main():
    # 定义chromedriver路径
    driver_path = r'..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
    # 获取chrome浏览器驱动
    driver = webdriver.Chrome()  # executable_path=driver_path
    # 使用driver打开极客时间登录页面
    login_url = 'https://account.geekbang.org/signin'
    driver.get(login_url)
    # 此处while死循环实际上可以不写 当执行完所有代码后 浏览器会自动关闭
    while True:
        # 输入手机号
        driver.find_element_by_class_name("nw-input").send_keys("18576614172")
        # 输入密码
        driver.find_element_by_class_name("input").send_keys("KevinWong#Libra@1995")
        # 点击登录按钮
        driver.find_element_by_class_name("mybtn").click()
        # 为了使ajax加载完成 此处使用隐式等待让程序等待5秒钟
        driver.implicitly_wait(5)
        # 找到左侧栏的“我的订阅”链接并点击
        driver.find_element_by_class_name("left-nav").find_elements_by_tag_name("a")[4].click()
        # 找到页面中部的“开始学习”按钮并点击
        """
        由于我只订阅了一门付费专栏 
        因此页面中只有一个“开始学习”按钮
        所以直接获取第一个按钮即可
        如果有多门付费专栏可以使用find_elements_by_class_name()这个方法
        它返回一个List 可通过循环获取每一个按钮并进行点击
        """
        driver.find_element_by_class_name("btn-wrapper").click()
        # 切换到新打开的专栏文章列表页面
        """
            因为点击“开始学习”之后 
            会在浏览器打开一个新的标签页 
            所以此处需要将driver转换到新打开的专栏文章列表
            否则无法获取新打开的页面的数据
        """
        driver.switch_to.window(driver.window_handles[1])

        # 配置PDF选项 避免中文乱码
        options = {
            'page-size': 'Letter',
            'encoding': "UTF-8",
            'custom-header': [
                ('Accept-Encoding', 'gzip')
            ]
        }
        # 找到文章列表页面所有的文章标题
        titles = driver.find_elements_by_class_name("article-item-title")

        print("正在爬取专栏文章，并生成PDF文件...")
        # 记录爬取文章的开始时间
        start = time.time()
        for i in range(len(titles)):
            # 点击当前选中的标题 跳转到文章内容页面
            driver.find_elements_by_class_name("article-item-title")[i].click()

            # 等待页面加载
            driver.implicitly_wait(5)

            print('正在爬取第' + str(i + 1) + '篇文章')
            # 获取当前文章的标题
            title = driver.find_element_by_class_name("article-title").text
            """
            因为要在windows下保存为PDF文件 
            所以文件名不能为特殊字符
            此处将可能出现的特殊替换为空字符串
            """
            raw_title = re.sub('[\/:：*?"<>|]', '', title).replace('  ',' ')
            # 获取文章内容页面的详细内容 使用pdfkit生成PDF文件并保存到本地
            pdfkit.from_string(driver.page_source, 'R:\\' + raw_title + '.pdf', options=options)

            # 返回到文章列表页面
            driver.back()

            break

        # 记录爬取文章的结束时间
        end = time.time()
        print("所有文章爬取完毕！共耗时" + str(int(end - start)) + "秒")
        break


if __name__ == '__main__':
    main()
