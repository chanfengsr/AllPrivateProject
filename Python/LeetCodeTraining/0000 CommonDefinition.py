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
    sListNode = ListNode.creatByList(list(range(10)))
    # ret = s.
    sListNode.print()
