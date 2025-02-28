using UnityEngine;
//Chúng ta sẽ lướt nhanh qua phần này
public class MySimpleArray : MonoBehaviour
{

    //khai báo array
    public int[] numbers;
    private void Awake()
    {
        numbers = new int[5];
    }
    private void Start()
    {
        //thêm giá trị vào array
        numbers[0] = 10;
        numbers[1] = 20;
        numbers[2] = 30;
        numbers[3] = 40;
        numbers[4] = 50;

        //các thao tác truy xuất đơn giản (có thể comment lại và chạy play để xem thử kết quả)

        //truyền index = 2 để lấy số 30
        Debug.Log(numbers[2]);

        //sử dụng for để duyệt qua các phần tử
        for (int i = 0; i < numbers.Length; i++)
        {
            Debug.Log(numbers[i]);
        }

        //cập nhật giá trị một phần tử trong mảng
        numbers[2] = 100;

        //dĩ nhiên, cũng có thể sử dụng foreach duyệt qua các phần tử
        foreach (int number in numbers)
        {
            Debug.Log(number);
        }

        // Xóa phần tử theo giá trị
        RemoveByValue(30); 

        // Xóa phần tử theo index
        RemoveByIndex(1);

        // Không thể thêm phần tử vào mảng sau khi khởi tạo, vì Array là một biến tĩnh.
        // numbers[5] = 60; //sẽ gây lỗi IndexOutOfRangeException khi chạy nếu cố gắng thêm vào
    }

    private void RemoveByIndex(int indexToRemove)
    {
        int[] newArr = new int[numbers.Length - 1];
        int newIndex = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (i != indexToRemove)
            {
                newArr[newIndex++] = numbers[i];
            }
        }

        numbers = newArr;
    }

    void RemoveByValue(int valueToRemove)
    {
        int newSize = 0;
        foreach (int value in numbers)
        {
            if (value != valueToRemove)
                newSize++;
        }
        int[] newArr = new int[newSize];
        int index = 0;
        foreach (int value in numbers)
        {
            if (value != valueToRemove)
                newArr[index++] = value;
        }

        numbers = newArr;
    }
}

//Array là như vậy, còn List<T> sẽ trông thế nào?

