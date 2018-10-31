"""
    计算素数

十亿内素数个数， 数字位数每增加一位，质数存在的概率的分母便增加2.3
π(10)=4
π(100)=25
π(1000)=168
π(10000)=1229
π(100000)=9592
π(1000000)=78498
π(10000000)=664579
π(100000000)=5761455
π(1000000000)=50847534

C语言 筛选法代码
https://zhidao.baidu.com/question/558184345.html

目前最大素数
序号	49
素数	2^74207281-1
位数	22,338,618
发现人	CurtisCooper
时间	2016

"""
import datetime
import math

numberLimit = 10000 * 1000

# 已计算出的值（可在已有结果上继续计算）
primeNum = [2]

# 起始计算值
num = 3
maxNum = numberLimit - 1 if numberLimit % 2 == 0 else numberLimit  # -1 确保最后出现 “100% completed.”
if primeNum[len(primeNum) - 1] > num:
    num = primeNum[len(primeNum) - 1] + 2

calcPercent = []  # 百分比位置，大于 100万 才有
if maxNum >= 10000 * 100 - 1:
    percent = 1.0
    count = 100 if maxNum > 10000 * 200 else 10
    subVal = 0.01 if maxNum > 10000 * 200 else 0.1

    while count > 0:
        calcPercent.insert(0, int(maxNum * percent))
        percent -= subVal
        count -= 1

percentAdd = 100 // (len(calcPercent)) if len(calcPercent) > 0 else 0
percentNum = percentAdd
percentVal = calcPercent.pop(0) if len(calcPercent) > 0 else maxNum + 1

isPrime = True
dt1 = datetime.datetime.now()
sqrt = int(math.sqrt(maxNum))
while num <= maxNum:
    isPrime = True

    # for pNum in primeNum:
    #     if pNum > num // 2:
    #         break
    #
    #     if num % pNum == 0:
    #         isPrime = False
    #         break

    for pNum in primeNum:
        if pNum > sqrt:
            break

        if num % pNum == 0:
            isPrime = False
            break

    if isPrime:
        primeNum.append(num)

    if num >= percentVal:
        print('%s%% completed.' % percentNum)
        percentNum += percentAdd
        percentVal = calcPercent.pop(0) if len(calcPercent) > 0 else maxNum

    num += 2

dt2 = datetime.datetime.now()

print()
print('Total found: %s' % len(primeNum))
print('Max prime number: %s' % primeNum[len(primeNum) - 1])
print('Time elapsed: %s' % str(dt2 - dt1))

# export to file
fileName = r"r:\\%s.txt" % datetime.datetime.now().__str__().replace(':', '').replace('.', '')
nf = open(fileName, 'wt')
for num in primeNum:
    nf.write(str(num) + ',')

nf.write('\n\nNumber Limit: %s' % numberLimit)
nf.write('\nTotal output: %s' % len(primeNum))
nf.write('\nMax prime number: %s' % primeNum[len(primeNum) - 1])
nf.write('\nTime elapsed: %s' % str(dt2 - dt1))
nf.close()
