'''
给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。

如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。

您可以假设除了数字 0 之外，这两个数都不会以 0 开头。

示例：

输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
输出：7 -> 0 -> 8
原因：342 + 465 = 807
'''


# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None


class Solution:
    def addTwoNumbers(self, l1, l2):
        """
        :type l1: ListNode
        :type l2: ListNode
        :rtype: ListNode
        """
        sum = l1.val + l2.val
        rem = sum // 10  # 整除进位部分
        ret = ListNode(sum % 10)  # 余数部分
        wrk = ret
        l1 = l1.next
        l2 = l2.next

        while l1 is not None or l2 is not None:
            v1 = 0 if l1 is None else l1.val
            v2 = 0 if l2 is None else l2.val

            sum = v1 + v2 + rem
            rem = sum // 10

            wrk.next = ListNode(sum % 10)
            wrk = wrk.next

            if l1 is not None:
                l1 = l1.next

            if l2 is not None:
                l2 = l2.next

        if rem > 0:
            wrk.next = ListNode(rem)
        return ret


if __name__ == '__main__':
    s = Solution()

    l1 = ListNode(2)
    l1.next = ListNode(4)
    l1.next.next = ListNode(5)

    l2 = ListNode(5)
    l2.next = ListNode(6)
    l2.next.next = ListNode(4)
    l2.next.next.next = ListNode(5)

    ret = s.addTwoNumbers(l1, l2)
    while ret is not None:
        print(ret.val)
        ret = ret.next
