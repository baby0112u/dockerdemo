# FROM microsoft/dotnet:sdk
# WORKDIR /app
# COPY . /app
# CMD [ "dotnet", "run" ]

FROM microsoft/dotnet:sdk as build-dev
WORKDIR /code
COPY *.csproj /code
RUN dotnet restore
COPY . /code
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:runtime
WORKDIR /app
COPY --from=build-dev /code/out /app
ENTRYPOINT [ "dotnet","console.dll" ]

