using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastInfo : MonoBehaviour
{
    // Ở phần này, chúng ta sẽ giải thích về array (nó là gì, cách khai báo, tạo và sử dụng mảng)
    // Chúng ta sẽ tìm hiểu mảng một chiều và mảng nhiều chiều, các cách duyệt qua mảng khác nhau, cách đọc dữ liệu từ đầu vào và đầu ra.

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

    // Xem Demo và giải thích cho đoạn 1-3 ở đây
    MyArrayDemo MyArrayDemo;

    // 4. Truy cập và Duyệt Mảng
    // - Truy cập qua chỉ số: arr[i].
    // - Duyệt mảng bằng vòng lặp for, foreach, while.

    // 5. Bảo vệ Lỗi Tràn Chỉ Số
    // - Truy cập sai chỉ số sẽ gây lỗi IndexOutOfRangeException.

    // 6. Ví dụ Thao Tác với Mảng
    // - Đảo ngược mảng bằng cách sử dụng mảng phụ.
    // - Kiểm tra mảng đối xứng (phần tử đầu bằng phần tử cuối,...).
    // - Nhập và xuất mảng từ/ra console.
    // - In mảng với định dạng tùy chỉnh.

    // 7. Mảng Hai Chiều (Ma Trận)
    // - Khai báo: int[,] matrix = new int[2,3];
    // - Truy cập: matrix[row, col]
    // - Duyệt bằng vòng lặp lồng nhau.

    // 8. Mảng Jagged (Mảng các Mảng)
    // - Mỗi phần tử là một mảng con với độ dài khác nhau.
    // - Khai báo: int[][] jaggedArray = new int[2][];

}
