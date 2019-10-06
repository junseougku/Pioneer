using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterClass : MonoBehaviour
{
    private static MonsterClass instance = null;
    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    public static MonsterClass GetInstance()
    {

        return instance;
    }


    public List<Enemy> enemys = new List<Enemy>();

}
