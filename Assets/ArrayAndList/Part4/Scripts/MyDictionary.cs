using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class MyDictionary : MonoBehaviour
{
    //Dictionary<TKey, TValue> là một collection trong C# lưu trữ các cặp key-value.

    //rất hữu dụng với các dạng dữ liệu mang kiểu id là duy nhất.

    //ví dụ: ta có 1 class gồm mã sinh viên, tên sinh viên và điểm
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

    //sau đó, ta tạo 1 triệu sinh viên và lưu chúng vào dictionary.
    private void Start()
    {
        //2 hàm này dùng để kiểm tra tốc độ đọc của dictionary và list
        Stopwatch swDic = Stopwatch.StartNew();
        Stopwatch swList = Stopwatch.StartNew();

        int dataSize = 1_000_000;

        Dictionary<int, Student> studentDic = new Dictionary<int, Student>();
        for (int i = 1; i < dataSize; i++)
        {
            studentDic.Add(i, new Student(i, "Test" + i, 10 * i));
        }

        //sau đó, để lấy sinh viên D ta chỉ cần truyền vào dictionary key (ở đây là mã sinh viên) để lấy ra value
        swDic.Start();
        studentDic.TryGetValue(312, out Student studentValue);
        MyDebug.Log("Dictionary Student Name: " + studentValue.name);
        swDic.Stop();

        //Tuy nhiên, khác với dictionary, list lưu dữ liệu dưới dạng mảng, vậy nên để truy xuất sinh viên có id mong muốn dưới dạng key value
        //điều đó khiến việc truy vấn cũng phức tạp hơn
        List<Student> studentList = studentDic.Values.ToList();
        swList.Start();
        foreach (Student student in studentList)
        {
            if (student.id == 312)
            {
                MyDebug.Log("List Student Name: " + student.name);
                break;
            }
        }
        swList.Stop();

        //điều đó khiến tốc độ truy xuất dữ liệu giữa dictionary và list khác nhau.
        MyDebug.Log("Dictionary search speed: " + swDic.ElapsedMilliseconds + "ms"); //khi play unity kết quả cho được là 400ms
        MyDebug.Log("List search speed: " + swList.ElapsedMilliseconds + "ms"); // khi play unity kết quả cho được là 445ms

        swDic.Reset();
        swList.Reset();

        //tốc đo xóa phần từ trong list và dictionary cũng khác nhau
        int removeIndex = dataSize / 2;
        swList.Start();
        studentList.RemoveAt(removeIndex);
        swList.Stop();

        swDic.Start();
        studentDic.Remove(removeIndex);
        swDic.Stop();

        MyDebug.Log("Dictionary remove speed: " + swDic.ElapsedTicks + "tick"); //2742 tick
        MyDebug.Log("List remove speed: " + swList.ElapsedTicks + "tick");//3409 tick

        //lý do có sự khác nhau rõ ràng như vậy là vì:

        //+ Dictionary sử dụng bảng băm (hash table), giúp truy xuất và xóa dữ liệu trực tiếp theo key
        //+ List là 1 mảng động (dynamic array), List truy xuất và xóa dữ liệu dựa vào index.
        //+ Tuy nhiên khi xóa dư liệu trong List, nó sẽ dịch chuyển các phần tử phía sau lên trên để lấp vào chỗ trống
        //làm cho việc xóa một phần tử ở giữa danh sách mất thời gian hơn.
    }
}
