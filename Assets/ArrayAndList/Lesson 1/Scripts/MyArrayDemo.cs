using System;
using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
using static UnityEditor.Progress;

public class MyArrayDemo : MonoBehaviour
{
    // Mảng khai báo có thể chứa dữ liệu thuộc kiểu nguyên thủy hoặc kiểu tham chiếu.

    // Kiểu nguyên thủy ví dụ: int, float, char, bool,...
    public float[] arrFloat;
    public int[] arrInt;
    // Kiểu tham chiếu ví dụ: string, object, class, array,...
    public string[] arrString;
    public Player[] arrPlayer;
    private void Start()
    {
        // Tuy đã khai báo, nhưng các biến mảng vẫn chưa được khởi tạo (chưa cấp phát vùng nhớ), nên mặc định các biến mảng này có giá trị là null.

        // Array trong C# là kiểu tham chiếu, vì vậy cần phải cấp phát vùng nhớ trước khi sử dụng.
        // cuối cùng, mảng có độ dài cố định nên cần chỉ định kích thước khi khởi tạo.

        // Kiểu nguyên thủy ví dụ
        arrFloat = new float[5];
        arrInt = new int[5];

        // Kiểu tham chiếu ví dụ
        arrString = new string[5];
        arrPlayer = new Player[5];

       
    }
    // Sau khi cấp phát vùng nhớ, array hiện tại đã có thể sử dụng. Các giá trị mặc định được khởi tạo trong array sẽ phụ thuộc vào kiểu dữ liệu mà array được khai báo.
    // ví dụ kiểu nguyên thủy int, float sẽ có giá trị mặc định trong phần tử là 0
    [ProButton]
    void GetValue()
    {
        Debug.Log($"arrFloat[0] = {arrFloat[0]}");
        Debug.Log($"arrInt[0] = {arrInt[0]}");
    }

    // kiểu tham chiếu sẽ là null
    [ProButton]
    void GetRefValue()
    {
        //vì là null nên các giá trị này khi debuglog không cho ra kết quả
        MyDebug.Log($"arrPlayer[0].name = {arrPlayer[0].name}");
        MyDebug.Log($"arrString[0] = {arrString[0]}");
    }

    // vì các giá trị phần tử của array đang là mặc định, vậy nên chúng ta sẽ tạo giá trị cho nó
    [ProButton]
    void SetPlayerValue()
    {
        Player player = new Player
        {
            id = 0,
            name = "An",
            score = 10,
        };

        // gán giá trị vào phần tử trong mảng và sử dụng
        arrPlayer[0] = player;
        MyDebug.Log("Success! arrPlayer[0].name = " + arrPlayer[0].name);// vì đã gán giá trị, myArray[0] sẽ mang giá trị của một class player và kết quả khi debug sẽ là An
    }
}

// tạo một class đơn giản
[System.Serializable]
public class Player
{
    public int id;
    public string name;
    public int score;
}