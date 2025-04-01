using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

// Để sử dụng list, ta cần khai báo namespace System.Collections.Generic.
using System.Collections.Generic;
using static UnityEditor.Progress;
using static MyListDemo;

public class MyListDemo : MonoBehaviour
{
    // List khai báo có thể chứa dữ liệu thuộc kiểu bất kỳ do tham số truyền vào là dạng generic.

    // Kiểu nguyên thủy ví dụ: int, float, char, bool,...
    public List<float> listFloat;
    public List<int> listInt;
    // Kiểu tham chiếu ví dụ: string, object, class, array,...
    public List<string> listString;
    public List<Player> listPlayer;
    private void Start()
    {
        // Tuy đã khai báo, nhưng các list vẫn chưa được khởi tạo (chưa tạo vùng nhớ).
        // Vì vậy, mặc định các biến List sẽ có giá trị là null.
        // => Cần dùng "new List<>()" để cấp phát vùng nhớ trước khi sử dụng.
        // Khác với Array, List không có độ dài cố định. Khi khởi tạo không bắt buộc phải chỉ định kích thước ban đầu vì List sẽ tự động mở rộng khi thêm phần tử mới.

        // Kiểu nguyên thủy ví dụ
        listFloat = new List<float>();
        listInt = new List<int>();
        // Kiểu tham chiếu ví dụ
        listString = new List<string>();
        listPlayer = new List<Player>();


        // hoặc có thể khai báo giới hạn kích thước trước được nốt (vì về cơ bản List là phiên bản mở rộng của Array, vậy nên không lạ lùng gì điều này)
        // Kiểu nguyên thủy ví dụ
        listFloat = new List<float>(5);
        listInt = new List<int>(5);
        // Kiểu tham chiếu ví dụ
        listString = new List<string>(5);
        listPlayer = new List<Player>(5);
    }
    // Sau khi khởi tạo, List hiện tại đã có thể sử dụng. Tuy nhiên, List KHÔNG tự tạo phần tử sẵn.
    // Các giá trị mặc định chỉ xuất hiện khi bạn chủ động thêm phần tử vào danh sách. (dòng 32 - 37)
    // Ví dụ: nếu thêm 1 phần tử kiểu nguyên thủy, giá trị mặc định sẽ là 0, kiểu tham chiếu sẽ là null

    // Kiểm tra giá trị mặc định trong List sau khi thêm phần tử
    [ProButton]
    void GetValue()
    {
        MyDebug.Log($"listFloat[0] = {listFloat[0]}");
        MyDebug.Log($"listInt[0] = {listInt[0]}");
    }

    // Kiểu tham chiếu sẽ là null nếu chưa gán gì
    [ProButton]
    void GetRefValue()
    {
        //vì là null nên các giá trị này khi debuglog không cho ra kết quả
        MyDebug.Log($"listPlayer[0].name = {listPlayer[0].name}");
        MyDebug.Log($"listString[0] = {listString[0]}");
    }

    // Gán giá trị vào phần tử đầu tiên trong List và kiểm tra
    [ProButton]
    void SetPlayerValue()
    {
        Player player = new Player
        {
            id = 0,
            name = "An",
            score = 10,
        };

        listPlayer[0] = player;
        MyDebug.Log("Success! listPlayer[0].name = " + listPlayer[0].name);
    }

    // Ngoài ra còn có 1 thứ cần chú ý ở list, đó là Tổng sức chứa phần tử của List (Capacity)
    // Khi thêm phần tử mới, bộ nhớ được cấp phát và mở rộng tự động
    // Khi tạo mới, Capacity sẽ = 0 và lần đầu thêm phần từ Capacity sẽ = 4. Sau đó, cứ mỗi lần số phần tử (Count) đạt đến tổng sức chứa phần tử của list (Capacity)
    // => Capacity sẽ x2 độ lớn.
    // Mỗi lần như vậy sẽ rất tốn tài nguyên để update lại bộ nhớ, vậy nên đây là một điều cần lưu ý khi sử dụng list.
    [ProButton]
    void CheckCapacity()
    {
        listInt = new List<int>();
        for (int i = 0; i < 34; i++)
        {
            listInt.Add(i);
            MyDebug.Log($"List count:{listInt.Count}/ List capacity: {listInt.Capacity}");
        }
    }

    // Vậy cách mà list mở rộng sẽ như thế nào?
    // Về cơ bản, List là phiên bản mở rộng của Array, vậy nên ta sẽ viết 1 custom List từ Array nhé :3

    public class MyCustomList<T>
    {
        // Khởi tạo array generic
        private T[] items;
        private int count;

        // lấy count và capacity của List phiên bản tả thực
        public int Count => count;
        public int Capacity => items.Length;

        public MyCustomList()
        {
            items = new T[4]; // Giống List<T>, bắt đầu với capacity 4
            count = 0;
        }

        /// <summary>
        /// Linh động thêm item vào list.
        /// mỗi khi đầy phần tử trong array ẩn của list. nó sẽ tự động nâng capacity lên
        /// </summary>
        public void Add(T item)
        {
            if (count >= Capacity)
            {
                // Mở rộng capacity: nhân đôi
                int newCapacity = Capacity * 2;
                T[] newArray = new T[newCapacity];
                for (int i = 0; i < count; i++)
                {
                    newArray[i] = items[i];
                }

                items = newArray;
            }

            items[count] = item;
            count++;
        }

        /// <summary>
        /// Lấy/đặt phần tử tại vị trí index (bắt đầu từ 0).
        /// Bên ngoài sẽ truy xuất thông qua hàm này, ko sử dụng mảng nội bộ
        /// </summary>
        public T this[int index]
        {
            //Trong này có 2 exception huyền thoại mà ngày nào cũng gặp :))
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new System.IndexOutOfRangeException();

                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new System.IndexOutOfRangeException();
                }
                items[index] = value;
            }
        }
    }

    //khai báo list
    MyCustomList<int> customListInt;
    MyCustomList<Player> customListPlayer;
    [ProButton]
    void MyCheckCapacity()
    {
        customListInt = new MyCustomList<int>();
        for (int i = 0; i < 34; i++)
        {
            customListInt.Add(i);
            MyDebug.Log($"List count:{customListInt.Count}/ List capacity: {customListInt.Capacity}");
        }
        // có thể thấy, mỗi lần array đạt giới hạn, để mở rộng bằng cách x2 sức chứa, nó sẽ tạo 1 mảng mới và duyệt dòng for.
        // mỗi lần như vậy, dữ liệu sẽ lớn dần, ảnh hưởng đến bộ nhớ của máy.
    }

    // Gán giá trị vào phần tử đầu tiên trong List và kiểm tra
    [ProButton]
    void SetMyPlayerValue()
    {
        customListPlayer = new MyCustomList<Player>();
        Player player = new Player
        {
            id = 0,
            name = "An",
            score = 10,
        };
        customListPlayer.Add(player);
        MyDebug.Log("Success! listPlayer[0].name = " + customListPlayer[0].name);
    }
}