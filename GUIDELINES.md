# Fulma : contributing to the project

## Foreword
Hi there, we're happy you deciced to join the band so as to make this project even better!
Although contributing to this project is not complicated we'll help you get started.

# Build requirements

* [dotnet SDK](https://www.microsoft.com/net/download/core) 2.0 or higher
* [node.js](https://nodejs.org) 6.11 or higher
* Yarn JS package manager: [yarn](https://yarnpkg.com)

## Install dependencies and first build

In order to install the dependencies, generate the docs and build the project just type the following commands:

On windows:
```shell
./fake.cmd build
```

On Unix:
```shell
./fake.sh build
```

## How you can help
Now, you're all set and ready, you can help us in many different ways which we'll describe here.

Before starting contributing, please make sure you've read the [How to make a clean pull request](#how-to-make-a-clean-pull-requestpr) paragraph.

### 1 - Solve issues

#### Choose
Just head up to the [Issues page](https://github.com/MangelMaxime/Fulma/issues?q=is%3Aopen+is%3Aissue) on Github then choose the issue you want to work on. Mention by commenting the issue that you are working on it, so we can avoid being several working on the same issue.

#### Code
The source code for the project is located in the `src` folder.
So start coding and when you're done, just use the *Build* command:

#### Build

On windows:
```shell
./fake.cmd build
```

On Unix:
```shell
./fake.sh build
```

#### Test
In order to test what you've just commited, the easiest way is to create/update the documentation. The documentation being build using Fulma itself.

### 2 - Add or update documentation

#### Choose
Just head up to the [Issues page](https://github.com/MangelMaxime/Fulma/issues?q=is%3Aissue+is%3Aopen+label%3ADocumentation) on Github then choose the doc issue you want to work on.

#### Code architecture
The documentation in the Fulma project can be found in the `docs` folder. The documentation is generated from source files located in the `docs/src` folder.

The common architecture for building docs is the following:
1 - A folder by category (for instance Layout or Elements). This architecture mimics the one you can find in the library root `src` folder.

2 - `Introduction.fs` file. This file hosts the a Markdown based text documentation introducing a category.

3 - `Router.fs` file`. This file is responsible for routing the requests to the local components. For instance, if you add the documentation for a new component to the category, you'll have to add the route to this documentation

4 - A `.fs` file per component (for instance Columns.fs). This is the file that hosts actual *code samples* and proper documentation (markdown based) for the component.

##### Notes on how the documentation code works

In order to display an example and the code used, you need to use:

```fs
Render.docSection
    "[Your section title goes here]"
    (Widgets.Showcase.view demoView (Render.getViewSource demoView))
```

In the previous code `demoView` has the signature `unit -> Fable.Import.React.ReactElement`.

In order to inject, the code used in `demoView`, we use `Render.getViewSource` function which will be handle by a plugin to inject the code as a string.

:warning: For the plugin to work correctly, it's important to not have any empty line in the code of `demoView` :warning: If you need to have to space out your code you can use comment like [in Form.fs file](docs/src/Fulma/Elements/Form.fs).

If you want to create an interactive example, please create a stateful component and a `code` function to provide the code to the plugin. You can see an example [in Model.fs](docs/src/Fulma/Components/Modal.fs) and [in Switch.fs](docs/src/FulmaExtensions/Switch.fs).

#### Watch and test
In order to live test your updates to the documentation, please use the *WatchDocs* command:

On windows:
```shell
./fake.cmd build -t WatchDocs
```

On Unix:
```shell
./fake.sh build -t WatchDocs
```

Then proceed to the [local page](http://localhost:8080) and check your updates there.

### 3 - Adventurer?
Just head up to the [Issues page](https://github.com/MangelMaxime/Fulma/issues?q=is%3Aissue+is%3Aopen+label%3A%22up+for+graps%22) on Github then choose the issue you want to work on.

Follow instructions provided [here](#1---solve-issues)

### 4 - Confirmed developer?
Just head up to the [Issues page](https://github.com/MangelMaxime/Fulma/issues?q=is%3Aissue+is%3Aopen+label%3Aenhancement) on Github then choose the issue you want to work on.

Follow instructions provided [here](#1---solve-issues)

## How to make a clean pull request

This documentation is based on [Marc Diethelm's](https://github.com/MarcDiethelm/contributing/edit/master/README.md)

Look for a project's contribution instructions. If there are any, follow them.

- Create a personal fork of the project on Github.
- Clone the fork on your local machine. Your remote repo on Github is called `origin`.
- Add the original repository as a remote called `upstream`.
- If you created your fork a while ago be sure to pull upstream changes into your local repository.
- Create a new branch to work on! Branch from `develop` if it exists, else from `master`.
- Implement/fix your feature, comment your code.
- Follow the code style of the project, including indentation.
- If the project has tests run them!
- Write or adapt tests as needed.
- Add or change the documentation as needed.
- Squash your commits into a single commit with git's [interactive rebase](https://help.github.com/articles/interactive-rebase). Create a new branch if necessary.
- Push your branch to your fork on Github, the remote `origin`.
- From your fork open a pull request in the correct branch. Target the project's `develop` branch if there is one, else go for `master`!
- …
- If the maintainer requests further changes just push them to your branch. The PR will be updated automatically.
- Once the pull request is approved and merged you can pull the changes from `upstream` to your local repo and delete
your extra branch(es).

And last but not least: Always write your commit messages in the present tense. Your commit message should describe what the commit, when applied, does to the code – not what you did to the code.
