using System;
using System.Collections.Generic;
using System.Linq;
using Heap;

namespace Heap
{
    internal class BenchmarkException : Exception
    {
        public BenchmarkException()
        {
        }
    }

    internal class Node
    {
        public Node L;
        public Node R;
    }

    internal class NodeTree
    {
        public int value;
        public NodeTree L;
        public NodeTree R;
    }

    internal class Node2
    {
        public int value;
        public Node2 next;
    }

    internal class QueueNode2
    {
        private int _size;
        private Node2 _head;
        private Node2 _tail;

        public QueueNode2()
        {
            _size = 0;
            _head = new Node2();
            _tail = _head;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void Push(Node2 node)
        {
            _tail.next = node;
            _tail = node;
            _size++;
        }

        public Node2 Pop()
        {
            Node2 curHead = _head;
            _head = _head.next;
            _size--;
            return curHead;
        }
    }

    internal class HeapBenchmark
    {
        private static bool Int2bool(int i)
        {
            if (i == 0)
                return false;
            else
                return true;
        }

        private static int[] RandomInit(int size, int min, int max)
        {
            Random randNum = new Random();
            return Enumerable
                .Repeat(0, size)
                .Select(i => randNum.Next(min, max))
                .ToArray();
        }

        private static void __VERIFIER_assert(bool cond)
        {
            if (!cond)
            {
                throw new BenchmarkException();
            }
        }

        private static void remove(Node x)
        {
            if(x.R != null)
                x.R.L = x.L;
            if(x.L != null)
                x.L.R=x.R;
        }

        private static void re_insert(Node x)
        {
            if(x.R != null)
                x.R.L=x;
            if(x.L != null)
                x.L.R=x;
        }

        private static bool is_list_containing_x(Node l, Node x)
        {
            if(l == x)
                return true;

            if(l.R != null)
                return is_list_containing_x(l.R, x);

            return false;
        }

        public static void dancing_true(int n)
        {
            Node list = new Node();

            Node x = list;
            Node tail = list;

            while(true)
            {
                n -= 1;
                Node node = new Node();

                if(n == 0)
                    break;

                node.L = tail;
                tail.R = node;
                node.R = null;
                tail = node;
                if (n == 3)
                {
                    x = node;
                }
            }

            if (is_list_containing_x(list, x))
            {
                remove(x);
            }

            __VERIFIER_assert(list==x || !is_list_containing_x(list, x));
            re_insert(x);

            __VERIFIER_assert(is_list_containing_x(list, x));
        }

        public static Node2 Tree2List(NodeTree tree, Node2 list)
        {
            if (tree == null) return list;

            Node2 newNode = new Node2();
            newNode.value = tree.value;
            newNode.next = null;
            list.next = newNode;
            list = newNode;
            list = Tree2List(tree.L, list);
            list = Tree2List(tree.R, list);

            return list;
        }

        public static int SumList(Node2 list)
        {
            int res = 0;
            Node2 head = list;
            while (head != null)
            {
                res += head.value;
                head = head.next;
            }

            return res;
        }


        public static int SumTree(NodeTree tree)
        {
            if (tree == null) return 0;
            return SumTree(tree.L) + SumTree(tree.R) + tree.value;
        }

        public static void CheckTree(NodeTree tree)
        {
            Node2 list = new Node2();
            list.value = 0;
            Node2 head = list;
            Tree2List(tree, list);
            int s1 = SumList(head);
            int s2 = SumTree(tree);
            __VERIFIER_assert(s1 == s2);

        }

        public static void Main(string[] args)
        {
//            NodeTree root = new NodeTree {value = 25, L = new NodeTree{value = 15}
//                ,R = new NodeTree{value = 10, L = new NodeTree{value = 3}, R = new NodeTree{value =1}}};
//            CheckTree(root);
        }
    }
}
