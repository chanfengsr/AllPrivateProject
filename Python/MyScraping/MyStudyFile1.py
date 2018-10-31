import os
import os.path
import urllib
from urllib.request import urlopen, urlretrieve, pathname2url
import hashlib
import re
import html
from bs4 import BeautifulSoup
from selenium import webdriver
import random
import shutil
import tempfile
import time
import datetime
import math



dt1 = datetime.datetime.now()

a = 2 ** 2147483647 % 2147483647



dt2 = datetime.datetime.now()
print(str(dt2 - dt1))
print(dt1)
print(dt2)
