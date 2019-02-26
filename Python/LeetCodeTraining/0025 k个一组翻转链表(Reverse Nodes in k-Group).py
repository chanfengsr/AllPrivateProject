''' Todo
https://leetcode-cn.com/problems/reverse-nodes-in-k-group

给出一个链表，每 k 个节点一组进行翻转，并返回翻转后的链表。
k 是一个正整数，它的值小于或等于链表的长度。如果节点总数不是 k 的整数倍，那么将最后剩余节点保持原有顺序。
示例 :
给定这个链表：1->2->3->4->5
当 k = 2 时，应当返回: 2->1->4->3->5
当 k = 3 时，应当返回: 3->2->1->4->5
说明 :

你的算法只能使用常数的额外空间。
你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
'''


class Solution:
    def reverseKGroup(self, head, k):
        """
        :type head: ListNode
        :type k: int
        :rtype: ListNode
        """
        if head is None:
            return head

        headNew = None  # 新的返回值
        tail = None  # 单次反转的尾
        pre = None
        cur = head
        while cur is not None:
            canRev = True  # 当前位置往后，是否可以反转 k - 1 次

            # 测试后面是否可以反转 k - 1 次
            t = cur
            i = k - 1  # 当前元素开始需要单次翻转次数
            while i > 0:
                t = t.next
                if t is None:
                    canRev = False
                    break
                i -= 1

            # 开始反转
            if canRev:
                pre = None
                tt = cur

                i = k  # 反转次数
                while i > 0:
                    cur.next, pre, cur = pre, cur, cur.next
                    i -= 1

                if tail is not None:
                    tail.next = pre
                tail = tt
                if headNew is None:
                    headNew = pre
            else:
                if tail is not None:
                    tail.next = cur
                break

        return headNew if headNew is not None else head


# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

    def print(self):
        l = []
        wrk = self
        while wrk is not None:
            l.append(wrk.val)
            wrk = wrk.next
        print(l)

    def creatByList(list):
        ret = ListNode(list[0])
        wrk = ret
        for i in list[1:]:
            wrk.next = ListNode(i)
            wrk = wrk.next
        return ret

    creatByList = staticmethod(creatByList)


if __name__ == '__main__':
    s = Solution()
    head = ListNode.creatByList(list(range(1, 5 + 1)))

    head = None

    ret = s.reverseKGroup(head, 6)
    if ret:
        ret.print()
