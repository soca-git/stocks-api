docker build -t stocks-api-app . # create Docker image
docker tag stocks-api-app registry.heroku.com/stocks-api-app/web # create tag between Heroku image & local image

# Deploy image to Heroku
heroku login
heroku container:login
heroku container:push web -a stocks-api-app
heroku container:release web -a stocks-api-app

Write-Host -ForegroundColor Green "Deployment was successful!"