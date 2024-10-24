Step 0)
Copy the workflow YAML file from .github/workflows/ to your project

Step 1)
Configure the repository secrets and source path:
``ỳaml
 source: ./ #needs to point to the API's folder, so this could be ./server/api/
```

Repository secrets:

![image](https://github.com/user-attachments/assets/4402a677-7745-4a24-8487-822e630a82a2)


How to find the secrets:

```bash
gcloud iam service-accounts keys create key.json --iam-account YOUR_SERVICE_ACCOUNT_EMAIL
```

The way you find you service account email is like this:
```bash
gcloud iam service-accounts list
```

The "NAME" variable is the name of your cloud run service - you can find the name using the CLI like this:
```bash
gcloud run services list
```

Step 2)
Make sure you've configured the URL:

```csharp
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";
var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";

var app = builder.Build();

app.MapGet("/", () => $"Hello {target}!");

Console.WriteLine(JsonSerializer.Serialize(Environment.GetEnvironmentVariables()));
app.Run(url);
```

Step 3)
Trigger it

![image](https://github.com/user-attachments/assets/39e55349-9150-4b30-ba82-990d08c16a2f)
