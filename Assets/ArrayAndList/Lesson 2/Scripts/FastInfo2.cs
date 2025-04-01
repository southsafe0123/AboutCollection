using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastInfo2 : MonoBehaviour
{
    // Ở phần này, chúng ta sẽ giải thích về List (nó là gì, cách khai báo, tạo và sử dụng danh sách động)
    // Chúng ta sẽ tìm hiểu danh sách một chiều, các cách duyệt qua List khác nhau, cách đọc và ghi dữ liệu từ đầu vào và đầu ra.
    
    // - Về cơ bản List giống Array, nhưng khác nhau ở cách khai báo và sử dụng collection, sẽ giải thích rõ hơn trong các demo

    // 1. List là gì?
    // - Là danh sách động chứa các phần tử có cùng kiểu dữ liệu.
    // - Các phần tử được đánh số từ 0 đến N-1 gọi là chỉ số (index).
    // - Tổng số phần tử gọi là Count.
    // - List chỉ có một chiều, nhưng có thể chứa các List khác để tạo List đa chiều (ít dùng).

    // 2. Khai báo và cấp phát bộ nhớ
    // - List KHÔNG CẦN ĐỘ DÀI CỐ ĐỊNH khi khai báo.
    // - BỘ NHỚ được CẤP PHÁT và mở rộng TỰ ĐỘNG khi thêm phần tử mới.
    // - List lưu trữ các phần tử trên heap giống như array.

    // 3. Khởi tạo List và Giá trị Mặc định
    // - CÓ THỂ KHỞI TẠO RỖNG hoặc khởi tạo kèm danh sách giá trị.
    // - Khi thêm phần tử bằng Add(), List sẽ TỰ ĐỘNG MỞ RỘNG.
    // - Không có giá trị mặc định như mảng, chỉ có khi bạn khởi tạo trước.

    // Xem Demo và giải thích cho đoạn 1-3
    MyListDemo MyListDemo;

    // 4. Truy cập và Duyệt List
    // - Truy cập qua chỉ số: list[i].
    // - Tương tác với List sử dụng collection.
    // - Truy cập sai chỉ số sẽ gây lỗi ArgumentOutOfRangeException.

    // Xem Demo và giải thích cho đoạn 4
    MySimpleList MySimpleList;


}
