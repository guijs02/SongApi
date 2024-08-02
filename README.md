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

| HTTP Method | Endpoint          | Description            |
|-------------|-------------------|------------------------|
| GET         | /api/song/{id}    | Gets a song.           |
| GET         | /api/song         | Gets all song.         |
| POST        | /api/song         | Register a new song.   |
| DELETE      | /api/song/{id}    | Delete a song.         |

## 📡 Tecnologias
- C#
- .NET Core
- Docker
- EF Core
- MongoDb

## 🛠 Funcionalidades
- Cadastro de musicas

## 💡 Patterns
- Service
- Model

## 📖 Recursos e conceitos
- Injeção de Dependência
- Swagger
- DTO
- API RestFul
