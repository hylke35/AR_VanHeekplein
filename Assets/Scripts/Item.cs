using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    public Text itemName;
    //public List<GameObject> reviewScores;
    public GameObject Star;

    private int id { get; set; }

    public Text description;
    public Text uploadedAt;
/*    public Text Longitude;
    public Text Latitude;*/
    private double latitude { get; set; }




    public string GetItemName()
    {
        return itemName.text;
    }

    public void SetItemName(string textString)
    {
        itemName.text = textString;
    }

    public void SetItemDesc(string textString)
    {
        description.text = textString;
    }
    public void SetUploadedAt(string textString)
    {
        uploadedAt.text = textString;
    }

/*    public void SetLongitude(double longitude)
    {
        this.Longitude.text = longitude.ToString();
    }
    
    public void SetLatitude(double latitude)
    {
        this.Latitude.text = latitude.ToString();
    }*/
}
