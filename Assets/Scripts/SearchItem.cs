
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
    async void Start()
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
                item.GetComponent<Item>().SetLongitude(data.longitude);
                item.GetComponent<Item>().SetLatitude(data.latitude);
                item.GetComponent<Item>().SetUploadedAt(data.updated_at);

                item.transform.SetParent(itemTemplate.transform.parent, false);

            }
        }
        else
        {
            Debug.Log(apiResponse.message);
        }

        /*for (int i = 1; i <= 20; i++)
        {
            GameObject item = Instantiate(itemTemplate) as GameObject;
            item.SetActive(true);
            item.GetComponent<Item>().SetText("Art #" + i);
            item.transform.SetParent(itemTemplate.transform.parent, false);
        }*/
    }

    // Update is called once per frame
     void Update()
    {
        
    }
}