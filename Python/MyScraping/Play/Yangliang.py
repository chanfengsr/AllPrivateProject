import time, re, os
from bs4 import BeautifulSoup
from selenium import webdriver


perFixList = ['0 讲义', '1 文本精讲', '2 亮解单词', '3 带读训练', '4 原声', '5 带读', '课后练习']
courseList = \
    ["Day 1 Find Your Greatness",
     "Day 2 Ideas Are Scary",
     "Day 3 Airplane Announcement (1)",
     "Day 4 Airplane Announcement (2)",
     "Day 5 The Astronomer",
     "Day 6 The Donkey in the Lion’s Skin",
     "Day 7 How to Be Proactive",
     "Day 8 Eat That Frog",
     "Day 9 Resident Evil - Opening scene",
     "Day 10 Shrek 1 - Opening Scene",
     "Day 11 ILM-Creating the Impossible",
     "Day 12 ILM-Creating the Impossible",
     "Day 13 Start With Why (1)",
     "Day 14 Start With Why (2)",
     "Day 15 Barack Obama Presidential Victory Speech, 2008",
     "Day 16 NAACP Image Awards Acceptance Speech",
     "Day 17 Cross-cultural Communication(1)",
     "Day 18 Cross-cultural Communication(2)",
     "Day 19 Audrey Hepburn",
     "Day 20 Heinz - The Ketchup Kings",
     "Day 21 Waken",
     "Day 22 Share the Spirit of Olympic Games",
     "Day 23 Stephen Fry - On Depression",
     "Day 24 Alexandre Dumas - Wait and Hope",
     "Day 25 HBO - The Complete OSCARS Experience",
     "Day 26 Reality TV - Big Brother",
     "Day 27 Police Arrest a Parrot",
     "Day 28 Labrador guns down its owner",
     "Day 29 The Picture of Dorian Gray",
     "Day 30 Animal Farm",
     "Day 31 Think Different",
     "Day 32 Mercedes-Benz - The best or nothing",
     "Day 33 IHG",
     "Day 34 Nick's Manhattan Beach",
     "Day 35 The Ass and His Purchaser",
     "Day 36 Mercury and The Sculptor",
     "Day 37 Clash of the Titans Opening Scene",
     "Day 38 Transformers Opening Scene",
     "Day 39 The Lord of the Rings - The Prologue",
     "Day 40 Zootopia-Judy Hopps’ Speech",
     "Day 41 Face Change Bravely",
     "Day 42 Persist, and Anything is Within Your Reach",
     "Day 43 David and Goliath：Underdogs, Misfits, and the Art of Battling Giants (1)",
     "Day 44 David and Goliath：Underdogs, Misfits, and the Art of Battling Giants (2)",
     "Day 45 The Road to Character (1)",
     "Day 46 The Road to Character (2)",
     "Day 47 Martin Luther King Jr. - I Have A Dream (Excerpts)",
     "Day 48 John F. Kennedy Presidential Inaugural Speech (Excerpts)",
     "Day 49 Truman Announces Hiroshima Bombing (1)",
     "Day 50 Truman Announces Hiroshima Bombing (2)",
     "Day 51 The unanimous Declaration of the thirteen united States of America (Excerpt)",
     "Day 52 The History of Slavery In America",
     "Day 53 Henry Ford",
     "Day 54  Liberace",
     "Day 55  Dale Carnegie - A Man of Influence",
     "Day 56 Arnold Schwarzenegger",
     "Day 57 Love’s Philosophy",
     "Day 58 How Do I Love Thee？",
     "Day 59 Ann Landers—On Class",
     "Day 60 Albert Einstein—Never Lose a Holy Curiosity",
     "Day 61 East of Eden (Excerpt)",
     "Day 62 In Search of Lost Time (Excerpt)",
     "Day 63 Bottlenose Dolphins",
     "Day 64 Jesus Christ Lizard"]

for doc in courseList:
    print(doc)
    for perfix in perFixList:
        print(perfix + ' ' + doc)
    print()

exit()

artFile = '.\\C365.html'

if os.path.exists(artFile):
    listFile = open(artFile, 'rt', encoding='UTF-8')
    origHtml = listFile.read()
    listFile.close()
    bs = BeautifulSoup(origHtml, "html.parser")

    for artItem in bs.find_all("h4", {"class": "weui_media_title"}):
        title = artItem.get_text().strip()
        url = artItem["hrefs"].strip()

        print(title)
        print(url)
        print()
