using UnityEngine;
//khai báo namespace System.Collections.Generic để sử dụng List<T>
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using System;
using static MyClassArray;
using Unity.VisualScripting;

public class MySimpleList : MonoBehaviour
{
    // với một List kiểu nguyên thủy việc khai báo và truy xuất sẽ có những cách như sau
    public List<int> numbers;

    // khai báo list kiểu tham chiếu
    List<Player> players;
    private void Start()
    {
        InitValue();
    }
    void InitValue()
    {
        numbers = new List<int>();
        //thêm giá trị vào list
        numbers.Add(10);
        numbers.Add(30);
        numbers.Add(40);
        numbers.Add(10);
        numbers.Add(50);

        CreatePlayerList();
    }

    //vì là phiên bản mở rộng của array, nên việc truy xuất cũng tương tự như array
    [ProButton]
    void GetNumber(int index)
    {
        //truyền index để lấy số
        if (index > -1 && index < numbers.Count)
            Debug.Log(numbers[index]);
    }
    [ProButton]
    void GetAllValueUsingFor()
    {
        //sử dụng for để duyệt qua các phần tử
        for (int i = 0; i < numbers.Count; i++)
        {
            Debug.Log(numbers[i]);
        }
    }
    [ProButton]
    void UpdateValue(int index, int value)
    {
        //cập nhật giá trị một phần tử trong mảng
        if (index > -1 && index < numbers.Count)
            numbers[index] = value;
    }
    [ProButton]
    void GetAllValueUsingForEach()
    {
        //sử dụng foreach duyệt qua các phần tử
        foreach (int number in numbers)
        {
            Debug.Log(number);
        }
    }
    [ProButton]
    void GetAllValueUsingWhile()
    {
        //sử dụng while duyệt qua các phần tử
        int i = 0;
        while (i < numbers.Count)
        {
            Debug.Log(numbers[i]);
            i++;
        }
    }

    // Vì List là kiểu dữ liệu KHÔNG cố định kích thước và được hỗ trợ bởi các phương thức của collection,
    // nên khi muốn xoá phần tử, ta có thể sử dụng các hàm của collection để thực hiện thay cho vòng lặp for, foreach hoặc while

    // Xóa phần tử theo index
    [ProButton]
    void RemoveByIndex(int index)
    {
        numbers.RemoveAt(index);
    }

    // Xóa phần tử theo giá trị
    [ProButton]
    void RemoveByValue(int valueToRemove)
    {
        numbers.Remove(valueToRemove);
    }

    // ngoài ra còn có các hàm khác được C# hỗ trợ việc quản lý mảng thông qua sử dụng list
    void SearchIndexOf(int number)
    {
        //Tìm index đầu tiên của phần tử trong List
        int index = numbers.FindIndex(i => i == number);
        MyDebug.Log($"index found: {index}");
        if (index < 0)
        {
            MyDebug.Log($"index not found");
        }
    }
    void SearchLastIndexOf(int number)
    {
        //Tìm index cuối cùng của phần tử trong List
        int lastIndex = numbers.FindLastIndex(i => i == number);
        MyDebug.Log($"last index found: {lastIndex}");
        if (lastIndex < 0)
        {
            MyDebug.Log($"last index not found");
        }
    }
    void SearchExists()
    {
        //Kiểm tra phần tử có tồn tại trong List hay không
        bool isContain = numbers.Exists(i => i == 150);
        MyDebug.Log($"isContain: {isContain}");
    }


    void CreatePlayerList()
    {
        players = new List<Player>();
        players.Add(new Player { id = 1, name = "antest1", score = 10 });
        players.Add(new Player { id = 2, name = "antest2", score = 20 });
        players.Add(new Player { id = 3, name = "antest1", score = 30 });
        players.Add(new Player { id = 4, name = "antest2", score = 40 });
        players.Add(new Player { id = 5, name = "antest1", score = 10 });
        players.Add(new Player { id = 6, name = "antest2", score = 60 });
    }
    [ProButton]
    void FindNumber(int number)
    {
        //Tìm phần tử đầu tiên thỏa điều kiện	
        int numberFound = numbers.Find(i => i == number);
        MyDebug.Log($"numberFound: {numberFound}");
        //Thường thì hàm này dùng để tìm 1 class phức tạp hơn.
        //Ví dụ
        Player playerFound = players.Find(p => p.score == numberFound);
        if (playerFound != null)
        {
            MyDebug.Log($"example playerFound.name: {playerFound.name}");
        }
    }
    [ProButton]
    void FindAll(int number)
    {

        //Tìm tất cả các phần tử thỏa mãn điều kiện
        List<int> listFound = numbers.FindAll(i => i > number);

        //Thường thì hàm này dùng để tìm 1 class phức tạp hơn.
        //Ví dụ
        Player playerFound = players.Find(p => p.score > number);
        if (playerFound != null)
        {
            MyDebug.Log($"example playerFound.name: {playerFound.name}");
        }
    }

    [ProButton]
    void ReverseList()
    {
        //đảo ngược thứ tự trong list
        players.Reverse();
    }

    [ProButton]
    void SortList(SortBy sortBy)
    {
        //sắp xếp thứ tự trong list sử dụng hàm sort có sẵn và compareto
        switch (sortBy)
        {
            case SortBy.id:
                players.Sort((a, b) => a.id.CompareTo(b.id));
                break;
            case SortBy.name:
                players.Sort((a, b) => a.name.CompareTo(b.name));
                break;
            case SortBy.score:
                players.Sort((a, b) => a.score.CompareTo(b.score));
                break;
        };
    }

    // Nếu được chỉ định kích thước khi khởi tạo, giả sử kích thước = 5, mà index sẽ có giá trị N-1 => nếu index > 4 sẽ gây lỗi IndexOutOfRangeException
    [ProButton]
    void TestError()
    {
        numbers[5] = 60;//sẽ gây lỗi IndexOutOfRangeException khi chạy nếu cố gắng thêm vào
    }


}

