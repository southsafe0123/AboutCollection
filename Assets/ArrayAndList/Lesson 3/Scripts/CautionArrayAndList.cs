using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class CautionArrayAndList : MonoBehaviour
{
    //khai báo
    public List<int> numbers;
    public List<string> players;

    //các lưu ý khi dùng list và array
    #region Nên cache numbers.count trước khi dùng for
    [ProButton]
    private void CacheCount()
    {
        int numCount = numbers.Count;
        for (int i = 0; i < numCount; i++)
        {
            Debug.Log(numbers[i]);
        }
    }
    #endregion

    #region Khi nào sử dụng Array
    [ProButton]
    private void UseArrayExample()
    {
        // Array nên dùng khi:
        // - Dữ liệu cố định
        // - Biết trước số lượng phần tử
        // - Ưu tiên hiệu suất (Array nhanh hơn List trong truy xuất tuần tự)
        string[] daysOfWeek = new string[]
        {
            "Sunday", "Monday", "Tuesday", "Wednesday",
            "Thursday", "Friday", "Saturday"
        };

        for (int i = 0; i < daysOfWeek.Length; i++)
        {
            Debug.Log(daysOfWeek[i]);
        }
    }
    #endregion

    #region Khi nào sử dụng List
    [ProButton]
    private void UseListExample()
    {
        // List phù hợp khi dữ liệu có thể thay đổi linh hoạt (thêm/xóa phần tử)
        players = new List<string> { "Alice", "Bob", "Charlie" };

        // Thêm phần tử vào danh sách
        players.Add("David");

        // Xóa phần tử khỏi danh sách
        players.Remove("Alice");

        // Duyệt qua danh sách và thực hiện các thao tác với phần tử
        foreach (var player in players)
        {
            Debug.Log(player);
        }

        // Tìm phần tử trong danh sách
        if (players.Contains("Charlie"))
        {
            // Thực hiện các thao tác khi tìm thấy "Charlie"
        }
    }
    #endregion

    #region Cẩn thận với Capacity của List<T>
    // Capacity (Dung lượng) là số lượng phần tử tối đa List<T> có thể chứa trước khi phải cấp phát thêm bộ nhớ.
    // mỗi khi thêm phần tử mới vào list, nếu số lượng đạt đến capacity, List<T> sẽ tự động tạo mới một List<T> khác có capacity lớn hơn.
    // Cấp phát bộ nhớ mới và sao chép dữ liệu cũ vào mảng mới, dẫn đến tốn thời gian và bộ nhớ tạm thời.
    // đã giải thích trong 
    MyListDemo demo;
    [ProButton]
    private void CapacityCaution1()
    {
        numbers = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            numbers.Add(i);
            Debug.Log($"Count: {numbers.Count}, Capacity: {numbers.Capacity}");
        }
    }

    //LƯU Ý
    //khi xóa phần tử của List<T>. ví dụ list.clear(), Count của list sẽ về 0, nhưng Capacity vẫn giữ nguyên, gây lãng phí bộ nhớ. 
    [ProButton]
    private void CapacityCaution2()
    {
        numbers = new List<int>(1000);
        for (int i = 0; i < 1000; i++)
        {
            numbers.Add(i);
        }

        // Xóa hết phần tử trong danh sách
        numbers.Clear();

        Debug.Log($"Count: {numbers.Count}, Capacity: {numbers.Capacity}");
        // Kết quả: Count: 0, Capacity: 1000

        // Có thể sử dụng TrimExcess để giải phóng bộ nhớ thừa
        numbers.TrimExcess();
        Debug.Log($"Count: {numbers.Count}, Capacity: {numbers.Capacity}");
        // Kết quả: Count: 0, Capacity: 0 (sau khi TrimExcess)
    }
    #endregion

    #region Chú ý khi xóa phần tử trong List<T>
        // ❌ Lỗi logic: khi xóa phần tử tại i, các phần tử phía sau sẽ bị dịch lên
    // => nên dùng vòng for ngược (reverse loop)
    //thay vào đó có thể dùng reverse for loop
    [ProButton]
    void Caution()
    {
        numbers = new List<int> { 1, 2, 3, 4, 5 };
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                numbers.RemoveAt(i);
            }
        }
    }

    //trong foreach không thể modify collection(delete)
    //nếu cố ý sẽ bị throw InvalidOperationException
    [ProButton]
    void Caution2()
    {
        numbers = new List<int> { 1, 2, 3, 4, 5 };
        foreach (var num in numbers)
        {
            if (num % 2 == 0)
            {
                numbers.Remove(num); // Lỗi: InvalidOperationException
            }
        }
    }
    #endregion
}

