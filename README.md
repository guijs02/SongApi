## Sobre o SongApi
Esta é uma API Crud focada na inserção de musicas.
<br>
<br>

## Endpoint de Exemplo
```json
{
  "name": "hello",
  "artist": "Adele"
}
```

### Song Endpoints

| HTTP Method | Endpoint             | Description            |
|-------------|----------------------|------------------------|
| GET         | /api/v1/song/{id}    | Gets a song.           |
| GET         | /api/v1/song         | Gets all song.         |
| POST        | /api/v1/song         | Register a new song.   |
| DELETE      | /api/v1/song/{id}    | Delete a song.         |

## 📡 Tecnologias
- C#
- .NET Core
- Docker
- EF Core
- MongoDb

## 🛠 Funcionalidades
- Cadastro
- Deleção
- Alteração

## 💡 Patterns
- Service
- Model

## 📖 Recursos e conceitos
- Injeção de Dependência
- Swagger
- DTO
- API RestFul

## 🕹 Como executar o projeto 
- Siga a instalação do docker no site: https://docs.docker.com/desktop/install/windows-install/
- Após baixar o Docker, clone o projeto e acesse o terminal no diretório do projeto.
- Para executar o projeto execute o comando:
```
docker compose up 
```
Ou 
```
docker compose up -d
```
Para habilitar o terminal após iniciar :)
