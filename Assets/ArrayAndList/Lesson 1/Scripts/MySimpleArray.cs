﻿using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;
//Chúng ta sẽ lướt nhanh qua phần này
//Play và sử dụng các nút có sẵn trên editor
public class MySimpleArray : MonoBehaviour
{
    // với một array kiểu nguyên thủy việc khai báo và truy xuất sẽ có những cách như sau
    public int[] numbers = new int[5];

    private void Start()
    {
        InitValue();
    }
    void InitValue()
    {
        //thêm giá trị vào array
        numbers[0] = 10;
        numbers[1] = 20;
        numbers[2] = 30;
        numbers[3] = 40;
        numbers[4] = 50;
    }
    [ProButton]
    void GetNumber(int index)
    {
        //truyền index để lấy số
        if (index > -1 && index < numbers.Length)
            Debug.Log(numbers[index]);
    }
    [ProButton]
    void GetAllValueUsingFor()
    {
        //sử dụng for để duyệt qua các phần tử
        for (int i = 0; i < numbers.Length; i++)
        {
            Debug.Log(numbers[i]);
        }
    }
    [ProButton]
    void UpdateValue(int index, int value)
    {
        //cập nhật giá trị một phần tử trong mảng
        if (index > -1 && index < numbers.Length)
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
        int i  = 0;
        while (i < numbers.Length)
        {
            Debug.Log(numbers[i]);
            i++;
        }
    }

    // Vì mảng (array) là kiểu dữ liệu cố định kích thước và không được hỗ trợ bởi các phương thức của collection,
    // nên khi muốn xoá phần tử, thường phải tự xử lý bằng cách sử dụng vòng lặp để tạo một mảng mới không chứa phần tử cần xoá.

    // Xóa phần tử theo index
    [ProButton]
    void RemoveByIndex(int index)
    {
        if (index < 0 && index >= numbers.Length) return;

        // khai báo array và chỉ định kích thước.
        int[] newArr = new int[numbers.Length - 1];
        int newIndex = 0;

        //có thể dùng vòng lặp for chạy từ 0 đến độ dài của array numbers
        for (int i = 0; i < numbers.Length; i++)
        {
            //check điều kiện vào loại phần tử muốn xóa
            if (i != index)
            {
                newArr[newIndex++] = numbers[i];
            }
        }

        //thay array mới cho numbers;
        numbers = newArr;
    }

    // Xóa phần tử theo giá trị
    [ProButton]
    void RemoveByValue(int valueToRemove)
    {
        //đếm lengh mới nếu không có value được truyền vào
        int newSize = 0;

        //có thể dùng foreach để duyệt qua từng phần tử trong mảng
        foreach (int value in numbers)
        {
            if (value != valueToRemove)
                newSize++;
        }

        // khai báo array và chỉ định kích thước.
        int[] newArr = new int[newSize];
        int index = 0;

        //ngoài ra có thể sử dụng while để lặp qua các phần tử và thực hiện truy xuất

        int i = 0;
        while (i < numbers.Length)
        {
            if (numbers[i] != valueToRemove)
            {
                newArr[index] = numbers[i];
                index++;
            }
            i++;
        }

        //thay array mới cho numbers;
        numbers = newArr;
    }
    // Không thể thêm phần tử vào mảng sau khi khởi tạo, vì Array là một kiểu dữ liệu tĩnh. (cố định kích thước sau khi khởi tạo).
    // việc chỉ định kích thước = 5, array index sẽ có giá trị N-1 vậy nên nếu index lớn hơn 4 sẽ gây lỗi IndexOutOfRangeException
    [ProButton]
    void TestError()
    {
        numbers[5] = 60;//sẽ gây lỗi IndexOutOfRangeException khi chạy nếu cố gắng thêm vào
    }
}

