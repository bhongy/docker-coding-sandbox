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
    golang.org/x/tools/gopls@v0.6.2 \
    # not sure what is it for so omit for now
    # github.com/cweill/gotests/...@v1.6.0 \
    # to run "debug test"
    github.com/go-delve/delve/cmd/dlv@v1.5.1 \
    # to run "Go: Add import"
    github.com/uudashr/gopkgs/v2/cmd/gopkgs@v2.1.2 \
    github.com/josharian/impl@v1.0.0 \
    github.com/davidrjenni/reftools/cmd/fillstruct@latest \
    github.com/ramya-rao-a/go-outline@latest
