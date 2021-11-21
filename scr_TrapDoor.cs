using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TrapDoor : MonoBehaviour
{
    public SpriteRenderer thisSpriteRenderer;
    public BoxCollider2D thisBoxCollider;
    public bool trapDoorOpen = false;
    public Sprite openSprite;
    public Sprite closedSprite;
    public Transform player;
    private float distanceX, distanceY;

    private void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        thisBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        distanceX = Mathf.Abs(player.transform.position.x - transform.position.x);
        distanceY = player.transform.position.y - transform.position.y;
        if (distanceX < 1 && distanceY < 1 && distanceY > 0)
        {
            thisSpriteRenderer.sprite = openSprite;
            trapDoorOpen = true;
            thisBoxCollider.isTrigger = true;
        }
    }
    private void OnMouseDown()
    {
        if(trapDoorOpen == false)
        {
            thisSpriteRenderer.sprite = openSprite;
            trapDoorOpen = true;
            thisBoxCollider.isTrigger = true;
        }
        else if(trapDoorOpen == true)
        {
            thisSpriteRenderer.sprite = closedSprite;
            trapDoorOpen = false;
            thisBoxCollider.isTrigger = false;
        }
    }

  

}
