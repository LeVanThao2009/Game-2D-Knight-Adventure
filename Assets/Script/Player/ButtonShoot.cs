using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonShoot : MonoBehaviour, IPointerDownHandler
{
    public PlayerShoot player;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.ShootButton();
    }
}
