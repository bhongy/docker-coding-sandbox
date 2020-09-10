FROM golang:1.15.2
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
    golang.org/x/tools/gopls \
    github.com/cweill/gotests/... \
    github.com/josharian/impl \
    # The Go extension complains "Analysis Tools Missing" without these
    github.com/mdempsky/gocode \
    github.com/uudashr/gopkgs/v2/cmd/gopkgs \
    github.com/ramya-rao-a/go-outline \
    github.com/stamblerre/gocode \
    github.com/rogpeppe/godef \
    github.com/sqs/goreturns \
    golang.org/x/lint/golint
