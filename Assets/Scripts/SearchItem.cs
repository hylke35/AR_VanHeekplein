using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchItem : MonoBehaviour
{
    public List<GameObject> objectsList;
    [SerializeField]
    public GameObject itemTemplate;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 20; i++)
        {
            GameObject item = Instantiate(itemTemplate) as GameObject;
            item.SetActive(true);
            item.GetComponent<Item>().SetText("Art #" + i);
            item.transform.SetParent(itemTemplate.transform.parent, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}