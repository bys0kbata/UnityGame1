using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public string TagName = "Enemy";
    public bool isdead = false; //переменная которая обозначает разрушился объект, или еще нет
    public float timeRemaining = 100;//время после которого должен удалится объект после разрушения (сделано во благо оптимизации)

    public GameObject[] FoundObjects;
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;//включаем у риджидбоди синематик дабы наш объект не разрушался раньше времени
        FoundObjects = GameObject.FindGameObjectsWithTag(TagName);

    }

    void OnCollisionEnter(Collision collision)//проверяем на объект на коллизию
    {
        GetComponent<Rigidbody>().isKinematic = false;//и если он с чем-то столкнулся, отключаем синематик тем самым разрушая его

        foreach (GameObject o in FoundObjects)
        {
            if (o.GetInstanceID() == gameObject.GetInstanceID())
                continue;
            Debug.Log("Найдено");
        }





        isdead = true;//делаем переменную положительной, чтобы скрипт смог понять что обьект уже "отработан", и его можно удалить
    }

    void Update()
    {
        if (isdead)//если переменная положительная, то запускаем таймер 
        {
            timeRemaining -= Time.deltaTime;//сам таймер			

            if (timeRemaining < 0) //и если время таймера меньше нуля, то 
            {
                Destroy(gameObject);//просто удаляем объект
            }
        }
    }
}