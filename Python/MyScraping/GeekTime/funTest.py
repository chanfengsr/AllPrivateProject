import time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver

dicArtUrl = {}
# 定义 chromedriver 路径
realDir = os.path.dirname(os.path.realpath(__file__))
driver_path = realDir + r'\..\..\virtualEnv\chromedriver_2.43\chromedriver.exe'
# 获取chrome浏览器驱动

driver = webdriver.Chrome(executable_path=driver_path)
driver.get(r'https://time.geekbang.org/course/detail/145-71676')
driver.implicitly_wait(2)
time.sleep(2)

# print(driver.find_element('class name','on').text)


# 文章总数
artCount = len(driver.find_element_by_class_name('video-list').find_elements_by_tag_name('li'))

findCurLoc = False  # 找到当前网页的位置
for i in range(5):
    videoList = driver.find_element_by_class_name('video-list')
    for t in videoList.find_elements_by_tag_name('li'):
        if findCurLoc:  # 点击下一篇
            t.click()
            driver.implicitly_wait(1)
            # time.sleep(1)
            findCurLoc = False
            break

        # print('%s : %s' % (t.text,t.get_attribute('class')))
        if t.get_attribute('class') == 'on':  # 找到当前位置了,准备点击下一篇
            findCurLoc = True
            dicArtUrl[driver.find_element_by_class_name('vplayer').find_element_by_class_name(
                'title').text] = driver.current_url

print(dicArtUrl)

dicArtUrl = {'01 | 课程综述': 'https://time.geekbang.org/course/detail/145-71676',
             '02 | 安装Git': 'https://time.geekbang.org/course/detail/145-71677',
             '03 | 使用Git之前需要做的最小配置': 'https://time.geekbang.org/course/detail/145-71678',
             '04 | 创建第一个仓库并配置local用户信息': 'https://time.geekbang.org/course/detail/145-71679',
             '05 | 通过几次commit来认识工作区和暂存区': 'https://time.geekbang.org/course/detail/145-71680',
             '06 | 给文件重命名的简便方法': 'https://time.geekbang.org/course/detail/145-71681',
             '07 | 通过git log 查看版本演变历史': 'https://time.geekbang.org/course/detail/145-71682',
             '08 | gitk：通过图形界面工具来查看版本历史': 'https://time.geekbang.org/course/detail/145-71683',
             '09 | 探密.git目录': 'https://time.geekbang.org/course/detail/145-71684',
             '10 | commit、tree和blob三个对象之间的关系': 'https://time.geekbang.org/course/detail/145-72012',
             '11 | 小练习：数一数tree的个数': 'https://time.geekbang.org/course/detail/145-71685',
             '12 | 分离头指针情况下的注意事项': 'https://time.geekbang.org/course/detail/145-72013',
             '13 | 进一步理解HEAD和branch': 'https://time.geekbang.org/course/detail/145-71686',
             '14 | 怎么删除不需要的分支？': 'https://time.geekbang.org/course/detail/145-72794',
             '15 | 怎么修改最新commit的message？': 'https://time.geekbang.org/course/detail/145-72795',
             '16 | 怎么修改老旧commit的message？': 'https://time.geekbang.org/course/detail/145-72796',
             '17 | 怎样把连续的多个commit整理成1个？': 'https://time.geekbang.org/course/detail/145-72797',
             '18 | 怎样把间隔的几个commit整理成1个？': 'https://time.geekbang.org/course/detail/145-72798',
             '19 | 怎么比较暂存区和HEAD所含文件的差异？': 'https://time.geekbang.org/course/detail/145-72799',
             '20 | 怎么比较工作区和暂存区所含文件的差异？': 'https://time.geekbang.org/course/detail/145-72800',
             '21 | 如何让暂存区恢复成和HEAD的一样？': 'https://time.geekbang.org/course/detail/145-72801',
             '22 | 如何让工作区的文件恢复为和暂存区一样？': 'https://time.geekbang.org/course/detail/145-73552',
             '23 | 怎样取消暂存区部分文件的更改？': 'https://time.geekbang.org/course/detail/145-73553',
             '24 | 消除最近的几次提交': 'https://time.geekbang.org/course/detail/145-73554',
             '25 | 看看不同提交的指定文件的差异': 'https://time.geekbang.org/course/detail/145-73555',
             '26 | 正确删除文件的方法': 'https://time.geekbang.org/course/detail/145-73556',
             '27 | 开发中临时加塞了紧急任务怎么处理？': 'https://time.geekbang.org/course/detail/145-73557',
             '28 | 如何指定不需要Git管理的文件？': 'https://time.geekbang.org/course/detail/145-73558',
             '29 | 如何将Git仓库备份到本地？': 'https://time.geekbang.org/course/detail/145-73559',
             '30 | 注册一个GitHub账号': 'https://time.geekbang.org/course/detail/145-73560',
             '31 | 配置公私钥': 'https://time.geekbang.org/course/detail/145-73561',
             '32 | 在GitHub上创建个人仓库': 'https://time.geekbang.org/course/detail/145-75473',
             '33 | 把本地仓库同步到GitHub': 'https://time.geekbang.org/course/detail/145-75474',
             '34 | 不同人修改了不同文件如何处理？': 'https://time.geekbang.org/course/detail/145-75475',
             '35 | 不同人修改了同文件的不同区域如何处理？': 'https://time.geekbang.org/course/detail/145-75476',
             '36 | 不同人修改了同文件的同一区域如何处理？': 'https://time.geekbang.org/course/detail/145-75477',
             '37 | 同时变更了文件名和文件内容如何处理？': 'https://time.geekbang.org/course/detail/145-75478',
             '38 | 把同一文件改成了不同的文件名如何处理？': 'https://time.geekbang.org/course/detail/145-75479',
             '39 | 禁止向集成分支执行push -f操作': 'https://time.geekbang.org/course/detail/145-75480',
             '40 | 禁止向集成分支执行变更历史的操作': 'https://time.geekbang.org/course/detail/145-75481',
             '41 | GitHub为什么会火？': 'https://time.geekbang.org/course/detail/145-75911',
             '42 | GitHub都有哪些核心功能？': 'https://time.geekbang.org/course/detail/145-75912',
             '43 | 怎么快速淘到感兴趣的开源项目?': 'https://time.geekbang.org/course/detail/145-75913',
             '44 | 怎样在GitHub上搭建个人博客': 'https://time.geekbang.org/course/detail/145-76146',
             '45 | 开源项目怎么保证代码质量？': 'https://time.geekbang.org/course/detail/145-76147',
             '46 | 为何需要组织类型的仓库？': 'https://time.geekbang.org/course/detail/145-76148',
             '47 | 创建团队的项目': 'https://time.geekbang.org/course/detail/145-76151',
             '48 | 怎样选择适合自己团队的工作流？': 'https://time.geekbang.org/course/detail/145-76152',
             '49 | 如何挑选合适的分支集成策略？': 'https://time.geekbang.org/course/detail/145-76153',
             '50 | 启用issue跟踪需求和任务': 'https://time.geekbang.org/course/detail/145-76174',
             '51 | 如何用project管理issue？': 'https://time.geekbang.org/course/detail/145-76175',
             '52 | 项目内部怎么实施code review？': 'https://time.geekbang.org/course/detail/145-76180',
             '53 | 团队协作时如何做多分支的集成？': 'https://time.geekbang.org/course/detail/145-76379',
             '54 | 怎样保证集成的质量？': 'https://time.geekbang.org/course/detail/145-76380',
             '55 | 怎样把产品包发布到GitHub上？': 'https://time.geekbang.org/course/detail/145-76381',
             '56 | 怎么给项目增加详细的指导文档？': 'https://time.geekbang.org/course/detail/145-76382',
             '57 | 国内互联网企业为什么喜欢GitLab？': 'https://time.geekbang.org/course/detail/145-76383',
             '58 | GitLab有哪些核心的功能？': 'https://time.geekbang.org/course/detail/145-76384',
             '59 | GitLab上怎么做项目管理？': 'https://time.geekbang.org/course/detail/145-76385',
             '60 | GitLab上怎么做code review？': 'https://time.geekbang.org/course/detail/145-76394',
             '61 | GitLab上怎么保证集成的质量？': 'https://time.geekbang.org/course/detail/145-76395'}
