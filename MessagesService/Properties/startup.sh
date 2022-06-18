#!/bin/bash
exec dotnet ef database update
exec dotnet MessagesService.dll