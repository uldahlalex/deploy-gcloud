- Step 0)
Use the YAML file from .github/workflows/ as a deployment template for your project

- Step 1)
Configure path in the yaml file to your API's folder
```yml
 source: ./ #needs to point to the API's folder, so this could be ./server/api/
```

- Step 2) Repository secrets:

![image](https://github.com/user-attachments/assets/4402a677-7745-4a24-8487-822e630a82a2)


How to find the values for the secrets:

The way you find you service account email is like this:
```bash
gcloud iam service-accounts list
```

Now use this for generating the SA key:
```bash
gcloud iam service-accounts keys create key.json --iam-account YOUR_SERVICE_ACCOUNT_EMAIL
```

The "NAME" variable in the YAML file is the name of your cloud run service - you can find the name using the GCloud CLI like this:
```bash
gcloud run services list
```

- Step 3)
Make sure you've configured the URL in your C# code to use appropriate URL. 
Here's my entire startup:
```csharp
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";
var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";

var app = builder.Build();

app.MapGet("/", () => $"Hello {target}!");

Console.WriteLine(JsonSerializer.Serialize(Environment.GetEnvironmentVariables()));
app.Run(url);
```

- Step 4)
Trigger it!

The workflow file feature's a "workflow dispatch" which you manually trigger like this:
![image](https://github.com/user-attachments/assets/39e55349-9150-4b30-ba82-990d08c16a2f)
