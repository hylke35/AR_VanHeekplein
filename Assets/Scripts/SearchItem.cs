
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SearchItem : MonoBehaviour
{

    public List<GameObject> objectsList;
    private GameObject item;
    public Dropdown dropDown;
    public GameObject itemTemplate;


    // Start is called before the first frame update
    public void Start()
    {
        GetObjects();
    }


    //Get the objects which are approved from the database;
    public async void GetObjects()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("http://20.52.187.225:8000/api/artobjects");
        var contents = await response.Content.ReadAsStringAsync();
        APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(contents);

        if (apiResponse.success == true)
        {

            foreach (Data data in apiResponse.data)
            {
               
                
                item = Instantiate(itemTemplate);
                item.SetActive(true);
                Debug.Log(data.id);
                item.GetComponent<Item>().SetID(data.id);
                item.GetComponent<Item>().SetItemName(data.name);
                item.GetComponent<Item>().SetItemDesc(data.description);
                /*item.GetComponent<Item>().SetLongitude(data.longitude);
                item.GetComponent<Item>().SetLatitude(data.latitude);*/
                item.GetComponent<Item>().SetUploadedAt(data.updated_at);
                double stars = await GetReviews(data.id);

                string starsString = stars.ToString();

                item.GetComponent<Item>().SetReview(starsString);

                item.GetComponent<Item>().SetFullStars();
             
                item.transform.SetParent(itemTemplate.transform.parent, false);

                objectsList.Add(item);
             /*   apiResponse.data.OrderBy(go => GetReviews(data.id)).ToArray();
                for (int i = 0; i < apiResponse.data.Count; i++)
                {
                    objectsList[i].transform.SetSiblingIndex(i);
                }*/

            }


        }

    }

    //An API call to get the average review score of an object
    public async Task<double> GetReviews(int Id)
    {
        double average = 0;
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync("http://20.52.187.225:8000/api/reviews/" + Id);
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                if (contents.StartsWith("{\"success\":true"))
                {
                    APIResponseReview apiResponse = JsonConvert.DeserializeObject<APIResponseReview>(contents);

                    if (apiResponse.success == true)
                    {

                        double sum = 0;
                        foreach (ReviewData reviewData in apiResponse.data)
                        {
                            
                            sum += int.Parse(reviewData.review);

                            //Debug.Log(reviewData.review);
                        }


                        average = Math.Round(sum / apiResponse.data.Count);

                    }
                }
            }
        }

        return average;
    }


    //Search the list created to and compare it to the input of the InputField
    public void SearchList(string input)
        {
        foreach(GameObject item in objectsList)
        {
            if (input == "")
                item.SetActive(true);
            
            if (input != "")
            {
                if (item.GetComponent<Item>().GetItemName().ToLower() == input.ToLower().Trim())
                {
                    item.SetActive(true);
                }
                else item.SetActive(false);
            }
            
        }
    }


    
  
   
}