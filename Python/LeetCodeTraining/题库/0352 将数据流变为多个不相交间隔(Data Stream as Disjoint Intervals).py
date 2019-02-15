'''
https://leetcode-cn.com/problems/data-stream-as-disjoint-intervals

给定一个非负整数的数据流输入 a1，a2，…，an，…，将到目前为止看到的数字总结为不相交的间隔列表。
例如，假设数据流中的整数为 1，3，7，2，6，…，每次的总结为：
[1, 1]
[1, 1], [3, 3]
[1, 1], [3, 3], [7, 7]
[1, 3], [7, 7]
[1, 3], [6, 7]

 
进阶：
如果有很多合并，并且与数据流的大小相比，不相交间隔的数量很小，该怎么办?
提示：
特别感谢 @yunhong 提供了本问题和其测试用例。
'''

# Definition for an interval.
# class Interval:
#     def __init__(self, s=0, e=0):
#         self.start = s
#         self.end = e

class SummaryRanges:

    def __init__(self):
        """
        Initialize your data structure here.
        """
        

    def addNum(self, val):
        """
        :type val: int
        :rtype: void
        """
        

    def getIntervals(self):
        """
        :rtype: List[Interval]
        """
        


# Your SummaryRanges object will be instantiated and called as such:
# obj = SummaryRanges()
# obj.addNum(val)
# param_2 = obj.getIntervals()


if __name__ == '__main__':
    s = Solution()
    # ret = s.
    print(s)
