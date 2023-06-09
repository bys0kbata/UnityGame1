using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentSplit : MonoBehaviour
{

    public bool isdead = false; //переменная которая обозначает разрушился объект, или еще нет
    public float timeRemaining = 100;//время после которого должен удалится объект после разрушения (сделано во благо оптимизации)
    [SerializeField] private GameObject _Monik;
    Destroy des;
    BoxCollider BOX;
    Material svet;

    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = false;//включаем у риджидбоди синематик дабы наш объект не разрушался раньше времени
    }
        
    void OnCollisionEnter(Collision collision)//проверяем на объект на коллизию
    {
        Destroy(gameObject);
        //ChangeColorsTrafficLight();
        Vector3 pos = gameObject.transform.position;
        isdead = true;
        print("Столкновение есть");

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