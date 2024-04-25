using System;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions {

    public static void Shuffle(this IList<string> list) {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static string Pop(this IList<string> list) {
        if (list.Count == 0)
        {
            throw new InvalidOperationException("A lista está vazia.");
        }

        string lastElement = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return lastElement;
    }
}
