# gmail-email-format-verification 📬

This applicaiton container a simple .NET Core API with a single endpoint `POST /api/emails/unique`. This endpoint takes a JSON body that consists of an array of strings which represent emails. From here, the API will analyze these emails to find only the unique instances of them per the gmail email aliasing format, meaning it will remove and `.` from the username, and remove all characters after any instance of a `+` in the username. 
For example: `masonomara@gmail.com`, `masonomara+ads@gmail.com` and `mason.omara+somemoreads@gmail.com` all translate to a single email: `masonomara@gmail.com`. The results of this API endpoint should print out all unique emails with `.` and aliasing removed from their usernames, as well as the count of unique emails.

## Running the API 🐕

### Run With Docker 🐳

If you're interested in running the applicaiton without the need to download a .NET Core compiler on your machine, you can use Docker to do so using the following comamnds from the root of the project:

```
docker build -t gmail-email-format-verification .
docker run -d -p 8080:80 --name gmail-unique-container gmail-email-format-verification
```

Then simply hit the endpoint at `[POST] http://localhost:8080/api/emails/unique`. See the request body example below.

### Run Without Docker 💻

Download your IDE of choice that can run a .NET Core solution and fire er' up. Visual Studio/Code are some Microsoft sanctioned ones.

Then simply hit the endpoint at `[POST] http://localhost:5000/api/emails/unique`. See the request body example below.

## Hitting The API 🥊

There exists only a single endpoint: `POST api/emails/unique` that expects a request body that looks like this:

```
["masonomara@gmail.com", "masonomara+ads@gmail.com", "mason.omara+somemoreads@gmail.com"]
```

The result of which should return

```
{
    "uniqueEmails": [
        "masonomara@gmail.com"
    ],
    "count": 1
}
```

These is also some basic validation for inputs, but nothing crazy!
