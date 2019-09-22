FROM mcr.microsoft.com/dotnet/core/runtime:2.2

COPY /Docker_Weight/bin/Release/netcoreapp2.2/LiftingWeight.dll app/

ENTRYPOINT ["dotnet", "app/LiftingWeight.dll"]