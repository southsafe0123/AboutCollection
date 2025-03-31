using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayAndListMemory : MonoBehaviour
{
        const int SIZE = 10_000_000; // 10 triệu phần tử

    void Start()
    {
        long beforeArrayMemory = GC.GetTotalMemory(true);
        int[] array = new int[SIZE]; 
        for(int i = 0; i < SIZE; i++)
        {
            array[i] = i;
        }
        long afterArrayMemory = GC.GetTotalMemory(true);

        long beforeListMemory = GC.GetTotalMemory(true);
        List<int> list = new List<int>(SIZE); 
        for (int i = 0; i < SIZE; i++)
        {
            list.Add(i);
        }
        long afterListMemory = GC.GetTotalMemory(true);

        Debug.Log($"Bộ nhớ sử dụng cho Array: {afterArrayMemory - beforeArrayMemory} bytes");
        Debug.Log($"Bộ nhớ sử dụng cho List<T>: {afterListMemory - beforeListMemory} bytes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
