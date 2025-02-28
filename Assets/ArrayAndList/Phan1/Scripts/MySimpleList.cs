using UnityEngine;


//nếu chưa xem MySimpleArray.cs, hãy xem nó đầu tiên...

//khai báo namespace System.Collections.Generic để sử dụng List<T>
using System.Collections.Generic;

public class MySimpleList : MonoBehaviour
{
    //khai báo list
    public List<int> numbers;
    private void Awake()
    {
        numbers = new List<int> {10,20,30,40,50};

    }
    private void Start()
    {
        //thêm giá trị vào list
        numbers.Add(60);

        //truyền index = 2 để lấy số 30
        Debug.Log(numbers[2]);

        //sử dụng for để duyệt qua các phần tử
        for (int i = 0; i < numbers.Count; i++)
        {
            Debug.Log(numbers[i]);
        }

        //cập nhật giá trị một phần tử trong list
        numbers[2] = 100;

        //dĩ nhiên, cũng có thể sử dụng foreach duyệt qua các phần tử
        foreach (int number in numbers)
        {
            Debug.Log(number);
        }
        // Xóa phần tử theo giá trị
        numbers.Remove(30); // Xóa giá trị 30 khỏi danh sách

        // Xóa phần tử theo index
        numbers.RemoveAt(1); // Xóa phần tử ở chỉ số 1 (lúc này là giá trị 20)
    }
}

//nhìn chung Array và List<T> cả hai đều dùng để quản lý dữ liệu.

//tuy nhiên List<T> lại trông có vẻ nhỉn hơn khi không phải dùng vòng lặp for duyệt qua từng phần tử để xóa
//đồng thời List<T> cũng có thể mở rộng giới hạn, cho phép chứa thêm giá trị khi cần bằng cách sử dụng Add()

//nhưng không phải lúc nào cũng nên dùng List<T> (sẽ giải thích thêm ở Phần 3)

