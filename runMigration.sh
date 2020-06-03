#!/usr/bin/env bash
cd DigitalOwl.Migrations;
dotnet ef migrations add $1 --startup-project ../DigitalOwl.Api/DigitalOwl.Api.csproj;
cd ..;