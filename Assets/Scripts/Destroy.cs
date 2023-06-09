using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public string TagName = "Enemy";
    public bool isdead = false; //���������� ������� ���������� ���������� ������, ��� ��� ���
    public float timeRemaining = 100;//����� ����� �������� ������ �������� ������ ����� ���������� (������� �� ����� �����������)

    public GameObject[] FoundObjects;
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;//�������� � ���������� ��������� ���� ��� ������ �� ���������� ������ �������
        FoundObjects = GameObject.FindGameObjectsWithTag(TagName);

    }

    void OnCollisionEnter(Collision collision)//��������� �� ������ �� ��������
    {
        GetComponent<Rigidbody>().isKinematic = false;//� ���� �� � ���-�� ����������, ��������� ��������� ��� ����� �������� ���

        foreach (GameObject o in FoundObjects)
        {
            if (o.GetInstanceID() == gameObject.GetInstanceID())
                continue;
            Debug.Log("�������");
        }





        isdead = true;//������ ���������� �������������, ����� ������ ���� ������ ��� ������ ��� "���������", � ��� ����� �������
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