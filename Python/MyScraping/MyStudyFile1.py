import os
import os.path
import urllib
from urllib.request import urlopen, urlretrieve, pathname2url
import hashlib
import re
import html
from bs4 import BeautifulSoup
import random
import shutil
import tempfile
import math
import time
import datetime
from selenium import webdriver
import pdfkit, time, re


def main():
    artFile = 'GeekTime/demo.html'
    listFile = open(artFile, 'rt', encoding='UTF-8')
    origHtml = listFile.read()
    bs = BeautifulSoup(origHtml, "html.parser")

    print(bs.select_one('a[class="title"]').text.strip())

    print('Done.')


if __name__ == '__main__':
    main()
