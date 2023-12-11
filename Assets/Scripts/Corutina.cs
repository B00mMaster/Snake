using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corutina : MonoBehaviour
{

    
    public static IEnumerator caca()
    {
        yield return new WaitForSecondsRealtime (5);

    }
}
