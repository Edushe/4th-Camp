using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    void Awake() { instance = this; }
    public static UIManager Instance
    { get { return instance; } }

    public int coinCount;//��ǰ��ҵ�����
    public Text coinCountShow;//�����������ʾ

    public float currentHealth;//��ǰѪ��
    public float maxHealth;//���Ѫ��
    public Slider healthShow;//Ѫ������ʾ

    private void Update()
    {
        coinCountShow.text = coinCount.ToString();//���½��������ʾ
        healthShow.value = currentHealth / maxHealth;//����Ѫ����ʾ
    }
}
