"""
    判断是否是素数
"""
import math

num = 2147483647


if num == 2:
    print(True)
    exit()

if num % 2 == 0:
    print(False)
    exit()

i = 3
isPrime = True
while i <= int(math.sqrt(num)):
    if num % i == 0:
        isPrime = False
        break

    i += 2

print(isPrime)