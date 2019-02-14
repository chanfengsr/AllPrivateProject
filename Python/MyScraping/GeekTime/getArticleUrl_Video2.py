"""
用于获取摘要和回复
"""
import pdfkit, time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

listArtUrl = [('01 | 合格程序员的第一步：算法与数据结构', 'https://time.geekbang.org/course/detail/130-41518'),
 ('02 | 如何事半功倍地学习算法与数据结构', 'https://time.geekbang.org/course/detail/130-41524'),
 ('03 | 如何计算算法的复杂度', 'https://time.geekbang.org/course/detail/130-41531'),
 ('04 | 如何通过LeetCode来进行算法题目练习', 'https://time.geekbang.org/course/detail/130-41551'),
 ('05 | 理论讲解：数组&链表', 'https://time.geekbang.org/course/detail/130-41552'),
 ('06 | 面试题：反转一个单链表&判断链表是否有环', 'https://time.geekbang.org/course/detail/130-41547'),
 ('07 | 理论讲解：堆栈&队列', 'https://time.geekbang.org/course/detail/130-41553'),
 ('08 | 面试题：判断括号字符串是否有效', 'https://time.geekbang.org/course/detail/130-41557'),
 ('09 | 面试题：用队列实现栈&用栈实现队列', 'https://time.geekbang.org/course/detail/130-41558'),
 ('10 | 理论讲解：优先队列', 'https://time.geekbang.org/course/detail/130-41559'),
 ('11 | 面试题：返回数据流中的第K大元素', 'https://time.geekbang.org/course/detail/130-41560'),
 ('12 | 面试题：返回滑动窗口中的最大值', 'https://time.geekbang.org/course/detail/130-41561'),
 ('13 | 理论讲解：哈希表', 'https://time.geekbang.org/course/detail/130-42704'),
 ('14 | 面试题：有效的字母异位词', 'https://time.geekbang.org/course/detail/130-42702'),
 ('15 | 面试题：两数之和', 'https://time.geekbang.org/course/detail/130-42703'),
 ('16 | 面试题：三数之和', 'https://time.geekbang.org/course/detail/130-42705'),
 ('17 | 理论讲解：树&二叉树&二叉搜索树', 'https://time.geekbang.org/course/detail/130-42706'),
 ('18 | 面试题：验证二叉搜索树', 'https://time.geekbang.org/course/detail/130-42707'),
 ('19 | 面试题：二叉树&二叉搜索树的最近公共祖先', 'https://time.geekbang.org/course/detail/130-42708'),
 ('20 | 理论讲解：二叉树遍历', 'https://time.geekbang.org/course/detail/130-42709'),
 ('21 | 理论讲解：递归&分治', 'https://time.geekbang.org/course/detail/130-42710'),
 ('22 | 面试题：Pow(x,n)', 'https://time.geekbang.org/course/detail/130-42711'),
 ('23 | 面试题：求众数', 'https://time.geekbang.org/course/detail/130-42713'),
 ('24 | 理论讲解：贪心算法', 'https://time.geekbang.org/course/detail/130-42714'),
 ('25 | 面试题：买卖股票的最佳时机', 'https://time.geekbang.org/course/detail/130-42715'),
 ('26 | 理论讲解：广度优先搜索', 'https://time.geekbang.org/course/detail/130-42716'),
 ('27 | 理论讲解：深度优先搜索', 'https://time.geekbang.org/course/detail/130-42717'),
 ('28 | 面试题：二叉树层次遍历', 'https://time.geekbang.org/course/detail/130-67634'),
 ('29 | 面试题：二叉树的最大和最小深度', 'https://time.geekbang.org/course/detail/130-67635'),
 ('30 | 面试题：生成有效括号组合', 'https://time.geekbang.org/course/detail/130-67636'),
 ('31 | 理论讲解：剪枝', 'https://time.geekbang.org/course/detail/130-67637'),
 ('32 | 面试题：N皇后问题', 'https://time.geekbang.org/course/detail/130-67638'),
 ('33 | 面试题：数独问题', 'https://time.geekbang.org/course/detail/130-67639'),
 ('34 | 理论讲解：二分查找', 'https://time.geekbang.org/course/detail/130-67640'),
 ('35 | 面试题：实现一个求解平方根的函数', 'https://time.geekbang.org/course/detail/130-67641'),
 ('36 | 理论讲解：字典树', 'https://time.geekbang.org/course/detail/130-67642'),
 ('37 | 面试题：实现一个字典树', 'https://time.geekbang.org/course/detail/130-67644'),
 ('38 | 面试题：二维网格中的单词搜索问题', 'https://time.geekbang.org/course/detail/130-67643'),
 ('39 | 理论讲解：位运算', 'https://time.geekbang.org/course/detail/130-67645'),
 ('40 | 面试题：统计位1的个数', 'https://time.geekbang.org/course/detail/130-67646'),
 ('41 | 面试题：2的幂次方问题&比特位计数问题', 'https://time.geekbang.org/course/detail/130-67647'),
 ('42 | 面试题：N皇后问题的另一种解法', 'https://time.geekbang.org/course/detail/130-67648'),
 ('43 | 理论理解：动态规划（上）', 'https://time.geekbang.org/course/detail/130-69763'),
 ('44 | 理论理解：动态规划（下）', 'https://time.geekbang.org/course/detail/130-69764'),
 ('45 | 面试题：爬楼梯', 'https://time.geekbang.org/course/detail/130-69779'),
 ('46 | 面试题：三角形的最小路径和', 'https://time.geekbang.org/course/detail/130-69780'),
 ('47 | 面试题：乘积最大子序列', 'https://time.geekbang.org/course/detail/130-69781'),
 ('48 | 面试题：股票买卖系列', 'https://time.geekbang.org/course/detail/130-69782'),
 ('49 | 面试题：最长上升子序列', 'https://time.geekbang.org/course/detail/130-69783'),
 ('50 | 面试题：零钱兑换', 'https://time.geekbang.org/course/detail/130-69784'),
 ('51 | 面试题：编辑距离', 'https://time.geekbang.org/course/detail/130-69785'),
 ('52 | 理论讲解：并查集', 'https://time.geekbang.org/course/detail/130-72531'),
 ('53 | 面试题：岛屿的个数&朋友圈（上）', 'https://time.geekbang.org/course/detail/130-72539'),
 ('54 | 面试题：岛屿的个数&朋友圈（下）', 'https://time.geekbang.org/course/detail/130-72535'),
 ('55 | 理论讲解： LRU Cache', 'https://time.geekbang.org/course/detail/130-72543'),
 ('56 | 面试题：设计和实现一个LRU Cache缓存机制', 'https://time.geekbang.org/course/detail/130-72545'),
 ('57 | 理论讲解：布隆过滤器', 'https://time.geekbang.org/course/detail/130-72546'),
 ('58 | 课程重点回顾', 'https://time.geekbang.org/course/detail/130-73421'),
 ('59 | FAQ答疑&面试中切题四件套', 'https://time.geekbang.org/course/detail/130-73458'),
 ('60 | 回到起点：斐波拉契数列', 'https://time.geekbang.org/course/detail/130-73459'),
 ('61 | 白板实战番外篇：斐波拉契数列', 'https://time.geekbang.org/course/detail/130-73461'),
 ('62 | 最后的一些经验分享', 'https://time.geekbang.org/course/detail/130-73465')]


def SaveFile(artTitle, orgHtml):
    # 保存目录
    exportPath = "R:\\"

    # 生成干净的 html 的模板
    modHtml = "<html>%s<body><h3>%s</h3>%s%s</body></html>"

    fileTitle = re.sub('[\/:：*?"<>|]', '', artTitle.strip()).replace('  ', ' ')

    # 获取到网页完整内容
    bs = BeautifulSoup(orgHtml, "html.parser")

    # 只获取干净的摘要和留言 html 并保存
    [s.extract() for s in bs.find_all("script")]  # 去干净 JS
    headHtml = bs.find("head")
    contentBoxHtml = bs.find("div", {"class": "content-box"})
    commentsHtml = bs.find("div", {"class": "comments"})
    noCommentsHtml = bs.find("div", {"class": "no-comment"})
    if contentBoxHtml is None: contentBoxHtml = ''
    if commentsHtml is None or noCommentsHtml is not None: commentsHtml = ''

    # 跳过，不输出
    if contentBoxHtml == '' and commentsHtml == '':
        return

    targetHtml = modHtml % (headHtml, artTitle, contentBoxHtml, commentsHtml)
    htmlFile = open(exportPath + fileTitle + '.html', 'w', encoding='utf-8')
    htmlFile.write(targetHtml)
    htmlFile.close()


realDir = os.path.dirname(os.path.realpath(__file__))

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

# 定义 chromedriver 路径
driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'

# 获取chrome浏览器驱动
driver = webdriver.Chrome(executable_path=driver_path)

''' 调试可注释 
# 使用driver打开极客时间登录页面
print("正在登录网站...")
login_url = 'https://account.geekbang.org/signin'
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
'''

errList = []
for doc in listArtUrl:
    title, url = doc

    print("正在抓取：" + title)
    driver.get(url)
    driver.implicitly_wait(3)
    time.sleep(3)

    # 滚到最底端，获取完整的网页内容
    pageHeight_orig = driver.execute_script('return document.body.scrollHeight')
    while True:
        driver.execute_script('window.scrollBy(0,50000)')
        time.sleep(3)
        pageHeight_new = driver.execute_script('return document.body.scrollHeight')

        if pageHeight_new == pageHeight_orig:
            break
        else:
            pageHeight_orig = pageHeight_new

    try:
        SaveFile(title, driver.page_source)
        print("Done.")
    except:
        errList.append(title)

if len(errList) > 0:
    print('失败的抓取：')
    for name in errList:
        print(name)
