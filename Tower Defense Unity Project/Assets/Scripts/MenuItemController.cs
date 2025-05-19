using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class MenuItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Text Settings")]
    public TextMeshProUGUI menuText;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.yellow;

    [Header("Wing Sprites")]
    public GameObject leftWing;    // Wings_L 스프라이트
    public GameObject rightWing;   // Wings_R 스프라이트

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        
        // 기본 상태에서는 날개 숨기기
        if (leftWing != null) leftWing.SetActive(false);
        if (rightWing != null) rightWing.SetActive(false);

        // 기본 텍스트 색상 설정
        if (menuText != null)
        {
            menuText.color = normalColor;
        }
    }

    // 마우스가 메뉴 항목 위에 올라갔을 때
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 텍스트 색상 변경
        if (menuText != null)
        {
            menuText.color = hoverColor;
        }

        // 날개 스프라이트 표시
        if (leftWing != null) leftWing.SetActive(true);
        if (rightWing != null) rightWing.SetActive(true);
    }

    // 마우스가 메뉴 항목에서 벗어났을 때
    public void OnPointerExit(PointerEventData eventData)
    {
        // 텍스트 색상 원래대로
        if (menuText != null)
        {
            menuText.color = normalColor;
        }

        // 날개 스프라이트 숨기기
        if (leftWing != null) leftWing.SetActive(false);
        if (rightWing != null) rightWing.SetActive(false);
    }
}