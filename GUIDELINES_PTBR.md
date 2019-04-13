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

No código anterior `demoView` possui a assinatura `unit -> Fable.Import.React.ReactElement`.

Para injetar o código usado em `demoView`, devemos usar a função `Render.getViewSource` que será capturada por um plugin que injetará o códico como uma string.

:warning: Para o correto funcionamento do plugin é importante que não existam linhas vazias no código de `demoView` :warning: Se você precisar de espaço no seu código pode usar comentários como especificado [em Form.fs file](docs/src/Fulma/Elements/Form.fs).

Se você quiser criar um exemplo interativo, por favor crie um componente com estados e uma função `code` para prover o código para o plugin. Você pode consultar exemplos aqui [Model.fs](docs/src/Fulma/Components/Modal.fs) e aqui [Switch.fs](docs/src/FulmaExtensions/Switch.fs).

#### Monitoração e teste 
Com a finalidade de testar suas atualizações na documentação, por favor use o comando *WatchDocs*:

No windows:
```shell
./fake.cmd build -t WatchDocs
```

No Unix:
```shell
./fake.sh build -t WatchDocs
```

Então vá para a [página local](http://localhost:8080) e observe as suas altualizações.

### 3 - Aventureiro?
Apenas entre de cabeça na [página de Issues](https://github.com/MangelMaxime/Fulma/issues?q=is%3Aissue+is%3Aopen+label%3A%22up+for+graps%22) no Github e escolha uma tarefa na qual você gostaria de trabalhar.

Siga as instruções fornecidas [aqui](#1---solve-issues)

### 4 - Desenvolvedor confirmado?
apenas entra de cabeça na [página de Issues](https://github.com/MangelMaxime/Fulma/issues?q=is%3Aissue+is%3Aopen+label%3Aenhancement) no Github e escolha uma tarefa na qual você gostaria de trabalhar.

Siga as instruções fornecidas [aqui](#1---solve-issues)

## Como fazer uma pull request limpa?

Essa documentação é baseada no padrão de [Marc Diethelm](https://github.com/MarcDiethelm/contributing/edit/master/README.md)

Procure pelas instruções de contribuição do projeto. Se existir alguma, entãs às siga.

- Crie um fork pessoal do projeto no Github.
- Clone o fork na sua máquina local. Seu repositório remoto no Github é chamado de `origin`.
- Adicione o repositório original como um remoto chamado de `upstream`.
- Se você criou seu fork a um tempo atrás, certfique-se de executar o comando pull parar capturar alterações para seu repositório local.
- Crie um novo branch para trabalhar! Branch de `develop` se existir, senão branch do `master`.
- Implemente/conserte sua feature, comente seu código.
- Siga o padrão de código do projeto, incluindo identação.
- Se o projeto possui teste rode-os!
- Escreva e adapte os teste conforme a necessidade.
- Adicione ou mude a documentação conforme for necessário.
- Comprima seus commits em um único commit utilizando o [rebase interativo](https://help.github.com/articles/interactive-rebase) do git. Crie um branch se for necessário.
- Adicione o seu branch no seu fork no Github, a `origin` remota.
- A partir do seu fork abra uma pull request no branch correto. Objetive o brach `develop` do projeto caso exista um, senão vá para o `master`!
- …
- Se os mantenedores requisitarem mudanças adicionais apenas às adicione no seu branch. A PR será atualizada automaticamente.
- Uma que vez a pull request for aprovada e adicionada você pode capturar as alterações de `upstream` para o seu repositório local e deletar
seus bramch(es) extras.

E por fim mas não menos importante: Sempres escreva as mensagens do seu commit no presente. Seu commit deve descrever o que o commit, quando aplicado, faz para o código – não o que ele fez para o código.
