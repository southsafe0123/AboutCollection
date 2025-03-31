using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastInfo : MonoBehaviour
{
    // Ở phần này, chúng ta sẽ giải thích về array (nó là gì, cách khai báo, tạo và sử dụng mảng)
    // Chúng ta sẽ tìm hiểu mảng một chiều các cách duyệt qua mảng khác nhau, cách đọc dữ liệu từ đầu vào và đầu ra.

    // 1. Mảng là gì?
    // - Là tập hợp các biến có cùng kiểu dữ liệu, gọi là phần tử.
    // - Đánh số từ 0 đến N-1 gọi là chỉ số (index).
    // - Tổng số phần tử của mảng gọi là độ dài (length) của mảng.
    // - Mảng có nhiều chiều nhưng phổ biến nhất là mảng một chiều và mảng hai chiều.

    // 2. Khai báo và cấp phát bộ nhớ
    // - Mảng có độ dài cố định, được xác định khi khởi tạo.
    // - Các phần tử của mảng được lưu trong bộ nhớ heap.

    // 3. Khởi tạo Mảng và Giá trị Mặc định
    // - Mảng có thể được khởi tạo cùng lúc khi khai báo.
    // - Các phần tử số mặc định là 0, kiểu tham chiếu mặc định là null.

    // Xem Demo và giải thích cho đoạn 1-3
    MyArrayDemo MyArrayDemo;

    // 4. Truy cập và Duyệt Mảng
    // - Truy cập qua chỉ số: arr[i].
    // - Duyệt mảng bằng vòng lặp for, foreach, while.
    // - Truy cập sai chỉ số sẽ gây lỗi IndexOutOfRangeException.

    // Xem Demo và giải thích cho đoạn 4
    MySimpleArray MySimpleArray;

    //5. Sắp xếp và đảo ngược mảng
    // - Sắp xếp bằng hệ thông sử dụng Array.Sort()
    // - Sắp xếp bằng hệ thống sử dụng hàm tự chế.
    // - Đảo ngược mảng bằng hệ thông sử dụng Array.Sort()
    // - Đảo ngược mảng bằng hệ thống sử dụng hàm tự chế.

    // Xem Demo và giải thích cho đoạn 5
    MyClassArray MyClassArray;



}
