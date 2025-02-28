using UnityEngine;

public class MyFindArray : MonoBehaviour
{
    //nếu chưa xem MyFindList.cs, hãy xem nó đầu tiên...

    //1. (có thể lướt nhanh qua phần này)
    #region Tìm kiếm cơ bản
    /*
     
     public int[] numbers;

    private void Awake()
    {
        // Khởi tạo mảng với các giá trị ban đầu
        numbers = new int[] { 10, 20, 30, 40, 50 };
    }

    private void Start()
    {
        // Về cơ bản Array không có các hàm hỗ trợ sẵn để truy xuất, tìm kiếm.
        // Vậy nên ta phải viết hàm riêng để thao tác.

        // Thêm giá trị vào mảng (tạo mảng mới với kích thước lớn hơn)
        numbers = AddToArray(numbers, 30);

        // Tìm index đầu tiên của phần tử trong mảng
        int index = IndexOf(numbers, 30); // Kết quả là 2, vì tìm thấy phần tử 30 đầu tiên

        // Tìm index cuối cùng của phần tử trong mảng
        int lastIndex = LastIndexOf(numbers, 30); // Kết quả là 5, vì tìm thấy phần tử 30 cuối cùng

        // Kiểm tra phần tử có tồn tại trong mảng hay không
        bool isContain = Contains(numbers, 10);

        // Tìm phần tử đầu tiên thỏa mãn điều kiện (ví dụ: > 20)
        int number = Find(numbers, 20);

        // Tìm tất cả các phần tử thỏa mãn điều kiện (ví dụ: > 30)
        int[] filteredNumbers = FindAll(numbers, 30);
    }

    */
    #endregion
    #region các hàm hỗ trợ tìm kiếm cơ bản
    /*
     // Thêm phần tử vào mảng
    private int[] AddToArray(int[] array, int newItem)
    {
        int[] newArray = new int[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        newArray[array.Length] = newItem;
        return newArray;
    }

    // Tìm index đầu tiên của phần tử trong mảng
    private int IndexOf(int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
                return i;
        }
        return -1;
    }

    // Tìm index cuối cùng của phần tử trong mảng
    private int LastIndexOf(int[] array, int value)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] == value)
                return i;
        }
        return -1;
    }

    // Kiểm tra phần tử có tồn tại trong mảng hay không
    private bool Contains(int[] array, int value)
    {
        return IndexOf(array, value) != -1;
    }

    // Tìm phần tử đầu tiên thỏa mãn điều kiện (ví dụ: lớn hơn một giá trị nhất định)
    private int Find(int[] array, int minValue)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > minValue)
                return array[i];
        }
        return -1;
    }

    // Tìm tất cả các phần tử thỏa mãn điều kiện (ví dụ: lớn hơn một giá trị nhất định)
    private int[] FindAll(int[] array, int minValue)
    {
        // Đếm số phần tử thỏa mãn điều kiện
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > minValue)
                count++;
        }

        // Tạo mảng mới chứa các phần tử thỏa mãn điều kiện
        int[] result = new int[count];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > minValue)
                result[index++] = array[i];
        }

        return result;
    }
     
     */

    #endregion

    //2.
    #region  Tìm kiếm danh sách Class
    //Trước tiên hãy tạo 1 class và khai báo list Player
    public class Player
    {
        public string Name;
        public int Score;

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    public Player[] players;

    private void Awake()
    {
        // Khởi tạo mảng với các đối tượng Player ban đầu
        players = new Player[]
        {
            new Player("Alice", 150),
            new Player("Bob", 100),
            new Player("Charlie", 200),
            new Player("Alice", 100)
        };
    }

    private void Start()
    {
        // Thêm một đối tượng Player vào mảng
        Player newPlayer = new Player("David", 120);
        players = AddToArray(players, newPlayer);

        // Tìm index đầu tiên của phần tử trong mảng
        int index = FindIndex(players, "Alice", 150);

        // Tìm index cuối cùng của phần tử trong mảng
        int lastIndex = FindLastIndex(players, "Alice", 100);

        // Kiểm tra phần tử có tồn tại trong mảng hay không
        bool isContain = Exists(players, "Bob", 100);

        // Tìm phần tử đầu tiên thỏa mãn điều kiện (ví dụ: có điểm số > 100)
        Player playerFound = Find(players, 100);

        // Tìm tất cả các phần tử thỏa mãn điều kiện (ví dụ: có điểm số > 100)
        Player[] highScorePlayers = FindAll(players, 100);

        Debug.Log("index: " + index);
        Debug.Log("lastIndex: " + lastIndex);
        Debug.Log("isContain: " + isContain);
        Debug.Log("playerFound.Name/playerFound.Score: " + playerFound.Name + "/" + playerFound.Score);
        Debug.Log("highScorePlayers.Length: " + highScorePlayers.Length);
    }
    #endregion
    #region các hàm hỗ trợ tìm kiếm Class
    //có thể lướt nhanh qua phần này
    // Thêm phần tử vào mảng
    private Player[] AddToArray(Player[] array, Player newItem)
    {
        Player[] newArray = new Player[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        newArray[array.Length] = newItem;
        return newArray;
    }

    // Tìm index đầu tiên của phần tử trong mảng dựa trên Name và Score
    private int FindIndex(Player[] array, string name, int score)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Name == name && array[i].Score == score)
                return i;
        }
        return -1;
    }

    // Tìm index cuối cùng của phần tử trong mảng dựa trên Name và Score
    private int FindLastIndex(Player[] array, string name, int score)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i].Name == name && array[i].Score == score)
                return i;
        }
        return -1;
    }

    // Kiểm tra phần tử có tồn tại trong mảng hay không
    private bool Exists(Player[] array, string name, int score)
    {
        return FindIndex(array, name, score) != -1;
    }

    // Tìm phần tử đầu tiên thỏa mãn điều kiện (ví dụ: có điểm số > minScore)
    private Player Find(Player[] array, int minScore)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Score > minScore)
                return array[i];
        }
        return null;
    }

    // Tìm tất cả các phần tử thỏa mãn điều kiện (ví dụ: có điểm số > minScore)
    private Player[] FindAll(Player[] array, int minScore)
    {
        // Đếm số phần tử thỏa mãn điều kiện
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Score > minScore)
                count++;
        }

        // Tạo mảng mới chứa các phần tử thỏa mãn điều kiện
        Player[] result = new Player[count];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Score > minScore)
                result[index++] = array[i];
        }

        return result;
    }
    #endregion
}

//tiếp theo ta sẽ đến với phần sort