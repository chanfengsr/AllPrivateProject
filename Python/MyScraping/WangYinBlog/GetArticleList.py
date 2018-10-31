from urllib.request import urlopen
from bs4 import BeautifulSoup
from WangYinBlog.ScrapWangYin import ScrapWangYin

html = urlopen("http://www.yinwang.org")
bsObj = BeautifulSoup(html, "html.parser")
scraper = ScrapWangYin()

# liList = bsObj.findAll("li", {"class": "list-group-item title"})
# for li in liList:
#     aTag = li.a

    # print(aTag.get_text())
    # print(aTag.attrs["href"])
    # print()

    # print("Scraping <<%s>> webpage..." % aTag.get_text())
    # scraper.sourceURL = aTag.attrs["href"]
    # scraper.ScrapHtml()
    # print("finished.\n")


liList = [r"http://www.yinwang.org/blog-cn/2017/01/02/elitism"]
for li in liList:
    scraper.sourceURL = li
    scraper.ScrapHtml()
    print("finished.\n")

print("All done.")

'''
讨厌的 C# IDisposable 接口
http://yinwang.org/blog-cn/2016/10/13/c-sharp-disposable

C 编译器优化过程中的 Bug
http://yinwang.org/blog-cn/2016/10/12/compiler-bug

对 Rust 语言的分析
http://yinwang.org/blog-cn/2016/09/18/rust

支付宝的身份验证问题
http://yinwang.org/blog-cn/2016/09/16/alipay

测试的道理
http://yinwang.org/blog-cn/2016/09/14/tests

Tesla autopilot 引起致命车祸
http://yinwang.org/blog-cn/2016/07/10/tesla-autopilot-fatal-crash

Google Maps的设计问题
http://yinwang.org/blog-cn/2016/07/05/google-maps

养生节目带来的危害
http://yinwang.org/blog-cn/2016/06/28/yangsheng

欧盟草拟法案，对机器人征税
http://yinwang.org/blog-cn/2016/06/24/robot-tax

两个计划的变动
http://yinwang.org/blog-cn/2016/06/22/plan-change

IT业给世界带来的危机
http://yinwang.org/blog-cn/2016/06/20/it-and-society

关于离开美国的决定
http://yinwang.org/blog-cn/2016/06/19/leaving-united-states

美国社会的信息不平等现象
http://yinwang.org/blog-cn/2016/06/14/information-inequality

Java 有值类型吗？
http://yinwang.org/blog-cn/2016/06/08/java-value-type

Swift 语言的设计错误
http://yinwang.org/blog-cn/2016/06/06/swift

我的 tweet 系统
http://yinwang.org/blog-cn/2016/05/25/my-tweet

正面思维的误区
http://yinwang.org/blog-cn/2016/05/22/positive-thinking

未来计划
http://yinwang.org/blog-cn/2016/05/14/future

关于博文的自愿付费方式
http://yinwang.org/blog-cn/2016/04/13/pay-blog

到底是谁在欺负我们读书少？
http://yinwang.org/blog-cn/2016/04/07/cfa

我为什么不再做PL人
http://yinwang.org/blog-cn/2016/03/31/no-longer-pl

Go语言，Docker和Kubernetes
http://yinwang.org/blog-cn/2016/03/27/docker

为什么自动车完全不可以犯错误
http://yinwang.org/blog-cn/2016/03/19/self-driving-car-liability

Google的眼光
http://yinwang.org/blog-cn/2016/03/17/google-vision

AlphaGo与人工智能
http://yinwang.org/blog-cn/2016/03/09/alpha-go

不要去SeaWorld
http://yinwang.org/blog-cn/2016/02/25/sea-world

我看自动驾驶技术
http://yinwang.org/blog-cn/2016/02/12/self-driving-car

给Java说句公道话
http://yinwang.org/blog-cn/2016/01/18/java

Tesla Autopilot
http://yinwang.org/blog-cn/2016/01/10/tesla-autopilot

给Las Vegas的差评
http://yinwang.org/blog-cn/2016/01/04/las-vegas

Tesla Model X的车门设计问题
http://yinwang.org/blog-cn/2015/12/21/tesla-model-x

写书计划
http://yinwang.org/blog-cn/2015/12/19/book-plan

Tesla Model S的设计失误
http://yinwang.org/blog-cn/2015/12/12/tesla-model-s

编程的智慧
http://yinwang.org/blog-cn/2015/11/21/programming-philosophy

图灵的光环
http://yinwang.org/blog-cn/2015/10/18/turing

谈谈Parser
http://yinwang.org/blog-cn/2015/09/19/parser

数学和编程
http://yinwang.org/blog-cn/2015/07/04/math

谈程序的正确性
http://yinwang.org/blog-cn/2015/07/02/program-correctness

DRY原则的误区
http://yinwang.org/blog-cn/2015/06/14/dry-principle

所谓软件工程
http://yinwang.org/blog-cn/2015/06/07/software-engineering

编程的宗派
http://yinwang.org/blog-cn/2015/04/03/paradigms

智商的圈套
http://yinwang.org/blog-cn/2015/03/20/trap-of-intelligence

我为什么不再公开开发Yin语言
http://yinwang.org/blog-cn/2015/03/18/yin-lang-secret

设计的重要性
http://yinwang.org/blog-cn/2015/03/17/design

我为什么在乎这一个A+
http://yinwang.org/blog-cn/2015/03/13/a-plus

不要做聪明人
http://yinwang.org/blog-cn/2015/03/08/be-a-fool

怎样尊重一个程序员
http://yinwang.org/blog-cn/2015/03/03/how-to-respect-a-programmer

所谓“人为错误”
http://yinwang.org/blog-cn/2015/02/24/human-errors

创造者的思维方式
http://yinwang.org/blog-cn/2015/02/01/creative-thinking

人的价值
http://yinwang.org/blog-cn/2015/01/29/human-value

牛校综合征
http://yinwang.org/blog-cn/2015/01/05/top-university-syndrome

我和 Google 的故事（2015 修订版）
http://yinwang.org/blog-cn/2014/12/31/google-story

在三藩的两年
http://yinwang.org/blog-cn/2014/12/11/san-francisco

恶评《星际穿越》
http://yinwang.org/blog-cn/2014/11/12/interstellar

RSS与三不主义
http://yinwang.org/blog-cn/2014/09/17/rss

谈创新
http://yinwang.org/blog-cn/2014/09/15/innovation

谦虚不是一种美德
http://yinwang.org/blog-cn/2014/08/14/modesty

怎样成为一个天才
http://yinwang.org/blog-cn/2014/08/11/genius

休息，休息一会儿
http://yinwang.org/blog-cn/2014/07/17/rest

关系模型的实质
http://yinwang.org/blog-cn/2014/04/24/relational

对 Go 语言的综合评价
http://yinwang.org/blog-cn/2014/04/18/golang

黑客文化的精髓
http://yinwang.org/blog-cn/2014/04/11/hacker-culture

电视编剧的问题
http://yinwang.org/blog-cn/2014/04/10/tv-formulas

天下第一萌程序
http://yinwang.org/blog-cn/2014/04/07/racket-pig

学术腐败是历史的必然
http://yinwang.org/blog-cn/2014/03/24/academic-corruption

一个对 Dijkstra 的采访视频
http://yinwang.org/blog-cn/2014/02/18/dijkstra-interview

程序语言与它们的工具
http://yinwang.org/blog-cn/2014/02/04/pl-tool

RubySonar：一个 Ruby 静态分析器
http://yinwang.org/blog-cn/2014/01/28/rubysonar

程序语言与……
http://yinwang.org/blog-cn/2014/01/25/pl-and

我和权威的故事
http://yinwang.org/blog-cn/2014/01/04/authority

PySonar2 开源了
http://yinwang.org/blog-cn/2013/10/29/pysonar2

丘奇和图灵
http://yinwang.org/blog-cn/2013/07/13/church-turing

Pydiff Python结构化程序比较工具
http://yinwang.org/blog-cn/2013/07/06/PyDiff-Python%E7%BB%93%E6%9E%84%E5%8C%96%E7%A8%8B%E5%BA%8F%E6%AF%94%E8%BE%83%E5%B7%A5%E5%85%B7

我离开了Coverity
http://yinwang.org/blog-cn/2013/06/19/bye-coverity

原因与证明
http://yinwang.org/blog-cn/2013/04/26/reason-and-proof

Ydiff 结构化的程序比较
http://yinwang.org/blog-cn/2013/04/21/ydiff-%E7%BB%93%E6%9E%84%E5%8C%96%E7%9A%84%E7%A8%8B%E5%BA%8F%E6%AF%94%E8%BE%83

程序语言不是工具
http://yinwang.org/blog-cn/2013/04/21/programming-languages-are-not-tools

编辑器与IDE
http://yinwang.org/blog-cn/2013/04/20/editor-ide

程序语言的常见设计错误(2) - 试图容纳世界
http://yinwang.org/blog-cn/2013/04/18/language-design-mistake2

关于语言的思考
http://yinwang.org/blog-cn/2013/04/17/languages

Yoda 表示法错在哪里
http://yinwang.org/blog-cn/2013/04/14/yoda-notation

几个超炫的专业词汇
http://yinwang.org/blog-cn/2013/04/14/terminology

一种新的操作系统设计
http://yinwang.org/blog-cn/2013/04/14/os-design

Markdown 的一些问题
http://yinwang.org/blog-cn/2013/04/14/markdown

谈程序的“通用性”
http://yinwang.org/blog-cn/2013/04/13/generality

什么是启发
http://yinwang.org/blog-cn/2013/04/12/inspiration

Scheme 编程环境的设置
http://yinwang.org/blog-cn/2013/04/11/scheme-setup

我为什么离开 Cornell
http://yinwang.org/blog-cn/2013/04/10/cornell

谈“测试驱动的开发”
http://yinwang.org/blog-cn/2013/04/07/test-driven-dev

爱因斯坦谈教育
http://yinwang.org/blog-cn/2013/04/03/einstein-on-education

谈谈 Currying
http://yinwang.org/blog-cn/2013/04/02/currying

谈惰性求值
http://yinwang.org/blog-cn/2013/04/01/lazy-evaluation

对函数式语言的误解
http://yinwang.org/blog-cn/2013/03/31/purely-functional

什么是“脚本语言”
http://yinwang.org/blog-cn/2013/03/29/scripting-language

Chez Scheme 的传说
http://yinwang.org/blog-cn/2013/03/28/chez-scheme

Lisp 已死，Lisp 万岁！
http://yinwang.org/blog-cn/2013/03/26/lisp-dead-alive

论对东西的崇拜
http://yinwang.org/blog-cn/2013/03/24/tools

“解决问题”与“消灭问题”
http://yinwang.org/blog-cn/2013/03/19/eliminate-problems

程序语言的常见设计错误(1) - 片面追求短小
http://yinwang.org/blog-cn/2013/03/15/language-design-mistake1

谈语法
http://yinwang.org/blog-cn/2013/03/08/on-syntax

Oberon 操作系统：被忽略的珍宝
http://yinwang.org/blog-cn/2013/03/07/oberon

谈 Linux，Windows 和 Mac
http://yinwang.org/blog-cn/2013/03/07/linux-windows-mac

解密“设计模式”
http://yinwang.org/blog-cn/2013/03/07/design-patterns

Braid - 一个发人深思的游戏
http://yinwang.org/blog-cn/2013/03/04/braid

TeXmacs：一个真正“所见即所得”的排版系统
http://yinwang.org/blog-cn/2012/09/18/texmacs

怎样写一个解释器
http://yinwang.org/blog-cn/2012/08/01/interpreter

什么是语义学
http://yinwang.org/blog-cn/2012/07/25/semantics

GTF - Great Teacher Friedman
http://yinwang.org/blog-cn/2012/07/04/dan-friedman

什么是“对用户友好”
http://yinwang.org/blog-cn/2012/05/18/user-friendliness

'''
