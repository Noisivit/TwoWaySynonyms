# Simplification
For simplisity I used the same models in webapp and in application layer.

# Running steps
1) From repository catalog run preconfigured docker-compose file with MS SQL database image ```docker-compose up```
2) Run database migration 
```dotnet ef database update -p ./src/application/TwoWaySynonyms.Infrastructure -s ./src/web/TwoWaySynonyms.Web```
3) run web application
```dotnet run -p ./src/web/TwoWaySynonyms.Web```

Take a look at ```https://localhost:5001/```
