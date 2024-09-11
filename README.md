# Technical Assessment CDB Investment Calculation

## How to run via Docker:
 - Install Docker and Docker Compose
 - Browse to the project root directory  
 - Run `docker-compose up -d`
 - Frontend: http://localhost:8082/cdb-investment-calculator
 - Backend: Swagger: http://localhost:8081/swagger/index.html

 ## How to run in development mode:
 - Backend
    - Browse to the backend folder
    - Open Solution file on Visual Studio Community/Professional or your favorite IDE
    - Run the project
    - Swagger: http://localhost:5139/swagger/index.html

 - Frontend
    - Browse to the frontend folder
    - Open Visual Studio Code or your favorite IDE
    - If you want run it with backend solution in development mode, change the `enviroment.ts` file. Instructions there.
    - Run the project: `ng serve`.
    - Page: http://localhost:4200/cdb-investment-calculator

 ## Testing:
 - Backend: 
 -  _Disclaimer_: Docker: port 8082. Development mode: port 5139
 ```
 curl --location 'http://localhost:8082/api/calculator/cdb' \
--header 'accept: */*' \
--header 'Content-Type: application/json' \
--data '{
  "initialAmount": 500,
  "months": 1
}'
 ```
 - Via Frontend:
    - Follow the link (Docker): http://localhost:8082/cdb-investment-calculator
    - Follow the link (Development mode): http://localhost:4200/cdb-investment-calculator