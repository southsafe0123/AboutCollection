using System;
using UnityEngine;

public class MySortArray : MonoBehaviour
{
    // nếu chưa xem MyDortList.cs, hãy xem nó đầu tiên...
    // ở phần sorting cho array, c# đã tích hợp sẵn các hàm hỗ trợ sort cho array, vậy nên để sử dụng có thể khai báo namespace System
    // sau đó có thể sort tương tự như List<T>
    // trong 1 số trường hợp sắp xếp có nhiều điều kiện phức tạp, cần phải triển khai để duyệt qua các vòng lặp for
    //1.
    #region Sort cơ bản
    /*
      public int[] numbers;
    public string[] names;

    private void Awake()
    {
        // Khởi tạo mảng số và tên
        numbers = new int[] { 50, 20, 40, 10, 30 };
        names = new string[] { "Charlie", "Alice", "Bob", "Eve", "David" };
    }

    private void Start()
    {
        // Sắp xếp số theo thứ tự tăng dần (Sử dụng thuật toán sắp xếp thủ công)
        SortIntArrayAscending(numbers);

        // Sắp xếp số theo thứ tự giảm dần
        SortIntArrayDescending(numbers);

        // Sắp xếp tên theo thứ tự bảng chữ cái (A -> Z)
        SortStringArrayAscending(names);

        // Sắp xếp tên theo thứ tự ngược lại (Z -> A)
        SortStringArrayDescending(names);

        // hoặc có thể sử dụng Array.sort, Array.reverse sử dụng namespace System
        Array.Sort(numbers);
        Array.Reverse(numbers);
        Array.Sort(names);
        Array.Reverse(names);
    }

     */

    #endregion
    #region các hàm hỗ trợ sort cơ bản
    /*
        //có thể lướt nhanh qua phần này
        // Sắp xếp số tăng dần
    private void SortIntArrayAscending(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] > array[j])
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    // Sắp xếp số giảm dần
    private void SortIntArrayDescending(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] < array[j])
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    // Sắp xếp chuỗi theo thứ tự bảng chữ cái (A -> Z)
    private void SortStringArrayAscending(string[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (string.Compare(array[i], array[j]) > 0)
                {
                    string temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    // Sắp xếp chuỗi theo thứ tự ngược lại (Z -> A)
    private void SortStringArrayDescending(string[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (string.Compare(array[i], array[j]) < 0)
                {
                    string temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

   */

    #endregion
     
    //2.
    #region Sort Class

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
        // Khởi tạo mảng các đối tượng Player
        players = new Player[]
        {
            new Player("Alice", 150),
            new Player("Bob", 100),
            new Player("Charlie", 200),
            new Player("David", 120),
            new Player("Eve", 180)
        };
    }

    private void Start()
    {
        Debug.Log("Before Sort");
        Debug.Log("---------------");
        foreach (Player p in players)
        {
            Debug.Log($"Name: {p.Name}/Score: {p.Score}");
        }


        // Sắp xếp Player theo điểm số tăng dần
        SortPlayerByScoreAscending(players);

        // Sắp xếp Player theo điểm số giảm dần
        SortPlayerByScoreDescending(players);

        // Sắp xếp Player theo tên (A -> Z)
        SortPlayerByNameAscending(players);

        // Sắp xếp Player theo tên (Z -> A)
        SortPlayerByNameDescending(players);

        // hoặc có thể sử dụng Array.sort, Array.reverse sử dụng namespace System
        // cách sử dụng tương tự với bên mysortlist.cs

        // Sắp xếp theo điểm số tăng dần
        Array.Sort(players, (p1, p2) => p1.Score - p2.Score);

        // Sắp xếp theo điểm số giảm dần
        Array.Sort(players, (p1, p2) => p2.Score - p1.Score);

        // Sắp xếp theo tên từ A đến Z
        Array.Sort(players, (p1, p2) => string.Compare(p1.Name, p2.Name));

        // Sắp xếp theo tên từ Z đến A
        Array.Sort(players, (p1, p2) => string.Compare(p2.Name, p1.Name));

        // Sắp xếp kết hợp: Điểm số tăng dần, nếu bằng điểm thì sắp xếp theo tên
        Array.Sort(players, (p1, p2) =>
        {
            int scoreComparison = p1.Score - p2.Score;
            if (scoreComparison == 0)
            {
                return string.Compare(p1.Name, p2.Name);
            }
            return scoreComparison;
        });

        Debug.Log("---------------");
        Debug.Log("After Sort");
        Debug.Log("---------------");

        foreach (Player p in players)
        {
            Debug.Log($"Name: {p.Name}/Score: {p.Score}");
        }
    }

    #endregion
    #region Các hàm hỗ trợ SortClass
    //có thể lướt nhanh qua phần này
    // Sắp xếp Player theo điểm số tăng dần
    private void SortPlayerByScoreAscending(Player[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i].Score > array[j].Score)
                {
                    Player temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    // Sắp xếp Player theo điểm số giảm dần
    private void SortPlayerByScoreDescending(Player[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i].Score < array[j].Score)
                {
                    Player temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    // Sắp xếp Player theo tên (A -> Z)
    private void SortPlayerByNameAscending(Player[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (string.Compare(array[i].Name, array[j].Name) > 0)
                {
                    Player temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    // Sắp xếp Player theo tên (Z -> A)
    private void SortPlayerByNameDescending(Player[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (string.Compare(array[i].Name, array[j].Name) < 0)
                {
                    Player temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    #endregion
}