FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base

# 設置工作目錄
WORKDIR /app	

# 開放 Port
EXPOSE 80
EXPOSE 443
EXPOSE 22

# 安裝常用工具
RUN apt-get update
RUN apt-get install -y unzip
RUN apt-get install -y openssh-server
RUN apt-get install -y vim

# 遠端偵錯用
WORKDIR /
RUN mkdir /var/run/sshd
RUN echo 'root:password' | chpasswd
RUN sed -i 's/PermitRootLogin prohibit-password/PermitRootLogin yes/' /etc/ssh/sshd_config
RUN service ssh restart
RUN /usr/sbin/sshd
RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v vs2017u5 -l /root/.vs-debugger/

# 建置
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["FrontStage.API/FrontStage.API.csproj", "FrontStage.API/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "FrontStage.API/FrontStage.API.csproj"
COPY . .
WORKDIR "/src/FrontStage.API"
RUN dotnet build "FrontStage.API.csproj" -c Release -o /app

# 發佈
FROM build AS publish
RUN dotnet publish "FrontStage.API.csproj" -c Release -o /app

# 運行
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FrontStage.API.dll"]