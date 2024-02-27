# Estudos .NET + Docker + Kubernetes

> Pequeno projeto para testes e primeiros passos utilizando variáveis de ambiente obtidas do arquivo de configuração  `.yaml`


## Passos para execução

### Criação da imagem
```shell
docker build -t dotnet-docker-k8s -f Dockerfile . 
```
### Publicação da imagem em rede local

- Criação de um registro local para imagens Docker

```shell
    docker run -d -p 5000:5000 --restart=always --name registry registry:2   
```

- Criação de um alias entre imagem criada e o registro da mesma

```shell
    docker tag dotnet-docker-k8s localhost:5000/dotnet-docker-k8s 
```
- Publicação da imagem no registro local

```shell
    docker push localhost:5000/dotnet-docker-k8s 
```

### Aplicação do arquivo de configuração K8s

```shell
kubectl apply -f console-deployment.yaml         
```

## Meus aprendizados 

### .NET 

- Para acessar as variáveis de ambientes é só usar `Environment.GetEnvironmentVariable("nome_da_variavel");`
- Um container é executado e encerrado, para interações maiores e acompanhamentos é necessário que haja estruturas que mantenham o mesmo de pé. No caso de uma aplicação console podemos usar o ``while(true)`` 
- Toda e qualquer modificação no código exigirá que a imagem docker seja recriada


### Kubernetes

- O K8s olhará para o DockerHub, se formos usar imagens locais é necessário publicar em um registro local e utilizar o campo ``imagePullPolicy: IfNotPresent`` no arquivo de configuração do docker