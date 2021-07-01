using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    
    public Text itemName;
    //public List<GameObject> reviewScores;
    public GameObject EmptyStar;
    public GameObject FullStar;
    private string review;
    private int Id;

    public Text successText;
    public Text description;
    public Text uploadedAt;
/*    public Text Longitude;
    public Text Latitude;*/
    private double latitude { get; set; }


 
    public void SetReview(string newReview)
    {
        review = newReview;
    }    
    public void SetID(int id)
    {
        Id = id;
    }

    public int GetID()
    {
        return Id;
    }

    public void SetFullStars()
    {
        switch(review)
        {
            case "1":
                FullStar.transform.GetChild(0).gameObject.SetActive(true);
                    break;
            case "2":
                FullStar.transform.GetChild(0).gameObject.SetActive(true);
                FullStar.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "3":
                FullStar.transform.GetChild(0).gameObject.SetActive(true);
                FullStar.transform.GetChild(1).gameObject.SetActive(true);
                FullStar.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "4":

                FullStar.transform.GetChild(0).gameObject.SetActive(true);
                FullStar.transform.GetChild(1).gameObject.SetActive(true);
                FullStar.transform.GetChild(2).gameObject.SetActive(true);
                FullStar.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "5":
                FullStar.transform.GetChild(0).gameObject.SetActive(true);
                FullStar.transform.GetChild(1).gameObject.SetActive(true);
                FullStar.transform.GetChild(2).gameObject.SetActive(true);
                FullStar.transform.GetChild(3).gameObject.SetActive(true);
                FullStar.transform.GetChild(4).gameObject.SetActive(true);
            break;

            default:
                break;
        }
    }
    public string GetItemName()
    {
        return itemName.text;
    }

   
    public async void PostReview(int review)
    {

        using var client = new HttpClient();

        var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("art_object_id", Id.ToString()),
                new KeyValuePair<string, string>("review", review.ToString())
            };

       

        var content = new FormUrlEncodedContent(pairs);
        var response = await client.PostAsync("http://20.52.187.225:8000/api/reviews", content);
        if (response.IsSuccessStatusCode)
        {
            var contents = await response.Content.ReadAsStringAsync();
            successText.text = "Review submitted!";
            Invoke(nameof(DisableText), 5f);
            Debug.Log(contents);
        }
    }

    void DisableText()
    {
        successText.enabled = false;
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
