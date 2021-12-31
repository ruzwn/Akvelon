# Akvelon trainee C# test task
Solution is ASP NET Core project with Entity Framework Core for ORM. <br />
Solution contains two controllers for working with Project and Task entities.
Clean architecture, CQRS, Mediator and Data Transer Object patterns were used in the solution. <br />
For mapping models was used AutoMapper, for implemeting Mediator pattern was used MediatR.
SQLite database is used for data storage. All API documentation is provided by Swagger. <br />


## Docker
Install Docker for Windows https://www.docker.com/products/docker-desktop . <br />
For create docker image open PowerShell and map to the solution folder (...\Akvelon). <br />
Here you have to run command "docker build -t akvelondockerimage .". <br />
After creating docker image with name "akvelondockerimage" yot need to run command "docker run -it --rm --name akvelondockercontainer akvelondockerimage"
for creating docker creating and running container with the name "akvelondockercontainer". <br />
Now you need to open second PowerShell window and execute command "docker exec akvelondockercontainer ipconfig"
and copy data of field "IPv4 Address" (172.26.6.207 for example). <br />
Well done, now you have to paste copied IPv4 Address in browser search line and press enter and now you can test my API. <br />
To shut down the container press "Ctrl + C" in PowerShell. <br />
