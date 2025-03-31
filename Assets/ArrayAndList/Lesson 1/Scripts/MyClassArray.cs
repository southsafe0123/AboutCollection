using System;
using System.Collections;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class MyClassArray : MonoBehaviour
{
    //Để gần với thực thế hơn, ta sẽ sử dụng array class thay vì các dữ liệu nguyên thủy.
    [System.Serializable]
    public class Student
    {
        public int id;
        public string name;
        public int score;
        public Student(int id, string name, int score)
        {
            this.id = id;
            this.name = name;
            this.score = score;
        }
    }

    public Student[] students;

    private void Start()
    {
        InitData();
    }
    private void InitData()
    {
        students = new Student[5];
        students[0] = new Student(1, "Diya", 50);
        students[1] = new Student(2, "Ali", 60);
        students[2] = new Student(3, "Hanna", 70);
        students[3] = new Student(4, "Fatima", 80);
        students[4] = new Student(5, "Charles", 90);
    }

    //khởi tạo enum để chọn lựa trên editor (không cần để ý)
    public enum SortBy
    {
        id, name, score
    }
    //Sau khi đã khai báo array. để sắp xếp dữ liệu trong array, ta có thể dùng hàm có sẵn của hệ thống Array.Sort()
    //với cách này, có thể nhanh chóng cho ra kết quả sort mong muốn.
    [ProButton]
    void SortArray(SortBy sortBy)
    {
        switch (sortBy)
        {

            case SortBy.id:
                Array.Sort(students, (a, b) => a.id.CompareTo(b.id));
                break;
            case SortBy.name:
                Array.Sort(students, (a, b) => a.name.CompareTo(b.name));
                break;
            case SortBy.score:
                Array.Sort(students, (a, b) => a.score.CompareTo(b.score));
                break;
        };

        // Có thể thấy, Array.Sort gồm 2 tham số:
        //  1. Mảng muốn sắp xếp (students) (hàm gốc của sort cho ta thấy đây là 1 generic)
        //  2. Comparison (hàm so sánh 2 phần tử)

        // Với Comparison, đây là một delegate (giải thích trong khóa học của thầy Khải :D) nhận vào 2 đối tượng mà ở đây là a và b.

        // Vì là delegate, nên ta cần "đăng ký" một hàm so sánh cho nó.
        // Ở đây ta dùng biểu thức lambda: (a, b) => a.id.CompareTo(b.id)

        // Phương thức CompareTo là của interface IComparable, trả về kiểu int.
        // Kết quả như sau:
        //      - Trả về < 0 nếu a đứng trước b
        //      - Trả về > 0 nếu a đứng sau b
        //      - Trả về 0 nếu a và b bằng nhau
        // Sau đó, hàm sort của C# sẽ bắt đầu xử lý vòng lặp sắp xếp theo kết quả trả về của comparison.

    }

    //đây là phiên bản tả thực của Array.Sort được mình tái hiện lại
    //khai báo generic (Generic sẽ dạy ở bài sau), sử dụng IComparable<T> để gọi CompareTo
    public int MyCompare<T>(T a, T b) where T : IComparable<T>
    {
        //sử dụng CompareTo từ IComparable, trả về kiểu int
        return a.CompareTo(b);
    }
    //khai báo delegate
    public delegate int MyComparison<in T>(T a, T b);
    //tạo hàm có 2 tham số truyền vào gồm 1 generic và 1 delegate MyComparison
    public void MySort<T>(T[] array, MyComparison<T> comparison)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                // Khi dùng MySort với một delegate như: (a, b) => MyCompare(a.id, b.id)
                // Thì ở đây: students[i] chính là a, students[j] là b
                // Việc truy cập a.id hay a.score là do delegate khai báo ở MySortArray quyết định
                if (comparison(array[i], array[j]) > 0)
                {
                    // Hoán đổi
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
    //có thể bấm nút khi play (việc sort sẽ diễn ra tương tự như Sort của hệ thống.
    [ProButton]
    void MySortArray(SortBy sortBy)
    {
        switch (sortBy)
        {
            case SortBy.id:
                MySort(students, (a, b) => MyCompare(a.id, b.id));
                break;
            case SortBy.name:
                MySort(students, (a, b) => MyCompare(a.name, b.name));
                break;
            case SortBy.score:
                MySort(students, (a, b) => MyCompare(a.score, b.score));
                break;
        };
    }

    //Để đảo ngược (reverse array), ta có thể dùng hàm có sẵn của hệ thống Array.Reverse()
    //với cách này, có thể nhanh chóng cho ra kết quả đảo ngược thứ tự của mảng.

    [ProButton]
    void ReverseArray()
    {
        Array.Reverse(students);
    }

    //1 phiên bản tả thực khác của array reverse. =))
    public void MyReverse<T>(T[] array)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left < right)
        {
            // Hoán đổi phần tử đối xứng
            T temp = array[left];
            array[left] = array[right];
            array[right] = temp;

            left++;
            right--;
        }
    }
    [ProButton]
    void MyReverseArray()
    {
        MyReverse(students);
    }
}
