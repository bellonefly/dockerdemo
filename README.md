切換到 DockerDemo 目錄執行底下指令前後端就可以 Run 起來
docker-compose up -d

前端網址：
http://127.0.0.1:8401 

後端網址：
http://127.0.0.1:8301



個別執行方式

前端：

docker build --build-arg env=build -t dockerdemo_backstageweb -f FrontStage.Web/Dockerfile .

docker run -d -p 8401:80 --name=dockerdemo_backstageweb_1 dockerdemo_backstageweb

後端：

docker build -t dockerdemo_backstageapi -f FrontStage.API/Dockerfile .

docker run -d -p 8301:80 --env ASPNETCORE_ENVIRONMENT=Release --name=dockerdemo_backstageapi_1 dockerdemo_backstageapi
