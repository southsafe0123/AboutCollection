using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class PerformanceArrayAndList : MonoBehaviour
{
    //List<T> được sử dụng rộng rãi trong C#, thay thế cho mảng
    //List<T> cung cấp nhiều tính năng tiện lợi, đặc biệt là khả năng mở rộng kích thước, nhưng có thể đánh đổi hiệu suất.

    // code là bài kiểm tra hiệu suất chôm từ bài viết https://www.jacksondunstan.com/articles/3058
    // có thể chạy code này bằng cách gán script vào camera và build ở chế độ non-development, 64-bit processors, windowed 640×480

    // code chạy thử với 100 triệu lần đọc và ghi, sử dụng 10.000 phần tử với 10.000 vòng lặp.
    private const int NumIterations = 10000;
    private const int Length = 10000;

    private string report;

    void Start()
    {
        var stopwatch = new System.Diagnostics.Stopwatch();
        int sum;
        var array = new int[Length];
        var list = new List<int>(Length);
        for (var i = 0; i < Length; ++i)
        {
            array[i] = i;
            list.Add(i);
        }

        stopwatch.Reset();
        stopwatch.Start();
        for (var it = 0; it < NumIterations; ++it)
        {
            sum = 0;
            for (var i = 0; i < Length; ++i)
            {
                sum += array[i];
            }
        }
        var arrayReadTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Reset();
        stopwatch.Start();
        for (var it = 0; it < NumIterations; ++it)
        {
            for (var i = 0; i < Length; ++i)
            {
                array[i] = i;
            }
        }
        var arrayWriteTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Reset();
        stopwatch.Start();
        for (var it = 0; it < NumIterations; ++it)
        {
            sum = 0;
            for (var i = 0; i < Length; ++i)
            {
                sum += list[i];
            }
        }
        var listReadTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Reset();
        stopwatch.Start();
        for (var it = 0; it < NumIterations; ++it)
        {
            for (var i = 0; i < Length; ++i)
            {
                list[i] = i;
            }
        }
        var listWriteTime = stopwatch.ElapsedMilliseconds;

        report =
            "Test,Array Time,List Time\n"
            + "Read," + arrayReadTime + "," + listReadTime + "\n"
            + "Write," + arrayWriteTime + "," + listWriteTime;
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, Screen.width, Screen.height), report);
    }
}

//kết quả thu được trong bài viết khi:

//Đọc từ List<T> chậm hơn 47% so với mảng.
//Ghi vào List<T> chậm hơn 695% so với mảng.

//Lý do List<T> chậm hơn Array do List
#region decomplite mscorlib.dll sẽ cho ra được đoạn code
/*
 public T this[int index]
    {
        get
        {
            if ((uint)index >= (uint)this._size)
                throw new ArgumentOutOfRangeException("index");
            return this._items[index];
        }
        set
        {
            this.CheckIndex(index);
            if (index == this._size)
                throw new ArgumentOutOfRangeException("index");
            this._items[index] = value;
        }
    }


private void CheckIndex(int index)
{
    if (index < 0 || (uint)index > (uint)this._size)
        throw new ArgumentOutOfRangeException("index");
}


có thể thấy, khi chạy, List<T> trong C# triển khai giao diện IList<T>, cung cấp truy cập phần tử qua chỉ số (indexer).
mỗi lần set và get đều phải gọi lại checkindex để kiểm tra giá trị, nhánh điều kiện (branching) này gây tốn thời gian.
 */
#endregion