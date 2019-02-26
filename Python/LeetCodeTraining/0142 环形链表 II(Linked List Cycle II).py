''' Done
https://leetcode-cn.com/problems/linked-list-cycle-ii

给定一个链表，返回链表开始入环的第一个节点。 如果链表无环，则返回 null。
为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 如果 pos 是 -1，则在该链表中没有环。
说明：不允许修改给定的链表。
 
示例 1：
输入：head = [3,2,0,-4], pos = 1
输出：tail connects to node index 1
解释：链表中有一个环，其尾部连接到第二个节点。


示例 2：
输入：head = [1,2], pos = 0
输出：tail connects to node index 0
解释：链表中有一个环，其尾部连接到第一个节点。


示例 3：
输入：head = [1], pos = -1
输出：no cycle
解释：链表中没有环。


 
进阶：
你是否可以不用额外空间解决此题？
'''

"""
思路：
0：起点
A：环点
B：相遇点
0--->A------>
     ^      |
     |      B
     <------|

0AB * 2 = 0ABAB
SO: 0AB = BAB
SO: 0A = BA
SO: 从 相遇点 B 开始出发和从 0 开始出发，会在 A 处相遇

"""


class Solution(object):
    def detectCycle(self, head):
        """
        :type head: ListNode
        :rtype: ListNode
        """

        # 找环
        hasCycle = False

        slow = fast = head
        while fast and fast.next:
            slow, fast = slow.next, fast.next.next
            if slow is fast:
                hasCycle = True
                break

        if not hasCycle:
            return None

        # 找环点，一起慢走
        fast = head
        while fast is not slow:
            fast, slow = fast.next, slow.next
        return slow


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
    pos = 2

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

    ret = s.detectCycle(n1)
    if ret is not None:
        print(ret.val)
    else:
        print(ret)
