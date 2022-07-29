#!/usr/bin/env bash

export ImageName="sk-official-web"
export GCPImageName="gcr.io/stellar-38931/$ImageName:test"
docker build -t $ImageName .
docker tag $ImageName $GCPImageName
docker push $GCPImageName