using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN
{
    
        public enum LoaiDiChuyen
    {
        //Nút lệnh 1 tại vt1 đi lên, qua phải, đi xuông
        //Nút lệnh 2 đi xuống, qua trái, đi lên
        //tạo hành động cho nút lệnh di chuyển
        len_xuong,left_right,xuong_len,stop,right_left
    }
    //vị trí lúc di chuyển
    public class Status
    {
        public LoaiDiChuyen Type { get; set; }
        public int VITRI1 { get; set; }
        public int VITRI2 { get; set; }
    }
 
}
