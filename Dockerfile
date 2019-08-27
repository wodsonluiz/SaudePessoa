FROM golang
WORKDIR /go/src/github.com/habibridho/SaudePessoa
ADD . ./
RUN CGO_ENABLED=0 GOOS=linux go build -a -installsuffix .
EXPOSE 8888
ENTRYPOINT ./SaudePessoa
RUN pip install --upgrade pip
RUN pip install -r ./requirements.txt