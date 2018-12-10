using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DO_AN
{

    public partial class Form1 : Form
    {
        public Form1()
        {
         InitializeComponent();
        }      
     
        
            public int info;
            public Node Next;
            // Hàm khởi tạo
             void Node()
            {
            }
            void Node(int x, Node next)
            {
                this.info = x;
                this.Next = next;
            }
            // Tạo Node chứa dữ liệu
            Node CreateNode(int x)
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
            public Node Head;
            public Node Tail;
            void LinkedList()
            {
                Head = Tail = null;
            }
            // Hàm kiểm tra danh sách liên kết có rỗng hay không
             int IsEmptyList()
             {
                if (this.Head == null)
                    return 1;               // Danh sách rỗng
                return 0;                   // Danh sách không rỗng
             }
        // Thêm vào cuối danh sách
        Node addTail(Node tail,int x)
        { 
            Node p = new Node(x, null);
            p = CreateNode(x);
            if (tail == null)
                tail = p;
            else
            {
                this.Next = p;
                tail = tail.Next;
            }
            return tail;

        }
       
        Random rd = new Random();
        int[] M;
        Button[] Mn;
        int HEIGHT = 80;
        int SIZE = 50;
        int KHOANGCACHNUT = 50;
        public int speed()
        {
            int n = int.Parse(thoigian.Text.Trim());
            return n;
        }
        
        private void VENUT_Click(object sender, EventArgs e)
        {
            Node Head = new Node();
            Node Tail = new Node();
            int n = int.Parse(txtSoNut.Text.Trim());
            M = new int[n];
            Mn = new Button[n];
            MANHINH.Controls.Clear();
            for (int i = 0; i < n; i++)
            {
                Node value = new Node();
                Button btn = new Button();
                value.info = rd.Next(100);
                Tail = addTail(Tail, value.info);
                btn.Text = value.info + "" + value.Next + "";
                btn.Width = btn.Height = 50;
                btn.Location = new Point(
                    KHOANGCACHNUT + MANHINH.Controls.Count * (btn.Width + KHOANGCACHNUT),
                    MANHINH.Height / 2 - btn.Height / 2);
                MANHINH.Controls.Add(btn);
                value = value.Next;
                Mn[i] = btn;
            }
        }
        private void DiChuyen(int VITRI1, int VITRI2)
        {
            Status st = new Status();
            st.VITRI1 = VITRI1;
            st.VITRI2 = VITRI2;
            st.Type = LoaiDiChuyen.len_xuong;
            for (int x = 0; x < HEIGHT; x++)
            {
                backgroundWorker1.ReportProgress(0, st);
                System.Threading.Thread.Sleep(speed());
            }
            st.Type = LoaiDiChuyen.right_left;
            int WIDTH = Math.Abs(VITRI1 - VITRI2) * (SIZE + KHOANGCACHNUT);
            for (int x = 0; x < WIDTH; x++)
            {
                backgroundWorker1.ReportProgress(0, st);
                System.Threading.Thread.Sleep(speed());
            }
            st.Type = LoaiDiChuyen.xuong_len;
            for (int x = 0; x < HEIGHT; x++)
            {
                backgroundWorker1.ReportProgress(0, st);
                System.Threading.Thread.Sleep(speed());
            }

            st.Type = LoaiDiChuyen.stop;
            backgroundWorker1.ReportProgress(0, st);
            System.Threading.Thread.Sleep(speed());
        }
        Node Merge1(Node h1,Node h2)
        {
            Node t1 = new Node();
            Node t2 = new Node();
            Node temp = new Node();
            //Quay trở lại nếu danh sách thứ nhất trống.
            if (h1 == null)
                return h2;
            //Quay trở lại nếu danh sách thứ hai trống.
            if (h2 == null)
                return h1;
            t1 = h1;
            //Một vòng lặp để duyệt qua danh sách thứ hai, để hợp nhất các nút thành h1 theo cách được sắp xếp.
            while (h2 != null)
            {
                // Đặt nút đầu của danh sách thứ hai là t2.
                t2 = h2;

                // Chuyển đầu danh sách thứ hai sang đầu danh sách tiếp theo
                h2 = h2.Next;
                t2.Next = null;
                //Nếu giá trị dữ liệu nhỏ hơn đầu của danh sách đầu tiên, hãy thêm nút đó vào đầu.
                if (h1.info > h2.info)
                {
                    t2.Next = h1;
                    h1 = t2;
                    t1 = h1;
                    continue;
                }
            // đi qua danh sách đầu tiên.
            flag:

                if (t1.Next == null)
                {
                    t1.Next = t2;
                    t1 = t1.Next;
                }
                //chuyển danh sách đầu tiên cho đến t2->data nhiều hơn dữ liệu của nút.
                else if ((t1.Next).info <= t2.info)
                {
                    t1 = t1.Next;
                    goto flag;
                }
                else
                {
                    //Chèn nút dưới dạng t2->data sẽ nhỏ hơn nút tiếp theo.
                    temp = t1.Next;
                    t1.Next = t2;
                    t2.Next = temp;
                }

            }

            //Trả lại phần đầu của danh sách được sắp xếp mới.
            return h1;
        }
        void MergeSort1(Node head)  // trỏ đa cấp
        {
            Node first = new Node();
            Node second = new Node();
            Node temp = new Node();
            first = head;
            temp = head;
            //Quay trở lại nếu danh sách có ít hơn hai nút.
            if (first == null || first.Next == null)
            {
                return;
            }
            else
            {
                //Chia danh sách thành hai nửa đầu tiên và thứ hai là người đứng đầu danh sách.
                while (first.Next != null)
                {
                    first = first.Next;
                    if (first.Next != null)
                    {
                        temp = temp.Next;
                        first = first.Next;
                    }
                }
                second = temp.Next;
                temp.Next = null;
                first = head;
            }
            //Thực hiện cách tiếp cận phân chia và chinh phục.
            MergeSort1(first);
            MergeSort1(second);
            // Hợp nhất hai phần của danh sách thành một phần được sắp xếp.
            head = Merge1(first, second);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MergeSort1(Head);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Đã Xếp Xong !!!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        //Node Merge2(Node h1, Node h2)
        //{
        //    Node t1 = new Node();
        //    Node t2 = new Node();
        //    Node temp = new Node();
        //    //Quay trở lại nếu danh sách thứ nhất trống.
        //    if (h1 == null)
        //        return h2;
        //    //Quay trở lại nếu danh sách thứ hai trống.
        //    if (h2 == null)
        //        return h1;
        //    t1 = h1;
        //    //Một vòng lặp để duyệt qua danh sách thứ hai, để hợp nhất các nút thành h1 theo cách được sắp xếp.
        //    while (h2 != null)
        //    {
        //        // Đặt nút đầu của danh sách thứ hai là t2.
        //        t2 = h2;

        //        // Chuyển đầu danh sách thứ hai sang đầu danh sách tiếp theo
        //        h2 = h2.Next;
        //        t2.Next = null;
        //        //Nếu giá trị dữ liệu nhỏ hơn đầu của danh sách đầu tiên, hãy thêm nút đó vào đầu.
        //        if (h1.info  < h2.info)
        //        {
        //            t1.Next = h1;
        //            h1 = t2;
        //            t1 = h1;
        //            continue;
        //        }
        //    // đi qua danh sách đầu tiên.
        //    flag:

        //        if (t1.Next == null)
        //        {
        //            t1.Next = t2;
        //            t1 = t1.Next;
        //        }
        //        //chuyển danh sách đầu tiên cho đến t2->data nhiều hơn dữ liệu của nút.
        //        else if ((t1.Next).info <= t2.info)
        //        {
        //            t1 = t1.Next;
        //            goto flag;
        //        }
        //        else
        //        {
        //            //Chèn nút dưới dạng t2->data sẽ nhỏ hơn nút tiếp theo.
        //            temp = t1.Next;
        //            t1.Next = t2;
        //            t2.Next = temp;
        //        }

        //    }

        //    //Trả lại phần đầu của danh sách được sắp xếp mới.
        //    return h1;
        //}
        //void MergeSort2(Node head)  // trỏ đa cấp
        //{
        //    Node first = new Node();
        //    Node second = new Node();
        //    Node temp = new Node();
        //    first = head;
        //    temp = head;
        //    //Quay trở lại nếu danh sách có ít hơn hai nút.
        //    if (first == null || first.Next == null)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        //Chia danh sách thành hai nửa đầu tiên và thứ hai là người đứng đầu danh sách.
        //        while (first.Next != null)
        //        {
        //            first = first.Next;
        //            if (first.Next != null)
        //            {
        //                temp = temp.Next;
        //                first = first.Next;
        //            }
        //        }
        //        second = temp.Next;
        //        temp.Next = null;
        //        first = head;
        //    }
        //    //Thực hiện cách tiếp cận phân chia và chinh phục.
        //    MergeSort2(first);
        //    MergeSort2(second);
        //    // Hợp nhất hai phần của danh sách thành một phần được sắp xếp.
        //    head = Merge2(first, second);
        //}

    }
   
}
 
