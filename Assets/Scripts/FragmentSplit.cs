using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentSplit : MonoBehaviour
{

    public bool isdead = false; //���������� ������� ���������� ���������� ������, ��� ��� ���
    public float timeRemaining = 100;//����� ����� �������� ������ �������� ������ ����� ���������� (������� �� ����� �����������)
    [SerializeField] private GameObject _Monik;
    Destroy des;
    BoxCollider BOX;
    Material svet;

    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = false;//�������� � ���������� ��������� ���� ��� ������ �� ���������� ������ �������
    }
        
    void OnCollisionEnter(Collision collision)//��������� �� ������ �� ��������
    {
        Destroy(gameObject);
        //ChangeColorsTrafficLight();
        Vector3 pos = gameObject.transform.position;
        isdead = true;
        print("������������ ����");

    }

    void Update()
    {
        if (isdead)//���� ���������� �������������, �� ��������� ������ 
        {
            timeRemaining -= Time.deltaTime;//��� ������			

            if (timeRemaining < 0) //� ���� ����� ������� ������ ����, �� 
            {
                Destroy(gameObject);//������ ������� ������
            }
        }
    }
}