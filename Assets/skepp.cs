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
    public float timerSec;
    public float timerMin;
    public float timerHours;
    public float speed = 10;
    public float positionX;
    public float positionY;

    // Use this for initialization
    void Start()
    {
        positionX = Random.Range(10.41f, -10.41f);
        transform.position = new Vector3(0, 0, 0);
        

    }

    // Update is called once per frame
    void Update()
    {
        //detta gör att skeppet svänger vänster samt gör så att jag kan ändra i unity vilken färg det ska ändras till
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, ((rotationSpeed - (rotationSpeed / 3)) * Time.deltaTime));
            rend.color = leftColor;
        }
        //Samma som ovan fast koden gör att den svänger till höger istället för vänster
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
            rend.color = rightColor;
        }
        //detta gör så att skeppet går framåt konstant

        transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
        //detta gör så att skeppet åker -5 steg bakåt när man håller inne S och eftersom originalspeeden var 10 så blir det 10-5=5
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-speed / 2 * Time.deltaTime, 0, 0, Space.Self);
        }
        //detta gör så att det tiden kommer upp i unity och går upp med 1 varje sekund (även fast det är kommas vid sidan)

        //den här gör att timern skrivs ut 1 gång per sekund och att man har minuter,
        //detta görs för att timern fortsätter räknas och när timerSec når 60 delar timerMin timern med 60 och får ut ett helt nummer och skriver ut det.

        timer += Time.deltaTime;
        timerSec = (int)timer % 60;
        timerMin = (int)(timer / 60) % 60;
        timerHours = (int)(timer / 3600) % 60;
        print(string.Format("{0:0}-{1:00}-{2:00}", timerHours, timerMin, timerSec));

        //detta gör så att färgen randomisas varje gång man trycker på mellanslag
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rend.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        if (transform.position.x < -10.4)
        {
            transform.position = new Vector3(10.4f, transform.position.y, 0);

        }
        //detta gör så att om skeppet åker utanför skärmen så åker den tillbaks in fast på andra sidan
        if (transform.position.x > 10.4)
        {
            transform.position = new Vector3(-10.4f, transform.position.y, 0);
        }
        if (transform.position.y < -5.5)
        {
            transform.position = new Vector3(transform.position.x, 5.5f, 0);

        }
        if (transform.position.y > 5.5)
        {
            transform.position = new Vector3(transform.position.x, -5.5f, 0);

        }

    }
}

