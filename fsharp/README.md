This project uses Visual Studio Code Remote Containers extension to run the development environment in Docker container.

## Requirement

1. [Docker Desktop](https://docs.docker.com/docker-for-mac/install/) daemon running on your machine
2. install [`ms-vscode-remote.remote-containers`](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) extension

## To start

1. In VSCode, select command `Remote-Container: Reopen in Container`
2. Wait for the container to build
3. The command prompt in vscode's integrated terminal should start at `/workspaces/docker-coding-sandbox/fsharp`

```sh
# Run a project (`-p` is the path to a project)
dotnet run -p src/MyConsoleApp
```

You can also run code by highlight it and `Option + Return` to evaluate it in F# interactive.

## .NET CLI

```sh
# create a new library project
dotnet new classlib -lang F# -o src/Domain

# create reference between projects
dotnet add src/MyConsoleApp/MyConsoleApp.fsproj reference src/Domain/Domain.fsproj
```

## References

- [Get Started with F# in Visual Studio Code](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-vscode)