using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ReadWriteSpeed : MonoBehaviour
{
    const int SIZE = 10_000_000;
    const int ACCESS_COUNT = 1_000_000;
    System.Random random = new System.Random();

    int[] array = new int[SIZE];
    List<int> list = new List<int>(SIZE);

    int[] randomIndexes = new int[ACCESS_COUNT];
    void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            int value = random.Next(1, 100);
            array[i] = value;
            list.Add(value);
        }

        for (int i = 0; i < ACCESS_COUNT; i++)
        {
            randomIndexes[i] = random.Next(0, SIZE);
        }

        // Benchmark truy xuất phần tử với Array
        Stopwatch sw = Stopwatch.StartNew();
        int sumArray = 0;
        for (int i = 0; i < ACCESS_COUNT; i++)
        {
            sumArray += array[randomIndexes[i]];
        }
        sw.Stop();
        UnityEngine.Debug.Log($"Array truy xuất {ACCESS_COUNT} phần tử mất: {sw.ElapsedMilliseconds} ms");

        // Benchmark truy xuất phần tử với List<T>
        sw.Restart();
        int sumList = 0;
        for (int i = 0; i < ACCESS_COUNT; i++)
        {
            sumList += list[randomIndexes[i]];
        }
        sw.Stop();
        UnityEngine.Debug.Log($"List<T> truy xuất {ACCESS_COUNT} phần tử mất: {sw.ElapsedMilliseconds} ms");
    }
}
