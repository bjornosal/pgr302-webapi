#!/usr/bin/env bash

if [ $1 ]
then
    dotnet ef migrations add $1
    dotnet ef database update
else 
    echo "Missing update name."
fi

