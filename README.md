Step 1)
Configure the repository secrets:

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
Trigger it

![image](https://github.com/user-attachments/assets/39e55349-9150-4b30-ba82-990d08c16a2f)
