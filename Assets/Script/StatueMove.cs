using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMove : MonoBehaviour
{
    public bool Left = false;
    public bool Right = false;   
    public float speed;
    public float Answer;
    public GameObject Particle;
    public bool Clear=false;

    // Start is called before the first frame update
    void Start()
    {
        if(Particle!=null)
        {
            Particle.SetActive(false);
        }
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, Random.Range(0.0f, 180.0f), 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Left==true)
        {
            this.transform.Rotate(0.0f, (-90.0f * Time.deltaTime) / speed, 0.0f);
        }

        if(Right==true)
        {
            this.transform.Rotate(0.0f, (90.0f * Time.deltaTime) / speed, 0.0f);
        }
        
        if(Particle!=null)
        {
            if(this.transform.eulerAngles.y<=Answer+3.0f&&this.transform.eulerAngles.y >=Answer-3.0f)
            {
                if(Particle.activeSelf==false)
                {
                    Particle.SetActive(true);
                    Clear = true;
                }
            }           

            else if(this.transform.eulerAngles.y<=360.0-Answer+3.0f&&this.transform.eulerAngles.y>=360-Answer-3.0f)
            {
                if(Particle.activeSelf==false)
                {
                    Particle.SetActive(true);
                    Clear = true;
                }
            }
            else
            {
                Particle.SetActive(false);
                Clear = false;
            }
        }
    }

    private void FixedUpdate()
    {
        this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }

    public void LeftButtonDown()
    {
        Left = true;
    }

    public void LeftButtonUp()
    {
        Left = false;
    }

    public void RightButtonDown()
    {
        Right = true;
    }

    public void RightButtonUp()
    {
        Right = false;
    }
}
