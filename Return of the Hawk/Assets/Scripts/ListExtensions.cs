using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions {

    public static void Shuffle(this IList<string> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
