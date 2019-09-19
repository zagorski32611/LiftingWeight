FROM mcr.microsoft.com/dotnet/core/runtime:2.2

COPY /home/joe/development/netcore/LiftingWeight/LiftingWeight/bin/Release/ app/

ENTRYPOINT ["dotnet", "app/LiftingWeight.dll"]