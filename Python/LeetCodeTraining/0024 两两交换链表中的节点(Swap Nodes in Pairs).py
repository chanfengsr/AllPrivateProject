''' Done
https://leetcode-cn.com/problems/swap-nodes-in-pairs

给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。
你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
 
示例:
给定 1->2->3->4, 你应该返回 2->1->4->3.
'''


class Solution:
    def swapPairs(self, head):
        """
        :type head: ListNode
        :rtype: ListNode
        """
        if head is None or head.next is None:
            return head

        ret = head.next
        pre = None
        while head is not None and head.next is not None:
            nHead = head.next.next
            if pre is not None:
                pre.next = head.next

            head.next.next, head, pre = head, head.next, head
            head.next.next = nHead
            head = nHead

        return ret

    # 极客时间
    def swapPairsGeekTime(self, head):
        pre, pre.next = self, head
        while pre.next and pre.next.next:
            a = pre.next
            b = a.next
            pre.next, b.next, a.next = b, a, b.next
            pre = a
        return self.next


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
    head = ListNode.creatByList(list(range(7)))
    ret = s.swapPairs(head)
    ret.print()
