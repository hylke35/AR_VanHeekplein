using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
using Newtonsoft.Json;
using System.Net.Http.Headers;

public class Login : MonoBehaviour
{
    private Label titleLabel;
    private TextField emailField;
    private TextField passwordField;
    private Button submitButton;

    private void Create()
    {

    }
    private void OnEnable()
    {

        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        titleLabel = rootVisualElement.Q<Label>("title-label");
        emailField = rootVisualElement.Q<TextField>("email");
        passwordField = rootVisualElement.Q<TextField>("password");
        submitButton = rootVisualElement.Q<Button>("submit");

        submitButton.RegisterCallback<ClickEvent>(async ev => await LoginUserAsync());
    }

    private async System.Threading.Tasks.Task LoginUserAsync()
    {
        var values = new Dictionary<string, string>{
          { "Email", emailField.text },
          { "Password", passwordField.text },
        };

        var json = JsonConvert.SerializeObject(values, Formatting.Indented);

        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync(
                "http://localhost:3001/api/v1/avh/login",
                 stringContent);
            var contents = await response.Content.ReadAsStringAsync();
            dynamic test = JsonConvert.DeserializeObject(contents);

            titleLabel.text = test.message;
        }
    }
}
