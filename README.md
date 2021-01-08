# Chat Application

#### Instructions for Running the App on your Machine with Docker(Windows or Linux)

1. Clone the repository

	`git clone https://github.com/erhanalankus/chat-app.git`

	`cd chat-app`

2. Enter SendGrid information into the Dockerfile. You should have received the information in an email, sent to you from me.
	
	Replace `{REDACTED-USERNAME}` with the username value in the email(in double quotes).
	
	Replace `{REDACTED-APIKEY}` with the API key in the email(in double quotes).

	Replace `{REDACTED-SENDER-EMAIL}` with the sender email in the email(in double quotes).

	For example, if the username is "Brad Pitt",the API key is "SG.12345", and the sender email is "brad@gmail.com", this is what the lines in your Dockerfile should look like:

	```
	ENV SendGridUser="Brad Pitt"
	ENV SendGridKey="SG.12345"
	ENV SenderEmail="brad@gmail.com"
	```

3. Build Docker image

	`docker build -t erhanalankus/chatapp .`

4. Run Docker container

	`docker run -p 8080:80 -v chatAppVolume:/app/Database erhanalankus/chatapp`

	This command will create a volume folder(named chatAppVolume) on your filesystem outside the container. The folder will be used to persist the SQLite database file. If you want, you can inspect the folder created in your machine at this path:

	*Windows:* `\\wsl$\docker-desktop-data\version-pack-data\community\docker\volumes\`

	*Linux:* `/var/lib/docker/volumes`

5. Visit localhost:8080 on your browser and use the application.


#### Instructions for Running the App on your Machine without Docker(Windows)

You can just hit `F5` and start the application. However, you need to enter the SendGrid credentials into the secrets.json file of ChatApp.Presentation.

Right click ChatApp.Presentation on the solution explorer and click "Manage User Secrets" to open the secrets.json file. Enter the SendGrid information into that file.

For example, if the username is "Brad Pitt", the API key is "SG.12345", and the email sender is "brad@gmail.com", this is what the lines in your secrets.json file should look like:

```
"SendGridUser": "Brad Pitt",
"SendGridKey": "SG.12345",
"SenderEmail": "brad@gmail.com",
```


#### About the Solution

The solution consists of six projects. The architecture is inspired by the Onion Architecture.

![Onion Archtecture Diagram](http://yunus.hacettepe.edu.tr/~erhan03/img/onion.png)

**ChatApp.Core:** This project has the core entities(Message, Room, ApplicationUser), ViewModels and the custom exception for invalid SendGrid credentials.

**ChatApp.Data:** This project has the database context class, configurations and the migrations.

**ChatApp.Service:** This project has the email sending implementation.

**ChatApp.Communication:** This project has the SignalR Hub class and the Entity-ViewModel mapping profiles.

**ChatApp.Presentation:** This Razor Pages project is responsible for registering and logging in the user, membership operations, and presenting them the chat application.

**ChatApp.Tests:** This MSTest project tests the email sending implementation against invalid SendGrid API keys.


#### How to Use the Chat Application

![How to use the chat application](http://yunus.hacettepe.edu.tr/~erhan03/img/chat-howto.png)