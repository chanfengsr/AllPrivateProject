''' Done
https://leetcode-cn.com/problems/reverse-linked-list

反转一个单链表。
示例:
输入: 1->2->3->4->5->NULL
输出: 5->4->3->2->1->NULL
进阶:
你可以迭代或递归地反转链表。你能否用两种方法解决这道题？
'''

class Solution:
    def reverseList(self, head):
        """
        :type head: ListNode
        :rtype: ListNode
        """
        if head is None or head.next is None:
            return head

        cur, pre = head, None

        while cur:
            next = cur.next
            cur.next = pre
            pre = cur
            cur = next

        return pre

    # 极客时间
    def reverseListGeekTime(self, head):
        cur, prev = head, None
        while cur:
            cur.next, prev, cur = prev, cur, cur.next
        return prev


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
    head = ListNode.creatByList(list(range(10)))
    ret = s.reverseList(head)
    ret.print()
