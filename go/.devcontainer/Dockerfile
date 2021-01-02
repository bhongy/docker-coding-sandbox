# image for golang development environment
# to use with vscode remote-container with go tools installed

FROM golang:1.15.3
ENV GO111MODULE=on

# install zsh and oh-my-zsh
RUN apt-get update \
    && apt-get install -y \
        zsh \
    && sh -c "$(wget -O- https://raw.githubusercontent.com/ohmyzsh/ohmyzsh/master/tools/install.sh)" \
    # clean up
    && apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/*

# Install go tools use by golang.go extension
RUN go get \
    golang.org/x/tools/gopls@v0.6.1 \
    github.com/cweill/gotests/...@v1.6.0 \
    github.com/go-delve/delve@v1.5.1 \
    github.com/josharian/impl@v1.0.0 \
    github.com/davidrjenni/reftools/cmd/fillstruct@latest \
    github.com/ramya-rao-a/go-outline@latest
