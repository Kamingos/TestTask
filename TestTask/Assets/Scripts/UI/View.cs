using System;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    internal event Action<int> OnBtnPressed;

    public void Init()
    {
        // ������ �������� �� �������, ����� ����� ���� �����������

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(() =>
            {
                // �������, ����� ������� ��������� �� ������� ������ �� ����� ����������� ���������
                int index = i;

                OnBtnPressed.Invoke(index);
            });
        }
    }

    public void DisableButttons()
    {
        foreach (var item in buttons)
        {
            item.interactable = false;
        }
    }

    public void ActivateButttons()
    {
        foreach (var item in buttons)
        {
            item.interactable = true;
        }
    }
}
