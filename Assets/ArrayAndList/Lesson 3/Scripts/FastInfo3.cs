using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastInfo3 : MonoBehaviour
{
    // Ở phần này, chúng ta sẽ lược lại về array và list
    // sau đó sẽ so sánh và liệt kê những lưu ý khi sử dụng array và list

    // 1. Về khái niệm:
    // - Array: Là cấu trúc dữ liệu tĩnh, có kích thước cố định sau khi khởi tạo.
    // - List<T>: Là danh sách động, có thể tự động mở rộng khi thêm phần tử.

    // 2. Khởi tạo:
    // - Array: Phải chỉ định kích thước khi khởi tạo → new int[5]
    // - List: Có thể khởi tạo rỗng, không cần kích thước → new List<int>()

    // 3. Kích thước:
    // - Array: Dùng array.Length để lấy số phần tử.
    // - List: Dùng list.Count để lấy số phần tử.

    // 4. Truy cập phần tử:
    // - Cả array và list đều hỗ trợ truy cập qua chỉ số: arr[i], list[i]

    // 5. Thêm / Xóa phần tử:
    // - Array: Không thể thêm/xóa trực tiếp. Phải tạo mảng mới.
    // - List: Có thể dùng Add(), Remove(), RemoveAt(), Insert()... nhờ vào collection.

    // 6. Tự mở rộng bộ nhớ (List):
    // - List có thuộc tính Capacity → dung lượng mảng ẩn bên trong.
    // - Khi Count > Capacity → List tự tạo mảng mới lớn hơn và copy dữ liệu sang.
    // - Việc này tiêu tốn hiệu suất (do copy dữ liệu).

    // Xem lại Mục lục của 2 phần trước để nhớ về Array và List
    FastInfo fast1;
    FastInfo2 fast2;

    // 7. Sử dụng khi nào?
    // - Array: Dùng khi số lượng phần tử cố định, ưu tiên hiệu suất.
    // - List: Dùng khi dữ liệu có thể thay đổi linh hoạt trong quá trình chạy.

    // 8. Lưu ý đặc biệt:
    // - Array khi Clear = tạo mảng mới / gán null → bộ nhớ cũ có thể bị giữ lại nếu không giải phóng.
    // - List khi Clear = Count = 0, nhưng Capacity vẫn giữ nguyên → cần TrimExcess() nếu muốn giải phóng bộ nhớ.

    // Xem Demo và giải thích cho đoạn 7-8
    CautionArrayAndList caution;

    // 9. Tốc độ:
    // - Array thường có tốc độ truy cập nhanh hơn một chút so với List do không có thêm overhead quản lý.
    // - Tuy nhiên, List linh hoạt và dễ dùng hơn trong phần lớn các tình huống thực tế.
    // Xem Demo và giải thích cho đoạn 9
    ReadWriteSpeed readWriteSpeed;
    ArrayAndListMemory arrayAndListMemory;

    // 10. Gợi ý sử dụng:
    // - Nếu bạn cần sắp xếp dữ liệu cố định: dùng array.
    // - Nếu bạn cần thêm/xóa liên tục và không biết trước kích thước: dùng list.
}
