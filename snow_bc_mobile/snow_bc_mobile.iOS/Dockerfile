FROM microsoft/dotnet-framework:4.7.1-windowsservercore-1709
ARG source
WORKDIR /app
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["C:\\app\\snow_bc_mobile.iOS.exe"]
