This project uses Visual Studio Code Remote Containers extension to run the development environment in Docker container.

## Requirement

1. [Docker Desktop](https://docs.docker.com/docker-for-mac/install/) daemon running on your machine
2. install [`ms-vscode-remote.remote-containers`](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers) extension

## To start

1. In VSCode, select command `Remote-Container: Reopen in Container`
2. Wait for the container to build
3. The command prompt in vscode's integrated terminal should start at `/workspaces/docker-coding-sandbox/go`

```sh
go run main.go
```
