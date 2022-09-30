using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using UnityEngine;

public class CSV : MonoBehaviour
{
    public static CSV instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public List<T> Parsing<T>(string fileName) where T : new()
    {
        List<T> list = new List<T>();

        //파일을 읽자
        string path = Application.streamingAssetsPath + "/" + fileName + ".csv";
        byte[] byteData = File.ReadAllBytes(path);
        string stringData = Encoding.GetEncoding("euc-kr").GetString(byteData);
        print(stringData);

        //띄어쓰기 없애기
        stringData = stringData.Trim();

        string[] lines = stringData.Split("\r\n");        

        //변수 이름 나누기
        string[] variable = lines[0].Split(",");

        //값 나누기
        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(",");         

            T data = new T();
            for(int j = 0; j < variable.Length; j++)
            {
                //variable[0] = "name", variable[1] = "phone", variable[2] = "email", variable[3] = "age"
                //해당 변수의 이름으로 정보를 얻어오자
                System.Reflection.FieldInfo fieldInfo = typeof(T).GetField(variable[j]);
                //int.parse, float.parse 와 같은 종류 알아내기
                TypeConverter typeConverter = TypeDescriptor.GetConverter(fieldInfo.FieldType);
                //data의 각변수에 값을 넣자
                fieldInfo.SetValue(data, typeConverter.ConvertFrom(values[j]));
            }

            list.Add(data);
        }

        return list;
    }

    //Parsing
    public List<UserInfoB> Parsing(string fileName)
    {
        List<UserInfoB> list = new List<UserInfoB>();

        //파일을 읽자
        string path = Application.dataPath + "/" + fileName + ".csv";
        byte [] byteData = File.ReadAllBytes(path);
        string stringData = Encoding.GetEncoding("euc-kr").GetString(byteData);
        print(stringData);

        //띄어쓰기 없애기
        stringData = stringData.Trim();

        string[] lines = stringData.Split("\r\n");
        ////엔터(\n) 기준으로 한줄씩 자르기
        //string [] lines = stringData.Split("\n");
        ////엔터(\r) 기준으로 한줄씩 자르기
        //for(int i = 0; i < lines.Length; i++)
        //{
        //    string[] temp = lines[i].Split("\r");
        //    lines[i] = temp[0];
        //}

        //변수 이름 나누기
        string[] variable = lines[0].Split(",");

        //값 나누기
        for(int i = 1; i < lines.Length; i++)
        {
            string [] values = lines[i].Split(",");

            //string name = values[0];
            //string phone = values[1];
            //string email = values[2];
            //string age = values[3];
            //print(
            //    variable[0] + ":" + name + "," +
            //    variable[1] + ":" + phone + "," +
            //    variable[2] + ":" + email + ", " + 
            //    variable[3] + ":" + age);

            UserInfoB data = new UserInfoB();
            data.name = values[0];
            data.phone = values[1];
            data.email = values[2];
            data.age = int.Parse(values[3]);

            list.Add(data);
        }

        return list;
    }

    
}
