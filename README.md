# Running steps
- from repository catalog run preconfigured docker-compose with MS SQL database image
```docker-compose up```
- run database migration 
```dotnet ef database update -p ./src/application/TwoWaySynonyms.Infrastructure -s ./src/web/TwoWaySynonyms.Web```
- run web application
```dotnet run -p ./src/web/TwoWaySynonyms.Web```

Enjoy at ```https://localhost:5001/``` :)
