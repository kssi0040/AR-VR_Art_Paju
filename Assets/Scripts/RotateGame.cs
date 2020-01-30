using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateGame : MonoBehaviour
{
    public StagePlay m_StagePlay;
    public List<GameObject> Statue=new List<GameObject>();
    public List<bool> Clear = new List<bool>();
    public int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(Statue.Count!=0)
        {
            for(int k=0;k<Statue.Count;k++)
            {
                Statue[k].transform.GetChild(3).gameObject.SetActive(false);
                Clear.Add(false);
            }
        }
        m_StagePlay = GameObject.Find("StagePlay").GetComponent<StagePlay>();        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.touchCount>0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if(EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        //    {
        //        return;
        //    }
        //    ObjectSelect();
        //}        
        if (Input.GetMouseButtonDown(0))
        {
            ObjectSelect();
        }

        for (int k = 0; k < Statue.Count; k++)
        {
            if (Statue[k].transform.GetChild(0).GetComponent<StatueMove>().Clear == true)
            {
                Clear[k] = true;               
            }
            else
            {
                Clear[k] = false;                
            }
        }
        Count = 0;
        for(int k=0;k<Clear.Count;k++)
        {
            if(Clear[k]==true)
            {
                Count++;
            }
        }
        if (Count == Clear.Count)
        {
            PlayerInfo.Instance.isComplite = true;            
        }
        else
        {
            PlayerInfo.Instance.isComplite = false;
        }

        for(int k=0;k<Statue.Count;k++)
        {
            if (Statue[k].transform.GetChild(0).GetComponent<StatueMove>().Left==true|| Statue[k].transform.GetChild(0).GetComponent<StatueMove>().Right == true)
            {
                Statue[k].transform.GetChild(2).gameObject.SetActive(true);                
            }
            else
            {
                Statue[k].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    void ObjectSelect()
    {        
        //if(Input.touchCount==1)
        //{
            Debug.Log("Start");
            RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        bool bCheck = Physics.Raycast(ray, out hit, 30.0f);
            if(bCheck==true)
            {
                string name = hit.collider.gameObject.name;

                foreach(GameObject obj in Statue)
                {
                    if(obj.transform.gameObject.name==name)
                    {                    
                        obj.transform.GetChild(3).gameObject.SetActive(true);
                    }
                    else
                    {
                        obj.transform.GetChild(3).gameObject.SetActive(false);
                    }
                }
            }
        //}
    }
}
