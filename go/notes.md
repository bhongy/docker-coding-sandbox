# Docker Coding Sandbox: Go - Notes

<!-- markdownlint-disable MD032 MD034 -->

🤔 a repo that runs exclusively inside container
- no source code on local machine what so ever (do not bind mount local folder)
  - ? need to create volume so work-in-progress is not lost when shuts down ?
  - work like "Remote-Container: Clone Repository in Container Volume"
- so we can pre-install dependencies in the docker image
- use git credentials from local machine

https://code.visualstudio.com/docs/remote/containers#_forwarding-or-publishing-a-port
https://code.visualstudio.com/docs/remote/containers-advanced#_creating-a-nonroot-user
https://github.com/Microsoft/vscode-dev-containers

```Dockerfile
ARG USERNAME=user-name-goes-here
ARG USER_UID=1000
ARG USER_GID=$USER_UID

# Create the user
RUN groupadd --gid $USER_GID $USERNAME \
    && useradd --uid $USER_UID --gid $USER_GID -m $USERNAME \
    #
    # [Optional] Add sudo support. Omit if you don't need to install software after connecting.
    && apt-get update \
    && apt-get install -y sudo \
    && echo $USERNAME ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/$USERNAME \
    && chmod 0440 /etc/sudoers.d/$USERNAME

# ********************************************************
# * Anything else you want to do like clean up goes here *
# ********************************************************

# [Optional] Set the default user. Omit if you want to keep the default as root.
USER $USERNAME
```

```json
{
  "mounts": [
    "source=${localEnv:HOME}${localEnv:USERPROFILE},target=/host-home-folder,type=bind,consistency=cached",
    ""
  ]
}
```
