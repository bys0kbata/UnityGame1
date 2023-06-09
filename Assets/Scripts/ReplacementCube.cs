using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacementCube : MonoBehaviour
{

    public bool isdead = false; //���������� ������� ���������� ���������� ������, ��� ��� ���
    public float timeRemaining = 100;//����� ����� �������� ������ �������� ������ ����� ���������� (������� �� ����� �����������)
    [SerializeField] private GameObject _Monik;

    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;//�������� � ���������� ��������� ���� ��� ������ �� ���������� ������ �������
    }

    void OnCollisionEnter(Collision collision)//��������� �� ������ �� ��������
    {
        Vector3 pos = gameObject.transform.position;
        GetComponent<Rigidbody>().isKinematic = false;//� ���� �� � ���-�� ����������, ��������� ��������� ��� ����� �������� ���
        isdead = true;//������ ���������� �������������, ����� ������ ���� ������ ��� ������ ��� "���������", � ��� ����� �������

        print("������������ ����");
        Instantiate(_Monik, pos, Quaternion.identity);
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