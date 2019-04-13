# Fulma : contribuindo para o projeto

## Introdução
Olá, estamos felizes por ter decidido se juntar à banda para tornar este projeto ainda melhor!
Embora não seja dificil contribuir para este projeto, nós iremos ajudá-lo a iniciar.

# Requisitos de Build

* [dotnet SDK](https://www.microsoft.com/net/download/core) 2.0 ou maior
* [node.js](https://nodejs.org) 6.11 ou maior
* Gerenciador de pacotes Yarn JS: [yarn](https://yarnpkg.com)

## Instalando as dependências e primeira build

Para instalar as dependências, gerar os documentos e construir a build do projeto, utilize os seguintes commandos:

No Windows:
```shell
./fake.cmd build
```

No Unix:
```shell
./fake.sh build
```

## Como você pode ajudar
Agora que já está pronto, você poderá nos ajudar de diferentes maneiras, que serão descritas aqui.

Antes de começar a contribuir, por favor certifique-se de já ter lido o parágrafo [Como fazer um pull request "limpo"](#how-to-make-a-clean-pull-requestpr).

### 1 - Resolvendo Issues

#### Escolha
Apenas vá até a [Página de Issues](https://github.com/MangelMaxime/Fulma/issues?q=is%3Aopen+is%3Aissue) no Github e escolha a issue que você deseja trabalhar. Mencione, comentando na issue, que você está trabalhando na mesma, para que possamos evitar várias pessoas trabalhando na mesma issue.

#### Codificação
O código fonte do projeto encontra-se na pasta `src`.
Portanto, comece a desenvolver e, quando tiver terminado, apenas utilize o comando *Build*:

#### Build

No windows:
```shell
./fake.cmd build
```

No Unix:
```shell
./fake.sh build
```

#### Teste
A forma mais fácil de testar o que você acabou de fazer commit é criando/ atualizando a documentação. A documentação é construída utilizando o próprio Fulma.

### 2 - Adicionando ou atualizando documentação

#### Escolha
Apenas vá até a [Página de Issues](https://github.com/MangelMaxime/Fulma/issues?q=is%3Aissue+is%3Aopen+label%3ADocumentation) no Github e escolha a issue de documentação que você deseja trabalhar.

#### Arquitetura de código
A documentação do projeto Fulma pode ser encontrado na pasta `docs`. A documentação é gerada dos arquivos fontes localizados na pasta `docs/src`. 

A arquitetura padrão para construção de documentos é a seguinte:

1 - Uma pasta por categoria (por exemplo, Layout ou Elements). Essa arquitetura imita a encontrada na pasta `src` da biblioteca raiz (root).

2 - Arquivo `Introduction.fs`. Esse arquivo hospeda o Markdown, texto base introduzindo a categoria.

3 - Arquivo `Router.fs`. Esse arquivo é responsável por rotear as requisições para os componentes locais. Por exemplo, se você adicionar a documentação para um novo componente à categoria, você também terá que adicionar a rota para essa documentação.

4 - Um arquivo `.fs` por componente (por exemplo, Columns.fs). Esse é o arquivo que hospeda as *amostras de código* atuais e a devida documentação (baseada em markdown) para o componente.

##### Observações de como funciona a documentação

Para exibir um exemplo e o código utilizado, você precisa utilizar:

```fs
Render.docSection
    "[Título da sua seção]"
    (Widgets.Showcase.view demoView (Render.includeCode __LINE__ __SOURCE_FILE__))
```
