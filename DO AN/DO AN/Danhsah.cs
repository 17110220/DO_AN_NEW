using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN
{
    public class Node
    {
        public int info;
        public Node Next;
        // Hàm khởi tạo
        public Node()
        {
        }
        public Node(int x, Node next)
        {
            this.info = x;
            this.Next = next;
        }
        // Tạo Node chứa dữ liệu
        public Node CreateNode(int x)
        {
            Node p = new Node();

            if (p == null)
            {
                return null;
            }
            else
            {
                this.info = x;
                this.Next = null;
                return p;
            }
        }
    }


    public class LinkedList
    {
        // Khai báo
        public Node Head;
        public Node Tail;

        public LinkedList()
        {
            Head = Tail = null;
        }
        // Hàm kiểm tra danh sách liên kết có rỗng hay không
        public int IsEmptyList()
        {
            if (this.Head == null)
                return 1;               // Danh sách rỗng
            return 0;                   // Danh sách không rỗng
        }
        // Thêm vào cuối danh sách
        public void addTail(int x)
        {
            Node p = new Node(x, null);
            if (this.Head == null)
                this.Head = this.Tail = p;
            else
            {
                this.Tail.Next = p;
                this.Tail = p;
            }
        }

    }
}
