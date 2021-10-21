using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scr_LimitMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 initialPosition, startPosition;
    private Vector2 mousePosition;
    private bool outOfBounds = false, takenOut = false;
    private float deltaX, deltaY, angleToRad, angle, length, height;
    private float b;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        startPosition = transform.position;
        angle = transform.eulerAngles.z;
        length = (float)(GetComponent<SpriteRenderer>().bounds.size.x / 1.5);
        height = (float)(GetComponent<SpriteRenderer>().bounds.size.y / 1.5);
        while (angle > 360)
            angle -= 360;
        angleToRad = angle * Mathf.PI / 180;

    }
    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        b = ((Camera.main.ScreenToWorldPoint(Input.mousePosition).x) * (Mathf.Sin(angleToRad) / Mathf.Cos(angleToRad)));
        Debug.Log(b.ToString());
    }

    private void OnMouseUp()
    {
        if (takenOut)
            Destroy(gameObject);
        if(outOfBounds)
        {
            gameObject.transform.position = startPosition;
            outOfBounds = false;
            initialPosition = startPosition;
        }
        else
        {
            initialPosition = transform.position;
        }
    }
    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (angle != 90 && angle != 270)
        {
            if (angle == 0)  //straight out right
            {
                if (gameObject.transform.position.x >= startPosition.x)
                {
                    transform.position = new Vector2((mousePosition.x - deltaX), initialPosition.y);
                    if (gameObject.transform.position.x >= (startPosition.x + length))
                    {
                        takenOut = true;
                    }
                    else
                    {
                        takenOut = false;
                    }
                }
                else
                    outOfBounds = true; 
            }
            else if(angle == 180) //straight out left
            {
                if (gameObject.transform.position.x <= startPosition.x)
                {
                    transform.position = new Vector2((mousePosition.x - deltaX), initialPosition.y);
                    if (gameObject.transform.position.x <= (startPosition.x - length))
                    {
                        takenOut = true;
                    }
                    else
                    {
                        takenOut = false;
                    }
                }
                else
                    outOfBounds = true;
            }
            else //diagonally
            {
                if(angle < 90) // out diagonally up right
                {
                    if (gameObject.transform.position.x >= startPosition.x)
                    {
                        transform.position = new Vector2((mousePosition.x - deltaX), ((mousePosition.x) * (Mathf.Sin(angleToRad) / Mathf.Cos(angleToRad))) - b + initialPosition.y);
                        if (gameObject.transform.position.x >= (startPosition.x + length))
                        {
                            takenOut = true;
                        }
                        else
                        {
                            takenOut = false;
                        }
                    }
                    else
                        outOfBounds = true;
                }
                else if (angle > 90 && angle < 180) // out diagonally up left
                {
                    if (gameObject.transform.position.x <= startPosition.x)
                    {
                        transform.position = new Vector2((mousePosition.x - deltaX), ((mousePosition.x) * (Mathf.Sin(angleToRad) / Mathf.Cos(angleToRad))) - b + initialPosition.y);
                        if (gameObject.transform.position.x <= (startPosition.x + length))
                        {
                            takenOut = true;
                        }
                        else
                        {
                            takenOut = false;
                        }
                    }
                    else
                        outOfBounds = true;
                }
                else if (angle > 180 && angle < 270) // diagonally down left
                {
                    if (gameObject.transform.position.x <= startPosition.x)
                    {
                        transform.position = new Vector2((mousePosition.x - deltaX), ((mousePosition.x) * (Mathf.Sin(angleToRad) / Mathf.Cos(angleToRad))) - b + initialPosition.y);
                        if (gameObject.transform.position.x <= (startPosition.x - length))
                        {
                            takenOut = true;
                        }
                        else
                        {
                            takenOut = false;
                        }
                    }
                    else
                        outOfBounds = true;
                }
                else //angle > 270
                {
                    if (gameObject.transform.position.x >= startPosition.x) //diagonally down right
                    {
                        transform.position = new Vector2((mousePosition.x - deltaX), ((mousePosition.x) * (Mathf.Sin(angleToRad) / Mathf.Cos(angleToRad))) - b + initialPosition.y);
                        if (gameObject.transform.position.x >= (startPosition.x - length))
                        {
                            takenOut = true;
                        }
                        else
                        {
                            takenOut = false;
                        }
                    }
                    else
                        outOfBounds = true;
                }
            }
        }
        else //outUp || outDown
        {
            if (angle == 90 ) // move only up and down
            {
                if (gameObject.transform.position.y >= startPosition.y)
                {
                    transform.position = new Vector2(initialPosition.x, mousePosition.y - deltaY);
                    if (gameObject.transform.position.y >= (startPosition.y + height))
                    {
                        takenOut = true;
                    }
                    else
                    {
                        takenOut = false;
                    }
                }   
                else
                    outOfBounds = true;
            }
            else // if(angle == 270)
            {
                if (gameObject.transform.position.y <= startPosition.y)
                { 
                    transform.position = new Vector2(initialPosition.x, mousePosition.y - deltaY);
                    if (gameObject.transform.position.y <= (startPosition.y - height))
                    {
                        takenOut = true;
                    }
                    else
                    {
                        takenOut = false;
                    }
                }
                else
                outOfBounds = true;
            }
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
