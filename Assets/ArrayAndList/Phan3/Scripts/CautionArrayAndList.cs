using System.Collections.Generic;
using UnityEngine;

public class CautionArrayAndList : MonoBehaviour
{
    //khai báo list và array
    public List<int> numbers = new List<int>(5);
    
    //các lưu ý khi dùng list và array
    #region Nên cache numbers.count trước khi dùng for
    private void CacheExample()
    {
        int numCount = numbers.Count;
        for (int i = 0; i < numCount; i++)
        {
            Debug.Log(numbers[i]);
        }
    }
    #endregion

    #region Khi nào sử dụng Array
    private void UseArrayExample()
    {
        // Array phù hợp khi dữ liệu có kích thước cố định, không thay đổi trong quá trình chạy
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
    private void UseListExample()
    {
        // List phù hợp khi dữ liệu có thể thay đổi linh hoạt (thêm/xóa phần tử)
        List<string> players = new List<string> { "Alice", "Bob", "Charlie" };

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
    private void CapacityCaution1()
    {
        List<int> numbers = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            numbers.Add(i);
            Debug.Log($"Count: {numbers.Count}, Capacity: {numbers.Capacity}");
        }
    }


    //khi xóa phần tử của List<T>. ví dụ list.clear(), Count của list sẽ về 0, nhưng Capacity vẫn giữ nguyên, gây lãng phí bộ nhớ. 

    private void CapacityCaution2()
    {
       
        List<int> numbers = new List<int>(1000);
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
    //Không nên dùng List<T> khi chỉ thêm/xóa phần tử ở đầu danh sách, vì phải di chuyển toàn bộ các phần tử phía sau
    //vì khi xóa các phần tử trong list, danh sách sẽ được cập nhật lại, các vị trí cũng theo đó mà thay đổi.
    //thay vào đó có thể dùng reverse for loop

    void Caution()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                numbers.RemoveAt(i); // Lỗi: IndexOutOfRangeException
            }
        }
    }

    //trong foreach không thể modify collection(delete)
    //nếu cố ý sẽ bị throw InvalidOperationException
    void Caution2()
    {
        foreach (var num in numbers)
        {
            if (num % 2 == 0)
            {
                numbers.Remove(num); // Lỗi: InvalidOperationException
            }
        }
    }
    #endregion


    #region
    #endregion
}

