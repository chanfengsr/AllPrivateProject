''' Done
https://leetcode-cn.com/problems/linked-list-cycle

给定一个链表，判断链表中是否有环。
为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 如果 pos 是 -1，则在该链表中没有环。
 
示例 1：
输入：head = [3,2,0,-4], pos = 1
输出：true
解释：链表中有一个环，其尾部连接到第二个节点。


示例 2：
输入：head = [1,2], pos = 0
输出：true
解释：链表中有一个环，其尾部连接到第一个节点。


示例 3：
输入：head = [1], pos = -1
输出：false
解释：链表中没有环。


 
进阶：
你能用 O(1)（即，常量）内存解决此问题吗？
'''


class Solution(object):
    def hasCycle(self, head):
        """
        :type head: ListNode
        :rtype: bool
        """

        # 慢、快 指针
        p1, p2 = head, head

        while p2 is not None and p2.next is not None:
            p1, p2 = p1.next, p2.next.next
            if p1 is p2:
                return True

        return False

    def hasCycleGeedTime(self, head):
        fast = slow = head
        while slow and fast and fast.next:
            slow, fast = slow.next, fast.next.next

            if slow is fast:
                return True
        return False


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
    n1 = ListNode.creatByList([1, 2, 3, 4, 5])

    # 环起始下标
    pos = -1

    if pos >= 0:
        i = 0
        wrkNode = n1
        ringNode = None  # 环起始点
        while wrkNode.next is not None:
            if i == pos:
                ringNode = wrkNode

            i += 1
            wrkNode = wrkNode.next

        if ringNode is None:
            wrkNode.next = wrkNode
        else:
            wrkNode.next = ringNode

    # for j in range(20):
    #     print(n1.val)
    #     n1 = n1.next
    # exit()

    print(s.hasCycle(n1))
