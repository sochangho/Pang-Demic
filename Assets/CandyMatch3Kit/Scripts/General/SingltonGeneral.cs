using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingltonGeneral<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    

    public static T instance
    {

        get
        {
            _instance = FindObjectOfType<T>();

            if(_instance == null)
            {

                var go = new GameObject(typeof(T).Name);
                _instance = go.AddComponent<T>();
            }
            return _instance;
        }

    }


}
