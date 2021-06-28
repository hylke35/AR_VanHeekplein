
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;


public class SearchItem : MonoBehaviour
{

    public List<GameObject> objectsList;
    [SerializeField]
    public GameObject itemTemplate;
    // Start is called before the first frame update
    public async void Start()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("http://20.52.187.225:8000/api/artobjects");
        var contents = await response.Content.ReadAsStringAsync();
        APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(contents);

        if (apiResponse.success == true)
        {
            
                foreach (Data data in apiResponse.data)
                {


                    GameObject item = Instantiate(itemTemplate) as GameObject;
                    item.SetActive(true);
                    item.GetComponent<Item>().SetItemName(data.name);
                    item.GetComponent<Item>().SetItemDesc(data.description);
                    /*item.GetComponent<Item>().SetLongitude(data.longitude);
                    item.GetComponent<Item>().SetLatitude(data.latitude);*/
                    item.GetComponent<Item>().SetUploadedAt(data.updated_at);

                    item.transform.SetParent(itemTemplate.transform.parent, false);

                    objectsList.Add(item);

                }

           
        }

    
    }


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

 


        // Update is called once per frame
        void Update()
        {
        
        }
   
}