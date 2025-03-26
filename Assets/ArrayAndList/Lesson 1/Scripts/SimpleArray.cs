using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


public class MyArrayDemo
{
    // Mảng khai báo có thể chứa dữ liệu thuộc kiểu nguyên thủy hoặc kiểu tham chiếu.

    // Kiểu nguyên thủy ví dụ: int, float, char, bool,...
    float[] arrFloat;
    int[] arrInt;
    // Kiểu tham chiếu ví dụ: string, object, class, array,...
    string[] arrString;
    Player[] arrPlayer;

    // Tuy đã khai báo, nhưng biến mảng vẫn chưa được khởi tạo (chưa tạo vùng nhớ) vậy nên mặc định các biến sẽ có giá trị null.
    // -> Do array là một biến tĩnh phải cấp phát vùng nhớ khi vừa khởi tạo.
    // vậy nên ta cần phải khai báo độ dài mảng cho nó.
    public MyArrayDemo(int arrayLengh)
    {
        // Kiểu nguyên thủy ví dụ
        arrFloat = new float[arrayLengh];
        arrInt = new int[arrayLengh];

        // Kiểu tham chiếu ví dụ
        arrString = new string[arrayLengh];
        arrPlayer = new Player[arrayLengh];
    }

    // Sau khi cấp phát vùng nhớ, array hiện tại đã có thể sử dụng. Các giá trị mặc định được khởi tạo trong array sẽ phụ thuộc vào kiểu dữ liệu mà array được khai báo.
    // ví dụ kiểu nguyên thủy int, float sẽ có giá trị mặc định trong phần tử là 0
    // kiểu tham chiếu sẽ là null

    // đó là 1 số thông tin về cách khai báo array, giờ chúng ta sẽ sử dụng class này như một array cho player và thực hiện các tác vụ xoay quanh array đó.

    /// <summary>
    /// Số phần tử hiện có trong danh sách.
    /// </summary>
    public int Length => arrPlayer.Length;

    /// <summary>
    /// Lấy/đặt phần tử tại vị trí index (bắt đầu từ 0).
    /// Bên ngoài sẽ truy xuất thông qua hàm này, ko sử dụng mảng nội bộ
    /// </summary>
    public Player this[int index]
    {
        get
        {
            if (index < 0 || index >= Length)
            {
                throw new System.IndexOutOfRangeException();

            }
            return arrPlayer[index];
        }
        set
        {
            if (index < 0 || index >= Length)
            {
                throw new System.IndexOutOfRangeException();
            }
            arrPlayer[index] = value;
        }
    }

    // chúng ta sẽ tiếp tục trong class simplearray bên dưới.
}
// code chạy trong scene
public class SimpleArray : MonoBehaviour
{
    private void Start()
    {
        // khai báo class và cấp phát vùng nhớ mong muốn cho array
        MyArrayDemo myArray = new MyArrayDemo(5);

        // vì chưa ta chỉ mới khai báo và cấp phát vùng nhớ, phần tử trong mảng vẫn chưa có giá trị (kiểu tham chiếu mặc định sẽ là null) nếu đặt debuglog ở đây
        //MyDebug.Log(myArray[0].name);

        // vậy nên ta phải khởi tạo giá trị
        Player player = new Player
        {
            id = 0,
            name = "An",
            score = 10,
        };

        // gán giá trị vào phần tử trong mảng và sử dụng
        myArray[0] = player;
        MyDebug.Log(myArray[0].name);// vì đã gán giá trị, myArray[0] sẽ mang giá trị của một class player và kết quả khi debug sẽ là An
    }
}

public class Player
{
    public int id;
    public string name;
    public int score;
}