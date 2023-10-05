## VARIABLES
$azureResourceGroup = "lagalt-db"
$azureContainerRegistry = "lagaltapi.azurecr.io"
$azureContainer = "lagalt-docker-container"

docker build -t lagaltapi .
#docker run --name lagalttest -p 8080:80 -d lagaltapi

docker images

## Display azure container
#az container show --resource-group $azureResourceGroup --name $azureContainer

# Login to azure container registry
# az acr login --name $azureContainerRegistry

#az acr show --name $azureContainerRegistry --query loginServer --output table

docker tag lagaltapi lagaltapi.azurecr.io/lagaltbackend:v0.1

docker push $azureContainerRegistry/lagaltbackend:v0.1

az container restart --resource-group $azureResourceGroup --name $azureContainer