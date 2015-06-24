#Deployment

###Overview

For both staging and production server, this project uses TeamCity to automatically build and deploy the website to Azure Web Apps. For the staging server, deployments are automatically triggered by GitHub pushes. For the production server, deployments are manually triggered after Q&A has run the integration tests.

###TeamCity configuration

The TeamCity project configuration consists of three build configurations

* GitHub Pull: 
  - Automatically triggered by GitHub pushes to https://github.com/DSoftTechnology/ADS-FDA-Pool3.git (queries every 60 seconds)
  - Runs NuGet to install / update packages defined in packages.config
  - Builds Xamarin solution
  - Runs NUnit and JetBrains dotCover (code coverage)
  - Publishes everything under the /Source/dosft.ads/dsoft.ads.web as artifact

* Azure Staging Deploy
  - Automatically triggered by succesfull GitHub Pull
  - Pushes the artifacts from the GitHub Pull to the staging Azure git repository (dsoft-ads-staging.azurewebsites.net)

* Azure Production Deploy
  - Manually triggered after Q&A integration tests
  - Pushes the artifacts from the GitHub Pull to the production Azure git repository (dsoft-ads.azurewebsites.net)

###Azure configuration

Azure has two Web Apps configured: dsoft-ads and dsoft-ads-staging. Each web app has its own local git repository and pushes to those repos automatically trigger deployments to the underlying web server. For more info on continuous deployment using GIT in Azure see: https://azure.microsoft.com/en-us/documentation/articles/web-sites-publish-source-control/

For development purposes, the source solution can be loaded in Xamarin Studio and run in the integrated XPS server.
