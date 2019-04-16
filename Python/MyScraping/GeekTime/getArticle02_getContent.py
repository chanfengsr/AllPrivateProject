import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

# Debug 状态，网页不登陆，不滚动
inDebug = True and False

createPdf = True #and False

# 滚动区域的 DIV
CLASS_SCROLL_NAME = 'ibY_sXau_0 ps'
# 抓取正文的 DIV
CLASS_SCRAP_NAME = '_1Dgl7pMn_0'

# 元素 1：文章原始标题
# 元素 2：网页地址或手工保存网页文件的绝对路径
courseList = \
    [('开篇词 | 作为程序员，为什么你应该学好数学？', 'https://time.geekbang.org/column/article/70844'),
 ('导读：程序员应该怎么学数学？', 'https://time.geekbang.org/column/article/71139'),
 ('01 | 二进制：不了解计算机的源头，你学什么编程', 'https://time.geekbang.org/column/article/71840'),
 ('02 | 余数：原来取余操作本身就是个哈希函数', 'https://time.geekbang.org/column/article/72163'),
 ('03 | 迭代法：不用编程语言的自带函数，你会如何计算平方根？', 'https://time.geekbang.org/column/article/72243'),
 ('04 | 数学归纳法：如何用数学归纳提升代码的运行效率？', 'https://time.geekbang.org/column/article/73036'),
 ('05 | 递归（上）：泛化数学归纳，如何将复杂问题简单化？', 'https://time.geekbang.org/column/article/73511'),
 ('06 | 递归（下）：分而治之，从归并排序到MapReduce', 'https://time.geekbang.org/column/article/73834'),
 ('数学专栏课外加餐（一） | 我们为什么需要反码和补码？', 'https://time.geekbang.org/column/article/74296'),
 ('数学专栏课外加餐（二） | 位操作的三个应用实例', 'https://time.geekbang.org/column/article/74717'),
 ('07 | 排列：如何让计算机学会“田忌赛马”？', 'https://time.geekbang.org/column/article/75129'),
 ('08 | 组合：如何让计算机安排世界杯的赛程？', 'https://time.geekbang.org/column/article/75662'),
 ('09 | 动态规划（上）：如何实现基于编辑距离的查询推荐？', 'https://time.geekbang.org/column/article/75807'),
 ('10 | 动态规划（下）：如何求得状态转移方程并进行编程实现？', 'https://time.geekbang.org/column/article/76183'),
 ('11 | 树的深度优先搜索（上）：如何才能高效率地查字典？', 'https://time.geekbang.org/column/article/76481'),
 ('12 | 树的深度优先搜索（下）：如何才能高效率地查字典？', 'https://time.geekbang.org/column/article/76822'),
 ('13 | 树的广度优先搜索（上）：人际关系的六度理论是真的吗？', 'https://time.geekbang.org/column/article/77129'),
 ('14 | 树的广度优先搜索（下）：为什么双向广度优先搜索的效率更高？', 'https://time.geekbang.org/column/article/77474'),
 ('15 | 从树到图：如何让计算机学会看地图？', 'https://time.geekbang.org/column/article/77849'),
 ('16 | 时间和空间复杂度（上）：优化性能是否只是“纸上谈兵”？', 'https://time.geekbang.org/column/article/78186'),
 ('17 | 时间和空间复杂度（下）：如何使用六个法则进行复杂度分析？', 'https://time.geekbang.org/column/article/78457'),
 ('18 | 总结课：数据结构、编程语句和基础算法体现了哪些数学思想？', 'https://time.geekbang.org/column/article/78790'),
 ('数学专栏课外加餐（三）：程序员需要读哪些数学书？', 'https://time.geekbang.org/column/article/79048'),
 ('19 | 概率和统计：编程为什么需要概率和统计？', 'https://time.geekbang.org/column/article/79441'),
 ('20 | 概率基础（上）：一篇文章帮你理解随机变量、概率分布和期望值', 'https://time.geekbang.org/column/article/79915'),
 ('21 | 概率基础（下）：联合概率、条件概率和贝叶斯法则，这些概率公式究竟能做什么？', 'https://time.geekbang.org/column/article/80393'),
 ('22 | 朴素贝叶斯：如何让计算机学会自动分类？', 'https://time.geekbang.org/column/article/80868'),
 ('23 | 文本分类：如何区分特定类型的新闻？', 'https://time.geekbang.org/column/article/81009'),
 ('24 | 语言模型：如何使用链式法则和马尔科夫假设简化概率模型？', 'https://time.geekbang.org/column/article/81105'),
 ('25 | 马尔科夫模型：从PageRank到语音识别，背后是什么模型在支撑？', 'https://time.geekbang.org/column/article/81374'),
 ('26 | 信息熵：如何通过几个问题，测出你对应的武侠人物？', 'https://time.geekbang.org/column/article/81673'),
 ('27 | 决策树：信息增益、增益比率和基尼指数的运用', 'https://time.geekbang.org/column/article/81941'),
 ('28 | 熵、信息增益和卡方：如何寻找关键特征？', 'https://time.geekbang.org/column/article/82296'),
 ('29 | 归一化和标准化：各种特征如何综合才是最合理的？', 'https://time.geekbang.org/column/article/82661'),
 ('30 | 统计意义（上）：如何通过显著性检验，判断你的A/B测试结果是不是巧合？', 'https://time.geekbang.org/column/article/82919'),
 ('31 | 统计意义（下）：如何通过显著性检验，判断你的A/B测试结果是不是巧合？', 'https://time.geekbang.org/column/article/83200'),
 ('32 | 概率统计篇答疑和总结：为什么会有欠拟合和过拟合？', 'https://time.geekbang.org/column/article/83593'),
 ('33 | 线性代数：线性代数到底都讲了些什么？', 'https://time.geekbang.org/column/article/83948'),
 ('34 | 向量空间模型：如何让计算机理解现实事物之间的关系？', 'https://time.geekbang.org/column/article/84292'),
 ('35 | 文本检索：如何让计算机处理自然语言？', 'https://time.geekbang.org/column/article/84575'),
 ('36 | 文本聚类：如何过滤冗余的新闻？', 'https://time.geekbang.org/column/article/84949'),
 ('37 | 矩阵（上）：如何使用矩阵操作进行PageRank计算？', 'https://time.geekbang.org/column/article/85194'),
 ('38 | 矩阵（下）：如何使用矩阵操作进行协同过滤推荐？', 'https://time.geekbang.org/column/article/85562'),
 ('39 | 线性回归（上）：如何使用高斯消元求解线性方程组？', 'https://time.geekbang.org/column/article/86014'),
 ('40 | 线性回归（中）：如何使用最小二乘法进行直线拟合？', 'https://time.geekbang.org/column/article/86326'),
 ('41 | 线性回归（下）：如何使用最小二乘法进行效果验证？', 'https://time.geekbang.org/column/article/86766'),
 ('42 | PCA主成分分析（上）：如何利用协方差矩阵来降维？', 'https://time.geekbang.org/column/article/87097'),
 ('43 | PCA主成分分析（下）：为什么要计算协方差矩阵的特征值和特征向量？', 'https://time.geekbang.org/column/article/87337'),
 ('44 | 奇异值分解：如何挖掘潜在的语义关系？', 'https://time.geekbang.org/column/article/87657'),
 ('45 | 线性代数篇答疑和总结：矩阵乘法的几何意义是什么？', 'https://time.geekbang.org/column/article/88078'),
 ('46 | 缓存系统：如何通过哈希表和队列实现高效访问？', 'https://time.geekbang.org/column/article/88408'),
 ('47 | 搜索引擎（上）：如何通过倒排索引和向量空间模型，打造一个简单的搜索引擎？', 'https://time.geekbang.org/column/article/88774'),
 ('48 | 搜索引擎（下）：如何通过查询的分类，让电商平台的搜索结果更相关？', 'https://time.geekbang.org/column/article/89279'),
 ('49 | 推荐系统（上）：如何实现基于相似度的协同过滤？', 'https://time.geekbang.org/column/article/89431'),
 ('50 | 推荐系统（下）：如何通过SVD分析用户和物品的矩阵？', 'https://time.geekbang.org/column/article/89745'),
 ('51 | 综合应用篇答疑和总结：如何进行个性化用户画像的设计？', 'https://time.geekbang.org/column/article/90112'),
 ('结束语 | 从数学到编程，本身就是一个很长的链条', 'https://time.geekbang.org/column/article/90384')]

realDir = os.path.dirname(os.path.realpath(__file__))


# 用户名、密码登录网站
def Login(driver):
    """
    用户名、密码登录网站
    :param driver: 浏览器
    :return:
    """

    # 用户名密码
    userId = ""
    password = ""
    pwdFilePath = realDir + '\\password.txt'
    if os.path.exists(pwdFilePath):
        pFile = open(pwdFilePath)
        userId = pFile.readline().strip()
        password = pFile.readline().strip()
        pFile.close()
    if userId == "": userId = input("UserId:")
    if password == "": password = input("Password:")

    # 使用driver打开极客时间登录页面
    print("正在登录网站...")
    login_url = 'https://account.geekbang.org/login'
    driver.get(login_url)

    # 输入手机号
    driver.find_element_by_class_name("nw-input").send_keys(userId)
    # 输入密码
    driver.find_element_by_class_name("input").send_keys(password)
    # 点击登录按钮
    driver.find_element_by_class_name("mybtn").click()
    # 为了使ajax加载完成 此处使用隐式等待让程序等待5秒钟
    driver.implicitly_wait(5)
    time.sleep(3)
    print("已登录。")


def createPdfFile(sourceHtml, pdfFileName):
    """
    :param sourceHtml: 源 html 可以是文件或 html 源码字符串
    :param pdfFileName:pdf 文件
    :return:
    """

    # 配置PDF选项 避免中文乱码
    options = {
        'page-size': 'Letter',
        'encoding': "UTF-8",
        'custom-header': [
            ('Accept-Encoding', 'gzip')
        ]
    }

    if not sourceHtml.startswith('<') and os.path.exists(sourceHtml):
        htmlFile = open(sourceHtml, 'rt', encoding='utf-8')
        html = htmlFile.read()
        htmlFile.close()
    else:
        html = sourceHtml
    html = html.replace(r'background:#000', r'background:#fff')  # 黑色背景色转成白色
    if pdfkit.from_string(html, pdfFileName, options=options):
        print("PDF 已生成。  --> %s.pdf" % (pdfFileName))


def processHtml(html, tarTitle):
    """
    处理 HTML 源码，生成文件，生成 PDF
    :param html: 原始网页的 html 源码
    :param tarTitle:生成文件的标题
    :return:
    """

    # 生成干净的 html 的模板
    modHtml = "<html>%s<body>%s</body></html>"

    bs = BeautifulSoup(html, "html.parser")

    # 专栏名称
    # columnName = bs.select_one('a[class="title"]').text.strip()
    # columnName = tarTitle
    columnName = ''

    # 保存目录
    exportPath = ("R:\\%s\\" % columnName).replace("\\\\", "\\")
    exportPathPDF = exportPath + "PDF\\"
    exportPathHTML = exportPath + "HTML\\"
    if not os.path.exists(exportPathPDF):
        os.makedirs(exportPathPDF)
    if not os.path.exists(exportPathHTML):
        os.makedirs(exportPathHTML)

    # 获取 m3u8 文件地址
    m3u8 = bs.find("audio")
    if m3u8 is not None:
        ffmpeg = 'ffmpeg -i %s -vcodec copy -acodec copy "%s.mp4"\n' % (m3u8["src"], tarTitle)

        # 写 ffmpeg 下载列表
        ffmpegListFile = open(exportPath + "ffmpegDownList.txt", 'a', encoding='gb2312')
        ffmpegListFile.write(ffmpeg)
        ffmpegListFile.close()

    # 获取干净的 html 并保存
    [s.extract() for s in bs.find_all("script")]  # 去干净 JS
    headHtml = bs.find("head")
    bodyDivHtml = bs.find("div", {"class": CLASS_SCRAP_NAME})
    targetHtml = modHtml % (headHtml, bodyDivHtml)
    targetHtml = targetHtml.replace('CFSR', '')  # 去掉私人信息
    htmlFile = open(exportPathHTML + tarTitle + '.html', 'w', encoding='utf-8')
    htmlFile.write(targetHtml)
    htmlFile.close()
    print("Html 抓取完成。  --> %s.html" % (tarTitle))

    # 用 html 生成 PDF 文件
    if createPdf:
        createPdfFile(targetHtml, exportPathPDF + tarTitle + '.pdf')


# 滚到最底端，获取完整的网页内容
def scrollDrive2Bottom(driver):
    # pageHeight_orig = driver.execute_script('return document.body.scrollHeight')
    # while True:
    #     driver.execute_script('window.scrollBy(0,50000)')
    #     time.sleep(3)
    #     pageHeight_new = driver.execute_script('return document.body.scrollHeight')
    #
    #     if pageHeight_new == pageHeight_orig:
    #         break
    #     else:
    #         pageHeight_orig = pageHeight_new

    divHeightOrg = driver.execute_script('return document.getElementsByClassName(\'' + CLASS_SCROLL_NAME + '\')[0].scrollTop')
    while True:
        driver.execute_script('document.getElementsByClassName(\'' + CLASS_SCROLL_NAME + '\')[0].scrollTop += 5000')
        time.sleep(3)
        divHeightNew = driver.execute_script('return document.getElementsByClassName(\'' + CLASS_SCROLL_NAME + '\')[0].scrollTop')

        if divHeightNew == divHeightOrg:
            break
        else:
            divHeightOrg = divHeightNew


def main():
    # 抓取成功的数量
    catchCount = 0

    # 抓取失败的列表
    errList = []

    t, f = courseList[0]
    isFile = os.path.exists(f)

    print("开始爬取专栏文章...")
    # 记录爬取文章的开始时间
    start = time.time()

    if isFile:
        for doc in courseList:
            title, fileFullName = doc
            tarTitle = re.sub('[\/:：*?"<>|]', '', title.strip()).replace('  ', ' ')

            try:
                file = open(fileFullName, 'rt', encoding='UTF-8')
                html = file.read()
                file.close()

                # 处理 HTML 源码，生成文件，生成 PDF
                processHtml(html, tarTitle)
            except:
                errList.append(title)

            catchCount += 1
            print("\n\n")
    else:

        # 定义chromedriver路径
        driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
        # 获取chrome浏览器驱动
        driver = webdriver.Chrome(executable_path=driver_path)

        if not inDebug:
            Login(driver)

        # 正式开始抓取
        for doc in courseList:
            title, url = doc
            tarTitle = re.sub('[\/:：*?"<>|]', '', title.strip()).replace('  ', ' ')

            try:
                print("正在抓取文章：" + tarTitle)
                driver.get(url)
                driver.implicitly_wait(5)
                time.sleep(5)

                # 滚到最底端，获取完整的网页内容
                if not inDebug or inDebug:  # 有时候不滚到最底下会抓出来空白的
                    scrollDrive2Bottom(driver)

                # 处理 HTML 源码，生成文件，生成 PDF
                processHtml(driver.page_source, tarTitle)
            except:
                errList.append(title)

            # 爬一篇文章后休息几秒钟
            catchCount += 1
            time.sleep(5)
            print("\n\n")

    # 记录爬取文章的结束时间
    end = time.time()

    print("ffmpeg 下载列表  --> ffmpegDownList.txt")
    print("所有文章爬取完毕！共 %d 篇，耗时 %d 秒" % (catchCount, int(end - start)))

    if len(errList) > 0:
        print("失败的抓取：")
        for name in errList: print(name)


if __name__ == '__main__':
    main()
