using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class skepp : MonoBehaviour
{
    public float rotationSpeed;
    public SpriteRenderer rend;
    public Color rightColor;
    public Color leftColor;
    public float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //detta gör att skeppet svänger vänster samt gör så att jag kan ändra i unity vilken färg det ska ändras till
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f,  ((rotationSpeed - (rotationSpeed / 3)) * Time.deltaTime));
            rend.color = leftColor;
        }
        //Samma som ovan fast koden gör att den svänger till höger istället för vänster
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
            rend.color = rightColor;
        }
        //detta gör så att skeppet går framåt konstant
        transform.Translate(10f * Time.deltaTime, 0, 0);
        //detta gör så att skeppet åker -5 steg bakåt när man håller inne S och eftersom originalspeeden var 10 så blir det 10-5=5
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-5f * Time.deltaTime, 0, 0);
        }
        //detta gör så att det tiden kommer upp i unity och går upp med 1 varje sekund (även fast det är kommas vid sidan)
       timer += Time.deltaTime;
        
        //Debug.Log(string.Format("{0}", timer));
        print((int)timer);
    }
    
}

