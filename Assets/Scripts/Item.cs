using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    public Text itemName;
    public List<GameObject> reviewScores;
    public GameObject Star;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    public void SetText(string textString)
    {
        itemName.text = textString;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
