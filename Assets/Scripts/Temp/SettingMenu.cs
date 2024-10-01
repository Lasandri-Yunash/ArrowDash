using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [Header("Space between menu items")]
    [SerializeField] Vector2 spacing;

    [Space]
    [Header("Main button rotation")]
    [SerializeField] float rotationDuration;
    [SerializeField] Ease rotationEase;

    [Space]
    [Header("Animation")]
    [SerializeField] float expandDuration;
    [SerializeField] float collapseDuration;
    [SerializeField] Ease expandEase;
    [SerializeField] Ease collapseEase;

    [Space]
    [Header("Fading")]
    [SerializeField] float expandFadeDuration;
    [SerializeField] float collapseFadeDuration;

    [Space]
    [Header("Music")]
    [SerializeField] AudioSource music;

    Button mainButton;
    SettingMenuItem[] menuItems;

    bool isExpanded = false;

    Vector2 mainButtonPosition;
    int itemsCount;

    private void Start()
    {
        itemsCount = transform.childCount - 1;
        menuItems = new SettingMenuItem[itemsCount];

        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent <SettingMenuItem> ();


        }

        mainButton = transform.GetChild(0).GetComponent <Button> ();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling ();

        mainButtonPosition = mainButton.transform.position;
        ResetPositions();
    }

    void ResetPositions()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i].transform.position = mainButtonPosition;
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if (isExpanded)
        {

            for (int i = 0; i < itemsCount; i++)
            {
                //menuItems[i].transform.position = mainButtonPosition + spacing * (i + 1);
               
                menuItems[i].trans.DOMove(mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1f, expandFadeDuration).From(0f);
            }
        }
        else
        {

            for (int i = 0; i < itemsCount; i++)
            {
                // menuItems[i].transform.position = mainButtonPosition;

                menuItems[i].trans.DOMove(mainButtonPosition, collapseDuration).SetEase(collapseEase);
                menuItems[i].img.DOFade(0f, collapseFadeDuration);
            }
        }

        mainButton.transform
           .DORotate(Vector3.forward * 180f, rotationDuration)
           .From(Vector3.zero)
           .SetEase(rotationEase);

    }

    public void OnItemClick(int index)
    {
        //here you can add you logic 
        switch (index)
        {
            case 0:
                //first button
                Debug.Log("Music");
                
                break;
            case 1:
                //second button
                Debug.Log("Sounds");
                break;
            case 2:
                //third button
                Debug.Log("Vibration");
                break;
             case 3:
                Debug.Log("plyaa");
                break;

        }
    }

    void OnDestroy()
    {
        //remove click listener to avoid memory leaks
        mainButton.onClick.RemoveListener(ToggleMenu);
    }

    
}
