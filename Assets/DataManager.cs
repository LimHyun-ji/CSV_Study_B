using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserInfoB
{
    public string name;
    public string phone;
    public string email;
    public int age;
}

[System.Serializable]
public class UserInfoA
{
    public string name;
    public string phone;
    public int age;
}


public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    //B반 연락처
    public List<UserInfoB> userInfoB;

    //A반 연락처
    public List<UserInfoA> userInfoA;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //userInfoB = CSV.instance.Parsing("Table_Contact_A");
        userInfoA = CSV.instance.Parsing<UserInfoA>("Table_Contact_A");
        userInfoB = CSV.instance.Parsing<UserInfoB>("Table_Contact_B");
    }

    void Update()
    {
    }

    
}
