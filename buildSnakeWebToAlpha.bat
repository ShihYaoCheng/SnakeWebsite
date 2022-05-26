docker build -t asia.gcr.io/stellar-38931/sk-web:master .
docker push asia.gcr.io/stellar-38931/sk-web:master

cd K8S\DeploySnakeWeb
kubectl config use-context gke_stellar-38931_asia-east1-b_snake-dev
kubectl delete -f 2-Config
kubectl create -f 2-Config

kubectl delete -f 4-Deploy
kubectl create -f 4-Deploy

pause